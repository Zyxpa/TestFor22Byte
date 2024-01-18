using System;
using UnityEngine;

[Serializable]
public class TileObj 
{
    public Vector3 position;

    public TileObj(Vector3 position)
    {
        this.position = position;
    }

    //public void Set(Vector3 vector, GameObject _prefub)
    //{
    //    pos = vector;
    //    prefub = _prefub;
    //}
}
