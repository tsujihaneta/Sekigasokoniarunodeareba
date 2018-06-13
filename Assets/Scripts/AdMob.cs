using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdMob : MonoBehaviour {

    //UnitID情報
    string adUnitId;
    BannerView bannerView;
    AdRequest request;
    public bool isDebug = false;

    // Use this for initialization
    void Start() {

#if UNITY_EDITOR
        isDebug = true;
#endif

        //if UNITY_ANDROID
        adUnitId = (isDebug) ? "ca-app-pub-3940256099942544/6300978111" : "ca-app-pub-1135852608188426/9077680417";

        // Create a banner.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
        // Create an empty ad request.
        request = new AdRequest.Builder().Build();

        //広告表示
        RequestAdmob();
    }

    // Update is called once per frame
    void Update() {

    }

    private void RequestAdmob() {

        // Load the interstitial with the request.
        bannerView.LoadAd(request);
    }
}
