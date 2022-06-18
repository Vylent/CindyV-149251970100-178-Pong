 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public PowerUpManager manager;
    public int speed;
    public bool isRight;
    public KeyCode upKey;
    public KeyCode downKey;

    private bool PUSpeedLeft;
    private bool PUSpeedRight;
    private Rigidbody2D rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        PUSpeedLeft = false;
        PUSpeedRight = false;
    }


    private void Update()
    {

        if (PUSpeedRight)
        {
            //Debug.Log("PercepatKanan");
            if (!PUSpeedLeft && !isRight)
            {
                MoveObject(GetInput());
            }
            else 
            {
                MoveObject(GetInputSpeedUp());  
            }

        }
        else if (PUSpeedLeft)
        {
            //Debug.Log("PercepatKiri");
            if (!PUSpeedRight && isRight )
             {
                 MoveObject(GetInput());
             }
             else 
             {
                 MoveObject(GetInputSpeedUp());
             }
        }
        else
        {
            MoveObject(GetInput());
        }
        
       
        
    }

    private Vector2 GetInput()
    {

        if (Input.GetKey(upKey))
        {
            //atas
            return Vector2.up * speed;
        }
        else if (Input.GetKey(downKey))
        {
            //bawah
            return Vector2.down * speed;
        }
        return Vector2.zero;
    }

    private Vector2 GetInputSpeedUp()
    {


            if (Input.GetKey(upKey))
            {
                //atas
                return Vector2.up * (speed * 2);
            }
            else if (Input.GetKey(downKey))
            {
                //bawah
                return Vector2.down * (speed * 2);
            }

        return Vector2.zero;
    }



    //Debug.Log("TEST: " +movement);
    private void MoveObject(Vector2 movement)
    {
        rig.velocity = movement;
    }

    // PU Paddle Panjang
    public void ActivatePULengthen()
    {
        gameObject.transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y* 2);
    }

    public void DeactivatePULengthen()
    {
        gameObject.transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y / 2);
    }
    
    //PU Paddle Speed
     //  if collision detected  on right then   if isright move 2x    
     public void PUSpeedLeftStatus(bool percepatKiri)
    {
        PUSpeedLeft = percepatKiri;
    }

    public void PUSpeedRightStatus(bool percepatKanan)
    {
        PUSpeedRight = percepatKanan;
    }


}
