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
    public float speedIncrease = 5;
    public float touch = -0.2f;

    private bool startZone,goodControllerPos;

    private Vector3  currentHeadPose;
    
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
        //     if (Input.GetKey(KeyCode.W) && startZone)
        // {
            
        //     debugText.text = "You got here!";
     
        //     player.position += transform.forward * speedIncrease * Time.deltaTime;

        // }
        // }
        
        // if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        // {
        //     // player.position += transform.forward * Time.deltaTime;
        //     player.position += transform.forward * Time.deltaTime;
        //     debugText.text = player.position.ToString();
        // }
        //     // StartZoneControls();

        if(!startZone){
            RollViaController();
            
            //du har ikke ramt her inde endnu og vi tester om speedincrease kan være for sig selv i start 
        }
        
        else {
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
        
        //else 
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
        while(true)
        {
            if(!startZone)
            {
                yield return new WaitForSeconds(1);
                speedIncrease += speedIncrease;
                  

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
        
        if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            player.position += transform.forward * 10 * Time.deltaTime;
        }
        else if (OVRInput.Get(OVRInput.Button.PrimaryTouchpad)){
            touch = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad).x;
            debugText.text = touch.ToString();             
        
                if (touch < 0)
            {
                //Go left
                player.position += (transform.right * -1) * 3 * Time.deltaTime;
                debugText.text = touch.ToString();               
                
            }
                else if(touch > 0)
            {
                //go right
                player.position += (transform.right) * 3 * Time.deltaTime;
                
            }

        
        } else if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)){
            player.position += transform.forward * speedIncrease * Time.deltaTime;
        }

    }
    //do the left and right turn when pressing the touchpad, 
    private void RollViaController(){
        
        debugText.text = "reached rollviaController";
        if(touch < 0 )
        {
            //go left and forward when not in the startzone
            player.position += ((transform.right * -1) + (transform.forward * speedIncrease)) * Time.deltaTime; 
        }
        else if (touch > 0)
        {
            //go right and forward when not in the start zone
            player.position += ((transform.right) + (transform.forward * speedIncrease)) * Time.deltaTime;
        }
       
        
    }

    

    

}
