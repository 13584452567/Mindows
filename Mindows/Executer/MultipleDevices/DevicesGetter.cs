﻿/*************************************************
** auth： zsh2401@163.com
** date:  2018/9/1 16:56:38 (UTC +8:00)
** desc： ...
*************************************************/
using System.Collections.Generic;
using System.Linq;
using Mindows.Basic.Calling.Adb;
using Mindows.Basic.Calling.Fastboot;
using Mindows.Basic.Device;

namespace Mindows.Basic.MultipleDevices
{
    /// <summary>
    /// 已连接设备获取器
    /// </summary>
    public class DevicesGetter : IDevicesGetter
    {
        private const string ADB_DEVICES_COMMAND = "devices";
        private const string FSB_DEVICES_COMMAND = "devices";
        private readonly AdbCommand adbDevices;
        private readonly FastbootCommand fastbootDevices;
        /// <summary>
        /// 构造器
        /// </summary>
        public DevicesGetter()
        {
            adbDevices = new AdbCommand(ADB_DEVICES_COMMAND);
            fastbootDevices = new FastbootCommand(FSB_DEVICES_COMMAND);
            adbDevices.NeverCreateNewWindow = true;
            fastbootDevices.NeverCreateNewWindow = true;
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IDevice> GetDevices()
        {
            List<IDevice> result = new List<IDevice>();
            Adb(result);
            Fastboot(result);
            return result;
        }

        private void Adb(List<IDevice> devices)
        {
            var lineOutput = adbDevices.Execute().Output.LineOut;
            for (int i = 1; i < lineOutput.Count(); i++)
            {
                if (DeviceBase.TryParse(lineOutput[i], out IDevice device))
                {
                    devices.Add(device);
                }
            }
        }

        private void Fastboot(List<IDevice> devices)
        {
            var lineOutput = fastbootDevices.Execute().Output.LineOut;
            for (int i = 0; i < lineOutput.Count(); i++)
            {
                if (DeviceBase.TryParse(lineOutput[i], out IDevice device))
                {
                    devices.Add(device);
                }
            }
        }
    }
}
