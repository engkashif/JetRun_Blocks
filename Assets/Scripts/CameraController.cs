using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private Vector3 startOffset;
    private Vector3 interimVector;

    void Start()
    {
        startOffset = transform.position - player.position;
    }

    
    void Update()
    {
        interimVector = player.position + startOffset;
        interimVector.x = 0;
        interimVector.y = transform.position.y;
        transform.position = interimVector;
    }
}
