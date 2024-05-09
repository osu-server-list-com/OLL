using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLL
{

    public static class AutoStart
    {
        private const string AppName = "MyApplication";
        private const string RunKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

        public static bool IsAutoStartEnabled()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RunKey, true))
            {
                return key.GetValue(AppName) != null;
            }
        }

        public static void ToggleAutoStart(bool enable)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RunKey, true))
            {
                if (enable)
                {
                    key.SetValue(AppName, System.Windows.Forms.Application.ExecutablePath);
                }
                else
                {
                    key.DeleteValue(AppName, false);
                }
            }
        }
    }
}
