using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : Button
{
    [SerializeField] LevelController levelController;
    public LevelController LevelController => levelController;

}
