using System;
using System.Runtime.InteropServices;

namespace DisplayRotationUtils;

internal class MonitorInfo
{
	[StructLayout(LayoutKind.Sequential)]
	internal struct MONITORINFOEX
	{
		public int cbSize;
		public RECT rcMonitor;
		public RECT rcWork;
		public uint dwFlags;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string szDevice;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct RECT
	{
		public int left, top, right, bottom;
	}

	[DllImport("user32.dll")]
	internal static extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip, MonitorEnumDelegate lpfnEnum, IntPtr dwData);

	internal delegate bool MonitorEnumDelegate(IntPtr hMonitor, IntPtr hdcMonitor, ref RECT lprcMonitor, IntPtr dwData);

	internal static int GetDisplayCount()
	{
		int count = 0;
		EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, (IntPtr hMonitor, IntPtr hdcMonitor, ref RECT lprcMonitor, IntPtr dwData) =>
		{
			count++;
			return true;
		}, IntPtr.Zero);

		return count;
	}
}
