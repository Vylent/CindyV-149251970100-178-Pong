using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public int speed;
    public KeyCode upKey;
    public KeyCode downKey;

    private Rigidbody2D rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        MoveObject(GetInput());
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

    //Debug.Log("TEST: " + movement);
    private void MoveObject(Vector2 movement)
    {
        
        rig.velocity = movement;
    }
}
