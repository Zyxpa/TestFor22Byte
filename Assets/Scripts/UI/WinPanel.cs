using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinPanel : PanelController
{
    [SerializeField] private TextMeshProUGUI RewardText;
    private int reward;

    public void SetReward(int value)
    {
        reward = value;
        RewardText.text = reward.ToString();
    }
}
