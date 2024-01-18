using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Video;
using static UnityEditor.Progress;

public class LevelController : MonoBehaviour
{
    [SerializeField] private string curentLevelName;
    [SerializeField] Tilemap blockTilemap;
    [SerializeField] Tilemap appleTilemap;
    [SerializeField] Transform tractorPos;
    [SerializeField] GameObject blockPrefub;
    [SerializeField] FruitEnterTriggerComponent applePrefub;
    [SerializeField] TractorController tractorPrefub;

    List<FruitEnterTriggerComponent> fruitEnterTriggerComponents = new List<FruitEnterTriggerComponent>();
    TractorController tractor;
    LevelDescription level;
    [ContextMenu("Save")]
    public void SaveLevel()
    {
        LevelDescription level = new LevelDescription();

        var val = blockTilemap.GetComponentsInChildren<MeshRenderer>().ToList();

        foreach ( var t in val)
        {
            var v = new TileObj(t.gameObject.transform.position);
            level.blocktTiles.Add(v);
        }

        val = appleTilemap.GetComponentsInChildren<MeshRenderer>().ToList();
        foreach (var t in val)
        {
            var v = new TileObj(t.gameObject.transform.position);
            level.appleTiles.Add(v);
        }
        level.tractorPos = new TileObj(tractorPos.position); ;
        SaveLoadJSON.Save(level, curentLevelName + ".json");
    }
    [ContextMenu("Load")]
    public LevelDescription LoadLevel()
    {
        level = SaveLoadJSON.Load<LevelDescription>(curentLevelName + ".json");

        foreach (var t in level.blocktTiles)
            Instantiate(blockPrefub, t.position, new Quaternion(), blockTilemap.transform);
        foreach (var t in level.appleTiles)
            fruitEnterTriggerComponents.Add(Instantiate(applePrefub, t.position, new Quaternion(), appleTilemap.transform));
        tractor = Instantiate<TractorController>(tractorPrefub, level.tractorPos.position, Quaternion.Euler(new Vector3(0, 90, 0)), appleTilemap.transform);
        tractor.SetMap(blockTilemap);
        return level;
    }

    public void Clear()
    {
        Destroy(tractor.gameObject);
        foreach (var t in fruitEnterTriggerComponents)
            Destroy(t.gameObject);
        fruitEnterTriggerComponents.Clear();
    }

    public void ReloadLevel()
    {
        tractor.gameObject.SetActive(false);
        tractor.gameObject.transform.position = level.tractorPos.position;
        tractor.gameObject.SetActive(true);

        tractor.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        foreach (var t in fruitEnterTriggerComponents)
            t.gameObject.SetActive(true);
    }
    internal List<FruitEnterTriggerComponent> GetFruits()
    {
        return fruitEnterTriggerComponents;
    }
}

[Serializable]
public class LevelDescription
{
    public List<TileObj> blocktTiles = new List<TileObj>();
    public List<TileObj> appleTiles = new List<TileObj>();
    public TileObj tractorPos;
    public int CountOfFruits => appleTiles.Count;
}
