using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Chessman : MonoBehaviour
{
    public GameObject controller;
    public GameObject controller1;
    public GameObject movePlate;

    private int value;

    private int xBoard = -1;
    private int yBoard = -1;

    private string player;
    private string pawnSwitch;

    public Sprite Black_Bishop, Black_Queen, Black_Knight, Black_Pawn, Black_King, Black_Rook;
    public Sprite White_Bishop, White_Queen, White_Knight, White_Pawn, White_King, White_Rook;

    public int moves = 0;
    public int k = 0;
    public int Y = 0;
    public int X = 0;
    public int ok;
    public int ok_click = 0;

    public void Activate()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        SetCoords();

        switch (this.name)
        {
            case "Black_Rook1": this.GetComponent<SpriteRenderer>().sprite = Black_Rook; player = "black"; break;
            case "Black_Queen": this.GetComponent<SpriteRenderer>().sprite = Black_Queen; player = "black"; break;
            case "Black_Bishop": this.GetComponent<SpriteRenderer>().sprite = Black_Bishop; player = "black"; break;
            case "Black_Knight": this.GetComponent<SpriteRenderer>().sprite = Black_Knight; player = "black"; break;
            case "Black_Pawn": this.GetComponent<SpriteRenderer>().sprite = Black_Pawn; player = "black"; break;
            case "Black_King": this.GetComponent<SpriteRenderer>().sprite = Black_King; player = "black"; break;
            case "Black_Rook": this.GetComponent<SpriteRenderer>().sprite = Black_Rook; player = "black"; break;
            case "White_Bishop": this.GetComponent<SpriteRenderer>().sprite = White_Bishop; player = "white"; break;
            case "White_Queen": this.GetComponent<SpriteRenderer>().sprite = White_Queen; player = "white"; break;
            case "White_Knight": this.GetComponent<SpriteRenderer>().sprite = White_Knight; player = "white"; break;
            case "White_Pawn": this.GetComponent<SpriteRenderer>().sprite = White_Pawn; player = "white"; break;
            case "White_King": this.GetComponent<SpriteRenderer>().sprite = White_King; player = "white"; break;
            case "White_Rook": this.GetComponent<SpriteRenderer>().sprite = White_Rook; player = "white"; break;
            case "White_Rook1": this.GetComponent<SpriteRenderer>().sprite = White_Rook; player = "white"; break;
        }
    }

    public void SetCoords()
    {
        float x = xBoard;
        float y = yBoard;

        x *= 0.66f;
        y *= 0.66f;

        x += -2.3f;
        y += -2.3f;

        this.transform.position = new Vector3(x, y, -1.0f);
    }

    public int GetXBoard()
    {
        return xBoard;
    }

    public int GetYBoard()
    {
        return yBoard;
    }

    public int GetMoves()
    {
        return moves;
    }

    public void SetXBoard(int x)
    {
        xBoard = x;
    }

    public void SetYBoard(int y)
    {
        yBoard = y;
    }

    private void OnMouseUp()
    {
        if(!controller.GetComponent<Game>().IsGameOver() && controller.GetComponent<Game>().GetCurrentPlayer() == player)
        {
            DestroyMovePlates();
            InitiateMovePlates();
        }
    }

    public void DestroyMovePlates()
    {
        GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");
        for(int i = 0;i < movePlates.Length;i++)
        {
            Destroy(movePlates[i]);
        }
    }

    public void InitiateMovePlates()
    {
        switch (this.name)
        {
            case "Black_Queen":
                value = -90;
                LineMovePlate(1, 0);
                LineMovePlate(0, 1);
                LineMovePlate(1, 1);
                LineMovePlate(-1, 0);
                LineMovePlate(0, -1);
                LineMovePlate(-1, -1);
                LineMovePlate(-1, 1);
                LineMovePlate(1, -1);
                break;
            case "White_Queen":
                value = 90;
                LineMovePlate(1, 0);
                LineMovePlate(0, 1);
                LineMovePlate(1, 1);
                LineMovePlate(-1, 0);
                LineMovePlate(0, -1);
                LineMovePlate(-1, -1);
                LineMovePlate(-1, 1);
                LineMovePlate(1, -1);
                break;
            case "Black_Knight":
                value = -30;
                LMovePlate();
                break;
            case "White_Knight":
                value = 30;
                LMovePlate();
                break;
            case "Black_Bishop":
                value = -30;
                LineMovePlate(1, 1);
                LineMovePlate(1, -1);
                LineMovePlate(-1, 1);
                LineMovePlate(-1, -1);
                break;
            case "White_Bishop":
                value = -30;
                LineMovePlate(1, 1);
                LineMovePlate(1, -1);
                LineMovePlate(-1, 1);
                LineMovePlate(-1, -1);
                break;
            case "Black_King":
                value = -900;
                Y = yBoard;
                X = xBoard;
                SurroundMovePlate();
                if (moves == 0)
                {
                    BlackCastling();
                }
                break;
            case "White_King":
                value = 900;
                Y = yBoard;
                X = xBoard;
                SurroundMovePlate();
                if(moves == 0)
                {
                    WhiteCastling();
                }
                break;
            case "Black_Rook":
            case "Black_Rook1":
                value = -50;
                Y = yBoard;
                X = xBoard;
                LineMovePlate(1, 0);
                LineMovePlate(0, 1);
                LineMovePlate(-1, 0);
                LineMovePlate(0, -1);
                break;
            case "White_Rook1":
            case "White_Rook":
                value = 50;
                Y = yBoard;
                X = xBoard;
                LineMovePlate(1, 0);
                LineMovePlate(0, 1);
                LineMovePlate(-1, 0);
                LineMovePlate(0, -1);
                break;
            case "Black_Pawn":
                value = -10;
                Y = yBoard;
                if (yBoard == 0)
                {
                    BlackSwitch();
                }
                if (moves == 0)
                {
                    StartPawnMovePlate(0, -1);
                }
                PawnMovePlate(xBoard, yBoard - 1);
                break;
            case "White_Pawn":
                value = 10;
                Y = yBoard;
                ok_click = moves;
                if(yBoard == 7)
                {
                    WhiteSwitch();
                }
                if (moves == 0)
                {
                    StartPawnMovePlate(0, 1);
                }
                PawnMovePlate(xBoard, yBoard + 1);
                break;
            }   
    }

    public void WhiteSwitch()
    {
        GameObject.FindGameObjectWithTag("WhiteQueen").GetComponent<Button>().enabled = true;
        GameObject.FindGameObjectWithTag("WhiteRook").GetComponent<Button>().enabled = true;
        GameObject.FindGameObjectWithTag("WhiteKnight").GetComponent<Button>().enabled = true;
        GameObject.FindGameObjectWithTag("WhiteBishop").GetComponent<Button>().enabled = true;
        GameObject.FindGameObjectWithTag("WhiteQueen").GetComponent<Image>().enabled = true;
        GameObject.FindGameObjectWithTag("WhiteRook").GetComponent<Image>().enabled = true;
        GameObject.FindGameObjectWithTag("WhiteKnight").GetComponent<Image>().enabled = true;
        GameObject.FindGameObjectWithTag("WhiteBishop").GetComponent<Image>().enabled = true;
        GameObject.FindGameObjectWithTag("Choose").GetComponent<Text>().enabled = true;
        GameObject s = GameObject.Find("WhitePawnSwitch");
        PawnSwitch pawnswitch = s.GetComponent<PawnSwitch>();
        string piece = pawnswitch.getPiece();
        ok = 0;
        switch (piece)
        {
            case "White_Bishop": ok = 1; this.GetComponent<SpriteRenderer>().sprite = White_Bishop; this.name = "White_Bishop"; break;
            case "White_Queen": ok = 1; this.GetComponent<SpriteRenderer>().sprite = White_Queen; this.name = "White_Queen"; break;
            case "White_Knight": ok = 1; this.GetComponent<SpriteRenderer>().sprite = White_Knight; this.name = "White_Knight"; break;
            case "White_Rook": ok = 1; this.GetComponent<SpriteRenderer>().sprite = White_Rook; this.name = "White_Rook"; break;
        }
        if(ok == 1)
        {
            GameObject.FindGameObjectWithTag("WhiteQueen").GetComponent<Button>().enabled = false;
            GameObject.FindGameObjectWithTag("WhiteRook").GetComponent<Button>().enabled = false;
            GameObject.FindGameObjectWithTag("WhiteKnight").GetComponent<Button>().enabled = false;
            GameObject.FindGameObjectWithTag("WhiteBishop").GetComponent<Button>().enabled = false;
            GameObject.FindGameObjectWithTag("WhiteQueen").GetComponent<Image>().enabled = false;
            GameObject.FindGameObjectWithTag("WhiteRook").GetComponent<Image>().enabled = false;
            GameObject.FindGameObjectWithTag("WhiteKnight").GetComponent<Image>().enabled = false;
            GameObject.FindGameObjectWithTag("WhiteBishop").GetComponent<Image>().enabled = false;
            GameObject.FindGameObjectWithTag("Choose").GetComponent<Text>().enabled = false;
        }
        
    }

    public void BlackSwitch()
    {
        GameObject.FindGameObjectWithTag("BlackQueen").GetComponent<Button>().enabled = true;
        GameObject.FindGameObjectWithTag("BlackRook").GetComponent<Button>().enabled = true;
        GameObject.FindGameObjectWithTag("BlackKnight").GetComponent<Button>().enabled = true;
        GameObject.FindGameObjectWithTag("BlackBishop").GetComponent<Button>().enabled = true;
        GameObject.FindGameObjectWithTag("BlackQueen").GetComponent<Image>().enabled = true;
        GameObject.FindGameObjectWithTag("BlackRook").GetComponent<Image>().enabled = true;
        GameObject.FindGameObjectWithTag("BlackKnight").GetComponent<Image>().enabled = true;
        GameObject.FindGameObjectWithTag("BlackBishop").GetComponent<Image>().enabled = true;
        GameObject.FindGameObjectWithTag("Choose").GetComponent<Text>().enabled = true;
        GameObject s = GameObject.Find("BlackPawnSwitch");
        PawnSwitch pawnswitch = s.GetComponent<PawnSwitch>();
        string piece = pawnswitch.getPiece();
        ok = 0;
        switch (piece)
        {
            case "Black_Bishop": ok = 1; this.GetComponent<SpriteRenderer>().sprite = Black_Bishop; this.name = "Black_Bishop"; break;
            case "Black_Queen": ok = 1; this.GetComponent<SpriteRenderer>().sprite = Black_Queen; this.name = "Black_Queen"; break;
            case "Black_Knight": ok = 1; this.GetComponent<SpriteRenderer>().sprite = Black_Knight; this.name = "Black_Knight"; break;
            case "Black_Rook": ok = 1; this.GetComponent<SpriteRenderer>().sprite = Black_Rook; this.name = "Black_Rook"; break;
        }
        if (ok == 1)
        {
            GameObject.FindGameObjectWithTag("BlackQueen").GetComponent<Button>().enabled = false;
            GameObject.FindGameObjectWithTag("BlackRook").GetComponent<Button>().enabled = false;
            GameObject.FindGameObjectWithTag("BlackKnight").GetComponent<Button>().enabled = false;
            GameObject.FindGameObjectWithTag("BlackBishop").GetComponent<Button>().enabled = false;
            GameObject.FindGameObjectWithTag("BlackQueen").GetComponent<Image>().enabled = false;
            GameObject.FindGameObjectWithTag("BlackRook").GetComponent<Image>().enabled = false;
            GameObject.FindGameObjectWithTag("BlackKnight").GetComponent<Image>().enabled = false;
            GameObject.FindGameObjectWithTag("BlackBishop").GetComponent<Image>().enabled = false;
            GameObject.FindGameObjectWithTag("Choose").GetComponent<Text>().enabled = false;
        }
    }

    public void WhiteCastling()
    {
        Game sc = controller.GetComponent<Game>();
        if (sc.PositionOnBoard(xBoard + 1, yBoard) && sc.GetPosition(xBoard + 1, yBoard) == null && sc.PositionOnBoard(xBoard + 2, yBoard) && sc.GetPosition(xBoard + 2, yBoard) == null)
        {
            GameObject rook = GameObject.Find("White_Rook");
            Chessman chessman = rook.GetComponent<Chessman>();
            
            if (chessman.moves == 0)
            {
                PointMovePlate(xBoard + 2, yBoard - 0);
            }
        }
        if (sc.PositionOnBoard(xBoard - 1, yBoard) && sc.GetPosition(xBoard - 1, yBoard) == null && sc.PositionOnBoard(xBoard - 2, yBoard) && sc.GetPosition(xBoard - 2, yBoard) == null && sc.PositionOnBoard(xBoard - 3, yBoard) && sc.GetPosition(xBoard - 3, yBoard) == null)
        {
            GameObject rook = GameObject.Find("White_Rook1");
            Chessman chessman = rook.GetComponent<Chessman>();
            if (chessman.moves == 0)
            {
                PointMovePlate(xBoard - 2, yBoard - 0);
            }
        }
    }

    public void BlackCastling()
    {
        Game sc = controller.GetComponent<Game>();
        if (sc.PositionOnBoard(xBoard + 1, yBoard) && sc.GetPosition(xBoard + 1, yBoard) == null && sc.PositionOnBoard(xBoard + 2, yBoard) && sc.GetPosition(xBoard + 2, yBoard) == null)
        {
            GameObject rook = GameObject.Find("Black_Rook");
            Chessman chessman = rook.GetComponent<Chessman>();
            if (chessman.moves == 0)
            {
                PointMovePlate(xBoard + 2, yBoard - 0);
            }
        }
        if (sc.PositionOnBoard(xBoard - 1, yBoard) && sc.GetPosition(xBoard - 1, yBoard) == null && sc.PositionOnBoard(xBoard - 2, yBoard) && sc.GetPosition(xBoard - 2, yBoard) == null && sc.PositionOnBoard(xBoard - 3, yBoard) && sc.GetPosition(xBoard - 3, yBoard) == null)
        {
            GameObject rook = GameObject.Find("Black_Rook1");
            Chessman chessman = rook.GetComponent<Chessman>();
            if (chessman.moves == 0)
            {
                PointMovePlate(xBoard - 2, yBoard - 0);
            }
        }
    }

    static int ok_white = 0;
    static int ok_black = 0;
    static int i = 0;
    static int j = 0;

    void Update()
    {
        X = xBoard;
        Y = yBoard;
        ok_click = moves;
        controller = GameObject.FindGameObjectWithTag("GameController");
        if (ok_white == 0)
        {
            GameObject king = GameObject.Find("White_King");
            Chessman chessman = king.GetComponent<Chessman>();
            if (chessman == null)
            {
                return;
            }
            if (chessman.xBoard == 6 && chessman.moves == 1 && chessman.yBoard == 0)
            {
                GameObject rook = GameObject.Find("White_Rook");
                Chessman chessrook = rook.GetComponent<Chessman>();
                if(chessrook.moves == 0 && i == 0)
                {
                    GameObject cp1 = controller.GetComponent<Game>().GetPosition(chessrook.xBoard, chessrook.yBoard);
                    Destroy(cp1);
                    GameObject new_Rook1 = controller.GetComponent<Game>().Create("White_Rook", 5, 0);
                    i++;
                    ok_white = 1;
                    controller.GetComponent<Game>().SetPosition(new_Rook1);
                }
            }
        }
        if(ok_white == 0)
        {
            GameObject king1 = GameObject.Find("White_King");
            Chessman chessman1 = king1.GetComponent<Chessman>();
            if (chessman1 == null)
            {
                return;
            }
            if (chessman1.xBoard == 2 && chessman1.moves == 1 && chessman1.yBoard == 0)
            {
                GameObject rook1 = GameObject.Find("White_Rook1");
                Chessman chessrook1 = rook1.GetComponent<Chessman>();
                if (chessrook1.moves == 0 && i == 0)
                {
                    GameObject cp2 = controller.GetComponent<Game>().GetPosition(chessrook1.xBoard, chessrook1.yBoard);
                    Destroy(cp2);
                    GameObject new_Rook2 = controller.GetComponent<Game>().Create("White_Rook1", 3, 0);
                    i++;
                    ok_white = 1;
                    controller.GetComponent<Game>().SetPosition(new_Rook2);
                }
            }
        }
        if (ok_black == 0)
        {
            GameObject king2 = GameObject.Find("Black_King");
            Chessman chessman2 = king2.GetComponent<Chessman>();
            if (chessman2 == null)
            {
                return;
            }
            if (chessman2.xBoard == 6 && chessman2.moves == 1 && chessman2.yBoard == 7)
            {
                GameObject rook2 = GameObject.Find("Black_Rook");
                Chessman chessrook3 = rook2.GetComponent<Chessman>();
                if (chessrook3.moves == 0 && j == 0)
                {
                    GameObject cp1 = controller.GetComponent<Game>().GetPosition(chessrook3.xBoard, chessrook3.yBoard);
                    Destroy(cp1);
                    GameObject new_Rook1 = controller.GetComponent<Game>().Create("Black_Rook", 5, 7);
                    j++;
                    ok_black = 1;
                    controller.GetComponent<Game>().SetPosition(new_Rook1);
                }
            }
        }
        if (ok_black == 0)
        {
            GameObject king3 = GameObject.Find("Black_King");
            Chessman chessman3 = king3.GetComponent<Chessman>();
            if (chessman3 == null)
            {
                return;
            }
            if (chessman3.xBoard == 2 && chessman3.moves == 1 && chessman3.yBoard == 7)
            {
                GameObject rook3 = GameObject.Find("Black_Rook1");
                Chessman chessrook4 = rook3.GetComponent<Chessman>();
                if (chessrook4.moves == 0 && j == 0)
                {
                    GameObject cp2 = controller.GetComponent<Game>().GetPosition(chessrook4.xBoard, chessrook4.yBoard);
                    Destroy(cp2);
                    GameObject new_Rook2 = controller.GetComponent<Game>().Create("Black_Rook1", 3, 7);
                    j++;
                    ok_black = 1;
                    controller.GetComponent<Game>().SetPosition(new_Rook2);
                }
            }
        }
    }

    public void LineMovePlate(int xIncrement,int yIncrement)
    {
        Game sc = controller.GetComponent<Game>();

        int x = xBoard + xIncrement;

        int y = yBoard + yIncrement;

        while(sc.PositionOnBoard(x,y) && sc.GetPosition(x,y) == null)
        {
            MovePlateSpawn(x, y);
            x += xIncrement;
            y += yIncrement;
        }

        if(sc.PositionOnBoard(x,y) && sc.GetPosition(x,y).GetComponent<Chessman>().player != player)
        {
            MovePlateAttackSpawn(x, y);
        }

    }
    
    public void StartPawnMovePlate(int xIncrement, int yIncrement)
    { 

        Game sc = controller.GetComponent<Game>();

        int x = xBoard + xIncrement;

        int y = yBoard + yIncrement;

        while (sc.PositionOnBoard(x, y) && sc.GetPosition(x, y) == null && k<2)
        {
            StarPawnMovePlateSpawn(x, y);
            x += xIncrement;
            y += yIncrement;
            k += 1;
        }
        k = 0;
    }

    public void StarPawnMovePlateSpawn(int matrixX, int matrixY)
    {
        float x = matrixX;
        float y = matrixY;
        float b = matrixY;

        x *= 0.66f;
        y *= 0.66f;

        x += -2.3f;
        y += -2.3f;

        GameObject mp = Instantiate(movePlate, new Vector3(x, y, -3.0f), Quaternion.identity);

        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.SetReference(gameObject);
        mpScript.SetCoords(matrixX, matrixY);
    }

    public void LMovePlate()
    {
        PointMovePlate(xBoard + 1, yBoard + 2);
        PointMovePlate(xBoard - 1, yBoard + 2);
        PointMovePlate(xBoard + 2, yBoard + 1);
        PointMovePlate(xBoard + 2, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard - 2);
        PointMovePlate(xBoard - 1, yBoard - 2);
        PointMovePlate(xBoard - 2, yBoard + 1);
        PointMovePlate(xBoard - 2, yBoard - 1);
    }

    public void SurroundMovePlate()
    {
        PointMovePlate(xBoard, yBoard + 1);
        PointMovePlate(xBoard, yBoard - 1);
        PointMovePlate(xBoard -1, yBoard - 1);
        PointMovePlate(xBoard -1, yBoard - 0);
        PointMovePlate(xBoard -1, yBoard + 1);
        PointMovePlate(xBoard + 1, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard - 0);
        PointMovePlate(xBoard + 1, yBoard + 1);
    }

    public void PointMovePlate(int x,int y)
    {
        Game sc = controller.GetComponent<Game>();
        if(sc.PositionOnBoard(x,y))
        {
            GameObject cp = sc.GetPosition(x, y);

            if(cp == null)
            {
                MovePlateSpawn(x, y);
            }
            else if(cp.GetComponent<Chessman>().player != player)
            {
                MovePlateAttackSpawn(x, y);
            }
        }
    }

    public void PawnMovePlate(int x, int y)
    {
        Game sc = controller.GetComponent<Game>();
        if (sc.PositionOnBoard(x, y))
        {
            if (sc.GetPosition(x,y) == null)
            {
                MovePlateSpawn(x, y);
            }
            if (sc.PositionOnBoard(x + 1, y) && sc.GetPosition(x + 1, y) != null && sc.GetPosition(x + 1, y).GetComponent<Chessman>().player != player)
            {
                MovePlateAttackSpawn(x + 1, y);
            }
             
            if (sc.PositionOnBoard(x - 1, y) && sc.GetPosition(x - 1, y) != null && sc.GetPosition(x - 1, y).GetComponent<Chessman>().player != player )
            {
                MovePlateAttackSpawn(x - 1, y);
            }
        }
    }

    public void MovePlateSpawn(int matrixX,int matrixY)
    {
        float x = matrixX;
        float y = matrixY;

        x *= 0.66f;
        y *= 0.66f;

        x += -2.3f;
        y += -2.3f;
        
        GameObject mp = Instantiate(movePlate,new Vector3(x,y,-3.0f), Quaternion.identity);

        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.SetReference(gameObject);
        mpScript.SetCoords(matrixX, matrixY);
    }

    public void MovePlateAttackSpawn(int matrixX, int matrixY)
    {
        float x = matrixX;
        float y = matrixY;

        x *= 0.66f;
        y *= 0.66f;

        x += -2.3f;
        y += -2.3f;

        GameObject mp = Instantiate(movePlate, new Vector3(x, y, -3.0f), Quaternion.identity);

        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.attack = true;
        mpScript.SetReference(gameObject);
        mpScript.SetCoords(matrixX, matrixY);
    }
}