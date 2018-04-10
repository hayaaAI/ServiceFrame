using System;
using System.Collections.Generic;
using Hayaa.BaseModel;
/// <summary>
///代码效率工具生成，此文件不要修改
/// </summary>
namespace Hayaa.ServicePlatform.Service
{
    public class AppComponentSearchPamater : SearchPamaterMariadbBase
    {
        public int? AppComponentId { set; get; }
        public List<int?> AppComponentIdList { set; get; }
        public int? AppComponentIdMax { set; get; }
        public int? AppComponentIdMin { set; get; }
        public void SetAppComponentId(int? max, int? min) { this.AppComponentIdMax = max; this.AppComponentIdMin = min; this.AppComponentIdPOT = PamaterOperationType.Between; }
        private PamaterOperationType AppComponentIdPOT;
        public void SetAppComponentId(int? info, PamaterOperationType pot) { this.AppComponentId = info; this.AppComponentIdPOT = pot; }
        private String GetAppComponentIdSqlForSharp()
        {
            String sql = ""; switch (AppComponentIdPOT)
            {
                case PamaterOperationType.Between: sql = "AppComponentId between @AppComponentIdMin to @AppComponentIdMax"; break;
                case PamaterOperationType.StringContains: sql = "AppComponentId like '%@AppComponentId%'"; break;
                case PamaterOperationType.Equal: sql = "AppComponentId=@AppComponentId"; break;
                case PamaterOperationType.GreaterEqual: sql = "AppComponentId>=@AppComponentId"; break;
                case PamaterOperationType.GreaterThan: sql = "AppComponentId>@AppComponentId"; break;
                case PamaterOperationType.LessEqual: sql = "AppComponentId<=@AppComponentId"; break;
                case PamaterOperationType.LessThan: sql = "AppComponentId<=@AppComponentId"; break;
                case PamaterOperationType.In: sql = "AppComponentId in(" + String.Join(",", this.AppComponentIdList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "AppComponentId in('" + String.Join("','", this.AppComponentIdList) + "')"; break;
            }
            return sql;
        }
        public int? ComponetId { set; get; }
        public List<int?> ComponetIdList { set; get; }
        public int? ComponetIdMax { set; get; }
        public int? ComponetIdMin { set; get; }
        public void SetComponetId(int? max, int? min) { this.ComponetIdMax = max; this.ComponetIdMin = min; this.ComponetIdPOT = PamaterOperationType.Between; }
        private PamaterOperationType ComponetIdPOT;
        public void SetComponetId(int? info, PamaterOperationType pot) { this.ComponetId = info; this.ComponetIdPOT = pot; }
        private String GetComponetIdSqlForSharp()
        {
            String sql = ""; switch (ComponetIdPOT)
            {
                case PamaterOperationType.Between: sql = "ComponetId between @ComponetIdMin to @ComponetIdMax"; break;
                case PamaterOperationType.StringContains: sql = "ComponetId like '%@ComponetId%'"; break;
                case PamaterOperationType.Equal: sql = "ComponetId=@ComponetId"; break;
                case PamaterOperationType.GreaterEqual: sql = "ComponetId>=@ComponetId"; break;
                case PamaterOperationType.GreaterThan: sql = "ComponetId>@ComponetId"; break;
                case PamaterOperationType.LessEqual: sql = "ComponetId<=@ComponetId"; break;
                case PamaterOperationType.LessThan: sql = "ComponetId<=@ComponetId"; break;
                case PamaterOperationType.In: sql = "ComponetId in(" + String.Join(",", this.ComponetIdList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "ComponetId in('" + String.Join("','", this.ComponetIdList) + "')"; break;
            }
            return sql;
        }
        public String ComponentServiceCompeleteName { set; get; }
        public List<String> ComponentServiceCompeleteNameList { set; get; }
        private PamaterOperationType ComponentServiceCompeleteNamePOT;
        public void SetComponentServiceCompeleteName(String info, PamaterOperationType pot) { this.ComponentServiceCompeleteName = info; this.ComponentServiceCompeleteNamePOT = pot; }
        private String GetComponentServiceCompeleteNameSqlForSharp()
        {
            String sql = ""; switch (ComponentServiceCompeleteNamePOT)
            {
                case PamaterOperationType.Between: sql = "ComponentServiceCompeleteName between @ComponentServiceCompeleteNameMin to @ComponentServiceCompeleteNameMax"; break;
                case PamaterOperationType.StringContains: sql = "ComponentServiceCompeleteName like '%@ComponentServiceCompeleteName%'"; break;
                case PamaterOperationType.Equal: sql = "ComponentServiceCompeleteName=@ComponentServiceCompeleteName"; break;
                case PamaterOperationType.GreaterEqual: sql = "ComponentServiceCompeleteName>=@ComponentServiceCompeleteName"; break;
                case PamaterOperationType.GreaterThan: sql = "ComponentServiceCompeleteName>@ComponentServiceCompeleteName"; break;
                case PamaterOperationType.LessEqual: sql = "ComponentServiceCompeleteName<=@ComponentServiceCompeleteName"; break;
                case PamaterOperationType.LessThan: sql = "ComponentServiceCompeleteName<=@ComponentServiceCompeleteName"; break;
                case PamaterOperationType.In: sql = "ComponentServiceCompeleteName in(" + String.Join(",", this.ComponentServiceCompeleteNameList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "ComponentServiceCompeleteName in('" + String.Join("','", this.ComponentServiceCompeleteNameList) + "')"; break;
            }
            return sql;
        }
        public String ComponentServiceName { set; get; }
        public List<String> ComponentServiceNameList { set; get; }
        private PamaterOperationType ComponentServiceNamePOT;
        public void SetComponentServiceName(String info, PamaterOperationType pot) { this.ComponentServiceName = info; this.ComponentServiceNamePOT = pot; }
        private String GetComponentServiceNameSqlForSharp()
        {
            String sql = ""; switch (ComponentServiceNamePOT)
            {
                case PamaterOperationType.Between: sql = "ComponentServiceName between @ComponentServiceNameMin to @ComponentServiceNameMax"; break;
                case PamaterOperationType.StringContains: sql = "ComponentServiceName like '%@ComponentServiceName%'"; break;
                case PamaterOperationType.Equal: sql = "ComponentServiceName=@ComponentServiceName"; break;
                case PamaterOperationType.GreaterEqual: sql = "ComponentServiceName>=@ComponentServiceName"; break;
                case PamaterOperationType.GreaterThan: sql = "ComponentServiceName>@ComponentServiceName"; break;
                case PamaterOperationType.LessEqual: sql = "ComponentServiceName<=@ComponentServiceName"; break;
                case PamaterOperationType.LessThan: sql = "ComponentServiceName<=@ComponentServiceName"; break;
                case PamaterOperationType.In: sql = "ComponentServiceName in(" + String.Join(",", this.ComponentServiceNameList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "ComponentServiceName in('" + String.Join("','", this.ComponentServiceNameList) + "')"; break;
            }
            return sql;
        }
        public String ComponentAssemblyName { set; get; }
        public List<String> ComponentAssemblyNameList { set; get; }
        private PamaterOperationType ComponentAssemblyNamePOT;
        public void SetComponentAssemblyName(String info, PamaterOperationType pot) { this.ComponentAssemblyName = info; this.ComponentAssemblyNamePOT = pot; }
        private String GetComponentAssemblyNameSqlForSharp()
        {
            String sql = ""; switch (ComponentAssemblyNamePOT)
            {
                case PamaterOperationType.Between: sql = "ComponentAssemblyName between @ComponentAssemblyNameMin to @ComponentAssemblyNameMax"; break;
                case PamaterOperationType.StringContains: sql = "ComponentAssemblyName like '%@ComponentAssemblyName%'"; break;
                case PamaterOperationType.Equal: sql = "ComponentAssemblyName=@ComponentAssemblyName"; break;
                case PamaterOperationType.GreaterEqual: sql = "ComponentAssemblyName>=@ComponentAssemblyName"; break;
                case PamaterOperationType.GreaterThan: sql = "ComponentAssemblyName>@ComponentAssemblyName"; break;
                case PamaterOperationType.LessEqual: sql = "ComponentAssemblyName<=@ComponentAssemblyName"; break;
                case PamaterOperationType.LessThan: sql = "ComponentAssemblyName<=@ComponentAssemblyName"; break;
                case PamaterOperationType.In: sql = "ComponentAssemblyName in(" + String.Join(",", this.ComponentAssemblyNameList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "ComponentAssemblyName in('" + String.Join("','", this.ComponentAssemblyNameList) + "')"; break;
            }
            return sql;
        }
        public String ComponentAssemblyFileName { set; get; }
        public List<String> ComponentAssemblyFileNameList { set; get; }
        private PamaterOperationType ComponentAssemblyFileNamePOT;
        public void SetComponentAssemblyFileName(String info, PamaterOperationType pot) { this.ComponentAssemblyFileName = info; this.ComponentAssemblyFileNamePOT = pot; }
        private String GetComponentAssemblyFileNameSqlForSharp()
        {
            String sql = ""; switch (ComponentAssemblyFileNamePOT)
            {
                case PamaterOperationType.Between: sql = "ComponentAssemblyFileName between @ComponentAssemblyFileNameMin to @ComponentAssemblyFileNameMax"; break;
                case PamaterOperationType.StringContains: sql = "ComponentAssemblyFileName like '%@ComponentAssemblyFileName%'"; break;
                case PamaterOperationType.Equal: sql = "ComponentAssemblyFileName=@ComponentAssemblyFileName"; break;
                case PamaterOperationType.GreaterEqual: sql = "ComponentAssemblyFileName>=@ComponentAssemblyFileName"; break;
                case PamaterOperationType.GreaterThan: sql = "ComponentAssemblyFileName>@ComponentAssemblyFileName"; break;
                case PamaterOperationType.LessEqual: sql = "ComponentAssemblyFileName<=@ComponentAssemblyFileName"; break;
                case PamaterOperationType.LessThan: sql = "ComponentAssemblyFileName<=@ComponentAssemblyFileName"; break;
                case PamaterOperationType.In: sql = "ComponentAssemblyFileName in(" + String.Join(",", this.ComponentAssemblyFileNameList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "ComponentAssemblyFileName in('" + String.Join("','", this.ComponentAssemblyFileNameList) + "')"; break;
            }
            return sql;
        }
        public String ComponentAssemblyFileStorePath { set; get; }
        public List<String> ComponentAssemblyFileStorePathList { set; get; }
        private PamaterOperationType ComponentAssemblyFileStorePathPOT;
        public void SetComponentAssemblyFileStorePath(String info, PamaterOperationType pot) { this.ComponentAssemblyFileStorePath = info; this.ComponentAssemblyFileStorePathPOT = pot; }
        private String GetComponentAssemblyFileStorePathSqlForSharp()
        {
            String sql = ""; switch (ComponentAssemblyFileStorePathPOT)
            {
                case PamaterOperationType.Between: sql = "ComponentAssemblyFileStorePath between @ComponentAssemblyFileStorePathMin to @ComponentAssemblyFileStorePathMax"; break;
                case PamaterOperationType.StringContains: sql = "ComponentAssemblyFileStorePath like '%@ComponentAssemblyFileStorePath%'"; break;
                case PamaterOperationType.Equal: sql = "ComponentAssemblyFileStorePath=@ComponentAssemblyFileStorePath"; break;
                case PamaterOperationType.GreaterEqual: sql = "ComponentAssemblyFileStorePath>=@ComponentAssemblyFileStorePath"; break;
                case PamaterOperationType.GreaterThan: sql = "ComponentAssemblyFileStorePath>@ComponentAssemblyFileStorePath"; break;
                case PamaterOperationType.LessEqual: sql = "ComponentAssemblyFileStorePath<=@ComponentAssemblyFileStorePath"; break;
                case PamaterOperationType.LessThan: sql = "ComponentAssemblyFileStorePath<=@ComponentAssemblyFileStorePath"; break;
                case PamaterOperationType.In: sql = "ComponentAssemblyFileStorePath in(" + String.Join(",", this.ComponentAssemblyFileStorePathList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "ComponentAssemblyFileStorePath in('" + String.Join("','", this.ComponentAssemblyFileStorePathList) + "')"; break;
            }
            return sql;
        }
        public String AssemblyVersion { set; get; }
        public List<String> AssemblyVersionList { set; get; }
        private PamaterOperationType AssemblyVersionPOT;
        public void SetAssemblyVersion(String info, PamaterOperationType pot) { this.AssemblyVersion = info; this.AssemblyVersionPOT = pot; }
        private String GetAssemblyVersionSqlForSharp()
        {
            String sql = ""; switch (AssemblyVersionPOT)
            {
                case PamaterOperationType.Between: sql = "AssemblyVersion between @AssemblyVersionMin to @AssemblyVersionMax"; break;
                case PamaterOperationType.StringContains: sql = "AssemblyVersion like '%@AssemblyVersion%'"; break;
                case PamaterOperationType.Equal: sql = "AssemblyVersion=@AssemblyVersion"; break;
                case PamaterOperationType.GreaterEqual: sql = "AssemblyVersion>=@AssemblyVersion"; break;
                case PamaterOperationType.GreaterThan: sql = "AssemblyVersion>@AssemblyVersion"; break;
                case PamaterOperationType.LessEqual: sql = "AssemblyVersion<=@AssemblyVersion"; break;
                case PamaterOperationType.LessThan: sql = "AssemblyVersion<=@AssemblyVersion"; break;
                case PamaterOperationType.In: sql = "AssemblyVersion in(" + String.Join(",", this.AssemblyVersionList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "AssemblyVersion in('" + String.Join("','", this.AssemblyVersionList) + "')"; break;
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