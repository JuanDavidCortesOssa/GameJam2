using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private float survivedTime = 0;
    private float score = 0;
    private float finalScore = 0;

    void Update()
    {
    }

    public void CalculateFinalScore()
    {
        finalScore = survivedTime * finalScore;
    }

    public void IncrementScore(float increment)
    {
        score += increment;
        Debug.Log("Score: " + score);
    }

    public void IncrementSurvivedTime()
    {
        survivedTime += Time.deltaTime;
        Debug.Log("Time Survived: " + survivedTime);
    }
}
