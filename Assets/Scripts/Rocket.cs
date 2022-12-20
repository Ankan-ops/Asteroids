using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Rocket: MonoBehaviour
{

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Sprite rocket;
    [SerializeField] private Sprite rocketWithFlame;
    [SerializeField] private float bulletForce = 0.5f;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private float xMax;
    private float yMax;
    private float rotationSpeed = 140f;
    private Transform gunTransform;

    public int cost = 10;

   
    public List<GameObject> hp;
    public GameObject heart;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        yMax = Camera.main.orthographicSize;
        xMax = yMax * Camera.main.aspect;

        gunTransform = transform.Find("gun");

        rb.freezeRotation = true;

        HeartsOfLife();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.right);
            sr.sprite = rocketWithFlame;

        }
        else
        {
            sr.sprite = rocket;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.SetRotation(rb.rotation + rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.SetRotation(rb.rotation - rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefab, gunTransform.position, transform.rotation);
            Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();

            rbBullet.velocity = transform.right * bulletForce;

        }


        if (rb.position.x > xMax)
        {
            rb.position = new Vector2(-xMax, rb.position.y);

        }
        else if (rb.position.x < -xMax)
        {
            rb.position = new Vector2(xMax, rb.position.y);
        }
        else if (rb.position.y > yMax)
        {
            rb.position = new Vector2(rb.position.x, -yMax);

        }
        else if (rb.position.y < -yMax)
        {
            rb.position = new Vector2(rb.position.x, yMax);
        }


    }


    public void HeartsOfLife()
    {

        float x = -9.66f;
        float y = 4.43f;
        hp.Add(Instantiate(heart, new Vector3(x, y, 0), Quaternion.identity));
        hp.Add(Instantiate(heart, new Vector3(x + 1, y, 0), Quaternion.identity));
        hp.Add(Instantiate(heart, new Vector3(x + 2, y, 0), Quaternion.identity));

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.StartsWith("rock"))
        {
            
            GameObject heartToDestroy = hp[hp.Count - 1];
            hp.RemoveAt(hp.Count - 1);
            Destroy(heartToDestroy);
            
        }

        Debug.Log("Print hp count" + hp.Count);


       

        if (hp.Count <= 0)
        {
            int s = Asteroid.GetScore();
            Debug.Log(s);
            PlayerPrefs.SetInt("Balance",  Asteroid.GetScore());

            PlayerPrefs.Save();
            
            SceneManager.LoadScene(0);
        
        }





    }


}  

