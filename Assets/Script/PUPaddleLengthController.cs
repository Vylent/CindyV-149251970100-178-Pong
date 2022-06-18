using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUPaddleLengthController : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;   
    public int lengthenDuration;
    public GameObject paddleKanan;
    public GameObject paddleKiri;
    public GameObject redball;

    private bool powerUpLeft;
    private bool powerUpRight;

    private void Start()
    {
        powerUpLeft = false;
        powerUpRight = false;
    }

    private void Update()
    {
        if (manager.GettimerPaddleLengKanan() > lengthenDuration)
        {
            paddleKanan.GetComponent<PaddleController>().DeactivatePULengthen();
            manager.rightLengTimer(false);
            manager.ResettimerPaddleLengKanan();
            powerUpRight = false;
        }
        else if (manager.GettimerPaddleLengKiri() > lengthenDuration)
        {
            paddleKiri.GetComponent<PaddleController>().DeactivatePULengthen();
            manager.leftLengTimer(false);
            manager.ResettimerPaddleLengKiri();
            powerUpLeft = false;
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {

            if (ball.transform.position.x < redball.transform.position.x)
            {
                if (!powerUpLeft)
                {
                paddleKiri.GetComponent<PaddleController>().ActivatePULengthen();               
                manager.leftLengTimer(true);  //panjangKanan
                powerUpLeft = true;
                }
            }
            else
            {
                if (!powerUpRight)
                {
                paddleKanan.GetComponent<PaddleController>().ActivatePULengthen();
                manager.rightLengTimer(true); // panjangKiri
                powerUpRight = true;
                }

            }
             manager.RemovePowerUp(gameObject);
        }
    }



}


