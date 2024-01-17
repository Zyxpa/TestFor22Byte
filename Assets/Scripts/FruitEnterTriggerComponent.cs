using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FruitEnterTriggerComponent : MonoBehaviour
{
    [SerializeField] FruitController fuit;
    [SerializeField] FruitEnterEvent action;
    virtual protected void OnTriggerEnter(Collider other)
    {
        action?.Invoke(fuit);
        this.gameObject.SetActive(false);
    }

    [Serializable]
    public class FruitEnterEvent : UnityEvent<FruitController> { }
}
