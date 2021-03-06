using System;
using System.Collections.Generic;
using System.Text;

namespace Mindows.Logging
{
    /// <summary>
    /// Logger
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// 发送日志
        /// </summary>
        /// <param name="level"></param>
        /// <param name="message"></param>
        void Log(string level, object message);
        /// <summary>
        /// 发送带有异常信息的日志
        /// </summary>
        /// <param name="level"></param>
        /// <param name="message"></param>
        /// <param name="e"></param>
        void Log(string level, object message, Exception e);
    }
    /// <summary>
    /// 泛型的日志器,根据泛型参数
    /// </summary>
    /// <typeparam name="TCategory"></typeparam>
    public interface ILogger<TCategory> : ILogger { }
}
