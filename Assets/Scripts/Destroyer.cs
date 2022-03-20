using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Entered");
        Destroy(other.gameObject);
    }

}
