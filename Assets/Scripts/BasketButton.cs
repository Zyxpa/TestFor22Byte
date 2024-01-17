using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BasketButton : Button
{
    [SerializeField] private FruitController.TypesOfFruit fruitType;

    public FruitController.TypesOfFruit FruitType => fruitType;

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
    }

    private void Awake()
    {
        base.Awake();
        //fruit = new FruitController(FruitController.TypesOfFruit.apple);
    }
}
