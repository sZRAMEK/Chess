using Assets.Enums;
using Assets.Scripts;
using Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript1 : MonoBehaviour
{
    public GameObject WHITEMARK;
    public GameObject BLACKMARK;
    public GameObject KnightTemplate;

    public Game gra;
    List<GameObject> instantions = new List<GameObject>();


    void Start()
        {
        List<IFigure> chessSet = new List<IFigure>();
        chessSet.Add(new King(new Position(1, 1), Scripts.Figures.Color.Black));
        chessSet.Add(new King(new Position(5, 7), Scripts.Figures.Color.White));
        IBoard board = new Board(chessSet, 8);
        HumanConsolePlayer player1 = new HumanConsolePlayer(board, new MoveParser(), new Timer(5),Scripts.Figures.Color.Black);
        HumanConsolePlayer player2 = new HumanConsolePlayer(board, new MoveParser(), new Timer(5),Scripts.Figures.Color.White);

        gra = new Game(player1, player2, board);

        DrawBoard(gra.GetBoardDescription());

    }

    public void GetMessage(string message)
    {
        Debug.Log(message);
        try
        {

            gra.MakeMove(message);

        }
        catch (InvalidGameSteupException ex)
        {
            Debug.Log(ex.Message + " " + message);
        }
        catch (InvalidInputException ex)
        {
            Debug.Log(ex.Message + " " + message);
        }
        catch (InvalidMoveException ex )
        {
            Debug.Log(ex.Message + " " + message);
        }
        
        DrawBoard(gra.GetBoardDescription());
    }

    private void DrawBoard(string desc)
    {
        string[] boardinfo = desc.Split('/');
        if (boardinfo[0] == "White")
        {
            BLACKMARK.GetComponent<SpriteRenderer>().enabled = false;
            WHITEMARK.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            BLACKMARK.GetComponent<SpriteRenderer>().enabled = true;
            WHITEMARK.GetComponent<SpriteRenderer>().enabled = false;
        }




        Debug.Log(desc);
        string[] FIGURY = boardinfo[1].Split('.');

        foreach (var item in instantions)
        {
            GameObject.Destroy(item);
        }


        foreach (var item in FIGURY)
        {
            string[] dane = item.Split(',');
            createobiect(dane);
            
        }
    }

    private void createobiect(string[] v)
    {
        

       instantions.Add(Instantiate(KnightTemplate, new Vector3(int.Parse(v[0]), int.Parse(v[1]), -1),Quaternion.identity));
    }
}

