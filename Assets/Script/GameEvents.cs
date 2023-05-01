using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Pixelplacement;

public class GameEvents : Singleton<GameEvents>
{
    public UnityAction<Fruit> FruitCollideEvent;
}
