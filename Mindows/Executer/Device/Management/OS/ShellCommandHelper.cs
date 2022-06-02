/*************************************************
** auth： zsh2401@163.com
** date:  2018/9/28 4:25:44 (UTC +8:00)
** desc： ...
*************************************************/
using Mindows.Basic.Calling.Adb;
using Mindows.Basic.Exceptions;
using Mindows.Basic.Util;

namespace Mindows.Basic.Device.Management.OS
{
    /// <summary>
    /// Shell命令帮助
    /// </summary>
    public static class ShellCommandHelper
    {
        /// <summary>
        /// 检测某个命令是否存在
        /// </summary>
        /// <param name="device"></param>
        /// <param name="cmd"></param>
        public static void CommandExistsCheck(IDevice device, string cmd)
        {
            var result = new ShellCommand(device, cmd)
               .Execute();
            if (result.ExitCode == (int)LinuxReturnCode.KeyHasExpired)
            {
                throw new CommandNotFoundException(cmd);
            }
        }
        /// <summary>
        /// 测试是否可以正常执行某个命令
        /// </summary>
        /// <param name="device"></param>
        /// <param name="cmd"></param>
        public static void SupportCheck(IDevice device, string cmd)
        {
            var result = new ShellCommand(device, cmd)
                .Execute();
            switch (result.ExitCode)
            {
                case (int)LinuxReturnCode.None:
                    break;
                case (int)LinuxReturnCode.KeyHasExpired:
                    throw new CommandNotFoundException(cmd);
                default:
                    throw new
                   AdbShellCommandFailedException(result.Output,result.ExitCode);
            }
        }
    }
}
