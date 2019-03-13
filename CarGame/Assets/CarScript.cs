using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    private MyGameManager myGameManager;

    public bool canDrive = false;
    public float carSpeed = 0f;
    public float velocity;
    public float accelerateSpeed = 0f;
    public float rotateSpeed = 5f;
    public VJHandler jsMovement;

    public bool crash = false;
    public float crashTimer = 3f;
    public float recoilTime = 3f;

    private Rigidbody myRB;

    public GameObject newTireMarkLeft;
    public GameObject activeTireMarkLeft;
    public Transform tireMarkRight;

    public bool drifting = false;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        canDrive = true;
        activeTireMarkLeft.SetActive(false);
        myGameManager = GameObject.Find("GameManager").GetComponent<MyGameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if(myGameManager.raceOn)
        {
            carSpeed = Mathf.Lerp(myRB.velocity.z, accelerateSpeed, Time.time);

            if (drifting == false && activeTireMarkLeft.activeSelf)
            {
                activeTireMarkLeft.transform.parent = null;
                activeTireMarkLeft = null;
                GameObject newMark = Instantiate(newTireMarkLeft, transform.position, transform.rotation);
                newMark.transform.parent = transform;
                activeTireMarkLeft = newMark;
                activeTireMarkLeft.SetActive(false);
            }

            if (jsMovement.InputDirection.x != 0f)
            {
                drifting = true;
                activeTireMarkLeft.SetActive(true);
            }

            else if (jsMovement.InputDirection.x == 0f)
            {
                drifting = false;
            }

            if (crash)
            {
                canDrive = false;
                crashTimer -= Time.deltaTime;
            }

            else if (!crash)
            {
                canDrive = true;
            }

            if (crashTimer <= 0f)
            {
                crash = false;
                crashTimer = recoilTime;
            }
        }
        else
        {
            carSpeed = 0f;
        }
            

    }

    void FixedUpdate()
    {
        if(canDrive)
        {
            myRB.velocity = transform.forward * carSpeed;
        }

        if(myRB.velocity.z != 0f)
        {
            transform.Rotate(Vector3.up, jsMovement.InputDirection.x * rotateSpeed);
        }      
    }

    public void Accelerate(float speed)
    {
        accelerateSpeed = speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            crash = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "CheckPoint1")
        {
            myGameManager.checkPoints[0] = true;
        }

        if (other.gameObject.name == "CheckPoint2")
        {
            myGameManager.checkPoints[1] = true;
        }

        if (other.gameObject.name == "CheckPoint3")
        {
            myGameManager.checkPoints[2] = true;
        }

        if (other.gameObject.name == "FinishLine")
        {
            if(myGameManager.checkPoints[myGameManager.checkPoints.Length-1] == true)
            {
                myGameManager.lapTime[myGameManager.lap-1] = myGameManager.currentLapTime;
                myGameManager.lap++;
                myGameManager.currentLapTime = 0f;
            }
        }
    }
}
