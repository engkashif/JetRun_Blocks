using UnityEngine;
using UnityEngine.UI;

public class TextOnEnabled : MonoBehaviour
{
    public Text shipsText;
    private int gemsNew;


    private void OnEnable()
    {
        gemsNew = PlayerPrefs.GetInt("GemsNum", 0);
        shipsText.text = gemsNew.ToString() + " Gems";
    }


}
