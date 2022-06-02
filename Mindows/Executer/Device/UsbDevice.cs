﻿/*************************************************
** auth： zsh2401@163.com
** date:  2018/8/30 4:53:10 (UTC +8:00)
** desc： ...
*************************************************/
using Mindows.Basic.Calling.Adb;
using Mindows.Basic.Util;
using Mindows.Logging;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Mindows.Basic.Device
{
    /// <summary>
    /// 通过USB连接的设备
    /// </summary>
    public sealed class UsbDevice : DeviceBase
    {
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="serialNumber"></param>
        /// <param name="state"></param>
        public UsbDevice(string serialNumber, DeviceState state)
        {
            this.SerialNumber = serialNumber ?? throw new ArgumentNullException(nameof(serialNumber));
            this.State = state;
        }

        /// <summary>
        /// 开启网络调试
        /// </summary>
        /// <param name="port"></param>
        /// <param name="tryConnect">是否在开启后尝试连接</param>
        public void OpenNetDebugging(ushort port, bool tryConnect = false)
        {
            IPAddress ip = null;
            if (tryConnect)
            {
                ip = this.GetLanIP();
                //SLogger<UsbDevice>.Info(ip?.ToString() ?? "can not get ip info");
            }
            this.Adb($"tcpip {port}").ThrowIfExitCodeNotEqualsZero();
            Task.Run(() =>
            {
                if (ip != null)
                {
                    Thread.Sleep(2000);
                    new AdbCommand($"connect {ip}:{port}").Execute().ThrowIfExitCodeNotEqualsZero();
                }
            });
        }
    }
}
