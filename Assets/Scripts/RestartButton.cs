using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }


    public void StartGame()
    {
        Asteroid.ReSetNumberofCreatedAsteroids();
        SceneManager.LoadScene(1);

    }

    public void ShopButton()
    {
        SceneManager.LoadScene(2);
    }





    public void DamageButton()
    {
        
    }


}
