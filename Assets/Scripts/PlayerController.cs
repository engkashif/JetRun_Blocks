using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Touch theTouch;
    private Vector2 touchStartPosition, touchEndPosition;

    public KeyCode left;
    public KeyCode right;
    public KeyCode up;
    public KeyCode down;

    public float incrSpeedForward;
    public float inceSpeedSides;
    public float forwardSpeed;
    public float leftRightSpeed;
    public float upDownSpeed;
    //public float currentTime;
    private float horizontalSpeed = 0;
    private float verticalSpeed = 0;

    private bool controlLock = false;
    private int moving = 0;
    private int lane = 0;
    private int verticalMoving = 0;
    private int verticalLane = 0;

    public float leftRightLimit;
    public float upDownLimit;

    private Vector3 currentPosition;
    //private Vector3 newPosition;

    private Vector3 lastPosition;

    private Rigidbody rb;

    private float currentTime;

    public AudioSource swipe_source;
    public AudioClip swipe_clip;

    private float lastZ;
    private int lastZint;
    private int newZint;

    private int gemsPresent;
    private int gemsNew;

    public GameObject scoreCounter;

    public Text gemsText;

    //public GameObject revivePanel;

    void Start()
    {
        currentTime = Time.time + 1.0f;
        currentPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        //rb.velocity = (new Vector3(horizontalSpeed, verticalSpeed, forwardSpeed)) * Time.deltaTime;
    }

    public void revive_func()
    {
        if(PlayerPrefs.GetInt("GemsNum", 0) >= 5)
        {
            gemsText.text = "";
            gemsPresent = PlayerPrefs.GetInt("GemsNum", 0);
            gemsNew = gemsPresent - 5;
            PlayerPrefs.SetInt("GemsNum", gemsNew);
            lastPosition = transform.position;
            lastZ = ((lastPosition.z) - 100) / 60;
            lastZint = (int)lastZ;
            newZint = (lastZint * 60) + 60;
            transform.position = new Vector3(transform.position.x, transform.position.y, newZint);
            gameObject.GetComponent<DestroyPlayer>().Mult_reset();
            forwardSpeed = 1500;
            leftRightSpeed = 3000;
            upDownSpeed = 3000;
            scoreCounter.GetComponent<ScoreCounter>().ReviveGame();
            gameObject.SetActive(true);
        }
        else
        {
            gemsText.text = "Not enough gems";
        }

        
        //revivePanel.SetActive(false);
    }

    public void Increase()
    {
        forwardSpeed = forwardSpeed + incrSpeedForward;
        leftRightSpeed = leftRightSpeed + inceSpeedSides;
        upDownSpeed = upDownSpeed + inceSpeedSides;
    }

    public void Decrease()
    {
        if(forwardSpeed>=500)
        {
            forwardSpeed = forwardSpeed - incrSpeedForward;
            leftRightSpeed = leftRightSpeed - inceSpeedSides;
            upDownSpeed = upDownSpeed - inceSpeedSides;
        }

    }



    void FixedUpdate()
    {
        rb.velocity = (new Vector3(horizontalSpeed, verticalSpeed, forwardSpeed)) * Time.deltaTime;
    }


    void Update()
    {
        if(Time.time <= currentTime)
        {
            return;
        }

        if (controlLock == true)
        {

            if (moving != 0)
            {
                if (moving == -1 && lane == 0)
                {

                    if (transform.position.x <= -leftRightLimit)
                    {
                        horizontalSpeed = 0;
                        //rb.velocity = (new Vector3(horizontalSpeed, verticalSpeed, forwardSpeed)) * Time.deltaTime;
                        transform.position = new Vector3(-leftRightLimit, transform.position.y, transform.position.z);
                        controlLock = false;
                        moving = 0;
                        lane -= 1;
                        
                    }
                }

                else if (moving == -1 && lane == 1)
                {
                    if (transform.position.x <= 0)
                    {
                        horizontalSpeed = 0;
                        //rb.velocity = (new Vector3(horizontalSpeed, verticalSpeed, forwardSpeed)) * Time.deltaTime;
                        transform.position = new Vector3(0, transform.position.y, transform.position.z);
                        controlLock = false;
                        moving = 0;
                        lane -= 1;
                        
                    }
                }


                else if (moving == 1 && lane == 0)
                {
                    if (transform.position.x >= leftRightLimit)
                    {
                        horizontalSpeed = 0;
                        //rb.velocity = (new Vector3(horizontalSpeed, verticalSpeed, forwardSpeed)) * Time.deltaTime;
                        transform.position = new Vector3(leftRightLimit, transform.position.y, transform.position.z);
                        controlLock = false;
                        moving = 0;
                        lane += 1;
                        
                    }
                }

                else if (moving == 1 && lane == -1)
                {
                    if (transform.position.x >= 0)
                    {
                        horizontalSpeed = 0;
                        //rb.velocity = (new Vector3(horizontalSpeed, verticalSpeed, forwardSpeed)) * Time.deltaTime;
                        transform.position = new Vector3(0, transform.position.y, transform.position.z);
                        controlLock = false;
                        moving = 0;
                        lane += 1;
                        
                    }
                }
            }

            else if (verticalMoving != 0)
            {
                if (verticalMoving == +1 && verticalLane == 0)
                {

                    if (transform.position.y >= (currentPosition.y+upDownLimit))
                    {
                        verticalSpeed = 0;
                        //rb.velocity = (new Vector3(horizontalSpeed, verticalSpeed, forwardSpeed)) * Time.deltaTime;
                        transform.position = new Vector3(transform.position.x, (currentPosition.y + upDownLimit), transform.position.z);
                        controlLock = false;
                        verticalMoving = 0;
                        verticalLane += 1;
                    }
                }

                else if (verticalMoving == +1 && verticalLane == -1)
                {

                    if (transform.position.y >= currentPosition.y)
                    {
                        verticalSpeed = 0;
                        //rb.velocity = (new Vector3(horizontalSpeed, verticalSpeed, forwardSpeed)) * Time.deltaTime;
                        transform.position = new Vector3(transform.position.x, currentPosition.y, transform.position.z);
                        controlLock = false;
                        verticalMoving = 0;
                        verticalLane += 1;
                    }
                }

                else if (verticalMoving == -1 && verticalLane == 0)
                {
                    if (transform.position.y <= (currentPosition.y-upDownLimit))
                    {
                        verticalSpeed = 0;
                        //rb.velocity = (new Vector3(horizontalSpeed, verticalSpeed, forwardSpeed)) * Time.deltaTime;
                        transform.position = new Vector3(transform.position.x, (currentPosition.y - upDownLimit), transform.position.z);
                        controlLock = false;
                        verticalMoving = 0;
                        verticalLane -= 1;
                    }
                }

                else if (verticalMoving == -1 && verticalLane == 1)
                {
                    if (transform.position.y <= currentPosition.y)
                    {
                        verticalSpeed = 0;
                        //rb.velocity = (new Vector3(horizontalSpeed, verticalSpeed, forwardSpeed)) * Time.deltaTime;
                        transform.position = new Vector3(transform.position.x, currentPosition.y, transform.position.z);
                        controlLock = false;
                        verticalMoving = 0;
                        verticalLane -= 1;
                    }
                }

                

            }

        }

        else if (controlLock == false)
            {

            if (Input.touchCount > 0)
            {
                theTouch = Input.GetTouch(0);

                if (theTouch.phase == TouchPhase.Began)
                {
                    touchStartPosition = theTouch.position;
                }

                else if (theTouch.phase == TouchPhase.Moved || theTouch.phase == TouchPhase.Ended)
                {
                    touchEndPosition = theTouch.position;

                    float x = touchEndPosition.x - touchStartPosition.x;
                    float y = touchEndPosition.y - touchStartPosition.y;

                    /*if (Mathf.Abs(x) == 0 && Mathf.Abs(y) == 0)
                    {

                    }*/

                    if (Mathf.Abs(x) > ((Mathf.Abs(y)) + 15 ))
                    {
                        if(x>30 && lane <= 0)
                        {
                            swipe_source.PlayOneShot(swipe_clip);
                            horizontalSpeed = leftRightSpeed;
                            //rb.velocity = (new Vector3(horizontalSpeed, verticalSpeed, forwardSpeed)) * Time.deltaTime;
                            moving = 1;
                            controlLock = true;
                        }
                        else if(x<-30 && lane >= 0)
                        {
                            swipe_source.PlayOneShot(swipe_clip);
                            horizontalSpeed = -leftRightSpeed;
                            //rb.velocity = (new Vector3(horizontalSpeed, verticalSpeed, forwardSpeed)) * Time.deltaTime;
                            moving = -1;
                            controlLock = true;
                        }
                        //direction = x > 0 ? “Right” : “Left”;
                    }

                    else if (Mathf.Abs(x) < ((Mathf.Abs(y)) - 15  ))
                    {
                        if (y>30 && verticalLane <= 0)
                        {
                            swipe_source.PlayOneShot(swipe_clip);
                            verticalSpeed = upDownSpeed;
                            //rb.velocity = (new Vector3(horizontalSpeed, verticalSpeed, forwardSpeed)) * Time.deltaTime;
                            verticalMoving = 1;
                            controlLock = true;
                        }
                        else if (y<-30 && verticalLane >= 0)
                        {
                            swipe_source.PlayOneShot(swipe_clip);
                            verticalSpeed = -upDownSpeed;
                            //rb.velocity = (new Vector3(horizontalSpeed, verticalSpeed, forwardSpeed)) * Time.deltaTime;
                            verticalMoving = -1;
                            controlLock = true;
                        }
                        //direction = y > 0 ? “Up” : “Down”;
                    }
                }
            }

            //start commenting from here
            /*
            if (Input.GetKeyDown(left) && lane>=0)
                {
                    swipe_source.PlayOneShot(swipe_clip);
                    horizontalSpeed = -leftRightSpeed;
                    //rb.velocity = (new Vector3(horizontalSpeed, verticalSpeed, forwardSpeed)) * Time.deltaTime;
                    moving = -1;
                    controlLock = true;
                    
                }
                else if (Input.GetKeyDown(right) && lane <= 0)
                {
                    swipe_source.PlayOneShot(swipe_clip);
                    horizontalSpeed = leftRightSpeed;
                    //rb.velocity = (new Vector3(horizontalSpeed, verticalSpeed, forwardSpeed)) * Time.deltaTime;
                    moving = 1;
                    controlLock = true;
                    

                }

                if (Input.GetKeyDown(up) && verticalLane <= 0)
                {
                    swipe_source.PlayOneShot(swipe_clip);
                    verticalSpeed = upDownSpeed;
                    //rb.velocity = (new Vector3(horizontalSpeed, verticalSpeed, forwardSpeed)) * Time.deltaTime;
                    verticalMoving = 1;
                    controlLock = true;
                }
                else if (Input.GetKeyDown(down) && verticalLane >= 0)
                 {
                    swipe_source.PlayOneShot(swipe_clip);
                    verticalSpeed = -upDownSpeed;
                    //rb.velocity = (new Vector3(horizontalSpeed, verticalSpeed, forwardSpeed)) * Time.deltaTime;
                    verticalMoving = -1;
                    controlLock = true;
                 }*/
                 //end commenting here


            }



    }
}
