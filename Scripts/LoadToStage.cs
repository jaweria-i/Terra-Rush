using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadToStage : MonoBehaviour
{
    

    void Start()
    {
        StartCoroutine(LoadLevel());
    }


    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(3);
      
      
        SceneManager.LoadScene(1);
    }
}
