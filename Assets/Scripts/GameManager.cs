using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject WinPanel;
    [SerializeField] GameObject LosePanel;

    public void Win()
    {
        Debug.Log("You Win!!");
        Time.timeScale = 0;
        WinPanel.SetActive(true);
    }

    public void Lose()
    {
        Debug.Log("You Lose!!");
        Time.timeScale = 0;
        LosePanel.SetActive(true);
    }
}
