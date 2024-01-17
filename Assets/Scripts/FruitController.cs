using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    public enum TypesOfFruit
    {
        apple, orange, lemon, none
    }

    [SerializeField] private TypesOfFruit type;

    public FruitController(TypesOfFruit a)
    {
        this.type = a;
    }

    public TypesOfFruit Type => type;
}
