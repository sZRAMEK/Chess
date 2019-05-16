using Assets.Scripts;
using Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript1 : MonoBehaviour
{

    public GameObject KnightTemplate;

    public Game gra;
    List<GameObject> instantions = new List<GameObject>();


    void Start()
        {
        List<IFigure> chessSet = new List<IFigure>();
        chessSet.Add(new King(new Position(1, 1), Scripts.Figures.Color.Black));
        chessSet.Add(new King(new Position(5, 7), Scripts.Figures.Color.White));

        HumanConsolePlayer player1 = new HumanConsolePlayer(new Board(chessSet, 8), new MoveParser(), new Timer(5),Scripts.Figures.Color.Black);
        HumanConsolePlayer player2 = new HumanConsolePlayer(new Board(chessSet, 8), new MoveParser(), new Timer(5),Scripts.Figures.Color.White);

        IBoard board = new Board(chessSet, 8);


        gra = new Game(player1, player2, board);


        DrawBoard(gra.GetBoardDescription());

        
        


    }

    public void GetMessage(string message)
    {
        Debug.Log(message);
        try
        {

        gra.GameLoop(message);

        }
        catch (Exception ex)
        {

            Debug.Log(ex.Message);
        }
        DrawBoard(gra.GetBoardDescription());
    }

    private void DrawBoard(string desc)
    {
        Debug.Log(desc);
        string[] FIGURY = desc.Split('.');

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

