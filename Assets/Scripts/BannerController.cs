using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerController : MonoBehaviour
{
    // Start is called before the first frame update

    public AdManager adManager;
    void Start()
    {
        adManager.RequestBanner();
        adManager.ShowBannerAd();
        //StartCoroutine(BannerCoroutine());
    }

    /*

    IEnumerator BannerCoroutine()
    {
        yield return new WaitForSeconds(1);
        adManager.ShowBannerAd();
    }
    */
}
