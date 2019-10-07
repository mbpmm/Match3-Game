﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using System;

public class AdManager : MonoBehaviour
{
    private string gameIDAndroid = "3317302";

    private string videoKey = "video";

    private string videoRewardedKey = "rewardedVideo";

    private void Awake()
    {
        Advertisement.Initialize(gameIDAndroid, true);   
    }

    //La que se encarga de llamar desde la UI el video
    public void UIWatchAd()
    {
        WatchVideoAd(VideoAdEnded);
    }

    public void UIWatchRewardedAd()
    {
        WatchRewardedVideoAd(VideoAdRewardedEnded);
    }

    //La que se encarga de reproducir el ad o avisar si no esta listo
    public void WatchVideoAd(Action<ShowResult> result)
    {
        if (Advertisement.IsReady(videoKey))
        {
            ShowOptions so = new ShowOptions();
            so.resultCallback = result;
            Advertisement.Show(videoKey,so);
        }
            
        else
        {
            Debug.Log("No anda la interne'");
        }
    }

    public void WatchRewardedVideoAd(Action<ShowResult> result)
    {
        if (Advertisement.IsReady(videoRewardedKey))
        {
            ShowOptions so = new ShowOptions();
            so.resultCallback = result;
            Advertisement.Show(videoRewardedKey,so);
        }
            
        else
        {
            Debug.Log("No anda la interne'");
        }
    }

    //La que gestiona el resultado
    public void VideoAdEnded(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Failed:
                Debug.Log("El ad fallo");
                break;
            case ShowResult.Skipped:
                Debug.Log("El ad skipeo");
                break;
            case ShowResult.Finished:
                Debug.Log("El ad termino");
                break;
            default:
                break;
        }
    }

    public void VideoAdRewardedEnded(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Failed:
                Debug.Log("El ad rewarded fallo");
                break;
            case ShowResult.Skipped:
                Debug.Log("El ad rewarded skipeo");
                break;
            case ShowResult.Finished:
                Debug.Log("El ad rewarded termino");
                break;
            default:
                break;
        }
    }
}
