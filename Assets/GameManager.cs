using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : Singleton<GameManager>
{


    private bool isPaused;
    private PlayerController focusedPlayerController;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    public void TogglePauseState(PlayerController newFocusedPlayerController)
    {
        focusedPlayerController = newFocusedPlayerController;
        
        isPaused = !isPaused;

        ToggleTimeScale();

        UpdateActivePlayerInputs();
        
        SwitchFocusedPlayerControlScheme();
    }

    private void ToggleTimeScale()
    {
        float newTimeScale = 0f;

        switch(isPaused)
        {
            case true:
                newTimeScale = 0f;
                break;

            case false:
                newTimeScale = 1f;
                break;
        }

        Time.timeScale = newTimeScale;
    }

    private void UpdateActivePlayerInputs()
    {
    }
    
    void SwitchFocusedPlayerControlScheme()
    {
        switch(isPaused)
        {
            case true:
                focusedPlayerController.EnablePauseMenuControls();
                break;

            case false:
                focusedPlayerController.EnableGameplayControls();
                break;
        }
    }
    public PlayerController GetFocusedPlayerController()
    {
        return focusedPlayerController;
    }
    
  
}