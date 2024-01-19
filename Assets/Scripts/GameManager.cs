using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GamePanelController GamePanel;
    [SerializeField] PanelController MenuPanel;
    [SerializeField] LevelController levelController;
    [SerializeField] List<LevelButton> levelButtons;

    private LevelDescription loadedLevel;
    private PlayerData playerData = new PlayerData();
    private void Awake()
    {
        MenuPanel.Show();
        foreach (var levelButton in levelButtons)
            levelButton.onClick.AddListener(delegate { LoadLevel(levelButton.LevelDescriptionName, levelButton.Price); });
    }

    public void Win()
    {
        Debug.Log("You Win!!");
        Time.timeScale = 0;
        GamePanel.WinPanel.Show();
        playerData.CountOfCoin += loadedLevel.Reward;
    }

    public void Lose()
    {
        Debug.Log("You Lose!!");
        Time.timeScale = 0;
        GamePanel.LosePanel.Show();
    }

    public async void LoadLevel(string levelName, int price)
    {
        if (price != null && price > playerData.CountOfCoin)
            return;
        MenuPanel.Hide();
        playerData.CountOfCoin -= price;
        loadedLevel = await levelController.LoadLevelAsync(levelName);
        GamePanel.OnLoadLevel(loadedLevel, levelController.GetFruits());
    }

    public void RestartLevel()
    {
        levelController.ReloadLevel(loadedLevel);
        GamePanel.RestartLevel(loadedLevel);
        Time.timeScale = 1;
    }
    public void GoOnMainMenu()
    {
        GamePanel.QuitLevel();
        MenuPanel.Show();
        levelController.Clear();
        Time.timeScale = 1;
    }
}
