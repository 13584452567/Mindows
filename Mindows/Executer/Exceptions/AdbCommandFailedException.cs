/*************************************************
** auth： zsh2401@163.com
** date:  2018/8/29 0:36:21 (UTC +8:00)
** desc： ...
*************************************************/
using Mindows.Basic.Data;

namespace Mindows.Basic.Exceptions
{
    /// <summary>
    /// ADB命令执行失败异常
    /// </summary>
    public class AdbCommandFailedException : CommandErrorException
    {
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="output"></param>
        /// <param name="exitCode"></param>
        public AdbCommandFailedException(Output output,int exitCode)
            : base(output?.ToString(),exitCode)
        {
        }
    }
}
