using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Defs/LevelDescription", fileName = "LevelDescription")]
public class LevelDescription : ScriptableObject
{
    [SerializeField] public string Name;
    [SerializeField] public int Reward;
    [SerializeField] public int Time;
    [SerializeField] public List<TileObj> blocktTiles = new List<TileObj>();
    //переписать на Dictionary для разных фруктов
    [SerializeField] public List<TileObj> appleTiles = new List<TileObj>();
    [SerializeField] public List<TileObj> tractorPos = new List<TileObj>();
    [SerializeField] public GameObject blockPrefub;
    [SerializeField] public FruitEnterTriggerComponent applePrefub;
    [SerializeField] public TractorController tractorPrefub;
    public int CountOfFruits => appleTiles.Count;
}

