using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{

    string gameId = "3800481";
    bool testMode = true;
    private string videoId = "video";
    private string RewardId = "rewardedVideo";
    private string BannerId = "bannermain";

    public Text waitText;

    private bool didAdsRemoved = false;

    private int gemsPresent;
    private int gemsNew;


    public Text gemsText;
    public Text gemsText2;

    void Start()
    {
        if (PlayerPrefs.GetInt("AdsRemovedSave", 0) == 1)
        {
            didAdsRemoved = true;
        }
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);
        if(didAdsRemoved == false)
        {
            StartCoroutine(ShowBannerWhenInitialized());
        }
        
    }

    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.05f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(BannerId);
    }


    public void HideAds()
    {
        if (didAdsRemoved == false)
        {
            Advertisement.Banner.Hide(false);
        }

    }

    void OnDestroy()
    {
        //Debug.Log("DestroyAdController");
        Advertisement.RemoveListener(this);
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

    public void ShowRewardedVideo()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady(RewardId))
        {
            waitText.text = "";
            Advertisement.Show(RewardId);
        }
        else
        {
            waitText.text = "Please wait 1 minute!";
        }
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        //AudioListener.volume = 1f;
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            if (placementId == RewardId)
            {
                gemsPresent = PlayerPrefs.GetInt("GemsNum", 0);
                gemsNew = gemsPresent + 5;
                //Debug.Log(gemsNew);
                PlayerPrefs.SetInt("GemsNum", gemsNew );
                gemsText.text = gemsNew.ToString() + " Gems";
                gemsText2.text = gemsNew.ToString() + " Gems";
            }
        }
        else if (showResult == ShowResult.Skipped)
        {
        }
        else if (showResult == ShowResult.Failed)
        {
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
    }
    public void OnUnityAdsDidError(string message)
    {
    }
    public void OnUnityAdsDidStart(string placementId)
    {
        //AudioListener.volume = 0f;
    }


}

