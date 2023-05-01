using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class GamePlayState : State
{
    public EnegyDrainer enegyDrainer;
    public Background background;
    public Animator monkeyAnimator;
    public TreeSpawner treeSpawner;

    private void Awake()
    {
        GameEvents.Instance.FruitCollideEvent = AddEnegy;
    }

    // Start is called before the first frame update
    void Start()
    {
        enegyDrainer.StartDraining();
        background.enabled = true;
        monkeyAnimator.enabled = true;
        treeSpawner.StartSpawning();
    }

    private void AddEnegy(Fruit fruit)
    {
        enegyDrainer.AddEnegy(20);
    }
}
