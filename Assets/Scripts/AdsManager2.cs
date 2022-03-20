using UnityEngine;
using UnityEngine.Advertisements;


public class AdsManager2 : MonoBehaviour
{

    string gameId = "3800481";
    bool testMode = true;
    private string videoId = "video";
    private string BannerId = "bannermain";

    private bool didAdsRemoved = false;


    void Start()
    {
        if(PlayerPrefs.GetInt("AdsRemovedSave", 0) == 1)
        {
            didAdsRemoved = true;
        }
        Advertisement.Initialize(gameId, testMode);
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
    }


    public void HideAds()
    {
        if (didAdsRemoved == false)
        {
            Advertisement.Banner.Hide(false);
        }
        
    }


    public void ShowBannerAdNow()
    {
        if(didAdsRemoved == false)
        {
            Advertisement.Banner.Show(BannerId);
        }
        
    }


    public void ShowInterstitialAd()
    {
        if(didAdsRemoved == false)
        {
            if (Advertisement.IsReady(videoId))
            {
                Advertisement.Show(videoId);
            }
        }
            
    }


    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        //AudioListener.volume = 1f;
    }

    public void OnUnityAdsReady(string placementId)
    {

    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //AudioListener.volume = 0f;
        // Optional actions to take when the end-users triggers an ad.
    }

    // When the object that subscribes to ad events is destroyed, remove the listener:


}

