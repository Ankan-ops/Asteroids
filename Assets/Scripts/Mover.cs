using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected float xMax;
    protected float yMax;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        yMax = Camera.main.orthographicSize;
        xMax = yMax * Camera.main.aspect;
    }

    // Update is called once per frame
    protected virtual void Update()
    {


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
}
