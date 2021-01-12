using UnityEngine;
using System;
using GoogleMobileAds.Api;




public class AdManager : MonoBehaviour
{

    string App_ID = "ca-app-pub-1734601237492663~3499928637";

    string Banner_Ad_ID = "ca-app-pub-1734601237492663/1475023145";


    string Interstitial_Ad_ID = "ca-app-pub-1734601237492663/8587226409";
    
    string Rewarded_Ad_ID = "";//"ca-app-pub-3940256099942544/5224354917";

    private BannerView bannerView;
    private InterstitialAd interstitial;
    private RewardBasedVideoAd rewardBasedVideo;

 
    void Start()
    {
        MobileAds.Initialize(App_ID);

    }



    public void RequestBanner()
    {
        // Create a 320x50 banner at the top of the screen.
        
        
        this.bannerView = new BannerView(Banner_Ad_ID, AdSize.Banner, AdPosition.Bottom);
        
       
    }

    public void RequestInterstitial()
    {

        if(this.interstitial == null)
        {
            // Initialize an InterstitialAd.
            this.interstitial = new InterstitialAd(Interstitial_Ad_ID);

            /*
            // Called when an ad request has successfully loaded.
            this.interstitial.OnAdLoaded += HandleOnAdLoaded;
            // Called when an ad request failed to load.
            this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;*/

            Debug.LogWarning("Loaded");

            AdRequest request = new AdRequest.Builder().Build();
            this.interstitial.LoadAd(request);
        }
    }

    public void RequestRewardBasedVideo()
    {
        rewardBasedVideo = RewardBasedVideoAd.Instance;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded video ad with the request.
        this.rewardBasedVideo.LoadAd(request, Rewarded_Ad_ID);
     }

    public void ShowVideoRewardAd()
    {
        if (rewardBasedVideo.IsLoaded())
        {
            rewardBasedVideo.Show();
        }
    }

    public void ShowInterstitialAd()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }

    public void ShowBannerAd()
    {
        // Create an empty ad request
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with request.
        this.bannerView.LoadAd(request);
    }


    public void DestroyInterstitialAd()
    {
        if (this.interstitial != null)
        {
            this.interstitial.Destroy();
        }
        
    }


    public void DestroyBannerAd()
    {
        if (this.bannerView != null)
        {
            Debug.Log("Sildim");
            this.bannerView.Destroy();
        }
        else
        {
            Debug.LogError("Sildim");
        }
        
    }

    // FOR EVENTS AND DELEGATES FOR ADS
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        Debug.Log("Ad Loaded");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.LogError("Ad Failed to Loaded");
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

}
