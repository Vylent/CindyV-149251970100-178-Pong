using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUPaddleSpeedUpController : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;
    public int speedDuration;
    public GameObject paddleKanan;
    public GameObject paddleKiri;
    public GameObject greenball;

    private bool powerUpLeft;
    private bool powerUpRight;

    private void Start()
    {
        powerUpLeft = false;
        powerUpRight = false;
    }

    private void Update()
    {
        if (manager.GettimerPaddleSpeedUpKanan() > speedDuration)
        {
            paddleKanan.GetComponent<PaddleController>().PUSpeedRightStatus(false);
            manager.rightSpeedUpTimer(false);
            manager.ResettimerPaddleSpeedUpKanan();
            powerUpRight = false;
        }
        else if (manager.GettimerPaddleSpeedUpKiri() > speedDuration)
        {
            paddleKiri.GetComponent<PaddleController>().PUSpeedLeftStatus(false);
            manager.leftSpeedUpTimer(false);
            manager.ResettimerPaddleSpeedUpKiri();
            powerUpLeft = false;
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {

            if (ball.transform.position.x < greenball.transform.position.x)
            {
                if (!powerUpLeft)
                {
                    paddleKiri.GetComponent<PaddleController>().PUSpeedLeftStatus(true);
                    manager.leftSpeedUpTimer(true);  //cepatKanan
                    powerUpLeft = true;
                }
  
            }
            else
            {
                if (!powerUpRight)
                {
                    paddleKanan.GetComponent<PaddleController>().PUSpeedRightStatus(true);
                    manager.rightSpeedUpTimer(true); // cepatKiri
                    powerUpRight = true;
                }
 

            }
            manager.RemovePowerUp(gameObject);
        }
    }

}
