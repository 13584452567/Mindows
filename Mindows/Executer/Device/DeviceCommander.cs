using Mindows.Basic.Calling;
using Mindows.Basic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mindows.Basic.Device
{
    /// <summary>
    /// 只要是向设备发出命令实现功能的类，理应该实现此类
    /// </summary>
    public abstract class DeviceCommander : CommandingObject
    {
        /// <summary>
        /// 目标设备
        /// </summary>
        public IDevice Device { get; private set; }
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="device"></param>
        public DeviceCommander(IDevice device)
        {
            this.Device = device;
        }
    }
}
