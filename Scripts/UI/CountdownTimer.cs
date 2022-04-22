using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    private float stop;
    private float currentTime = 0;
    private float startingTime = 20;
    [SerializeField] Text countDownText;
    public GameObject newTurn;

    void Start()
    {
        currentTime = startingTime;
    }

    public void Reset()
    {
        currentTime = startingTime;
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }

    void Update()
    {
        if(newTurn.GetComponent<Game>().IsGameOver() == false)
        {
            currentTime -= 1 * Time.deltaTime;
        }
        
        stop = currentTime;
        countDownText.text = currentTime.ToString("0");
        if (stop <= 0)
        {
            TimeOver();
        }
    }

    void TimeOver()
    {
        Time.timeScale = 0f;
    }
}
