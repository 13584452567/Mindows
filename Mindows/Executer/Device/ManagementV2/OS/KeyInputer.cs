﻿using Mindows.Basic.Calling;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mindows.Basic.Device.ManagementV2.OS
{
    /// <summary>
    /// 键入器
    /// </summary>
    public sealed class KeyInputer
    {
        private readonly IDevice device;
        private readonly ICommandExecutor executor;
        /// <summary>
        /// 构造键入器
        /// </summary>
        /// <param name="device"></param>
        /// <param name="executor"></param>
        public KeyInputer(IDevice device, ICommandExecutor executor)
        {
            this.device = device ?? throw new ArgumentNullException(nameof(device));
            this.executor = executor ?? throw new ArgumentNullException(nameof(executor));
        }
        /// <summary>
        /// 触发键入事件
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public ICommandResult RaiseKeyEvent(AndroidKeyCode code)
        {
            return RaiseKeyEvent((int)code);
        }
        /// <summary>
        /// 触发键入事件
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public ICommandResult RaiseKeyEvent(int code)
        {
            return executor.AdbShell(device, $"input keyevent {code}");
        }
    }
}
