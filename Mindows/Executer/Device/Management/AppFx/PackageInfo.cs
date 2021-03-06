/*************************************************
** auth： zsh2401@163.com
** date:  2018/8/30 5:49:54 (UTC +8:00)
** desc： ...
*************************************************/
using Mindows.Basic.Exceptions;
using System;
using System.Text.RegularExpressions;

namespace Mindows.Basic.Device.Management.AppFx
{
    /// <summary>
    /// 包信息
    /// </summary>
    [Obsolete("等待重做")]
    public sealed class PackageInfo
    {
        #region Property
        /// <summary>
        /// 这个包是否存在
        /// </summary>
        public bool IsExist
        {
            get
            {
                var result = Owner.Shell($"pm path {Name}");
                return result.Item2 == 0;
            }
        }
        /// <summary>
        /// 主界面类名
        /// </summary>
        public string MainActivity
        {
            get
            {
                if (!IsExist) { throw new PackageNotFoundException(Name); }
                var exeResult = Owner.Shell($"dumpsys package {Name}").Item1;
                var match = Regex.Match(exeResult.ToString(), mainActivityPattern);
                if (match.Success)
                {
                    return match.Result("${result}");
                }
                else
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// 包名
        /// </summary>
        public string Name { get; private set; }
        #endregion
        /// <summary>
        /// 这个包所在的设备
        /// </summary>
        public IDevice Owner { get; private set; }

        private static readonly string mainActivityPattern = $"android.intent.action.MAIN:{Environment.NewLine}.+.+\u0020(?<result>.+)";
        /// <summary>
        /// 构建
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="pkgName"></param>
        public PackageInfo(IDevice owner, string pkgName) : this(owner, pkgName, true)
        {
        }
        internal PackageInfo(IDevice owner, string pkgName, bool precheck = false)
        {
            this.Name = pkgName;
            this.Owner = owner;
            if (precheck)
            {
                Precheck();
            }
        }
        private void Precheck()
        {
            
        }
        /// <summary>
        /// 卸载
        /// </summary>
        public void Uninstall()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 强制停止
        /// </summary>
        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
