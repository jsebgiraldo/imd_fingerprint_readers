using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

public class Nfiq2
{
    // Import the DLL that contains the functions
    const string Nfiq2Dll = "nfiq2api.dll";
    static bool isInit = false;

    // Define the function signatures
    public static string InitNfiq2(out string hash)
    {
        IntPtr hashPtr;
        IntPtr resultPtr = InitNfiq2(out hashPtr);
        if (resultPtr != IntPtr.Zero)
        {
            hash = Marshal.PtrToStringAnsi(hashPtr);
            Marshal.FreeCoTaskMem(hashPtr); // Free the allocated memory
            return Marshal.PtrToStringAnsi(resultPtr);
        }
        else
        {
            hash = null;
            return null;
        }
    }

    [DllImport(Nfiq2Dll, CallingConvention = CallingConvention.StdCall)]
    public static extern void GetNfiq2Version(out int major, out int minor, out int patch, out IntPtr ocv);

    [DllImport(Nfiq2Dll, CallingConvention = CallingConvention.StdCall)]
    public static extern IntPtr InitNfiq2(out IntPtr hash);

    [DllImport(Nfiq2Dll, CallingConvention = CallingConvention.StdCall)]
    public static extern int ComputeNfiq2Score(int fpos, IntPtr pixels, int size, int width, int height, int ppi);

    // Define a helper method to convert byte[] to IntPtr
    public static IntPtr ConvertToIntPtr(byte[] array)
    {
        IntPtr ptr = Marshal.AllocHGlobal(array.Length);
        Marshal.Copy(array, 0, ptr, array.Length);
        return ptr;
    }

    // Define a helper method to release the allocated memory
    public static void FreeIntPtr(IntPtr ptr)
    {
        Marshal.FreeHGlobal(ptr);
    }
}