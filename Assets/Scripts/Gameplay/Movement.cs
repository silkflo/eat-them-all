using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Gameobject
    private Rigidbody2D myRigidBody;
    private BoxCollider2D myBoxCollier;

    //movement
    private float forwardSpeed = 5f;
    private Vector3 angleZ;
    private float rotateZ = 0;
    private float smash = 20;
    public static float fallingSpeed = -2.5f;
    // private float fallingSpeedAdjust = 0.15f;
    private float maxSpeed = -11f;



    private float acceleration = 1 ;


    //bool
    [HideInInspector]
    private bool cantMove;


    void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myBoxCollier = GetComponent<BoxCollider2D>();
        angleZ = GetComponent<Transform>().eulerAngles;


    }

    void Start()
    {


        if (Lose.gameOver == false || GameManager.instance.gameRestarted == true)
        {
            //INCREASE THE SPEED, COMMENT THIS LINE IF YOU DON T WANT INCREASE THE SPEED
            //start at 10sec and every 15sec 
            InvokeRepeating("increaseSpeed", 20f, 180f);
        }
    }


    void Update()
    {

        if (cantMove == false && GamePlayController.panelOnCantMove == false)
        {
            CheckUserInput();
        }

        if (fallingSpeed < maxSpeed)
        {
            print("Invoke canceled");

            CancelInvoke("increaseSpeed");
            fallingSpeed = maxSpeed;
        }

        LetFallItem();
        //  DeactivateHighObject();

        

        acceleration = acceleration + 0.1f;
       // print("Acceleration : " + acceleration);

    }


    private void LateUpdate()
    {
        AdjustSpawnSecurityTime();
    }


    //BACKUP CheckUserInput_2
    public void CheckUserInput_2()
    {

        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            acceleration = 1;
        }
        //RIGHT
        if (Input.GetKey(KeyCode.RightArrow))
        {

            print("hello ma geule");
            myRigidBody.velocity = new Vector2(forwardSpeed * acceleration, fallingSpeed);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            myRigidBody.velocity = new Vector2(0, fallingSpeed);
            acceleration = 1;
        }
        //LEFT
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidBody.velocity = new Vector2(-forwardSpeed * acceleration, fallingSpeed);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            myRigidBody.velocity = new Vector2(0, fallingSpeed);
            acceleration = 1;
        }
        
        //TURN
       else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            AudioManager.instance.TurnSound();

            GetComponent<Transform>().eulerAngles = new Vector3(0, 0, rotateZ - 90);
            rotateZ = transform.eulerAngles.z;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            AudioManager.instance.TurnSound();

            GetComponent<Transform>().eulerAngles = new Vector3(0, 0, rotateZ + 90);
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
            if (gameObject.activeSelf)
                StartCoroutine(SpawnDelay());


            if (gameObject.name == "Scarabe(Clone)")
            {
                AudioManager.instance.ScarabeSound();
            }
            else if (gameObject.name == "DragonFly(Clone)")
            {
                AudioManager.instance.DragonFlySound();
            }
            else if (gameObject.name == "Bomb(Clone)")
            {
                AudioManager.instance.BombSound();
            }
            else if (gameObject.name == "Fly(Clone)")
            {
                AudioManager.instance.FlySound();
            }
            else if (gameObject.name == "Worm(Clone)")
            {
                AudioManager.instance.WormSound();
            }

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
        if (SpawnSecurity.timeElapsed == SpawnSecurity.spawnSecurityTime - 20) //230
        {

            cantMove = true;
            myRigidBody.velocity = new Vector2(0, fallingSpeed);
            //  AudioManager.instance.FreeFallSound();
        }
    }




    void increaseSpeed()
    {

        if (GamePlayController.levelMode == 1)
            fallingSpeed = fallingSpeed - 0.05f;
        if (GamePlayController.levelMode == 2)
            fallingSpeed = fallingSpeed - 0.2f;
        if (GamePlayController.levelMode == 3)
            fallingSpeed = fallingSpeed - 0.6f;
        // print("speed increased by : (" + fallingSpeed +  " ; " + Score.currentTime + ")");
    }

    /*
    public void DeactivateHighObject()
    {
        if(gameObject.transform.position.y > 29)
        {
            gameObject.SetActive(false);
        }
    }
*/


    public void CheckUserInput()
    {
       
        TurnUpDown();
        SmashSpace();
        MoveLeftRight();
    }




    public void MoveLeftRight()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            acceleration = 1;
        }
        //RIGHT
        if (Input.GetKey(KeyCode.RightArrow))
        {

        
            myRigidBody.velocity = new Vector2(forwardSpeed * acceleration, fallingSpeed);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            myRigidBody.velocity = new Vector2(0, fallingSpeed);
            acceleration = 1;
        }
        //LEFT
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidBody.velocity = new Vector2(-forwardSpeed * acceleration, fallingSpeed);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            myRigidBody.velocity = new Vector2(0, fallingSpeed);
            acceleration = 1;
        }
    }

    
    public void TurnUpDown()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            AudioManager.instance.TurnSound();

            GetComponent<Transform>().eulerAngles = new Vector3(0, 0, rotateZ - 90);
            rotateZ = transform.eulerAngles.z;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            AudioManager.instance.TurnSound();

            GetComponent<Transform>().eulerAngles = new Vector3(0, 0, rotateZ + 90);
            rotateZ = transform.eulerAngles.z;
        }
    }


    public void SmashSpace()
    {
        if (Input.GetKey(KeyCode.Space))
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



    public void AdjustSpawnSecurityTime()
    {
        if (cantMove == true)
        {
            SpawnSecurity.spawnSecurityTime = 150; //250


        }
        else 
        {
            SpawnSecurity.spawnSecurityTime = 500;
           
        }
    }

}























