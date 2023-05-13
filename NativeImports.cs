using System.Runtime.InteropServices;

public static class NativeImports
{
    public const int WM_NCLBUTTONDOWN = 0xA1;
    public const int HT_CAPTION = 0x2;

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, nuint wParam, nint lParam);
    [DllImport("user32.dll")]
    public static extern bool ReleaseCapture();
}