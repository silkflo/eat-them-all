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
    private float fallingSpeed = -2.5f;
    //public float freeFallSpeed = -0.5f;


    //bool
    private bool cantMove = false;
    private bool leftLimit = false;
    private bool rightLimit = false;


    void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myBoxCollier = GetComponent<BoxCollider2D>();
        angleZ = GetComponent<Transform>().eulerAngles;
    }

    void Start()
    {
      
    }


    void Update()
    {
        if (cantMove == false)
        {
            
            CheckUserInput();
        }
    }


    void CheckUserInput()
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
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Transform>().eulerAngles = new Vector3(0, 0, rotateZ - 90);
            rotateZ = transform.eulerAngles.z;
        }
        //DOWN
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            myRigidBody.velocity = new Vector2(0, fallingSpeed * 15);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            myRigidBody.velocity = new Vector2(0, fallingSpeed);
        }

    }
 
    private void OnCollisionEnter2D(Collision2D target)
    {

        if ((target.collider.tag == TagManager.LEVEL_COLLIDER_TAG ||
             target.collider.tag == TagManager.BOMB_TAG ||
             target.collider.tag == TagManager.WORM_TAG || 
             target.collider.tag == TagManager.FOOD_TAG ||
             SpawnSecurity.timeElapsed > 150 ) && 
             cantMove == false)
        {
            cantMove = true;

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
    
}























