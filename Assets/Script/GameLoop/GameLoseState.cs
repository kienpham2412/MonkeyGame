using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Pixelplacement;

public class GameLoseState : State
{
    public void ReloadScene()
    {
        SceneManager.LoadScene("Main");
    }
}
