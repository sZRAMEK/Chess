using Assets.Enums;
using Assets.Scripts;
using Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public GameObject activeFieldMarker;

    public GameObject winnertext;

    public GameObject Promote;

    void Start()
        {
        List<IPiece> chessSet = new List<IPiece>();
        
       
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

        
        /*
        chessSet.Add(new Rock(new Position(0, 7), Scripts.Figures.Color.White));
        chessSet.Add(new King(new Position(2, 7), Scripts.Figures.Color.Black));
        chessSet.Add(new Rock(new Position(5, 7), Scripts.Figures.Color.Black));
        chessSet.Add(new Knight(new Position(7, 6), Scripts.Figures.Color.Black));
        chessSet.Add(new Knight(new Position(3, 6), Scripts.Figures.Color.White));
        chessSet.Add(new Pawn(new Position(1, 5), Scripts.Figures.Color.White));
        chessSet.Add(new Pawn(new Position(2, 5), Scripts.Figures.Color.White));
        chessSet.Add(new Pawn(new Position(4, 5), Scripts.Figures.Color.Black));
        chessSet.Add(new Pawn(new Position(6, 5), Scripts.Figures.Color.Black));
        chessSet.Add(new Queen(new Position(3, 5), Scripts.Figures.Color.Black));
        chessSet.Add(new Pawn(new Position(3, 4), Scripts.Figures.Color.Black));
        chessSet.Add(new Pawn(new Position(7, 4), Scripts.Figures.Color.Black));
        chessSet.Add(new Pawn(new Position(7, 3), Scripts.Figures.Color.White));
        chessSet.Add(new Queen(new Position(4, 2), Scripts.Figures.Color.White));
        chessSet.Add(new Pawn(new Position(5, 1), Scripts.Figures.Color.White));
        chessSet.Add(new Pawn(new Position(6, 1), Scripts.Figures.Color.White));
        chessSet.Add(new Rock(new Position(4, 0), Scripts.Figures.Color.White));
        chessSet.Add(new King(new Position(6, 0), Scripts.Figures.Color.White));
        */

        IBoard board = new Board(chessSet, 8);
        

        gra = new Game(board);
       
       
        DrawBoard(gra.GetBoardDescription());
    }
    string input;
    Vector3 from;
    Vector3 to;
    string[] xes = new string[] {"A","B","C","D","E","F","G","H" };
    private string winner = "";
    string[] boardinfo = null;

    private void Update()
    {
        if (boardinfo!=null)
        if (winner == "")
        {
            if (boardinfo[3] == "")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    from = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
                Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                activeFieldMarker.transform.position = new Vector3(Math.Max( 0,Math.Min((int)Math.Round(position.x),7)), Math.Max(0, Math.Min((int)Math.Round(position.y), 7)), 0);

                if (Input.GetMouseButtonUp(0))
                {
                    to = activeFieldMarker.transform.position;//Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Debug.Log(Math.Round(from.x) + "/" + Math.Round(from.y) + " " + Math.Round(to.x) + "/" + Math.Round(to.y));
                    GetMessage(xes[(int)Math.Round(from.x)] + (int)Math.Round(from.y + 1) + "," + xes[(int)Math.Round(to.x)] + (int)Math.Round(to.y + 1));
                }
            }
            else
            {
                
                Promote.SetActive(true);
            }
        }
        else
        {
                TextMeshPro textmeshpro = winnertext.GetComponent<TextMeshPro>();
                if (winner == "Tie")
                {
                    textmeshpro.text = $"Tie";
                    winnertext.SetActive(true);
                }
                else
                {
                    
                    textmeshpro.text = $"{winner} win!";
                    winnertext.SetActive(true);
                }
                 
        }

    }


    public void GetMessage(string message)
    {
        Promote.SetActive(false);
        Debug.Log(message);
        try
        {
            gra.MakeMove(message);
        }
        catch (Exception)
        {

            throw;
        }
            

        DrawBoard(gra.GetBoardDescription());
    }

    private void DrawBoard(string desc)
    {
        boardinfo = desc.Split('/');
        winner = boardinfo[2];
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
            Destroy(item);
        }

        instantions = new List<GameObject>();


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

