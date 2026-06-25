using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageControls : MonoBehaviour
{
    public void PlayForest()
    {
        SceneManager.LoadScene(4);
    }

    public void PlayDesert()
    {
        SceneManager.LoadScene(3);
    }

    public void PlayWinter()
    {
        SceneManager.LoadScene(5);
    }
}