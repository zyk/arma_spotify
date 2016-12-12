
/* 
 * ARMA3 Spotify control extension
 * zyk 2016 - zyk@jigoku.io
 *
 * Copyright: GNU GPL 2
 */

// based on Arma 3 c# example @ https://github.com/maca134/ARMAExtCS

using RGiesecke.DllExport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


/*
 // example script call 
 "ARMASpotify" callExtension "playpause";
*/

namespace ARMASpotify
{
	public class DllEntry
	{
		// from https://github.com/nadavbar/spotify-win-remote/blob/master/index.js
		const string SPOTIFY_WINDOW_CLASS_NAME = "SpotifyMainWindow";
		const int SPOTIFY_CMD_NEXT = 720896;
		const int SPOTIFY_CMD_PREV = 786432;
		const int SPOTIFY_CMD_PLAY_PAUSE = 917504;
		const int SPOTIFY_CMD_VOLUME_DOWN = 589824;
		const int SPOTIFY_CMD_VOLUME_UP = 655360;
		const int SPOTIFY_CMD_STOP = 851968;
		const int SPOTIFY_CMD_MUTE = 524288;

		const int ERROR_CODE = -1;

		[DllExport("_RVExtension@12", CallingConvention = System.Runtime.InteropServices.CallingConvention.Winapi)]
		public static void RVExtension(StringBuilder output, int outputSize, string function)
		{
			outputSize--; // make sure we don't hit a size limit
			if (function == "about")
			{
				output.Append("v1.0 http://arma.jigoku.io");
			}

			if (function.Contains("play_"))
			{
				char[] sep = { '_' };
				string song = function.Split('_')[1];
				playSpotify(song);
				output.Append("1");
			}
			else
			{
				int ret = -1;
				switch (function)
				{
					case "playpause":
						ret = sendSpotifyCommand(SPOTIFY_CMD_PLAY_PAUSE);
						break;
					case "stop":
						ret = sendSpotifyCommand(SPOTIFY_CMD_STOP);
						break;
					case "next":
						ret = sendSpotifyCommand(SPOTIFY_CMD_NEXT);
						break;
					case "previous":
						ret = sendSpotifyCommand(SPOTIFY_CMD_PREV);
						break;
					case "mute":
						ret = sendSpotifyCommand(SPOTIFY_CMD_MUTE);
						break;
					case "volume_up":
						ret = sendSpotifyCommand(SPOTIFY_CMD_VOLUME_UP);
						break;
					case "volume_down":
						ret = sendSpotifyCommand(SPOTIFY_CMD_VOLUME_DOWN);
						break;
				}
				output.Append(ret.ToString());
			}
		}

		[DllImport("User32.Dll")]
		public static extern int FindWindow(string lpClassName, string lpWindowName);
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

		// does not work.... yet.
		private static void playSpotify(string song)
		{
			//System.Diagnostics.Process.Start(song); // dangerous..
		}

		private static int sendSpotifyCommand(int type)
		{
			int window = FindWindow(SPOTIFY_WINDOW_CLASS_NAME, null);

			if (window > 0)
			{
				return SendMessage((System.IntPtr)window, 0x0319, (System.IntPtr)0, (System.IntPtr)type);
			}
			else
			{
				return ERROR_CODE;
			}
		}
	}
}
