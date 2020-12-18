using System;
using TMPro;
using UnityEngine;

public class PlayersScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _player1;
    [SerializeField] private TextMeshProUGUI _player2;
    
    
    public void DefinePlayer(String playerNumber)
    {
        switch (playerNumber)
        {
            case "Player1":
                UpdateScore(_player1);
                break;
            case "Player2":
                UpdateScore(_player2);
                break;
        }
    }
    
    private void UpdateScore(TextMeshProUGUI player)
    {
        int currentScore = int.Parse(player.text);
        int newScore = currentScore + 1;
        player.text = newScore.ToString();
    }
}
