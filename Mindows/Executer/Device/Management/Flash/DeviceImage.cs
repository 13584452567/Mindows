﻿/********************************************************************************
** auth： zsh2401@163.com
** date： 2018/1/9 12:06:54
** filename: DeviceImage.cs
** compiler: Visual Studio 2017
** desc： ...
*********************************************************************************/
using System;

namespace Mindows.Basic.Device.Management.Flash
{
    /// <summary>
    /// 设备镜像
    /// </summary>
    [Obsolete("", true)]
    public enum DeviceImage
    {
        /// <summary>
        /// Boot镜像
        /// </summary>
        Boot,
        /// <summary>
        /// Recovery镜像
        /// </summary>
        Recovery,
    }
}
