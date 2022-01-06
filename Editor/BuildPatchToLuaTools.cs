using PluginSet.Core.Editor;

namespace PluginSet.PatchToLua.Editor
{
    [BuildTools]
    public static class BuildPatchToLuaTools
    {
        
        [OnSyncEditorSetting]
        public static void OnSyncEditorSetting(BuildProcessorContext context)
        {
            context.AddLinkAssembly("PluginSet.PatchToLua");
        }
    }
}