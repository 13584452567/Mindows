﻿/*************************************************
** auth： zsh2401@163.com
** date:  2018/8/29 0:39:14 (UTC +8:00)
** desc： ...
*************************************************/
using AutumnBox.Basic.Calling;
using AutumnBox.Basic.Data;
using AutumnBox.Basic.Device;
using AutumnBox.Basic.Exceptions;
using System;

namespace AutumnBox.Basic.Util
{
    /// <summary>
    /// 异常抛出器
    /// </summary>
    public static class ThrowIf
    {
        /// <summary>
        /// 当没有SU权限时抛出
        /// </summary>
        /// <param name="device"></param>
        public static void ThrowIfHaveNoSu(this IDevice device)
        {
            if (!device.HaveSU())
            {
                throw new DeviceHasNoSuException();
            }
        }

        /// <summary>
        /// 放返回码不为0时抛出异常
        /// </summary>
        /// <param name="result"></param>
        public static void ThrowIfExitCodeNotEqualsZero(this Tuple<Output, int> result)
        {
            if (result.Item2 != 0)
            {
                throw new AdbShellCommandFailedException(result.Item1, result.Item2);
            }
        }

        /// <summary>
        /// 放返回码不为0时抛出异常
        /// </summary>
        /// <param name="result"></param>
        public static CommandResult ThrowIfShellExitCodeNotEqualsZero(this CommandResult result)
        {
            if (result.ExitCode != 0)
            {
                throw new AdbShellCommandFailedException(result.Output, result.ExitCode);
            }
            return result;
        }

        /// <summary>
        /// 放返回码不为0时抛出异常
        /// </summary>
        /// <exception cref="AdbCommandFailedException">ADB命令失败</exception>
        /// <param name="result"></param>
        public static CommandResult ThrowIfExitCodeNotEqualsZero(this CommandResult result)
        {
            if (result.ExitCode != 0)
            {
                throw new AdbCommandFailedException(result.Output, result.ExitCode);
            }
            return result;
        }

        /// <summary>
        /// 当ExitCode不为0时抛出异常
        /// </summary>
        /// <param name="result"></param>
        /// <exception cref="CommandErrorException"></exception>
        /// <returns></returns>
        public static CommandResult ThrowIfExitCodeIsNotZero(this CommandResult result)
        {
            if (result.ExitCode != 0)
            {
                throw new CommandErrorException(result.Output, result.ExitCode);
            }
            return result;
        }

        /// <summary>
        /// 当设备不存活时抛出
        /// </summary>
        /// <param name="device"></param>
        public static void ThrowIfNotAlive(this IDevice device)
        {
            if (device.IsAlive() == false)
            {
                throw new DeviceNotAliveException();
            }
        }
    }
}
