using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MainStatic;

public class DragAndDrop 
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    enum State { none, drag }

    State state;
    GameObject item;
    Vector2 offset;

    bool blackIsAI = true;

    public Vector2 pickPosition { get; private set; }
    public Vector2 dropPosition { get; private set; }

    public DragAndDrop()
    {
        state = State.none;
        item = null;
    }
    public bool Action()
    {
        switch (state)
        {
            case (State.none):
                if (IsMouseButtonPressed())
                    PickUp();
                break;
            case (State.drag):
                if (IsMouseButtonPressed())
                    Drag();
                else
                { Drop(); return true; }

                break;
        }
        return false;

    }
    bool IsMouseButtonPressed()
    {
        return Input.GetMouseButton(0);
    }

    void PickUp()
    {

        Vector2 clickPosition = GetClickPosition();
        Transform clickedItem = GetItemAt(clickPosition);
        if (clickedItem == null) return;

        
        pickPosition = clickedItem.position;
        if (Main.chess.isWhiteStep() && Main.chess.FigureColorIsWhite(GetSquare(Main.dragAndDrop.pickPosition))||
            !Main.chess.isWhiteStep() && !Main.chess.FigureColorIsWhite(GetSquare(Main.dragAndDrop.pickPosition)))
        {
            item = clickedItem.gameObject;
            ChangeLayerId(item, 2);
            state = State.drag;

            string from = GetSquare(Main.dragAndDrop.pickPosition);
            string figure = Main.chess.GetFigureAt(from).ToString();
            //Debug.Log("#################################: " + figure + " " + from + " "+to);
            Main.scriptBoard.MarkValidMoves(Main.chess, figure, from);
            //MarkValidMoves(chess, figure, from, to);
            offset = pickPosition - clickPosition;
        }
        else
        {
            if(item!=null)
            Drop();
        }
    }

    string GetSquare(Vector2 position)
    {
        int x = Convert.ToInt32(position.x / 2.0);
        int y = Convert.ToInt32(position.y / 2.0);
        return ((char)('a' + x)).ToString() + (y + 1).ToString();
    }


    Transform GetItemAt(Vector2 position)
    {
        RaycastHit2D[] figures = Physics2D.RaycastAll(position, position, 0.5f);
        if (figures.Length == 0)
            return null;
        return figures[0].transform;

    }

    Vector2 GetClickPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    void Drop()
    {
        dropPosition = item.transform.position;
        state = State.none;
        ChangeLayerId(item, 0);
        Main.scriptBoard.DefaultMark();
        item = null;
    }

    void Drag()
    {
        item.transform.position = GetClickPosition() + offset;
    }

    void ChangeLayerId(GameObject temp, int id)
    {
        var spriteBox = temp.GetComponent<SpriteRenderer>();
        spriteBox.sortingOrder = id;
    }
}
