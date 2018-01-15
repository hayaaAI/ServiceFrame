using Hayaa.BaseModel;

namespace Hayaa.RemoteService
{
    /// <summary>
    /// 程序内组件
    /// </summary>
    public class Component:BaseData
    {
        /// <summary>
        /// 组件身份ID，可固化数据
        /// </summary>
        public int ComponentID { set; get; }
        /// <summary>
        /// 展示名
        /// </summary>
        public string Title { set; get; }
        /// <summary>
        /// 组件名
        /// </summary>
        public string Name { set; get; }
    }
}