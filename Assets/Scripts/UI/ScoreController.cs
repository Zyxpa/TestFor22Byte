using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreController : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI CurrentScoreTMP;
    [SerializeField] private TextMeshProUGUI MaxScoreTMP;
    [SerializeField] UnityEvent WinEvent;

    private int currentScore = 0;
    private int maxScore = 0;

    private void Start()
    {
        CurrentScoreTMP.text = currentScore.ToString();
    }
    public void AddPoint()
    {
        currentScore++;
        CurrentScoreTMP.text = currentScore.ToString();
        if(currentScore == maxScore)
            WinEvent.Invoke();
    }

    public void SetMaxScore(int MaxScore)
    {
        maxScore = MaxScore;
        MaxScoreTMP.text = maxScore.ToString();
    }


}
