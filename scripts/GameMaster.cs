using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField]
    public int player1Score;

    [SerializeField]
    public int player2Score;

    private char[,] boxes = new char [3,3];

    [SerializeField]
    private GameObject[] tiles = new GameObject[9];

    private GameObject outOfNames;

    public char turn;

    public char X = 'X';

    public char O = 'O';

    private char EMPTY = ' ';

    private bool playing;


    void Start()
    {
        player1Score = 0;
        player2Score = 0;
        setBoard();
    }

    public bool onClick(int x, int y)
    {
        if (boxes[x,y] == EMPTY && playing)
        {
            boxes[x,y] = turn;

            if (SomeoneWon())
            {
                if (turn == X)
                {
                    player1Score++;
                    Messenger.Broadcast(GameEvent.PLAYER1_SCORE);
                    playing = false;
                }
                else if (turn == O)
                {
                    player2Score++;
                    Messenger.Broadcast(GameEvent.PLAYER2_SCORE);
                    playing = false;
                }
            }
            else if (IsTied())
            {
                Messenger.Broadcast(GameEvent.TIED);
                playing = false;
            }
            else
            {
                if (turn == X)
                {
                    turn = O;
                }
                else
                {
                    turn = X;
                }
            }
            return true;
        }
        else
        {
            return false;
        }
    }


    public void setBoard()
    {
        Messenger.Broadcast(GameEvent.RESET);
        turn = X;
        playing = true;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                boxes[i, j] = EMPTY;
            }
        }
        foreach (GameObject tile in tiles)
        {
            tile.GetComponent<TileBehavior>().ChangeSprite('R');
        }
    }

    private bool IsTied()
    {
        if (SomeoneWon())
        {
            return false;
        }
        for(int rowIndex = 0;rowIndex < 3; rowIndex++)
        {
            for (int columnIndex = 0; columnIndex < 3; columnIndex++)
            {
                if (boxes[rowIndex, columnIndex] == EMPTY)
                {
                    return false;
                }
            }
        }
        return true;
    }


    private bool SomeoneWon()
    {
        return WonByColumn() || WonByRow() ||  WonByDiagonal();
    }


    private bool WonByRow()
    {
        for (int rowIndex = 0; rowIndex < 3; rowIndex++)
        {
            if (boxes[0, rowIndex] != EMPTY
                    && boxes[0, rowIndex] == boxes[1, rowIndex]
                    && boxes[0, rowIndex] == boxes[2, rowIndex])
            {
                return true;
            }
        }
        return false;
    }


    private bool WonByColumn()
    {
        for (int columnIndex = 0; columnIndex < 3; columnIndex++)
        {
            if (boxes[columnIndex, 0] != EMPTY
                    && boxes[columnIndex, 0] == boxes[columnIndex, 1]
                    && boxes[columnIndex, 0] == boxes[columnIndex, 2])
            {
                return true;
            }
        }
        return false;
    }


    private bool WonByDiagonal()
    {
        return (boxes[1, 1] != EMPTY && (
            (boxes[0, 0] == boxes[1, 1] && boxes[2, 2] == boxes[1, 1])
            || (boxes[2, 0] == boxes[1, 1] && boxes[0, 2] == boxes[1, 1])));
    }
}
