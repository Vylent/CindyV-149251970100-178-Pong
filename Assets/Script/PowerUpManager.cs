using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public Transform spawnArea;
    public int maxPowerUpAmount;
    public int spawnInterval;
    public int despawnInterval;
    public Vector2 powerUpAreaMin;
    public Vector2 powerUpAreaMax;
    public List<GameObject> powerUpTemplateList;

    

    private List<GameObject> powerUpList;

    private float timer;
    private float timerPaddleLengKiri;
    private float timerPaddleLengKanan;
    private bool lengUpKanan;
    private bool lengUpKiri;
    private bool speedUpKanan;
    private bool speedUpKiri;
    private float timerPaddleSpeedUpKanan;
    private float timerPaddleSpeedUpKiri;
    


    private void Start()
    {        
        powerUpList = new List<GameObject>();
        timer = 0;
        timerPaddleLengKiri = 0;
        timerPaddleLengKanan = 0;
        lengUpKiri = false;
        lengUpKanan =  false;
        speedUpKiri = false;
        speedUpKanan =  false;
        timerPaddleSpeedUpKanan = 0;
        timerPaddleSpeedUpKiri = 0;

    }

    private void Update()
    {
       
        timer += Time.deltaTime;

        if (lengUpKiri) 
        {
            timerPaddleLengKiri += Time.deltaTime;
        }
        else if (lengUpKanan)
        {
            timerPaddleLengKanan += Time.deltaTime;
        }
        if (speedUpKiri) 
        {
            timerPaddleSpeedUpKiri += Time.deltaTime;
        }
        else if (speedUpKanan)
        {
            timerPaddleSpeedUpKanan += Time.deltaTime;
        }

            

        if (timer > spawnInterval)
        {
            GenerateRandomPowerUp();
            timer -= spawnInterval;
        }

        
    }

    public void GenerateRandomPowerUp()
    {
        GenerateRandomPowerUp(new Vector2(Random.Range(powerUpAreaMin.x, powerUpAreaMax.x), Random.Range(powerUpAreaMin.y, powerUpAreaMax.y)));
    }

    public void GenerateRandomPowerUp(Vector2 position)
    {
        if (powerUpList.Count >= maxPowerUpAmount)
        {
            if (timer > despawnInterval)
            {
                RemovePowerUp(powerUpList[0]);
            }
            return;
            
        }
        

        if (position.x < powerUpAreaMin.x ||
            position.x > powerUpAreaMax.x ||
            position.y < powerUpAreaMin.y ||
            position.y > powerUpAreaMax.y)
        {
            return;
        }

        int randomIndex = Random.Range(0, powerUpTemplateList.Count);

        GameObject powerUp = Instantiate(powerUpTemplateList[randomIndex], new Vector3(position.x, position.y, powerUpTemplateList[randomIndex].transform.position.z), Quaternion.identity, spawnArea);
        powerUp.SetActive(true);

        powerUpList.Add(powerUp);
    }

    public void RemovePowerUp(GameObject powerUp)
    {
        powerUpList.Remove(powerUp);
        Destroy(powerUp);
    }

    public void RemoveAllPowerUp()
    {
        while (powerUpList.Count > 0)
        {
            RemovePowerUp(powerUpList[0]);
        }
    }


    // Get collider ball -> PU Paddle Panjang then set timer on

    public void leftLengTimer(bool panjangKiri)
    {
        lengUpKiri = panjangKiri;
    }

    public void rightLengTimer(bool panjangKanan)
    {
        lengUpKanan = panjangKanan;
    }


    // Get timer Paddlle Panjang

    public float GettimerPaddleLengKiri()
    {
        return timerPaddleLengKiri;
    }
    
    public float GettimerPaddleLengKanan()
    {
        return timerPaddleLengKanan;
    }

    // Reset efek Paddle Panjang
    public void ResettimerPaddleLengKiri()
    {
        timerPaddleLengKiri = 0;
    }

    public void ResettimerPaddleLengKanan()
    {
        timerPaddleLengKanan = 0;
    }

    // Get collider ball -> PU Paddle SpeedUp    then set timer on

    public void leftSpeedUpTimer(bool cepatKiri)
    {
        speedUpKiri = cepatKiri;
    }

    public void rightSpeedUpTimer(bool cepatKanan)
    {
        speedUpKanan = cepatKanan;
    }


    //Get timer Paddlle SpeedUp
    public float GettimerPaddleSpeedUpKiri()
    {
        return timerPaddleSpeedUpKiri;
    }

    public float GettimerPaddleSpeedUpKanan()
    {
        return timerPaddleSpeedUpKanan;
    }

    // Reset efek Paddle Cepat
    public void ResettimerPaddleSpeedUpKiri()
    {
        timerPaddleSpeedUpKiri = 0;
    }

    public void ResettimerPaddleSpeedUpKanan()
    {
        timerPaddleSpeedUpKanan = 0;
    }
}

