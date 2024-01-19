using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Tilemaps;

public class LevelController : MonoBehaviour
{
    //[SerializeField] private string curentLevelName;
    [SerializeField] Tilemap blockTilemap;
    [SerializeField] Tilemap appleTilemap;
    [SerializeField] Tilemap tractorPos;
    [SerializeField] LevelDescription level;

    List<GameObject> blocks = new List<GameObject>();
    List<FruitEnterTriggerComponent> fruitEnterTriggerComponents = new List<FruitEnterTriggerComponent>();
    TractorController tractor;

    [ContextMenu("SaveAsset")]
    public void SaveAsset()
    {
        GetObjectFromTilemap<MeshRenderer>(blockTilemap, ref level.blocktTiles);
        GetObjectFromTilemap<MeshRenderer>(appleTilemap, ref level.appleTiles);
        GetObjectFromTilemap<TractorController>(tractorPos, ref level.tractorPos);
    }
    private void GetObjectFromTilemap<T>(Tilemap tilemap, ref List<TileObj> result) where T : Component
    {
        var objects = tilemap.GetComponentsInChildren<T>().ToList();

        foreach (var t in objects)
        {
            var v = new TileObj(t.gameObject.transform.position);
            result.Add(v);
        }
    }

    public async Task<LevelDescription> LoadLevelAsync(string levelName)
    {
        level = await Addressables.LoadAssetAsync<LevelDescription>(levelName).Task;
        foreach (var t in level.blocktTiles)
            blocks.Add(Instantiate(level.blockPrefub, t.position, new Quaternion(), blockTilemap.transform));
        foreach (var t in level.appleTiles)
            fruitEnterTriggerComponents.Add(Instantiate(level.applePrefub, t.position, new Quaternion(), appleTilemap.transform));
        foreach (var t in level.tractorPos)
            tractor = Instantiate(level.tractorPrefub, t.position, Quaternion.Euler(new Vector3(0, 90, 0)), appleTilemap.transform);

        tractor.SetMap(blockTilemap);
        return level;
    }

    [ContextMenu("Load")]
    public async void LoadLevelAsync2()
    {
        await LoadLevelAsync("LevelDescription");
    }
    public void Clear()
    {
        Destroy(tractor.gameObject);
        foreach (var t in fruitEnterTriggerComponents)
            Destroy(t.gameObject);
        fruitEnterTriggerComponents.Clear();
        foreach (var t in blocks)
            Destroy(t.gameObject);
        blocks.Clear();
    }

#if UNITY_EDITOR
    [ContextMenu("Clear")]
    public void ClearOnEditor()
    {
        var val = blockTilemap.GetComponentsInChildren<MeshRenderer>().ToList();
        foreach (var t in val)
            DestroyImmediate(t.gameObject);
        val = appleTilemap.GetComponentsInChildren<MeshRenderer>().ToList();
        foreach(var t in val)
            DestroyImmediate(t.gameObject);
    }
#endif
    public void ReloadLevel(LevelDescription loadedLevel)
    {
        tractor.gameObject.SetActive(false);
        tractor.gameObject.transform.position = level.tractorPos[0].position;
        tractor.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));

        foreach (var t in fruitEnterTriggerComponents)
            t.gameObject.SetActive(true);

        tractor.gameObject.SetActive(true);
    }
    internal List<FruitEnterTriggerComponent> GetFruits()
    {
        return fruitEnterTriggerComponents;
    }
}