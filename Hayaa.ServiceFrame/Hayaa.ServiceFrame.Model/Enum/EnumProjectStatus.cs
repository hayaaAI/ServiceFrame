using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.ServiceFrame.Model.Project
{
    /// <summary>
    /// 项目状态
    /// </summary>
    public enum ProjectStatus
    {
        /// <summary>
        /// 准备
        /// </summary>
        Ready=1,
        /// <summary>
        /// 已开始
        /// </summary>
        Started=2,
        /// <summary>
        /// 暂停
        /// </summary>
        Stop=3,
        /// <summary>
        /// 结束
        /// </summary>
        End=4,
        /// <summary>
        /// 重启
        /// </summary>
        Restart=5
    }
}
