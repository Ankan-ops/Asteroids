using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Asteroid : Mover
{
    public int health = 16;
    private static int numberOfAsteroids = 1;
    private static int numberOfCreatedAsteroids = 0;

    private static int score = 0;
    private static TMP_Text scoreDisplay;

    public static int GetScore()
    {
        return score;
    }

    public static void ReSetNumberofCreatedAsteroids()
    {
        numberOfCreatedAsteroids = 0;
        numberOfAsteroids = 1;
    }
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = 16;

        if (scoreDisplay == null)
        {
            GameObject scoreObject = GameObject.FindGameObjectWithTag("scoreDisplay");
            scoreDisplay =  scoreObject.GetComponent<TMP_Text>();
        }

        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        float xSpeed = Random.Range(0f, 1f);
        float ySpeed = Random.Range(0f, 1f);
        rb.velocity = new Vector2(xSpeed, ySpeed);

        //score = PlayerPrefs.GetInt("Balance", 0);
        
        numberOfCreatedAsteroids++;
        Debug.Log("no astroids: " + numberOfCreatedAsteroids);
        if (numberOfCreatedAsteroids == 1)
        {
            score = PlayerPrefs.GetInt("Balance", 0);

        }
        scoreDisplay.text = "Score: " + PlayerPrefs.GetInt("Balance", 0);


    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("bullet"))
        {
            //Bullet bulletScriptObject = collision.gameObject.GetComponent<Bullet>();
            health -= Bullet.Damage;
            Destroy(collision.gameObject);
            Debug.Log("Rock Health:" + health);
            score += 1;
            scoreDisplay.text = "Score:" + score;
            
        }
        if (health <= 0)
        {
            if (numberOfAsteroids < 10)
            {
                Instantiate(gameObject);
                Instantiate(gameObject);

                numberOfAsteroids += 2;
            }
            numberOfAsteroids -= 1;
            Destroy(gameObject);
            PlayerPrefs.SetInt("Balance", score);
            PlayerPrefs.Save();
        }
    }



}

