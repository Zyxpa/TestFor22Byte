using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : Button
{
    [SerializeField] TextMeshProUGUI priceText;
    [SerializeField] string levelDescriptionName;
    public int Price => Convert.ToInt32(priceText.text);
    public string LevelDescriptionName => levelDescriptionName;
}
