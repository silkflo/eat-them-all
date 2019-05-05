using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
   //Gameobject
    private Rigidbody2D myRigidBody;
    private BoxCollider2D myBoxCollier;

    //movement
    private float forwardSpeed = 10f;
    private Vector3 angleZ;
    private float rotateZ = 0;
    private float smash = 20;
    public static float fallingSpeed = -2.5f;
    
    //bool
    private bool cantMove ;
    



    void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myBoxCollier = GetComponent<BoxCollider2D>();
        angleZ = GetComponent<Transform>().eulerAngles;
    }

    void Start()
    {
        //INCREASE THE SPEED LAUNCHER, COMMENT THIS LINE IF YOU DON T WANT INCREASE THE SPEED
        //Over 4' speed and move to fast and can creates bugs of colliders
        //[speedname,1st time, frequency) --1-4-7-10'
        InvokeRepeating("increaseSpeed", 60f, 240f);
       
    }


    void Update()
    {
        
        if (cantMove == false)
        {
            CheckUserInput();
        }

         LetFallItem();

    }


    public void CheckUserInput()
    {
        //RIGHT
        if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidBody.velocity = new Vector2(forwardSpeed, fallingSpeed);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            myRigidBody.velocity = new Vector2(0, fallingSpeed);
        }
        //LEFT
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidBody.velocity = new Vector2(-forwardSpeed, fallingSpeed);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            myRigidBody.velocity = new Vector2(0, fallingSpeed);
        }
        //TURN
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GetComponent<Transform>().eulerAngles = new Vector3(0, 0, rotateZ - 90);
            rotateZ = transform.eulerAngles.z;
        }
        //DOWN
        else if (Input.GetKey(KeyCode.Space))
        {
            myRigidBody.velocity = new Vector2(0, fallingSpeed * smash);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            myRigidBody.velocity = new Vector2(0, fallingSpeed);
        }
        else
        {
            myRigidBody.velocity = new Vector2(0, fallingSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D target)
    {

        if ((target.collider.tag == TagManager.LEVEL_COLLIDER_TAG ||
             target.collider.tag == TagManager.BOMB_TAG ||
             target.collider.tag == TagManager.FOOD_TAG) &&
             cantMove == false)
        {
            cantMove = true;
            //TO AVOID THE DOUBLE SPAWN
            SpawnSecurity.timeElapsed = 0f;
            StartCoroutine(SpawnDelay());

        }
    }


    IEnumerator SpawnDelay()
    {
        if (cantMove == true)
        {
            yield return new WaitForSeconds(1f);

            FindObjectOfType<SpawnFood>().StartSpawningFood();
        }
    }

    void LetFallItem()
    {
        if (SpawnSecurity.timeElapsed == 230)
        {
            print("fall");
            cantMove = true;
            myRigidBody.velocity = new Vector2(0, fallingSpeed);
        }
    }


    void increaseSpeed()
    {
        fallingSpeed = fallingSpeed - 0.2f;
        forwardSpeed = forwardSpeed + 50f;

        print("speed increased by : (" + fallingSpeed + ";" + forwardSpeed + ")");
    }


}























