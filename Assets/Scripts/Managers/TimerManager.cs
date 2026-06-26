using UnityEngine;
using UnityEngine.UI;


public class TimerManager : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public float seconds;
    public float minutes;
    public UIManager uIManager;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining >=0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            Debug.Log("time as run out");
            timeRemaining = 0;
            timerIsRunning = false;
            uIManager.EndGame();
        }
    }

    public void CalcTime(float timeToDisplay)
    {
        minutes = Mathf.FloorToInt(timeRemaining / 60);//calc)
        seconds = Mathf.FloorToInt(timeRemaining % 60);//seconds
    } 
}   