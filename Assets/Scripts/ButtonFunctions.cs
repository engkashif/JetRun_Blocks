using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;


public class ButtonFunctions : MonoBehaviour
{
    public static int shipNum;

    public Text waitText2;

    public Text highScore;
    public int highestScore;
    public int gemsNum;
    public Text gemsNumText;
    public Text gemsNumText2;

    public GameObject shipsPage;
    public GameObject mainPage;
    public GameObject shopPage;

    public Button ship_1;
    public Button ship_2;
    public Button ship_3;
    public Button ship_4;
    public Button ship_5;
    public Button ship_6;
    public Button ship_7;
    public Button ship_8;


    public Sprite ship_back_green;
    public Sprite ship_back_red;


    public AudioSource button_source;
    public AudioClip button_clip;

    public GameObject loadingScreen;
    private float progress;
    public Slider progressSlider;

    public Canvas mainCanvas;

    //public int locked_2;

    public GameObject shipLocker_2;
    public GameObject shipLocker_3;
    public GameObject shipLocker_4;
    public GameObject shipLocker_5;
    public GameObject shipLocker_6;
    public GameObject shipLocker_7;
    public GameObject shipLocker_8;

    public Text lowGemsText2;
    public Text lowGemsText3;
    public Text lowGemsText4;
    public Text lowGemsText5;
    public Text lowGemsText6;
    public Text lowGemsText7;
    public Text lowGemsText8;

    private int gemsPresent;
    private int gemsNew;

    void Start()
    {
        highestScore = PlayerPrefs.GetInt("HighScore", 0);
        highScore.text = "High Score : " + highestScore;

        gemsNum = PlayerPrefs.GetInt("GemsNum", 0);
        gemsNumText.text = gemsNum.ToString() + " Gems";
        gemsNumText2.text = gemsNum.ToString() + " Gems";

        shipNum = PlayerPrefs.GetInt("ShipNum", 0);

        //locked = PlayerPrefs.GetInt("lockedNum", 101111111);

        if(PlayerPrefs.GetInt("locked2", 1) == 1)
        {
            shipLocker_2.SetActive(true);
        }
        if (PlayerPrefs.GetInt("locked3", 1) == 1)
        {
            shipLocker_3.SetActive(true);
        }
        if (PlayerPrefs.GetInt("locked4", 1) == 1)
        {
            shipLocker_4.SetActive(true);
        }
        if (PlayerPrefs.GetInt("locked5", 1) == 1)
        {
            shipLocker_5.SetActive(true);
        }
        if (PlayerPrefs.GetInt("locked6", 1) == 1)
        {
            shipLocker_6.SetActive(true);
        }
        if (PlayerPrefs.GetInt("locked7", 1) == 1)
        {
            shipLocker_7.SetActive(true);
        }
        if (PlayerPrefs.GetInt("locked8", 1) == 1)
        {
            shipLocker_8.SetActive(true);
        }


        if (shipNum == 0)
        {
            ship_1.image.sprite = ship_back_green;
            ship_2.image.sprite = ship_back_red;
            ship_3.image.sprite = ship_back_red;
            ship_4.image.sprite = ship_back_red;
            ship_5.image.sprite = ship_back_red;
            ship_6.image.sprite = ship_back_red;
            ship_7.image.sprite = ship_back_red;
            ship_8.image.sprite = ship_back_red;
        }

        else if (shipNum == 1)
        {
            ship_1.image.sprite = ship_back_red;
            ship_2.image.sprite = ship_back_green;
            ship_3.image.sprite = ship_back_red;
            ship_4.image.sprite = ship_back_red;
            ship_5.image.sprite = ship_back_red;
            ship_6.image.sprite = ship_back_red;
            ship_7.image.sprite = ship_back_red;
            ship_8.image.sprite = ship_back_red;
        }
        else if(shipNum == 2)
        {
            ship_1.image.sprite = ship_back_red;
            ship_2.image.sprite = ship_back_red;
            ship_3.image.sprite = ship_back_green;
            ship_4.image.sprite = ship_back_red;
            ship_5.image.sprite = ship_back_red;
            ship_6.image.sprite = ship_back_red;
            ship_7.image.sprite = ship_back_red;
            ship_8.image.sprite = ship_back_red;
        }

        else if (shipNum == 3)
        {
            ship_1.image.sprite = ship_back_red;
            ship_2.image.sprite = ship_back_red;
            ship_3.image.sprite = ship_back_red;
            ship_4.image.sprite = ship_back_green;
            ship_5.image.sprite = ship_back_red;
            ship_6.image.sprite = ship_back_red;
            ship_7.image.sprite = ship_back_red;
            ship_8.image.sprite = ship_back_red;
        }

        else if (shipNum == 4)
        {
            ship_1.image.sprite = ship_back_red;
            ship_2.image.sprite = ship_back_red;
            ship_3.image.sprite = ship_back_red;
            ship_4.image.sprite = ship_back_red;
            ship_5.image.sprite = ship_back_green;
            ship_6.image.sprite = ship_back_red;
            ship_7.image.sprite = ship_back_red;
            ship_8.image.sprite = ship_back_red;
        }

        else if (shipNum == 5)
        {
            ship_1.image.sprite = ship_back_red;
            ship_2.image.sprite = ship_back_red;
            ship_3.image.sprite = ship_back_red;
            ship_4.image.sprite = ship_back_red;
            ship_5.image.sprite = ship_back_red;
            ship_6.image.sprite = ship_back_green;
            ship_7.image.sprite = ship_back_red;
            ship_8.image.sprite = ship_back_red;
        }

        else if (shipNum == 6)
        {
            ship_1.image.sprite = ship_back_red;
            ship_2.image.sprite = ship_back_red;
            ship_3.image.sprite = ship_back_red;
            ship_4.image.sprite = ship_back_red;
            ship_5.image.sprite = ship_back_red;
            ship_6.image.sprite = ship_back_red;
            ship_7.image.sprite = ship_back_green;
            ship_8.image.sprite = ship_back_red;
        }

        else if (shipNum == 7)
        {
            ship_1.image.sprite = ship_back_red;
            ship_2.image.sprite = ship_back_red;
            ship_3.image.sprite = ship_back_red;
            ship_4.image.sprite = ship_back_red;
            ship_5.image.sprite = ship_back_red;
            ship_6.image.sprite = ship_back_red;
            ship_7.image.sprite = ship_back_red;
            ship_8.image.sprite = ship_back_green;
        }

    }



    public void PlayGame()
    {
        button_source.PlayOneShot(button_clip);
        //SceneManager.LoadScene("Game");
        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Game");
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            progress = Mathf.Clamp01(operation.progress / 0.9f);
            progressSlider.value = progress;

            yield return null;
        }


    }

    public void ChangeShip()
    {
        button_source.PlayOneShot(button_clip);
        shipsPage.SetActive(true);
        lowGemsText2.text = "";
        lowGemsText3.text = "";
        lowGemsText4.text = "";
        lowGemsText5.text = "";
        lowGemsText6.text = "";
        lowGemsText7.text = "";
        lowGemsText8.text = "";
        //mainPage.SetActive(false);
        //SceneManager.LoadScene("Ships");
    }


    public void Quit_func()
    {
        Application.Quit();
    }

    public void GoBack()
    {
        button_source.PlayOneShot(button_clip);
        //mainPage.SetActive(true);
        shipsPage.SetActive(false);
    }

    public void Ship_1_func()
    {
        button_source.PlayOneShot(button_clip);
        ship_1.image.sprite = ship_back_green;
        ship_2.image.sprite = ship_back_red;
        ship_3.image.sprite = ship_back_red;
        ship_4.image.sprite = ship_back_red;
        ship_5.image.sprite = ship_back_red;
        ship_6.image.sprite = ship_back_red;
        ship_7.image.sprite = ship_back_red;
        ship_8.image.sprite = ship_back_red;
        shipNum = 0;
        PlayerPrefs.SetInt("ShipNum", shipNum);
        //Debug.Log(shipNum);
    }

    public void Ship_2_func()
    {
        button_source.PlayOneShot(button_clip);
        ship_1.image.sprite = ship_back_red;
        ship_2.image.sprite = ship_back_green;
        ship_3.image.sprite = ship_back_red;
        ship_4.image.sprite = ship_back_red;
        ship_5.image.sprite = ship_back_red;
        ship_6.image.sprite = ship_back_red;
        ship_7.image.sprite = ship_back_red;
        ship_8.image.sprite = ship_back_red;
        shipNum = 1;
        PlayerPrefs.SetInt("ShipNum", shipNum);
        //Debug.Log(shipNum);
    }

    public void Ship_3_func()
    {
        button_source.PlayOneShot(button_clip);
        ship_1.image.sprite = ship_back_red;
        ship_2.image.sprite = ship_back_red;
        ship_3.image.sprite = ship_back_green;
        ship_4.image.sprite = ship_back_red;
        ship_5.image.sprite = ship_back_red;
        ship_6.image.sprite = ship_back_red;
        ship_7.image.sprite = ship_back_red;
        ship_8.image.sprite = ship_back_red;
        shipNum = 2;
        PlayerPrefs.SetInt("ShipNum", shipNum);
        //Debug.Log(shipNum);
    }

    public void Ship_4_func()
    {
        button_source.PlayOneShot(button_clip);
        ship_1.image.sprite = ship_back_red;
        ship_2.image.sprite = ship_back_red;
        ship_3.image.sprite = ship_back_red;
        ship_4.image.sprite = ship_back_green;
        ship_5.image.sprite = ship_back_red;
        ship_6.image.sprite = ship_back_red;
        ship_7.image.sprite = ship_back_red;
        ship_8.image.sprite = ship_back_red;
        shipNum = 3;
        PlayerPrefs.SetInt("ShipNum", shipNum);
        //Debug.Log(shipNum);
    }

    public void Ship_5_func()
    {
        button_source.PlayOneShot(button_clip);
        ship_1.image.sprite = ship_back_red;
        ship_2.image.sprite = ship_back_red;
        ship_3.image.sprite = ship_back_red;
        ship_4.image.sprite = ship_back_red;
        ship_5.image.sprite = ship_back_green;
        ship_6.image.sprite = ship_back_red;
        ship_7.image.sprite = ship_back_red;
        ship_8.image.sprite = ship_back_red;
        shipNum = 4;
        PlayerPrefs.SetInt("ShipNum", shipNum);
        //Debug.Log(shipNum);
    }

    public void Ship_6_func()
    {
        button_source.PlayOneShot(button_clip);
        ship_1.image.sprite = ship_back_red;
        ship_2.image.sprite = ship_back_red;
        ship_3.image.sprite = ship_back_red;
        ship_4.image.sprite = ship_back_red;
        ship_5.image.sprite = ship_back_red;
        ship_6.image.sprite = ship_back_green;
        ship_7.image.sprite = ship_back_red;
        ship_8.image.sprite = ship_back_red;
        shipNum = 5;
        PlayerPrefs.SetInt("ShipNum", shipNum);
        //Debug.Log(shipNum);
    }

    public void Ship_7_func()
    {
        button_source.PlayOneShot(button_clip);
        ship_1.image.sprite = ship_back_red;
        ship_2.image.sprite = ship_back_red;
        ship_3.image.sprite = ship_back_red;
        ship_4.image.sprite = ship_back_red;
        ship_5.image.sprite = ship_back_red;
        ship_6.image.sprite = ship_back_red;
        ship_7.image.sprite = ship_back_green;
        ship_8.image.sprite = ship_back_red;
        shipNum = 6;
        PlayerPrefs.SetInt("ShipNum", shipNum);
        //Debug.Log(shipNum);
    }

    public void Ship_8_func()
    {
        button_source.PlayOneShot(button_clip);
        ship_1.image.sprite = ship_back_red;
        ship_2.image.sprite = ship_back_red;
        ship_3.image.sprite = ship_back_red;
        ship_4.image.sprite = ship_back_red;
        ship_5.image.sprite = ship_back_red;
        ship_6.image.sprite = ship_back_red;
        ship_7.image.sprite = ship_back_red;
        ship_8.image.sprite = ship_back_green;
        shipNum = 7;
        PlayerPrefs.SetInt("ShipNum", shipNum);
        //Debug.Log(shipNum);
    }

    public void shop_func()
    {
        button_source.PlayOneShot(button_clip);
        shopPage.SetActive(true);
    }

    public void shop_back()
    {
        button_source.PlayOneShot(button_clip);
        shopPage.SetActive(false);
    }

    public void playOnlySound()
    {
        button_source.PlayOneShot(button_clip);
    }

    public void BuyShip2()
    {
        button_source.PlayOneShot(button_clip);
        if(PlayerPrefs.GetInt("GemsNum", 0) >= 50)
        {
            gemsPresent = PlayerPrefs.GetInt("GemsNum", 0);
            gemsNew = gemsPresent - 50;
            PlayerPrefs.SetInt("GemsNum", gemsNew);
            gemsNumText.text = gemsNew.ToString() + " Gems";
            gemsNumText2.text = gemsNew.ToString() + " Gems";
            PlayerPrefs.SetInt("locked2", 0);
            shipLocker_2.SetActive(false);
        }
        else
        {
            lowGemsText2.text = "Not enough gems!";
        }
    }

    public void BuyShip3()
    {
        button_source.PlayOneShot(button_clip);
        if (PlayerPrefs.GetInt("GemsNum", 0) >= 100)
        {
            gemsPresent = PlayerPrefs.GetInt("GemsNum", 0);
            gemsNew = gemsPresent - 100;
            PlayerPrefs.SetInt("GemsNum", gemsNew);
            gemsNumText.text = gemsNew.ToString() + " Gems";
            gemsNumText2.text = gemsNew.ToString() + " Gems";
            PlayerPrefs.SetInt("locked3", 0);
            shipLocker_3.SetActive(false);
        }
        else
        {
            lowGemsText3.text = "Not enough gems!";
        }
    }

    public void BuyShip4()
    {
        button_source.PlayOneShot(button_clip);
        if (PlayerPrefs.GetInt("GemsNum", 0) >= 200)
        {
            gemsPresent = PlayerPrefs.GetInt("GemsNum", 0);
            gemsNew = gemsPresent - 200;
            PlayerPrefs.SetInt("GemsNum", gemsNew);
            gemsNumText.text = gemsNew.ToString() + " Gems";
            gemsNumText2.text = gemsNew.ToString() + " Gems";
            PlayerPrefs.SetInt("locked4", 0);
            shipLocker_4.SetActive(false);
        }
        else
        {
            lowGemsText4.text = "Not enough gems!";
        }
    }
    public void BuyShip5()
    {
        button_source.PlayOneShot(button_clip);
        if (PlayerPrefs.GetInt("GemsNum", 0) >= 500)
        {
            gemsPresent = PlayerPrefs.GetInt("GemsNum", 0);
            gemsNew = gemsPresent - 500;
            PlayerPrefs.SetInt("GemsNum", gemsNew);
            gemsNumText.text = gemsNew.ToString() + " Gems";
            gemsNumText2.text = gemsNew.ToString() + " Gems";
            PlayerPrefs.SetInt("locked5", 0);
            shipLocker_5.SetActive(false);
        }
        else
        {
            lowGemsText5.text = "Not enough gems!";
        }
    }

    public void BuyShip6()
    {
        button_source.PlayOneShot(button_clip);
        if (PlayerPrefs.GetInt("GemsNum", 0) >= 1000)
        {
            gemsPresent = PlayerPrefs.GetInt("GemsNum", 0);
            gemsNew = gemsPresent - 1000;
            PlayerPrefs.SetInt("GemsNum", gemsNew);
            gemsNumText.text = gemsNew.ToString() + " Gems";
            gemsNumText2.text = gemsNew.ToString() + " Gems";
            PlayerPrefs.SetInt("locked6", 0);
            shipLocker_6.SetActive(false);
        }
        else
        {
            lowGemsText6.text = "Not enough gems!";
        }
    }

    public void BuyShip7()
    {
        button_source.PlayOneShot(button_clip);
        if (PlayerPrefs.GetInt("GemsNum", 0) >= 1500)
        {
            gemsPresent = PlayerPrefs.GetInt("GemsNum", 0);
            gemsNew = gemsPresent - 1500;
            PlayerPrefs.SetInt("GemsNum", gemsNew);
            gemsNumText.text = gemsNew.ToString() + " Gems";
            gemsNumText2.text = gemsNew.ToString() + " Gems";
            PlayerPrefs.SetInt("locked7", 0);
            shipLocker_7.SetActive(false);
        }
        else
        {
            lowGemsText7.text = "Not enough gems!";
        }
    }

    public void BuyShip8()
    {
        button_source.PlayOneShot(button_clip);
        if (PlayerPrefs.GetInt("GemsNum", 0) >= 2000)
        {
            gemsPresent = PlayerPrefs.GetInt("GemsNum", 0);
            gemsNew = gemsPresent - 2000;
            PlayerPrefs.SetInt("GemsNum", gemsNew);
            gemsNumText.text = gemsNew.ToString() + " Gems";
            gemsNumText2.text = gemsNew.ToString() + " Gems";
            PlayerPrefs.SetInt("locked8", 0);
            shipLocker_8.SetActive(false);
        }
        else
        {
            lowGemsText8.text = "Not enough gems!";
        }
    }

    public void WaitReset()
    {
        waitText2.text = "";
    }



}
