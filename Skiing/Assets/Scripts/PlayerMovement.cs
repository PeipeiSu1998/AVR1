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
    private float headRotation;

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
        StartCoroutine(SpeedIncrease());

        
    }



        void FixedUpdate()
        {
        //     Debug.Log(speedIncrease);
    
        if (Input.GetKey(KeyCode.W))
        {
           player.position += transform.forward * 5 * Time.deltaTime;
            debugText.text = speedIncrease.ToString();
        }
        if(!startZone){
            RollViaController();           
            
        }
        
     else if(startZone) {
            StartZoneControls();            
        }
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
                speedIncrease = speedIncrease * 1.5f;
                  

            }
            yield return null;

        }
        
        
        
    }

    private void StartZoneControls()
    {
        debugText.text = "startzoneControls";
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

        
        } 
        //make the dragging stuff
        // else if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)){

        //     player.position += transform.forward * speedIncrease * Time.deltaTime;
        // }
        return;

    }
    //do the left and right turn when pressing the touchpad, 
    private void RollViaController(){        
        
        if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            if(true)
            {
            player.position += transform.forward * 10 * Time.deltaTime;

            }
        }
        else if (OVRInput.Get(OVRInput.Button.PrimaryTouchpad)){
            touch = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad).x;
        if(touch < 0 )
        {
            debugText.text = touch.ToString();
            //go left and forward when not in the startzone
            player.position += ((transform.right * -1) + (transform.forward * speedIncrease)) * Time.deltaTime; 
        }
        else if (touch > 0)
        {
            //go right and forward when not in the start zone
            player.position += ((transform.right) + (transform.forward * speedIncrease)) * Time.deltaTime;
        }
        }
       return;
        
    }

    private bool Drag()
    {
        if(true){
            
        }

        return false;
    }

    

}
