/*************************************************
** auth： zsh2401@163.com
** date:  2018/9/26 2:05:41 (UTC +8:00)
** desc： ...
*************************************************/
using Mindows.Basic.Calling.Adb;
using Mindows.Basic.Calling.Cmd;
using Mindows.Basic.Calling.Fastboot;
using Mindows.Basic.Device;
using System;
using System.Linq;
using System.Collections.Generic;
using Mindows.Logging;
using AutumnBox.Basic.Calling;

namespace Mindows.Basic.Calling
{
    /// <summary>
    /// 提供高效的,自动化的命令管理
    /// </summary>
    public sealed class CommandStation
    {
        private ILogger<CommandStation> logger = LoggerFactory.AutoT<CommandStation>();
        private readonly List<ProcessBasedCommand> commands = new List<ProcessBasedCommand>();
        /// <summary>
        /// 注册一个命令,并交由CommandStation管理
        /// </summary>
        /// <param name="command"></param>
        public TCommand Register<TCommand>(TCommand command) where TCommand : ProcessBasedCommand
        {
            ThrowIfLocked();
            return CheckedRegister(command);
        }
        private TCommand CheckedRegister<TCommand>(TCommand command) where TCommand : ProcessBasedCommand
        {
            commands.Add(command);
            return command;
        }
        /// <summary>
        /// 获取Shell命令
        /// </summary>
        /// <param name="device"></param>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public ShellCommand GetShellCommand(IDevice device, string cmd)
        {
            ThrowIfLocked();
            return CheckedRegister(new ShellCommand(device, cmd));
        }
        /// <summary>
        /// 获取su命令
        /// </summary>
        /// <param name="device"></param>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public SuCommand GetSuCommand(IDevice device, string cmd)
        {
            ThrowIfLocked();
            return CheckedRegister(new SuCommand(device, cmd));
        }
        /// <summary>
        /// 获取一个被管理的ADB命令
        /// </summary>
        /// <param name="device"></param>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public AdbCommand GetAdbCommand(IDevice device, string cmd)
        {
            ThrowIfLocked();
            return CheckedRegister(new AdbCommand(device, cmd));
        }
        /// <summary>
        /// 获取一个被管理的ADB命令
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public AdbCommand GetAdbCommand(string cmd)
        {
            ThrowIfLocked();
            return CheckedRegister(new AdbCommand(cmd));
        }
        /// <summary>
        /// 获取一个被管理的ADB命令
        /// </summary>
        /// <param name="device"></param>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public FastbootCommand GetFastbootCommand(IDevice device, string cmd)
        {
            ThrowIfLocked();
            return CheckedRegister(new FastbootCommand(device, cmd));
        }
        /// <summary>
        /// 获取一个被管理的ADB命令
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public FastbootCommand GetFastbootCommand(string cmd)
        {
            ThrowIfLocked();
            return CheckedRegister(new FastbootCommand(cmd));
        }
        /// <summary>
        /// 获取一个被管理的Windows cmd命令
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public WindowsCmdCommand GetCmdCommand(string cmd)
        {
            ThrowIfLocked();
            return CheckedRegister(new WindowsCmdCommand(cmd));
        }
        /// <summary>
        /// 杀死所有被管理的命令的进程
        /// </summary>
        public void Free()
        {
            var runningCommand = from cmd in commands
                                 where cmd.process.IsRunning()
                                 select cmd;
            foreach (var cmd in runningCommand)
            {
                try
                {
                    logger.Debug("killing command:" + cmd);
                    cmd.Kill();
                }
                catch (Exception ex)
                {
                    logger.Warn($"can't stop command:{cmd.ToString()}", ex);
                }
            }
        }
        bool locked = false;
        private void ThrowIfLocked()
        {
            if (locked)
            {
                throw new InvalidOperationException("Command station has been locked");
            }
        }
        /// <summary>
        /// 锁定分配器
        /// </summary>
        public void Lock()
        {
            locked = true;
        }
        /// <summary>
        /// 解锁分配器
        /// </summary>
        public void Unlock()
        {
            locked = false;
        }
    }
}
