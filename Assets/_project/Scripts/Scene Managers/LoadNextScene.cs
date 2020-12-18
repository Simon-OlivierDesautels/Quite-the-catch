using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    public void NextScene()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        int sceneIndex = activeScene.buildIndex;
        SceneManager.LoadScene(sceneIndex + 1);
    }
}
