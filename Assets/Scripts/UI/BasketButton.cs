using UnityEngine;
using UnityEngine.UI;

public class BasketButton : Button
{
    [SerializeField] private FruitController.TypesOfFruit fruitType;

    public FruitController.TypesOfFruit FruitType => fruitType;

}
