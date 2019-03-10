using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public static bool shouldStop = false;
    public Rigidbody player;
    public GameObject canvas, camerarig;
    public Text debugText;
    private OVRCameraRig OVRCameraRig;
    
    

    public float movementSpeed = 2;
    public float rotationSpeed = 5;
    public float rotationDegrees = 90;
    public float speedIncrease = 1;
    public float touch = -0.2f;

    private bool startZone,goodControllerPos;

    private Vector3  currentHeadPose,goLeft,goRight, goLeftAndForward, goRightAndForward, forwardIncreasing, headingNow;
    
    private Vector2 touchPosition;
    private Transform eyeAnchor;


    // Use this for initialization
    void Start () {
        // player = GetComponent<Rigidbody>();
        canvas.name = "Canvas";
        canvas.GetComponent<Canvas>();
        debugText.name = "Text";
        debugText.GetComponent<Text>();
        // StartCoroutine(setTouchPosition());
        // StartCoroutine(SpeedIncrease());
        camerarig = GetComponent<GameObject>();
        // OVRCameraRig = camerarig.GetComponent<OVRCameraRig>();
        OVRCameraRig = FindObjectOfType<OVRCameraRig>();
        eyeAnchor = OVRCameraRig.centerEyeAnchor;
        // StartCoroutine(SpeedIncrease());
        
    }



        void FixedUpdate()
    {   
        

        
    //     print(eyeAnchor.rotation);
    //    debugText.text = eyeAnchor.rotation.ToString();
        //  if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)){
        //     player.position += transform.forward * 10 * Time.deltaTime;

        // }

        if(startZone){
            
            debugText.text = "Got to the method";
            StartZoneControls();
            //du har ikke ramt her inde endnu og vi tester om speedincrease kan være for sig selv i start 
        }
        else {
            
        }
        // else if(OVRInput.Get(OVRInput.Touch.PrimaryTouchpad))
        // {
        //     touchPosition = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
        // }
        // print(touchPosition);
        //if ((!shouldStop))
        //{
        //    headingNow += transform.forward * Time.deltaTime;
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
        if (Input.GetKey(KeyCode.W) && startZone)
        {
            
            debugText.text = "You got here!";
            // headingNow += forwardIncreasing;
            player.position += transform.forward * speedIncrease * Time.deltaTime;

        }
        //else if (Input.GetKey(KeyCode.A))
        //{
        //    player.position += goLeft;
        //    debugText.text = "a is reached";

        //}
        // else if (Input.GetKey(KeyCode.D))
        // {
        //     player.position += goRight;
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
        while(true)
        {
            if(!startZone)
            {
                yield return new WaitForSeconds(1);
                speedIncrease += speedIncrease;
                StopCoroutine(SpeedIncrease());  

            }

        }
        
        
        
    }

    private IEnumerator setTouchPosition(){
        while(true){        
            touchPosition = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
            yield return null;        
        }
    }

    private void StartZoneControls()
    {
        debugText.text ="Got inside the startz";
        if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            player.position += transform.forward * 10 * Time.deltaTime;
        }
        else if (OVRInput.Get(OVRInput.Touch.PrimaryTouchpad)){

            touch = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad).x;
             if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad))
             {
            debugText.text = touch.ToString();
                if (touch < 0)
            {
                //Go left
                player.position += (transform.right * -1) * 3 * Time.deltaTime;
                
            }
                else 
            {
                //go right
                player.position += (transform.right) * 3 * Time.deltaTime;
                
            }

        }
        }

    }
    //do the left and right turn when pressing the touchpad, 
    private void RollViaController(){
        

        if(touch < 0 && !startZone)
        {
            //go left and forward when not in the startzone
            player.position += ((transform.right * -1) + forwardIncreasing) * Time.deltaTime; 
        }
        else if (touch > 0 && !startZone)
        {
            //go right and forward when not in the start zone
            player.position += ((transform.right) + forwardIncreasing) * Time.deltaTime;
        }
       
        
    }

    

    

}
