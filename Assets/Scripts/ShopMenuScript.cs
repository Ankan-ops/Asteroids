using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ShopMenuScript : MonoBehaviour
{
    private static TMP_Text scoreDisplay;



    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreObject = GameObject.FindGameObjectWithTag("scoreDisplay");
        scoreDisplay = scoreObject.GetComponent<TMP_Text>();
        scoreDisplay.text = "Score:" + PlayerPrefs.GetInt("Balance");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyDamage()
    {
        int score = PlayerPrefs.GetInt("Balance");
        if (score >= 40)
        {
            Bullet.Damage += 1;
            Debug.Log("Damage purchased");
            score -= 40;
            PlayerPrefs.SetInt("Balance", score);
            PlayerPrefs.Save();
            scoreDisplay.text = "Score:" + score;


        }


    }
}
