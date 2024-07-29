using System;
using UnityEngine;

[RequireComponent(typeof(PieceCreate))]
public class CheeseGameController : MonoBehaviour
{
    [SerializeField] BoardLayer startingBoardLayout;

    [SerializeField] PieceCreate pieceCreate;

    void Awake()=>
        SetDependencies();

    void Start()=>
        StartNewGame();

    void StartNewGame()
    {
        CreatePiecesFromLayout(startingBoardLayout);
    }

    void SetDependencies()
    {
        pieceCreate = GetComponent<PieceCreate>();
    }

    void CreatePiecesFromLayout(BoardLayer Layout)
    {
        for (int i = 0; i < Layout.GetPiecesCount(); i++)
        {
            Vector2Int squareCoords = Layout.GetSquareCoordsAtIndes(i);
            TeamColor team = Layout.GetSquareTeamColorAtIndex(i);
            string typeName = Layout.GetSquarePieceNameAtIndex(i);

            Type type = Type.GetType(typeName);

            CreatePieceAndInitiazlize(squareCoords, team, type);
        }
    }

    void CreatePieceAndInitiazlize(Vector2Int squareCoords, TeamColor team, Type type)
    {
        Piece newPiece = pieceCreate.CreatePiece(type).GetComponent<Piece>();
    }
}
