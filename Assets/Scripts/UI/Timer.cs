using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Text;
    [SerializeField] UnityEvent TimeEnd;
    float value;
    public void SetMaxVal(float _maxValue)
    {;
        SetValue(_maxValue);
    }
    private void SetValue(float _value)
    {
        value = _value;
        Text.text = string.Format("{0}:{1}", (int)(value/60), value%60);
    }
    private void Start()
    {
        Invoke("Tick", 1f);
    }

    private void Tick()
    {
        SetValue(--value);

        if (value > 0)
            Invoke("Tick", 1f);
        else
            TimeEnd.Invoke();
        
    }
}
