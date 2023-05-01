using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostFruit : Fruit
{
    public override void TriggerFruitEffect()
    {
        gameObject.SetActive(false);
        GameEvents.Instance.FruitCollideEvent?.Invoke(this);
        Debug.Log("frost fruit collided");
    }
}
