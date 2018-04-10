using System;
using System.Collections.Generic;
using Hayaa.BaseModel;
/// <summary>
///代码效率工具生成，此文件不要修改
/// </summary>
namespace Hayaa.ServicePlatform.Service
{
    public class AppInstanceSearchPamater : SearchPamaterMariadbBase
    {
        public int? AppInstanceId { set; get; }
        public List<int?> AppInstanceIdList { set; get; }
        public int? AppInstanceIdMax { set; get; }
        public int? AppInstanceIdMin { set; get; }
        public void SetAppInstanceId(int? max, int? min) { this.AppInstanceIdMax = max; this.AppInstanceIdMin = min; this.AppInstanceIdPOT = PamaterOperationType.Between; }
        private PamaterOperationType AppInstanceIdPOT;
        public void SetAppInstanceId(int? info, PamaterOperationType pot) { this.AppInstanceId = info; this.AppInstanceIdPOT = pot; }
        private String GetAppInstanceIdSqlForSharp()
        {
            String sql = ""; switch (AppInstanceIdPOT)
            {
                case PamaterOperationType.Between: sql = "AppInstanceId between @AppInstanceIdMin to @AppInstanceIdMax"; break;
                case PamaterOperationType.StringContains: sql = "AppInstanceId like '%@AppInstanceId%'"; break;
                case PamaterOperationType.Equal: sql = "AppInstanceId=@AppInstanceId"; break;
                case PamaterOperationType.GreaterEqual: sql = "AppInstanceId>=@AppInstanceId"; break;
                case PamaterOperationType.GreaterThan: sql = "AppInstanceId>@AppInstanceId"; break;
                case PamaterOperationType.LessEqual: sql = "AppInstanceId<=@AppInstanceId"; break;
                case PamaterOperationType.LessThan: sql = "AppInstanceId<=@AppInstanceId"; break;
                case PamaterOperationType.In: sql = "AppInstanceId in(" + String.Join(",", this.AppInstanceIdList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "AppInstanceId in('" + String.Join("','", this.AppInstanceIdList) + "')"; break;
            }
            return sql;
        }
        public String Title { set; get; }
        public List<String> TitleList { set; get; }
        private PamaterOperationType TitlePOT;
        public void SetTitle(String info, PamaterOperationType pot) { this.Title = info; this.TitlePOT = pot; }
        private String GetTitleSqlForSharp()
        {
            String sql = ""; switch (TitlePOT)
            {
                case PamaterOperationType.Between: sql = "Title between @TitleMin to @TitleMax"; break;
                case PamaterOperationType.StringContains: sql = "Title like '%@Title%'"; break;
                case PamaterOperationType.Equal: sql = "Title=@Title"; break;
                case PamaterOperationType.GreaterEqual: sql = "Title>=@Title"; break;
                case PamaterOperationType.GreaterThan: sql = "Title>@Title"; break;
                case PamaterOperationType.LessEqual: sql = "Title<=@Title"; break;
                case PamaterOperationType.LessThan: sql = "Title<=@Title"; break;
                case PamaterOperationType.In: sql = "Title in(" + String.Join(",", this.TitleList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "Title in('" + String.Join("','", this.TitleList) + "')"; break;
            }
            return sql;
        }
        public DateTime? CreateTime { set; get; }
        public List<DateTime?> CreateTimeList { set; get; }
        public DateTime? CreateTimeMax { set; get; }
        public DateTime? CreateTimeMin { set; get; }
        public void SetCreateTime(DateTime? max, DateTime? min) { this.CreateTimeMax = max; this.CreateTimeMin = min; this.CreateTimePOT = PamaterOperationType.Between; }
        private PamaterOperationType CreateTimePOT;
        public void SetCreateTime(DateTime? info, PamaterOperationType pot) { this.CreateTime = info; this.CreateTimePOT = pot; }
        private String GetCreateTimeSqlForSharp()
        {
            String sql = ""; switch (CreateTimePOT)
            {
                case PamaterOperationType.Between: sql = "CreateTime between @CreateTimeMin to @CreateTimeMax"; break;
                case PamaterOperationType.StringContains: sql = "CreateTime like '%@CreateTime%'"; break;
                case PamaterOperationType.Equal: sql = "CreateTime=@CreateTime"; break;
                case PamaterOperationType.GreaterEqual: sql = "CreateTime>=@CreateTime"; break;
                case PamaterOperationType.GreaterThan: sql = "CreateTime>@CreateTime"; break;
                case PamaterOperationType.LessEqual: sql = "CreateTime<=@CreateTime"; break;
                case PamaterOperationType.LessThan: sql = "CreateTime<=@CreateTime"; break;
                case PamaterOperationType.In: sql = "CreateTime in(" + String.Join(",", this.CreateTimeList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "CreateTime in('" + String.Join("','", this.CreateTimeList) + "')"; break;
            }
            return sql;
        }
    }
}