/*************************************************
** auth： zsh2401@163.com
** date:  2018/8/30 4:34:37 (UTC +8:00)
** desc： ...
*************************************************/
using Mindows.Basic.Calling;
using Mindows.Basic.Calling.Adb;
using Mindows.Basic.Calling.Fastboot;
using Mindows.Basic.Data;
using Mindows.Basic.Device.Management.AppFx;
using Mindows.Basic.Device.Management.OS;
using Mindows.Basic.Util;
using System;

namespace Mindows.Basic.Device
{
    /// <summary>
    /// 设备对象拓展
    /// </summary>
    public static partial class DeviceExtension
    {
        /// <summary>
        /// 以SU权限执行Shell命令
        /// </summary>
        /// <param name="device"></param>
        /// <param name="sh"></param>
        /// <param name="suCheck"></param>
        /// <exception cref="Exceptions.DeviceHasNoSuException"></exception>
        /// <returns></returns>
        public static Tuple<Output, int> Su(this IDevice device, string sh, bool suCheck = true)
        {
            if (suCheck)
            {
                device.ThrowIfHaveNoSu();
            }
            var cmd = new SuCommand(device, sh);
            var result = cmd.Execute();
            return new Tuple<Output, int>(result.Output, result.ExitCode);
        }
        /// <summary>
        /// 执行shell命令
        /// </summary>
        /// <param name="device"></param>
        /// <param name="sh"></param>
        /// <returns></returns>
        public static Tuple<Output, int> Shell(this IDevice device, string sh)
        {
            var cmd = new ShellCommand(device, sh);
            var result = cmd.Execute();
            return new Tuple<Output, int>(result.Output, result.ExitCode);
        }
        /// <summary>
        /// 执行ADB命令
        /// </summary>
        /// <param name="device"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public static Tuple<Output, int> Adb(this IDevice device, string command)
        {
            var cmd = new AdbCommand(device, command);
            var result = cmd.Execute();
            return new Tuple<Output, int>(result.Output, result.ExitCode);
        }
        /// <summary>
        /// 获取Adb命令对象
        /// </summary>
        /// <param name="device"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public static AdbCommand GetAdb(this IDevice device, string command) {
            return new AdbCommand(device, command);
        }
        /// <summary>
        /// 获取Fastboot命令对象
        /// </summary>
        /// <param name="device"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public static FastbootCommand GetFastboot(this IDevice device, string command)
        {
            return new FastbootCommand(device, command);
        }
        /// <summary>
        /// 执行Fastboot命令
        /// </summary>
        /// <param name="device"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public static Tuple<Output, int> Fastboot(this IDevice device, string command)
        {
            var cmd = new FastbootCommand(device, command);
            var result = cmd.Execute();
            return new Tuple<Output, int>(result.Output, result.ExitCode);
        }
        /// <summary>
        /// 根据设备状态，判断使用adb还是fastboot执行命令
        /// 当设备处于Fastboot状态时，使用fastboot执行，否则用adb执行
        /// </summary>
        /// <param name="device"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public static Tuple<Output, int> Auto(this IDevice device, string command)
        {
            if (device.State == DeviceState.Fastboot)
            {
                return device.Fastboot(command);
            }
            else
            {
                return device.Adb(command);
            }
        }
    }
}
