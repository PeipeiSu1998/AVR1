using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static bool shouldStop = false;
    public Rigidbody player;
    public GameObject controller;

    public float movementSpeed = 2;
    public float rotationSpeed = 5;
    public float rotationDegrees = 90;
    public float speedIncrease = 0.2f;

    private bool startZone,controllerAccess,goodControllerPos, leftEngaged,rightEngaged;

    private Vector3  currentHeadPose,goLeft,goRight, goLeftAndForward, goRightAndForward, forwardIncreasing, headingNow;
    

    private Transform eyeAnchor;


    // Use this for initialization
    void Start () {
        player = GetComponent<Rigidbody>();
        headingNow = player.position;
        // eyeAnchor = OVRCameraRig.center;

        //what is the vector 3 on the rig when head is rolled left or right?
        // headRolledLeft = new Vector3();
        // headRolledRight = new Vector3();
        StartCoroutine(SpeedIncrease());

        forwardIncreasing = transform.forward * speedIncrease * Time.deltaTime;

        goLeft = (transform.right * -1) * Time.deltaTime;
        goRight = transform.right * Time.deltaTime;

        goLeftAndForward = ((transform.right * -1) + forwardIncreasing) * Time.deltaTime; 
        goRightAndForward = ((transform.right) + forwardIncreasing) * Time.deltaTime;

    }


    void FixedUpdate()
    {



        //if ((!shouldStop))
        //{
        //    headingNow += transform.forward * Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
        {
            player.position += transform.forward * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            player.position += goLeft;

        }
        else if (Input.GetKey(KeyCode.D))
        {
            player.position += goRight;
        }
        //else if (OVRInput.Get(OVRInput.Button.DpadLeft) && !startZone)
        //{
        //    player.position += goLeftAndForward;
        //}
        //else if (OVRInput.Get(OVRInput.Button.DpadLeft) && !startZone)
        //{
        //    player.position += goRightAndForward;
        //}

        //else if (OVRInput.Get(OVRInput.Button.DpadLeft) && startZone)
        //{
        //    player.position += goLeft;

        //}
        //else if (OVRInput.Get(OVRInput.RawButton.DpadRight) && startZone)
        //{
        //    player.position += goRight;
        //}

        // yes, are they touching the touchpad?
        //if (OVRInput.Get(OVRInput.Touch.PrimaryTouchpad))
        //{
        //    // yes, let's require an actual click rather than just a touch.
        //    if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        //    {
        //        player.position += goLeft;
        //        // button is depressed, handle the touch.
        //        //Vector2 touchPosition = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
        //        //ProcessControllerClickAtPosition(touchPosition);
        //    }
        //}




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

    private IEnumerator SpeedIncrease()
    {
        while (true)
        {

        print("speedincreasebefore" + speedIncrease);
        if (startZone)
        {
            speedIncrease += speedIncrease;
            print("speedincrease" + speedIncrease);
            yield return null;
        }

        }
    }

    private void ForwardViaController(){

        if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && startZone){
            //todo
        }
    }
    //do the rolling of the head with controller input
    private void RollViaController(){

        // if(OVRInput.GetDown(OVRInput.Button.DpadLeft)){
        //     player.position += transform.left * Time.deltaTime; 
        // }else if(Input.GetKeyDown(KeyCode.A)){
        //     player.position += transform.left * Time.deltaTime;
        // }
    }

    

}
