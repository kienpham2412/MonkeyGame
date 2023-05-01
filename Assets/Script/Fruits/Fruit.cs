using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fruit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        TriggerFruitEffect();
    }

    public abstract void TriggerFruitEffect();
}
