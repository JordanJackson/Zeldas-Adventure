using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectButton : MonoBehaviour 
{
    public string assetBundleName;
    public string assetName;

    public void LoadPlayerFromAssetBundle()
    {
        LoadAssets loader = GetComponent<LoadAssets>();
        StartCoroutine(loader.InstantiateGameObjectAsync(assetBundleName, assetName));
        //this.gameObject.SetActive(false);
    }

    private void Update()
    {
        Player p = FindObjectOfType<Player>();
        if (p != null)
        {
            Destroy(this.gameObject);
        }
    }
}
