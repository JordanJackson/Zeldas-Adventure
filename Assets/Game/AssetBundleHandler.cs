using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AssetBundleHandler : Singleton<AssetBundleHandler> 
{
    public string assetBundleVersionFileName;
    public float currentVersion;
    AssetBundle contentVersionBundle;

    AssetBundleVersion bundleMap;

    private IEnumerator Start()
    {
        AssetBundleCreateRequest contentVersionBundleRequest = AssetBundle.LoadFromFileAsync(Path.Combine(Application.streamingAssetsPath, "AssetBundles/Windows/" + assetBundleVersionFileName));
        yield return contentVersionBundleRequest;
        Debug.Log("Content version: " + assetBundleVersionFileName + " loaded.");

        contentVersionBundle = contentVersionBundleRequest.assetBundle;

        if (contentVersionBundle.Contains("AssetBundleVersion" + currentVersion.ToString("0.0")))
        {
            Debug.Log("AssetBundleVersion" + currentVersion.ToString("0.0") + " found.");

            bundleMap = contentVersionBundle.LoadAsset<AssetBundleVersion>("AssetBundleVersion" + currentVersion.ToString("0.0"));
            if (bundleMap != null)
            {
                Debug.Log("BundleMap loaded.");

                // iterate through bundles referenced by bundleMap and load them
                for (int i = 0; i < bundleMap.bundles.Count; i++)
                {
                    Debug.Log("Bundle: " + bundleMap.bundles[i].key.ToString());
                }
            }
            else
            {
                Debug.LogError("BundleMap failed to load.");
            }
        }
    }

}
