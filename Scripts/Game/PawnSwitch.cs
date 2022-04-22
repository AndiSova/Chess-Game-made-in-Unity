using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnSwitch : MonoBehaviour
{
    private string newPiece;

    public void WhiteRook()
    {
        newPiece = "White_Rook";
    }

    public void WhiteKnight()
    {
        newPiece = "White_Knight";
    }

    public void WhiteQueen()
    {
        newPiece = "White_Queen";
    }

    public void WhiteBishop()
    {
        newPiece = "White_Bishop";
    }

    public void BlackRook()
    {
        newPiece = "Black_Rook";
    }

    public void BlackKnight()
    {
        newPiece = "Black_Knight";
    }

    public void BlackQueen()
    {
        newPiece = "Black_Queen";
    }

    public void BlackBishop()
    {
        newPiece = "Black_Bishop";
    }

    public string getPiece()
    {
        return newPiece;
    }
}
