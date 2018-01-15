using Hayaa.BaseModel;

namespace Hayaa.RemoteService
{
    /// <summary>
    /// 部署程序
    /// </summary>
    public class App: BaseData
    {
        /// <summary>
        /// 程序身份ID
        /// </summary>
        public int AppID { set; get; }
        /// <summary>
        /// 展示名
        /// </summary>
        public string Title { set; get; }
        /// <summary>
        /// 程序名
        /// </summary>
        public string Name { set; get; }
       
    }
}