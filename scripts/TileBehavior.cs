using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehavior : MonoBehaviour
{
    [SerializeField]
    private int cordX;

    [SerializeField]
    private int cordY;

    [SerializeField]
    private GameMaster gm;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite rSprite;

    [SerializeField]
    private Sprite xSprite;

    [SerializeField]
    private Sprite oSprite;


    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        char move = gm.turn;
        if (gm.onClick(cordX, cordY))
        {
            ChangeSprite(move);
        }
    }

    public void ChangeSprite(char move)
    {
        if (move == gm.X)
        {
            spriteRenderer.sprite = xSprite;
        }
        else if (move == gm.O)
        {
            spriteRenderer.sprite = oSprite;
        }
        else if (move == 'R')
        {
            spriteRenderer.sprite = rSprite;
        }
    }
}
