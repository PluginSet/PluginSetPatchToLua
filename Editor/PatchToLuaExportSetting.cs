using System;
using System.Collections.Generic;
using PluginSet.Patch;

namespace PluginSet.PatchToLua.Editor
{
    [ToLuaGenerateSetting("PluginSet.PatchToLua.LuaWrap" ,"PatchWraps", "com.pluginset.patchtolua", -999998)]
    public static class PatchToLuaExportSetting
    {
        //导出时强制做为静态类的类型(注意customTypeList 还要添加这个类型才能导出)
        //unity 有些类作为sealed class, 其实完全等价于静态类
        [ToLuaGenerateStatic]
        public static List<Type> staticClassTypes = new List<Type>
        {
            typeof(PatchUtilWrapper),
            typeof(PatchResourcesManager),
        };

        //附加导出委托类型(在导出委托时, customTypeList 中牵扯的委托类型都会导出， 无需写在这里)
        [ToLuaGenerateDrop]
        [ToLuaGenerateDelegate]
        public static List<Type> customDelegateList = new List<Type>()
        {
			typeof(System.Action),
			typeof(System.Action<bool>),
			typeof(System.Action<float>),
			typeof(System.Action<PatchesDownloader>),
        };
        
        //在这里添加你要导出注册到lua的类型列表
        [ToLuaGenerateDrop]
        [ToLuaGenerateClass]
        public static List<Type> customTypeList = new List<Type>
        {
            typeof(CheckResult),
            typeof(PatchesDownloader.DownloadState),
            
            typeof(PatchUtilWrapper),
            typeof(FileManifest),
            typeof(FileDownloader),
            typeof(PatchesDownloader),
            typeof(PatchResourcesManager),
        };

        [ToLuaGenerateBaseType]
        public static Dictionary<Type, Type> baseTypes = new Dictionary<Type, Type>()
        {
	        {typeof(FileDownloader), null},
        };
        
//        [ToLuaGenerateNameSpace]
//        public static Dictionary<Type, string> nameSpaces = new Dictionary<Type, string>()
//        {
//            {typeof(PatchUtilWrapper), null},
//        };
        
        [ToLuaGenerateLibName]
        public static Dictionary<Type, string> libsName = new Dictionary<Type, string>()
        {
            {typeof(PatchUtilWrapper), "PatchUtil"},
        };
        
        [ToLuaGenerateBlackList]
        public static Dictionary<Type, IEnumerable<string>> blackList = new Dictionary<Type, IEnumerable<string>>()
        {
            {typeof(FileManifest), new [] {"AppendFileInfo"}},
            {typeof(PatchResourcesManager), new []
            {
                "PathInfoses", "SetMonoBehaviour", "AddSearchPath", "RemoveSearchPath",
                "Init", "Load", "LoadAsync", "GetAssetBundleFileName",
                "LoadBundle", "LoadBundleAsync", "ReleaseBundle", "DontReleaseBundle",
                "ReleaseAll", "LoadAsset", "LoadAssetAsync", "LoadAllAssets",
                "LoadAllAssetsAsync", "IsValidAssetFile", "LoadManifest", "GetAllAssetBundleNames",
                "GetAssetBundleName", "GetAssetPathsFromAssetBundle", "ExistsBundle",
            }},
            
        };
        
        [ToLuaGenerateDrop]
        public static List<Type> dropList = new List<Type>()
        {
            typeof(PatchUtil),
        };
    }
}
