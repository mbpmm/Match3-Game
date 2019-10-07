using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public int score;
    public int cantClicks;
    public Text text1;
    public Text text2;
    public GameObject admanager;
    private AdManager adMan;
    public GameObject analyticsmanager;
    private AnalyticsManager analMan;
    public GameObject panel;
    private bool cosa=false;
    // Start is called before the first frame update
    void Start()
    {
        cantClicks = 8;
        adMan = admanager.GetComponent<AdManager>();
        analMan = analyticsmanager.GetComponent<AnalyticsManager>();
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        text1.text="Score:" + score;
        text2.text = "Cant clicks:" + cantClicks;
        if (Input.GetMouseButtonDown(0)&&cantClicks>0)
        {
            score++;
            cantClicks--;
            adMan.UIWatchAd();

        }

        if (cantClicks==0)
        {
            analMan.PuntajeTotal(score);
            panel.SetActive(true);
            
        }


    }

    public void AddClicks()
    {
        cantClicks = 10;
        panel.SetActive(false);
    }
}
