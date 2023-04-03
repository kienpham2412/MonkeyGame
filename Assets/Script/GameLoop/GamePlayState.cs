using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class GamePlayState : State
{
    public EnegyDrainer enegyDrainer;

    // Start is called before the first frame update
    void Start()
    {
        enegyDrainer.StartDraining();
    }
}
