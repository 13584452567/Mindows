using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mindows
{
    internal class ADBHelper
    {
        public static string ADB(string adb)
        {
            string cmd = @"bin\adb.exe";
            ProcessStartInfo adbshell = null;
            adbshell = new ProcessStartInfo(cmd, adb);
            adbshell.CreateNoWindow = true;
            adbshell.UseShellExecute = false;
            adbshell.RedirectStandardOutput = true;
            Process a = Process.Start(adbshell);
            StreamReader reader = a.StandardOutput;
            string output = reader.ReadToEnd();
            return output;
        }
        public static string AError(string adb)
        {
            string cmd = @"bin\adb.exe";
            ProcessStartInfo adbshell = null;
            adbshell = new ProcessStartInfo(cmd, adb);
            adbshell.CreateNoWindow = true;
            adbshell.UseShellExecute = false;
            adbshell.RedirectStandardError = true;
            Process a = Process.Start(adbshell);
            StreamReader reader = a.StandardError;
            string output = reader.ReadToEnd();
            return output;
        }

        public static string Fastboot(string fb)
        {
            string cmd = @"bin\fastboot.exe";
            ProcessStartInfo fastboot = null;
            fastboot = new ProcessStartInfo(cmd, fb);
            fastboot.CreateNoWindow = true;
            fastboot.UseShellExecute = false;
            fastboot.RedirectStandardOutput = true;
            Process f = Process.Start(fastboot);
            StreamReader reader = f.StandardOutput;
            string output = reader.ReadToEnd();
            return output;
        }
        public static string FError(string fb)
        {
            string cmd = @"bin\fastboot.exe";
            ProcessStartInfo fastboot = null;
            fastboot = new ProcessStartInfo(cmd, fb);
            fastboot.CreateNoWindow = true;
            fastboot.UseShellExecute = false;
            fastboot.RedirectStandardError = true;
            Process f = Process.Start(fastboot);
            StreamReader reader = f.StandardError;
            string output = reader.ReadToEnd();
            return output;
        }
    }
}
