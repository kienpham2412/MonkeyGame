using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider energySlider;
    public float Value { get => energySlider.value; set => energySlider.value = value; }
    public float MaxValue { get => energySlider.maxValue; set => energySlider.maxValue = value; }

    public void SetInitialValue(float maxValue, float value)
    {
        MaxValue = maxValue;
        Value = value;
    }

    public void SetValue(float value)
    {
        energySlider.value = value;
    }
}
