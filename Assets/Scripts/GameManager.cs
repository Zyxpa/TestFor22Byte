using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PanelController WinPanel;
    [SerializeField] PanelController LosePanel;
    [SerializeField] PanelController GamePanel;
    [SerializeField] List<LevelButton> levelButtons;
    [SerializeField] BasketsController basketsController;
    [SerializeField] ScoreController scoreController;

    private LevelController loadedLevel;
    private void Awake()
    {
        foreach (var levelButton in levelButtons)
            levelButton.onClick.AddListener(delegate { LoadLevel(levelButton.LevelController); });
    }

    public void Win()
    {
        Debug.Log("You Win!!");
        Time.timeScale = 0;
        WinPanel.Show();
    }

    public void Lose()
    {
        Debug.Log("You Lose!!");
        Time.timeScale = 0;
        LosePanel.Show();
    }

    public void LoadLevel(LevelController levelController)
    {
        loadedLevel = levelController;
        GamePanel.Show();
        var LevelDes = levelController.LoadLevel();
        scoreController.SetMaxScore(LevelDes.CountOfFruits);
        basketsController.AddListenerOnFruit(levelController.GetFruits());
    }

    public void RestartLevel()
    {
        loadedLevel.ReloadLevel();
        LosePanel.Hide();
        Time.timeScale = 1;
    }
}
