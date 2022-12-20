using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Space : MonoBehaviour
{
    Texture2D background;
    // Start is called before the first frame update
    void Start()
    {
        float height = Camera.main.pixelWidth;
        float width = height * Camera.main.aspect;


        background = new Texture2D((int)width, (int)height);
        for (int x = 0; x < background.width; ++x)
        {
            for (int y = 0; y < background.height; ++y)
            {
                background.SetPixel(x, y, UnityEngine.Color.black);
            }
        }
        for (int i = 0; i < 5000; ++i)
        {
            int x = Random.Range(0, background.width-1);
            int y = Random.Range(0, background.height-1);
            float red = Random.Range(0.4f, 0.8f);
            float green = Random.Range(0.4f, 0.8f);
            float blue = Random.Range(0.4f, 0.8f);

            background.SetPixel(x, y, new UnityEngine.Color(red, green, blue));
            background.SetPixel(x+1, y, new UnityEngine.Color(red, green, blue));
            background.SetPixel(x, y+1, new UnityEngine.Color(red, green, blue));
            background.SetPixel(x+1, y+1, new UnityEngine.Color(red, green, blue));
        }
        background.Apply();
        Rect rect = new Rect(0, 0, background.width, background.height);
        Vector2 pivot = new Vector2(0.5f, 0.5f);
        GetComponent<SpriteRenderer>().sprite = Sprite.Create(background, rect, pivot);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
