using System;
using System.Collections;
using LuaInterface;
using PluginSet.Patch;
using UnityEngine;

namespace PluginSet.PatchToLua
{
    public static class PatchUtilWrapper
    {
        public static CheckResult CheckResourceVersion(string current, string target)
        {
            return PatchUtil.CheckResourceVersion(current, target);
        }
        
        public static string GetResourcesAssetBundle(string resourcePath, out string assetName)
        {
            return PatchUtil.GetResourcesAssetBundle(resourcePath, out assetName);
        }

        /// <summary>
        /// 分包检查更新通用逻辑（检查本地文件与目标URL文件的版本差异，判断是否需要更新）
        /// </summary>
        /// <param name="patchName">分包名称</param>
        /// <param name="urlPrefix">下载地址目录</param>
        /// <param name="streamingUrl">下载Streaming文件名</param>
        /// <param name="targetVersion">目标版本号</param>
        /// <param name="callback">检测回调</param>
        /// <returns></returns>
        public static IEnumerator CheckDownloadPatch(string patchName, string urlPrefix, string streamingUrl, string targetVersion = null, LuaFunction callback = null)
        {
            yield return PatchUtil.CheckDownloadPatch(patchName, urlPrefix, streamingUrl, targetVersion,
                delegate(PatchesDownloader downloader)
                {
                    try
                    {
                        if (callback == null || !callback.IsAlive)
                        {
                            downloader.Stop();
                            return;
                        }

                        callback.Call<PatchesDownloader>(downloader);
                    }
                    catch (Exception e)
                    {
                        downloader.Stop();
                        Debug.LogError("Callback lua in CheckDownloadPatch error: " + e);
                    }
                });
        }
    }
}