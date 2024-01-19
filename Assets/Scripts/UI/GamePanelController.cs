using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanelController : PanelController
{
    [SerializeField] WinPanel winPanel;
    [SerializeField] PanelController losePanel;
    [SerializeField] BasketsController basketsController;
    [SerializeField] HeaderController headerController;

    public PanelController WinPanel => winPanel;
    public PanelController LosePanel => losePanel;
    public BasketsController BasketsController => basketsController;
    public HeaderController HeaderController => headerController;

    public void Awake()
    {
        
    }

    internal void OnLoadLevel(LevelDescription loadedLevel, List<FruitEnterTriggerComponent> fruitEnterTriggerComponents)
    {
        Show();
        headerController.SetHeader(loadedLevel);
        basketsController.AddListenerOnFruit(fruitEnterTriggerComponents);
        winPanel.SetReward(loadedLevel.Reward);
    }

    internal void RestartLevel(LevelDescription loadedLevel)
    {
        LosePanel.Hide();
        headerController.SetHeader(loadedLevel);
    }
    public void QuitLevel()
    {
        Hide();
        WinPanel.Hide();
        losePanel.Hide();
    }

}
