/* =============================================================================*\
*
* Filename: IDevicesGetter.cs
* Description: 
*
* Version: 1.0
* Created: 9/27/2017 02:45:52(UTC+8:00)
* Compiler: Visual Studio 2017
* 
* Author: zsh2401
* Company: I am free man
*
\* =============================================================================*/

using Mindows.Basic.Device;
using System.Collections.Generic;

namespace Mindows.Basic.MultipleDevices
{
    /// <summary>
    /// 设备获取器
    /// </summary>
    public interface IDevicesGetter
    {
        /// <summary>
        /// 获取设备
        /// </summary>
        /// <returns></returns>
        IEnumerable<IDevice> GetDevices();
    }
}
