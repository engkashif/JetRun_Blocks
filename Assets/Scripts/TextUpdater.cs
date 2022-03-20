using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdater : MonoBehaviour
{
    public Text shopText;

    private int gemsNew;

    private bool alreadySelected = false;


    // Update is called once per frame
    public void PrintTextNow()
    {
        if(alreadySelected == false)
        {
            alreadySelected = true;
            StartCoroutine("PrintTextRoutine");
        }
        
    }

    private IEnumerator PrintTextRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);
            gemsNew = PlayerPrefs.GetInt("GemsNum", 0);
            shopText.text = gemsNew.ToString() + " Gems";
            //Debug.Log("Printed now");
        }
        
    }

    public void StopTextNow()
    {
        StopCoroutine("PrintTextRoutine");
    }
}
