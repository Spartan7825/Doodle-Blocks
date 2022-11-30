using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;


public class AdManager : MonoBehaviour
{
    private BannerView bannerAd;
    private InterstitialAd interstitial;

    private RewardedAd rewardBasedVideo;

    public static AdManager instance;
    public bool isRewarded = false;
    public int adsWatched = 0;
    GameSession theGameSession;
    pauseBtnScript pbs;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
        pbs = FindObjectOfType<pauseBtnScript>();
        MobileAds.Initialize(InitializationStatus => { });

        // Get singleton reward based video ad reference.
        this.rewardBasedVideo = new RewardedAd("ca-app-pub-3940256099942544/5224354917");

        // RewardBasedVideoAd is a singleton, so handlers should only be registered once.
        this.rewardBasedVideo.OnUserEarnedReward += this.HandleRewardBasedVideoRewarded;
        this.rewardBasedVideo.OnAdClosed += this.HandleRewardBasedVideoClosed;
        this.RequestRewardBasedVideo();
    }

    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder().Build();
    }

    public void RequestInterstitial()
    {

        string adUnitId = "ca-app-pub-5070531728786199/6091903466";
        // Clean up interstitial ad before creating a new one.
        if (this.interstitial != null)
            this.interstitial.Destroy();

        // Create an interstitial.
        this.interstitial = new InterstitialAd(adUnitId);

        // Load an interstitial ad.
        this.interstitial.LoadAd(this.CreateAdRequest());
    }

    public void ShowInterstitial()
    {
        if (this.interstitial.IsLoaded())
        {
            interstitial.Show();
        }
        else
        {
            Debug.Log("Inerstitial Ad is not ready yet");
        }
    }


    public void RequestRewardBasedVideo()
    {
        string adUnitId = "ca-app-pub-3940256099942544/5224354917";
        var rewardBasedVideo = new RewardedAd(adUnitId);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        this.rewardBasedVideo.LoadAd(request);
        // this.rewardBasedVideo.LoadAd(this.CreateAdRequest(), adUnitId);
    }

    public void ShowRewardBasedVideo()
    {
        if (!theGameSession.IsAutoPlayEnabled()) 
        {
            if (this.rewardBasedVideo.IsLoaded())
            {
                pbs.PauseGame();
                this.rewardBasedVideo.Show();
            }
            else { Debug.Log("No ad"); }
        }

    }

    #region RewardBasedVideo callback handlers

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        this.RequestRewardBasedVideo();
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        isRewarded = true;
    }
    #endregion

    // Update is called once per frame
    void Update()
    {
        if (isRewarded)
        {
            isRewarded = false;
            adsWatched += 1;
            theGameSession.isAutoPlayEnabled = true;
            pbs.ResumeGame();
        }
    }
}