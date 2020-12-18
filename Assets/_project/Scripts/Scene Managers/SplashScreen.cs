using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    [SerializeField] private int splashScreenDuration;
    private Scene activeScene; 
    
    // Start is called before the first frame update
    void Start()
    {
        activeScene = SceneManager.GetActiveScene();
        Invoke("NextScene", splashScreenDuration);
    }

    private void NextScene()
    {
        int sceneIndex = activeScene.buildIndex;
        SceneManager.LoadScene(sceneIndex + 1);
    }
}
