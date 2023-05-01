using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnegyDrainer : MonoBehaviour
{
    public float maxEnergy;
    public float energy;
    public float drainSpeed;
    public UnityEvent<float, float> OnEneryStartDraining;
    public UnityEvent<float> OnEnergyDraining;
    public UnityEvent OnEnergyDrained;
    private Coroutine drainRoutine;

    public void StartDraining()
    {
        drainRoutine = StartCoroutine(EnergyDrainRoutine());
    }

    private IEnumerator EnergyDrainRoutine()
    {
        OnEneryStartDraining?.Invoke(maxEnergy, energy);
        while (energy >= 0)
        {
            energy -= drainSpeed * Time.deltaTime;
            OnEnergyDraining?.Invoke(energy);
            yield return null;
        }

        OnEnergyDrained?.Invoke();
    }

    public void AddEnegy(float value)
    {
        energy += value;
        energy = Mathf.Clamp(energy, 0, maxEnergy);
    }
}
