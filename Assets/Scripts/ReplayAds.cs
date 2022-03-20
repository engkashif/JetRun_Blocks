using UnityEngine;

public class ReplayAds : MonoBehaviour
{
    public GameObject adsManager;

    private void OnEnable()
    {
        adsManager.GetComponent<AdsManager2>().ShowBannerAdNow();
        adsManager.GetComponent<AdsManager2>().ShowInterstitialAd();
    }

}
