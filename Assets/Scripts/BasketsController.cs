using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static FruitEnterTriggerComponent;

public class BasketsController : MonoBehaviour
{
    [SerializeField] private List<BasketButton> basketButtons;
    private FruitController.TypesOfFruit selectedasketType = FruitController.TypesOfFruit.none;

    [SerializeField]  UnityEvent CorrrectFruit;
    [SerializeField] UnityEvent UnCorrrectFruit;

    private void Start()
    {
        foreach (var basketButton in basketButtons)
            basketButton.onClick.AddListener(delegate { ChangedSelectedBasket(basketButton.FruitType); });
    }
    public void CollectFruits(FruitController fruit)
    {
        //if (selectedasketType == null) return;
        if (fruit.Type == selectedasketType)
            CorrrectFruit.Invoke();
        else
            UnCorrrectFruit.Invoke();
    }

    public void ChangedSelectedBasket(FruitController.TypesOfFruit basketType)
    {
        selectedasketType = basketType;
    }

    //private void CorrrectFruit()
    //{
    //    Debug.Log("Collect");
    //}

    //private void UnCorrrectFruit()
    //{
    //    Debug.Log(" NOO");
    //}
}
