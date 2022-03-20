using UnityEngine;

public class ShipSelector : MonoBehaviour
{
    public GameObject ship_1;
    public GameObject ship_2;
    public GameObject ship_3;
    public GameObject ship_4;
    public GameObject ship_5;
    public GameObject ship_6;
    public GameObject ship_7;
    public GameObject ship_8;



    void Start()
    {
        if(ButtonFunctions.shipNum == 0)
        {
            ship_1.SetActive(true);
            Destroy(ship_2);
            Destroy(ship_3);
            Destroy(ship_4);
            Destroy(ship_5);
            Destroy(ship_6);
            Destroy(ship_7);
            Destroy(ship_8);

        }
        else if(ButtonFunctions.shipNum == 1)
        {
            ship_2.SetActive(true);
            Destroy(ship_1);
            Destroy(ship_3);
            Destroy(ship_4);
            Destroy(ship_5);
            Destroy(ship_6);
            Destroy(ship_7);
            Destroy(ship_8);
        }
        else if(ButtonFunctions.shipNum == 2)
        {
            ship_3.SetActive(true);
            Destroy(ship_1);
            Destroy(ship_2);
            Destroy(ship_4);
            Destroy(ship_5);
            Destroy(ship_6);
            Destroy(ship_7);
            Destroy(ship_8);
        }
        else if (ButtonFunctions.shipNum == 3)
        {
            ship_4.SetActive(true);
            Destroy(ship_1);
            Destroy(ship_2);
            Destroy(ship_3);
            Destroy(ship_5);
            Destroy(ship_6);
            Destroy(ship_7);
            Destroy(ship_8);
        }
        else if (ButtonFunctions.shipNum == 4)
        {
            ship_5.SetActive(true);
            Destroy(ship_1);
            Destroy(ship_2);
            Destroy(ship_3);
            Destroy(ship_4);
            Destroy(ship_6);
            Destroy(ship_7);
            Destroy(ship_8);
        }
        else if (ButtonFunctions.shipNum == 5)
        {
            ship_6.SetActive(true);
            Destroy(ship_1);
            Destroy(ship_2);
            Destroy(ship_3);
            Destroy(ship_4);
            Destroy(ship_5);
            Destroy(ship_7);
            Destroy(ship_8);
        }
        else if (ButtonFunctions.shipNum == 6)
        {
            ship_7.SetActive(true);
            Destroy(ship_1);
            Destroy(ship_2);
            Destroy(ship_3);
            Destroy(ship_4);
            Destroy(ship_5);
            Destroy(ship_6);
            Destroy(ship_8);
        }
        else if (ButtonFunctions.shipNum == 7)
        {
            ship_8.SetActive(true);
            Destroy(ship_1);
            Destroy(ship_2);
            Destroy(ship_3);
            Destroy(ship_4);
            Destroy(ship_5);
            Destroy(ship_6);
            Destroy(ship_7);
        }


        else
        {
            ship_1.SetActive(true);
            Destroy(ship_2);
            Destroy(ship_3);
            Destroy(ship_4);
            Destroy(ship_5);
            Destroy(ship_6);
            Destroy(ship_7);
            Destroy(ship_8);
        }
    }

}
