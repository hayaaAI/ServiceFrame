using System;
using System.Collections.Generic;
using Hayaa.BaseModel;
/// <summary>
///代码效率工具生成，此文件不要修改
/// </summary>
namespace Hayaa.ServicePlatform.Service
{
    public class AppConfigSearchPamater : SearchPamaterMariadbBase
    {
        public int? AppConfigId { set; get; }
        public List<int?> AppConfigIdList { set; get; }
        public int? AppConfigIdMax { set; get; }
        public int? AppConfigIdMin { set; get; }
        public void SetAppConfigId(int? max, int? min) { this.AppConfigIdMax = max; this.AppConfigIdMin = min; this.AppConfigIdPOT = PamaterOperationType.Between; }
        private PamaterOperationType AppConfigIdPOT;
        public void SetAppConfigId(int? info, PamaterOperationType pot) { this.AppConfigId = info; this.AppConfigIdPOT = pot; }
        private String GetAppConfigIdSqlForSharp()
        {
            String sql = ""; switch (AppConfigIdPOT)
            {
                case PamaterOperationType.Between: sql = "AppConfigId between @AppConfigIdMin to @AppConfigIdMax"; break;
                case PamaterOperationType.StringContains: sql = "AppConfigId like '%@AppConfigId%'"; break;
                case PamaterOperationType.Equal: sql = "AppConfigId=@AppConfigId"; break;
                case PamaterOperationType.GreaterEqual: sql = "AppConfigId>=@AppConfigId"; break;
                case PamaterOperationType.GreaterThan: sql = "AppConfigId>@AppConfigId"; break;
                case PamaterOperationType.LessEqual: sql = "AppConfigId<=@AppConfigId"; break;
                case PamaterOperationType.LessThan: sql = "AppConfigId<=@AppConfigId"; break;
                case PamaterOperationType.In: sql = "AppConfigId in(" + String.Join(",", this.AppConfigIdList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "AppConfigId in('" + String.Join("','", this.AppConfigIdList) + "')"; break;
            }
            return sql;
        }
        public String SolutionID { set; get; }
        public List<String> SolutionIDList { set; get; }
        private PamaterOperationType SolutionIDPOT;
        public void SetSolutionID(String info, PamaterOperationType pot) { this.SolutionID = info; this.SolutionIDPOT = pot; }
        private String GetSolutionIDSqlForSharp()
        {
            String sql = ""; switch (SolutionIDPOT)
            {
                case PamaterOperationType.Between: sql = "SolutionID between @SolutionIDMin to @SolutionIDMax"; break;
                case PamaterOperationType.StringContains: sql = "SolutionID like '%@SolutionID%'"; break;
                case PamaterOperationType.Equal: sql = "SolutionID=@SolutionID"; break;
                case PamaterOperationType.GreaterEqual: sql = "SolutionID>=@SolutionID"; break;
                case PamaterOperationType.GreaterThan: sql = "SolutionID>@SolutionID"; break;
                case PamaterOperationType.LessEqual: sql = "SolutionID<=@SolutionID"; break;
                case PamaterOperationType.LessThan: sql = "SolutionID<=@SolutionID"; break;
                case PamaterOperationType.In: sql = "SolutionID in(" + String.Join(",", this.SolutionIDList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "SolutionID in('" + String.Join("','", this.SolutionIDList) + "')"; break;
            }
            return sql;
        }
        public String SolutionName { set; get; }
        public List<String> SolutionNameList { set; get; }
        private PamaterOperationType SolutionNamePOT;
        public void SetSolutionName(String info, PamaterOperationType pot) { this.SolutionName = info; this.SolutionNamePOT = pot; }
        private String GetSolutionNameSqlForSharp()
        {
            String sql = ""; switch (SolutionNamePOT)
            {
                case PamaterOperationType.Between: sql = "SolutionName between @SolutionNameMin to @SolutionNameMax"; break;
                case PamaterOperationType.StringContains: sql = "SolutionName like '%@SolutionName%'"; break;
                case PamaterOperationType.Equal: sql = "SolutionName=@SolutionName"; break;
                case PamaterOperationType.GreaterEqual: sql = "SolutionName>=@SolutionName"; break;
                case PamaterOperationType.GreaterThan: sql = "SolutionName>@SolutionName"; break;
                case PamaterOperationType.LessEqual: sql = "SolutionName<=@SolutionName"; break;
                case PamaterOperationType.LessThan: sql = "SolutionName<=@SolutionName"; break;
                case PamaterOperationType.In: sql = "SolutionName in(" + String.Join(",", this.SolutionNameList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "SolutionName in('" + String.Join("','", this.SolutionNameList) + "')"; break;
            }
            return sql;
        }
        public String ConfigContent { set; get; }
        public List<String> ConfigContentList { set; get; }
        private PamaterOperationType ConfigContentPOT;
        public void SetConfigContent(String info, PamaterOperationType pot) { this.ConfigContent = info; this.ConfigContentPOT = pot; }
        private String GetConfigContentSqlForSharp()
        {
            String sql = ""; switch (ConfigContentPOT)
            {
                case PamaterOperationType.Between: sql = "ConfigContent between @ConfigContentMin to @ConfigContentMax"; break;
                case PamaterOperationType.StringContains: sql = "ConfigContent like '%@ConfigContent%'"; break;
                case PamaterOperationType.Equal: sql = "ConfigContent=@ConfigContent"; break;
                case PamaterOperationType.GreaterEqual: sql = "ConfigContent>=@ConfigContent"; break;
                case PamaterOperationType.GreaterThan: sql = "ConfigContent>@ConfigContent"; break;
                case PamaterOperationType.LessEqual: sql = "ConfigContent<=@ConfigContent"; break;
                case PamaterOperationType.LessThan: sql = "ConfigContent<=@ConfigContent"; break;
                case PamaterOperationType.In: sql = "ConfigContent in(" + String.Join(",", this.ConfigContentList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "ConfigContent in('" + String.Join("','", this.ConfigContentList) + "')"; break;
            }
            return sql;
        }
        public int? Version { set; get; }
        public List<int?> VersionList { set; get; }
        public int? VersionMax { set; get; }
        public int? VersionMin { set; get; }
        public void SetVersion(int? max, int? min) { this.VersionMax = max; this.VersionMin = min; this.VersionPOT = PamaterOperationType.Between; }
        private PamaterOperationType VersionPOT;
        public void SetVersion(int? info, PamaterOperationType pot) { this.Version = info; this.VersionPOT = pot; }
        private String GetVersionSqlForSharp()
        {
            String sql = ""; switch (VersionPOT)
            {
                case PamaterOperationType.Between: sql = "Version between @VersionMin to @VersionMax"; break;
                case PamaterOperationType.StringContains: sql = "Version like '%@Version%'"; break;
                case PamaterOperationType.Equal: sql = "Version=@Version"; break;
                case PamaterOperationType.GreaterEqual: sql = "Version>=@Version"; break;
                case PamaterOperationType.GreaterThan: sql = "Version>@Version"; break;
                case PamaterOperationType.LessEqual: sql = "Version<=@Version"; break;
                case PamaterOperationType.LessThan: sql = "Version<=@Version"; break;
                case PamaterOperationType.In: sql = "Version in(" + String.Join(",", this.VersionList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "Version in('" + String.Join("','", this.VersionList) + "')"; break;
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
        public DateTime? UpdateTime { set; get; }
        public List<DateTime?> UpdateTimeList { set; get; }
        public DateTime? UpdateTimeMax { set; get; }
        public DateTime? UpdateTimeMin { set; get; }
        public void SetUpdateTime(DateTime? max, DateTime? min) { this.UpdateTimeMax = max; this.UpdateTimeMin = min; this.UpdateTimePOT = PamaterOperationType.Between; }
        private PamaterOperationType UpdateTimePOT;
        public void SetUpdateTime(DateTime? info, PamaterOperationType pot) { this.UpdateTime = info; this.UpdateTimePOT = pot; }
        private String GetUpdateTimeSqlForSharp()
        {
            String sql = ""; switch (UpdateTimePOT)
            {
                case PamaterOperationType.Between: sql = "UpdateTime between @UpdateTimeMin to @UpdateTimeMax"; break;
                case PamaterOperationType.StringContains: sql = "UpdateTime like '%@UpdateTime%'"; break;
                case PamaterOperationType.Equal: sql = "UpdateTime=@UpdateTime"; break;
                case PamaterOperationType.GreaterEqual: sql = "UpdateTime>=@UpdateTime"; break;
                case PamaterOperationType.GreaterThan: sql = "UpdateTime>@UpdateTime"; break;
                case PamaterOperationType.LessEqual: sql = "UpdateTime<=@UpdateTime"; break;
                case PamaterOperationType.LessThan: sql = "UpdateTime<=@UpdateTime"; break;
                case PamaterOperationType.In: sql = "UpdateTime in(" + String.Join(",", this.UpdateTimeList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "UpdateTime in('" + String.Join("','", this.UpdateTimeList) + "')"; break;
            }
            return sql;
        }
    }
}