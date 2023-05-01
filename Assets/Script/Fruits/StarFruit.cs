using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFruit : Fruit
{
    public override void TriggerFruitEffect()
    {
        gameObject.SetActive(false);
        GameEvents.Instance.FruitCollideEvent?.Invoke(this);
        Debug.Log("star fruit collided");
    }
}
