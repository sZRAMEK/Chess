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
    public GameObject KnightWhiteTemplate;
    public GameObject KnightBlackTemplate;

    public Game gra;
    List<GameObject> instantions = new List<GameObject>();

    public GameObject WhiteRockTemplate;
    public GameObject BlackRockTemplate;
    public GameObject WhiteBishopTemplate;
    public GameObject BlackBishopTemplate;
    public GameObject WhiteKnightTemplate;
    public GameObject BlackKnightTemplate;

    public GameObject BlackQueenTemplate;
    public GameObject WhiteQueenTemplate;
    public GameObject WhitePawnTemplate;
    public GameObject BlackPawnTemplate;
 
    void Start()
        {
        List<IFigure> chessSet = new List<IFigure>();
        chessSet.Add(new King(new Position(4, 7), Scripts.Figures.Color.Black));
        chessSet.Add(new King(new Position(4, 0), Scripts.Figures.Color.White));

        chessSet.Add(new Queen(new Position(3, 7), Scripts.Figures.Color.Black));
        chessSet.Add(new Queen(new Position(3, 0), Scripts.Figures.Color.White));

        chessSet.Add(new Rock(new Position(0, 0), Scripts.Figures.Color.White));
        chessSet.Add(new Rock(new Position(7, 0), Scripts.Figures.Color.White));
        chessSet.Add(new Rock(new Position(0, 7), Scripts.Figures.Color.Black));
        chessSet.Add(new Rock(new Position(7, 7), Scripts.Figures.Color.Black));

        chessSet.Add(new Bishop(new Position(2, 7), Scripts.Figures.Color.Black));
        chessSet.Add(new Bishop(new Position(5, 7), Scripts.Figures.Color.Black));
        chessSet.Add(new Bishop(new Position(2, 0), Scripts.Figures.Color.White));
        chessSet.Add(new Bishop(new Position(5, 0), Scripts.Figures.Color.White));

        chessSet.Add(new Knight(new Position(1, 7), Scripts.Figures.Color.Black));
        chessSet.Add(new Knight(new Position(6, 7), Scripts.Figures.Color.Black));
        chessSet.Add(new Knight(new Position(1, 0), Scripts.Figures.Color.White));
        chessSet.Add(new Knight(new Position(6, 0), Scripts.Figures.Color.White));

        for (int i = 0; i < 8; i++)
        {
            chessSet.Add(new Pawn(new Position(i, 1), Scripts.Figures.Color.White));
            chessSet.Add(new Pawn(new Position(i, 6), Scripts.Figures.Color.Black));
        }



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
        catch (NoFigureException ex)
        {
            Debug.Log(ex.Message + " " + message);
        }
        catch (OutOfBoundaryException ex)
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

        if (v[3] == "White")
        {
            if (v[2] == "King")
            {
                instantions.Add(Instantiate(KnightWhiteTemplate, new Vector3(int.Parse(v[0]), int.Parse(v[1]), -1), Quaternion.identity));
            }
            else if (v[2] == "Rock")
            {
                instantions.Add(Instantiate(WhiteRockTemplate, new Vector3(int.Parse(v[0]), int.Parse(v[1]), -1), Quaternion.identity));
            }
            else if (v[2] == "Bishop")
            {
                instantions.Add(Instantiate(WhiteBishopTemplate, new Vector3(int.Parse(v[0]), int.Parse(v[1]), -1), Quaternion.identity));
            }
            else if (v[2] == "Knight")
            {
                instantions.Add(Instantiate(WhiteKnightTemplate, new Vector3(int.Parse(v[0]), int.Parse(v[1]), -1), Quaternion.identity));

            }
            else if (v[2] == "Queen")
            {
                instantions.Add(Instantiate(WhiteQueenTemplate, new Vector3(int.Parse(v[0]), int.Parse(v[1]), -1), Quaternion.identity));

            }
            else if (v[2] == "Pawn")
            {
                instantions.Add(Instantiate(WhitePawnTemplate, new Vector3(int.Parse(v[0]), int.Parse(v[1]), -1), Quaternion.identity));

            }


        }
        else
        {
            if (v[2] == "King")
            {
                instantions.Add(Instantiate(KnightBlackTemplate, new Vector3(int.Parse(v[0]), int.Parse(v[1]), -1), Quaternion.identity));
            }
            else if (v[2] == "Rock")
            {
                instantions.Add(Instantiate(BlackRockTemplate, new Vector3(int.Parse(v[0]), int.Parse(v[1]), -1), Quaternion.identity));
            }
            else if (v[2]== "Bishop")
            {
                instantions.Add(Instantiate(BlackBishopTemplate, new Vector3(int.Parse(v[0]), int.Parse(v[1]), -1), Quaternion.identity));
            }
            else if (v[2] == "Knight")
            {
                instantions.Add(Instantiate(BlackKnightTemplate, new Vector3(int.Parse(v[0]), int.Parse(v[1]), -1), Quaternion.identity));

            }
            else if (v[2] == "Queen")
            {
                instantions.Add(Instantiate(BlackQueenTemplate, new Vector3(int.Parse(v[0]), int.Parse(v[1]), -1), Quaternion.identity));

            }
            else if (v[2] == "Pawn")
            {
                instantions.Add(Instantiate(BlackPawnTemplate, new Vector3(int.Parse(v[0]), int.Parse(v[1]), -1), Quaternion.identity));

            }
        }




    }
}

