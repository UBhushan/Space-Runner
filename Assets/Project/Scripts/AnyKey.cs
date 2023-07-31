using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnyKey : MonoBehaviour
{
    [SerializeField] int nextSceneIndex = 1;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
