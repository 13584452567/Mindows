using System;

namespace Mindows.Basic.Data
{
    /// <summary>
    /// 使用To模式订阅Output输出事件
    /// </summary>
    /// <typeparam name="TSelf"></typeparam>
    public interface IReceiveOutputByTo<TSelf>
    {
        /// <summary>
        /// 快捷订阅Output事件
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        TSelf To(Action<OutputReceivedEventArgs> callback);
    }
}
