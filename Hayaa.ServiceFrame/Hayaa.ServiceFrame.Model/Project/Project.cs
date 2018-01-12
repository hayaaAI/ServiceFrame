using Hayaa.BaseModel;
using System;

namespace Hayaa.ServiceFrame.Model.Project
{
    /// <summary>
    /// 项目
    /// </summary>
    public  class Project: BaseData
    {
        /// <summary>
        /// 项目ID
        /// </summary>
        public int ProjectID { set; get; }
        /// <summary>
        /// 展示名
        /// </summary>
        public String Title { set; get; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public String Name { set; get; }
        /// <summary>
        /// 项目开始时间
        /// </summary>
        public DateTime StartTime { set; get; }
        /// <summary>
        /// 预计结束时间
        /// </summary>
        public DateTime? EndTime { set; get; }
        /// <summary>
        /// 项目状态
        /// </summary>
        public ProjectStatus Status { set; get; }
        /// <summary>
        /// 项目类型
        /// </summary>
        public ProjectType Type { set; get; }
    }
}
