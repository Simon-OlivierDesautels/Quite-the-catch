using System;
using UnityEngine;

public class Net : MonoBehaviour
{
  private string _playerInput;
  private string _playerNumber;
  private void Start()
  {
    // _playerInput = transform.parent.GetComponent<PlayerInput>().ReturnPlayerNumber();
    // switch (_playerInput)
    // {
    //   case "Player1 (CoopInputManager)":
    //     _playerNumber = "Player1";
    //     break;
    //   case "Player2 (CoopInputManager)":
    //     _playerNumber = "Player2";
    //     break;
    // }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.GetComponent<Butterfly>())
    {
      FindObjectOfType<PlayersScore>().DefinePlayer(_playerNumber);
      Destroy(other.gameObject);
    }
    
  }
}
