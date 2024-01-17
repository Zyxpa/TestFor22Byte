using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EnterTriggerComponent : MonoBehaviour
{
    [SerializeField] EnterEvent action;

    virtual protected void OnTriggerEnter(Collider other)
    {
        action?.Invoke(this.gameObject);
    }

    [Serializable]
    public class EnterEvent: UnityEvent<GameObject> { }

}
