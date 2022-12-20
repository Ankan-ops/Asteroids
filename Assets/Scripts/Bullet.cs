using System.Collections;

using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bullet : Mover
{

    private static int damage = 4;
   

    public static int Damage
    {
        get 
        { 
            return damage; 
        
        }
        set
        { if (value > 0)
            {
                damage = value;
            }
            

        }
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

}
