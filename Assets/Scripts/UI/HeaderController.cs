using System;
using TMPro;
using UnityEngine;

public class HeaderController : MonoBehaviour
{
    [SerializeField] ScoreController scoreController;
    [SerializeField] TextMeshProUGUI levelName;
    [SerializeField] Timer timer;

    internal void SetHeader(LevelDescription loadedLevel)
    {
        levelName.text = loadedLevel.Name;
        scoreController.SetMaxScore(loadedLevel.CountOfFruits);
        timer.SetMaxVal(loadedLevel.Time);
    }
}
