using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace imd_fingerprint_readers.Controls
{
    public class CustomTabControl : TabControl
    {
        private const int WM_PAINT = 0x000F;
        private const int WM_ERASEBKGND = 0x0014;

        // Cache context to avoid repeatedly re-creating the object.
        // WM_PAINT is called frequently so it's better to declare it as a member.
        private BufferedGraphicsContext _bufferContext = BufferedGraphicsManager.Current;
        Font _tabFont = new Font("Segoe", 18.0f, FontStyle.Bold, GraphicsUnit.Pixel);
        SolidBrush _activeTextBrush = new SolidBrush(Color.Black);
        SolidBrush _inactiveTextBrush = new SolidBrush(Color.LightGray);
        Pen _linePen = new Pen(Color.FromArgb(100, 51, 52, 144), 2);

        private struct TabItemInfo
        {
            public Color BackColor;
            public Rectangle Bounds;
            public Font Font;
            public Color ForeColor;
            public int Index;
            public DrawItemState State;

            public TabItemInfo(DrawItemEventArgs e)
            {
                this.BackColor = e.BackColor;
                this.ForeColor = e.ForeColor;
                this.Bounds = e.Bounds;
                this.Font = e.Font;
                this.Index = e.Index;
                this.State = e.State;
            }
        }

        private Dictionary<int, TabItemInfo> _tabItemStateMap = new Dictionary<int, TabItemInfo>();

        public CustomTabControl()
        {
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;    // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            if (!_tabItemStateMap.ContainsKey(e.Index))
            {
                _tabItemStateMap.Add(e.Index, new TabItemInfo(e));
            }
            else
            {
                _tabItemStateMap[e.Index] = new TabItemInfo(e);
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_PAINT:
                    {
                        // Let system do its thing first.
                        base.WndProc(ref m);

                        // Custom paint Tab items.
                        HandlePaint(ref m);

                        break;
                    }
                case WM_ERASEBKGND:
                    {
                        if (DesignMode)
                        {
                            // Ignore to prevent flickering in DesignMode.
                        }
                        else
                        {
                            // base.WndProc(ref m);
                        }
                        break;
                    }
                default:
                    base.WndProc(ref m);
                    break;
            }
        }


        private Color _backColor = Color.FromArgb(255, 255, 255);
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public new Color BackColor
        {
            get
            {
                return _backColor;
            }
            set
            {
                _backColor = value;
            }
        }


        private void HandlePaint(ref Message m)
        {
            using (var g = Graphics.FromHwnd(m.HWnd))
            {
                SolidBrush backBrush = new SolidBrush(BackColor);
                Rectangle r = ClientRectangle;
                using (var buffer = _bufferContext.Allocate(g, r))
                {
                    if (Enabled)
                    {
                        buffer.Graphics.FillRectangle(backBrush, r);
                    }
                    else
                    {
                        buffer.Graphics.FillRectangle(backBrush, r);
                    }

                    // Paint items
                    foreach (int index in _tabItemStateMap.Keys)
                    {
                        DrawTabItemInternal(buffer.Graphics, _tabItemStateMap[index]);
                    }

                    buffer.Render();
                }
                backBrush.Dispose();
            }
        }

        private void DrawTabItemInternal(Graphics gr, TabItemInfo tabInfo)
        {
            /* Uncomment the two lines below to have each TabItem use the same height.
            ** The selected TabItem height will be slightly taller
            ** which makes unselected tabs float if you choose to 
            ** have a different BackColor for the TabControl background
            ** and your TabItem background. 
            */

            int fullHeight = _tabItemStateMap[this.SelectedIndex].Bounds.Height;
            tabInfo.Bounds.Height = fullHeight;

            SolidBrush _textBrush;
            SolidBrush backBrush = new SolidBrush(BackColor);

            // Paint selected. 
            // You might want to choose a different color for the 
            // background or the text.
            if ((tabInfo.State & DrawItemState.Selected) == DrawItemState.Selected && this.Enabled)
            {
                gr.FillRectangle(backBrush, tabInfo.Bounds);
                _textBrush= this._activeTextBrush;
            }
            // Paint unselected.
            else
            {
                _textBrush = this._inactiveTextBrush;
                gr.FillRectangle(backBrush, tabInfo.Bounds);
            }

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            gr.DrawString(this.TabPages[tabInfo.Index].Text, _tabFont, _textBrush, tabInfo.Bounds, new StringFormat(_stringFlags));

 
            if ((tabInfo.State & DrawItemState.Selected) == DrawItemState.Selected && this.Enabled)
            {
                Point from = new Point(0, tabInfo.Bounds.Top + tabInfo.Bounds.Height - 5);
                Point to = new Point(tabInfo.Bounds.Width, tabInfo.Bounds.Top + tabInfo.Bounds.Height - 5);
                gr.DrawLine(_linePen, from, to);

            }

            backBrush.Dispose();
        }
    }
}

