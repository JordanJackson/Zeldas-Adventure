using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AssetBundleVersion", menuName = "Data/AssetBundleVersion", order = 1)]
public class AssetBundleVersion : ScriptableObject 
{
    [System.Serializable]
    public class AssetBundleEntry
    {
        public string key;
        public List<string> bundleIds;
    }

    public float version;

    public List<AssetBundleEntry> bundles;
    
}
