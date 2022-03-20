using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] blocks;
    public Transform player;
    public GameObject coin;
    public GameObject boost;
    public GameObject slower;

    public float xySpawn;
    public float[] xSpawn;
    public float[] ySpawn;
    public float zSpawn;
    public float spawnDist;
    private float relativePos;
    public float coinOffset;

    //private List<GameObject> activeBlocks;

    //private Vector3[] spawnVector = new Vector3[9];
    //private Vector3 spawnVector;




    private bool[] xyPosition = new bool[9];
    private int[] randomValue = new int[9];
    private int[] randomValue2 = new int[9];
    private int iterationPosition;
    private int freeWay;
    private bool freeWayIndicate = false;


    void Start()
    {
        //zSpawn = 100;
        relativePos = spawnDist;
        BlockSpawn();
    }

    
    void Update()
    {
        //activeBlocks = new List<GameObject>();
        if (player.position.z >= relativePos)
        {
            zSpawn += spawnDist;
            BlockSpawn();
            relativePos += spawnDist;
        }
    }


    void BlockSpawn()
    {
        for (iterationPosition = 0; iterationPosition <= 8; iterationPosition++)
        {

            randomValue[iterationPosition] = Random.Range(0, 10);
            randomValue2[iterationPosition] = Random.Range(0, 100);

            if (randomValue[iterationPosition] >= 0 && randomValue[iterationPosition] <= 3)
            {
                Instantiate(coin, new Vector3(xSpawn[iterationPosition], ySpawn[iterationPosition], (zSpawn+coinOffset)), transform.rotation);
            }
            else if (randomValue2[iterationPosition] >= 4 && randomValue2[iterationPosition] <= 15)
            {
                Instantiate(boost, new Vector3(xSpawn[iterationPosition], (ySpawn[iterationPosition]-0.4f), (zSpawn + coinOffset)), transform.rotation);
            }
            else if (randomValue2[iterationPosition] >= 50 && randomValue2[iterationPosition] <= 54)
            {
                Instantiate(slower, new Vector3(xSpawn[iterationPosition], (ySpawn[iterationPosition] - 0.4f), (zSpawn + coinOffset)), transform.rotation);
            }


            if (iterationPosition == 8)
            {
                for (freeWay = 0; freeWay <= 8; freeWay++)
                {
                    if (randomValue[freeWay] == 2 || randomValue[freeWay] == 3 || randomValue[freeWay] == 7)
                    {
                        freeWayIndicate = true;
                        break;
                    }
                    else
                    {
                        freeWayIndicate = false;
                    }
                }
                if (freeWayIndicate == false)
                {
                    randomValue[iterationPosition] = 2;
                }
            }


            if (randomValue[iterationPosition] <= 1)
            {
                Instantiate(blocks[0], new Vector3(xSpawn[iterationPosition], ySpawn[iterationPosition], zSpawn), transform.rotation);

            }
            else if (randomValue[iterationPosition] >= 8)
            {
                Instantiate(blocks[1], new Vector3(xSpawn[iterationPosition], ySpawn[iterationPosition], zSpawn), transform.rotation);
            }
            else if (randomValue[iterationPosition] >= 4 && randomValue[iterationPosition] <= 6)
            {
                Instantiate(blocks[2], new Vector3(xSpawn[iterationPosition], ySpawn[iterationPosition], zSpawn), transform.rotation);
            }


        }
    }


}
