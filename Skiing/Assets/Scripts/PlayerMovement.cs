using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public static bool shouldStop = false;
    public Rigidbody player;
    public GameObject camerarig;
    private OVRCameraRig OVRCameraRig;
  
    public float movementSpeed = 2;
    public float rotationSpeed = 5;
    public float rotationDegrees = 90;
    public float speedIncrease = 5;
    public float transformIncrease = 1;
    public float touch = -0.2f;
    private float headRotation;

    private bool startZone, goodControllerPos;

    private Vector3 currentHeadPose;

    private Vector2 touchPosition;
    private Transform eyeAnchor;


    // Use this for initialization
    void Start()
    {
        // player = GetComponent<Rigidbody>();
        // StartCoroutine(setTouchPosition());
        // StartCoroutine(SpeedIncrease());
        camerarig = GetComponent<GameObject>();
        // OVRCameraRig = camerarig.GetComponent<OVRCameraRig>();
        OVRCameraRig = FindObjectOfType<OVRCameraRig>();
        eyeAnchor = OVRCameraRig.centerEyeAnchor;
        StartCoroutine(SpeedIncrease());

    }



    void FixedUpdate()
    {
        //     Debug.Log(speedIncrease);

        // if (Input.GetKey(KeyCode.W))
        // {
        //    player.position += transform.forward * speedIncrease * Time.deltaTime;
        //     debugText.text = speedIncrease.ToString();


        // }

        //else 
        if (!startZone)
        {
            RollViaController();

        }

        else if (startZone)
        {
            StartZoneControls();
        }
        // else if(OVRInput.Get(OVRInput.Touch.PrimaryTouchpad))
        // {
        //     touchPosition = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
        //     if(touchPosition.x < 0){
        //         debugText.text = touchPosition.ToString();
        //     player.position += (transform.right *-1)*Time.deltaTime;
        //     }
        // }


        // //tjekker efter knap tryk     
        // else 
        // if (OVRInput.Get(OVRInput.Button.PrimaryTouchpad))
        //    {
        //        debugText.text = "Reached it";
        //        player.position += transform.forward * 10 * Time.deltaTime;
        //     // button is depressed, handle the touch.
        //     //Vector2 touchPosition = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
        //     //ProcessControllerClickAtPosition(touchPosition);
        // }
        // else if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        // {
        //     debugText.text = "triggered";
        //     player.position += goLeft;

        // }        
        // else 
        // if (Input.GetKey(KeyCode.A))
        // {
        //    player.position += transform.forward * Time.deltaTime;
        //    debugText.text = "a is reached";

        // }
        // else if (Input.GetKey(KeyCode.D))
        // {
        //     player.position += transform.right * Time.deltaTime;
        // }

    }



    private void OnCollisionEnter(Collision other)
    {

        if (other.collider.CompareTag("GroundStart"))
        {
            startZone = true;
            // player.AddTorque(positiv if the map is reversed but could be used as a break when dragging)
        }
        else
        {
            startZone = false;
        }
    }

    //For every second spent on anything but the starting ground will increase speed x2
    private IEnumerator SpeedIncrease()
    {
        while (true)
        {
            if (!startZone)
            {
                yield return new WaitForSeconds(1);
                speedIncrease = speedIncrease * 1.5f;


            }

            yield return null;

        }



    }

    private IEnumerator TranformRateIncrease()
    {
        while (true)
        {
            if (!startZone)
            {
                yield return new WaitForSeconds(1);
                transformIncrease = transformIncrease * 15f;

            }
        }
    }

    //doesn't seem needed anymore
    private IEnumerator setTouchPosition()
    {
        while (true)
        {
            touchPosition = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
            yield return null;
        }
    }

    private void StartZoneControls()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            player.position += transform.forward * 10 * Time.deltaTime;
        }
        else if (OVRInput.Get(OVRInput.Button.PrimaryTouchpad))
        {
            touch = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad).x;

            if (touch < 0)
            {
                //Go left
                player.position += (transform.right * -1) * 3 * Time.deltaTime;

            }
            else if (touch > 0)
            {
                //go right
                player.position += (transform.right) * 3 * Time.deltaTime;

            }


        }
        //make the dragging stuff
        // else if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)){

        //     player.position += transform.forward * speedIncrease * Time.deltaTime;
        // }
        return;

    }

    //do the left and right turn when pressing the touchpad, 
    private void RollViaController()
    {

        if (!shouldStop)
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
            {
                if (true)
                {
                    player.position += transform.forward * 10 * Time.deltaTime;
                }
            }
            else if (OVRInput.Get(OVRInput.Button.PrimaryTouchpad))
            {
                touch = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad).x;
                if (touch < 0)
                {
                    //go left and forward when not in the startzone
                    player.position +=
                        ((transform.right * transformIncrease * -1) + (transform.forward * speedIncrease)) *
                        Time.deltaTime;
                }
                else if (touch > 0)
                {
                    //go right and forward when not in the start zone
                    player.position += ((transform.right * transformIncrease) + (transform.forward * speedIncrease)) *
                                       Time.deltaTime;
                }
            }

            return;
        }
    }

    private bool Drag()
    {
        if (true)
        {

        }

        return false;
    }
}



    

    

