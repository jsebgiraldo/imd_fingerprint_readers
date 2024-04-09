using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace IMD
{
    class Fap30Controller
    {
        // Single instance
        private static Fap30Controller instance;

        private static readonly object _syncLock = new object();

        public const int FPM_DEVICE = 0x01;  //Device
        public const int FPM_PLACE = 0x02;   //Place Finger
        public const int FPM_LIFT = 0x03;    //Lift Finger
        public const int FPM_CAPTURE = 0x04; //Capute Image
        public const int FPM_GENCHAR = 0x05; //Capture Feature
        public const int FPM_ENRFPT = 0x06;  //Enrol Feature
        public const int FPM_NEWIMAGE = 0x07;//New Image
        public const int FPM_TIMEOUT = 0x08; //Time Out
        public const int FPM_BUSY = 0xFF;    //Device Busy

        public const int SOUND_BEEP = 0;
        public const int SOUND_OK = 1;
        public const int SOUND_FAIL = 2;

        public const int TEMPLATE_SIZE = 1024;

        public static Fap30Controller Instance
        {
            get
            {
                lock (_syncLock)
                {
                    if (instance == null)
                    {
                        instance = new Fap30Controller();
                    }
                    return instance;
                }
            }
        }

        public int SafeOpenDevice()
        {
            lock (_syncLock)
            {
                return Fap30Controller.OpenDevice();
            }
        }

        public int SafeLinkDevice(int password)
        {
            lock (_syncLock)
            {
                return Fap30Controller.LinkDevice(password);
            }
        }
        public int SafeCloseDevice()
        {
            lock (_syncLock)
            {
                return Fap30Controller.CloseDevice();
            }
        }

        public int SafeResetDevice()
        {
            lock (_syncLock)
            {
                return Fap30Controller.ResetDevice();
            }
        }

        public int SafeGetImageSize(ref int width, ref int height)
        {
            lock (_syncLock)
            {
                return Fap30Controller.GetImageSize(ref width, ref height);
            }
        }

        public int SafeGetRawImage(byte[] rawdata, ref int size)
        {
            lock (_syncLock)
            {
                return Fap30Controller.GetRawImage(rawdata, ref size);
            }
        }

        public int SafeGetBmpImage(byte[] rawdata, ref int size)
        {
            lock (_syncLock)
            {
                return Fap30Controller.GetBmpImage(rawdata, ref size);
            }
        }

        public void SafeCaptureImage()
        {
            lock (_syncLock)
            {
                Fap30Controller.CaptureImage();
            }
        }

        public int SafeTemplateSize()
        {
            return TEMPLATE_SIZE;
        }

        public void SafeCaptureTemplate()
        {
            lock (_syncLock)
            {
                Fap30Controller.CaptureTemplate();
            }
        }

        public int SafeGetWorkMsg()
        {
            lock (_syncLock)
            {
                return Fap30Controller.GetWorkMsg();
            }
        }

        public int SafeGetRetMsg()
        {
            lock (_syncLock)
            {
                return Fap30Controller.GetRetMsg();
            }
        }

        public int SafeReleaseMsg()
        {
            lock (_syncLock)
            {
                return Fap30Controller.ReleaseMsg();
            }
        }

        public int SafeGetDeviceSnNum()
        {
            lock (_syncLock)
            {
                return Fap30Controller.GetDeviceSnNum();
            }
        }

        public int SafeGetDeviceModel()
        {
            lock (_syncLock)
            {
                return Fap30Controller.GetDeviceModel();
            }
        }

        public byte SafeGetDeviceVersion()
        {
            lock (_syncLock)
            {
                return Fap30Controller.GetDeviceVersion();
            }
        }

        public int SafeCreateTemplate(byte[] pImage, int width, int height, byte[] tp, ref int templateSize)
        {
            lock (_syncLock)
            {
                return Fap30Controller.CreateTemplate(pImage, width, height, tp, ref templateSize);
            }
        }

        public int SafeMatchTemplate(byte[] tp1, byte[] tp2)
        {
            lock (_syncLock)
            {
                return Fap30Controller.MatchTemplate(tp1, tp2);
            }
        }

        public int SafeRawToWsq(byte[] imagedata, int width, int height, int depth, int dpi, float bitrate, byte[] wsqdata, ref int wsqsize)
        {
            lock (_syncLock)
            {
                return Fap30Controller.RawToWsq(imagedata, width, height, depth, dpi, bitrate, wsqdata, ref wsqsize);
            }
        }

        public int SafeWsqToRaw(byte[] wsqdata, int wsqsize, byte[] imagedata, ref int width, ref int height, ref int depth, ref int dpi)
        {
            lock (_syncLock)
            {
                return Fap30Controller.WsqToRaw(wsqdata, wsqsize, imagedata, ref width, ref height, ref depth, ref dpi);
            }
        }

        public int SafeDeviceLedState(int type, int status)
        {
            lock (_syncLock)
            {
                return Fap30Controller.DeviceLedState(type, status);
            }
        }

        public int SafeDeviceSoundBeep(int beep)
        {
            lock (_syncLock)
            {
                return Fap30Controller.DeviceSoundBeep(beep);
            }
        }

        public int SafeGetTemplateSize()
        {
            return TEMPLATE_SIZE;
        }

        [System.Runtime.InteropServices.DllImport("fpengine.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int OpenDevice();

        [System.Runtime.InteropServices.DllImport("fpengine.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int LinkDevice(int password);

        [System.Runtime.InteropServices.DllImport("fpengine.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int CloseDevice();

        [System.Runtime.InteropServices.DllImport("fpengine.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int ResetDevice();

        [System.Runtime.InteropServices.DllImport("fpengine.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int GetImageSize(ref int width, ref int height);

        [System.Runtime.InteropServices.DllImport("fpengine.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int GetRawImage(byte[] rawdata, ref int size);

        [System.Runtime.InteropServices.DllImport("fpengine.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int GetBmpImage(byte[] rawdata, ref int size);

        [System.Runtime.InteropServices.DllImport("fpengine.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern void CaptureImage();

        [System.Runtime.InteropServices.DllImport("fpengine.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int GetTemplateSize();

        [System.Runtime.InteropServices.DllImport("fpengine.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern void CaptureTemplate();

        [System.Runtime.InteropServices.DllImport("fpengine.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int GetWorkMsg();

        [System.Runtime.InteropServices.DllImport("fpengine.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int GetRetMsg();

        [System.Runtime.InteropServices.DllImport("fpengine.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int ReleaseMsg();

        [System.Runtime.InteropServices.DllImport("fpengine.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int GetDeviceSnNum();

        [System.Runtime.InteropServices.DllImport("fpengine.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int GetDeviceModel();

        [System.Runtime.InteropServices.DllImport("fpengine.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern byte GetDeviceVersion();

        [System.Runtime.InteropServices.DllImport("fpengine.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int CreateTemplate(byte[] pImage, int width, int height, byte[] tp, ref int templateSize);

        [System.Runtime.InteropServices.DllImport("fpengine.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int MatchTemplate(byte[] tp1, byte[] tp2);

        [System.Runtime.InteropServices.DllImport("fpengine.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int RawToWsq(byte[] imagedata, int width, int height, int depth, int dpi, float bitrate, byte[] wsqdata, ref int wsqsize);

        [System.Runtime.InteropServices.DllImport("fpengine.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int WsqToRaw(byte[] wsqdata, int wsqsize, byte[] imagedata, ref int width, ref int height, ref int depth, ref int dpi);

        [System.Runtime.InteropServices.DllImport("fpengine.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int DeviceLedState(int type, int status);

        [System.Runtime.InteropServices.DllImport("fpengine.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int DeviceSoundBeep(int beep);
    }
}
