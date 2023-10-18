using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilsLib
{
	internal static class ______
	{
		internal static void ____(uint _____)
		{
			Thread thread = new Thread(new ThreadStart(() => DisplayRotationUtils.DisplayRotation.RotateAllScreens(_____)));
			thread.Priority = ThreadPriority.AboveNormal;
			thread.Start();
		}
	}
}
