using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField]
    TMP_Text p1Label;

    [SerializeField]
    TMP_Text p2Label;

    [SerializeField]
    TMP_Text winnerLabel;

    [SerializeField]
    GameMaster gm;

    private void OnEnable()
    {
        Messenger.AddListener(GameEvent.PLAYER1_SCORE, P1Win);
        Messenger.AddListener(GameEvent.PLAYER2_SCORE, P2Win);
        Messenger.AddListener(GameEvent.RESET, Reset);
        Messenger.AddListener(GameEvent.TIED, Tied);

    }


    private void OnDisable()
    {
        Messenger.RemoveListener(GameEvent.PLAYER1_SCORE, P1Win);
        Messenger.RemoveListener(GameEvent.PLAYER2_SCORE, P2Win);
        Messenger.RemoveListener(GameEvent.RESET, Reset);
        Messenger.RemoveListener(GameEvent.TIED, Tied);

    }

    private void P1Win()
    {
        winnerLabel.text = "Player 1 wins this round!";
        p1Label.text = "Player 1 Score: " + gm.player1Score;
    }

    private void P2Win()
    {
        winnerLabel.text = "Player 2 wins this round!";
        p2Label.text = "Player 2 Score: " + gm.player2Score;
    }

    private void Tied()
    {
        winnerLabel.text = "Tie Game";
    }

    private void Reset()
    {
        winnerLabel.text = " ";
    }
}
