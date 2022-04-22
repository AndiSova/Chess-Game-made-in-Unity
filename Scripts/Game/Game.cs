using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public GameObject chesspiece;

    private GameObject[,] positions = new GameObject[8, 8];
    private GameObject[] playerBlack = new GameObject[16];
    private GameObject[] playerWhite = new GameObject[16];

    private string currentplayer = "white";

    private bool gameOver = false;
    public GameObject reset;
    public GameObject time;

    void Start()
    {
        Time.timeScale = 1f;

        playerWhite = new GameObject[] { Create("White_Rook1", 0, 0), Create("White_Knight", 1, 0), Create("White_Queen", 3, 0), Create("White_Bishop", 2, 0), Create("White_King", 4, 0), Create("White_Pawn", 0, 1), Create("White_Pawn", 1, 1), Create("White_Pawn", 2, 1), Create("White_Pawn", 3, 1), Create("White_Pawn", 4, 1), Create("White_Pawn", 5, 1), Create("White_Pawn", 6, 1), Create("White_Pawn", 7, 1), Create("White_Bishop", 5, 0), Create("White_Knight", 6, 0), Create("White_Rook", 7, 0) };

        playerBlack = new GameObject[] { Create("Black_Rook1", 0, 7), Create("Black_Knight", 1, 7), Create("Black_Queen", 3, 7), Create("Black_Bishop", 2, 7), Create("Black_King", 4, 7), Create("Black_Pawn", 0, 6), Create("Black_Pawn", 1, 6), Create("Black_Pawn", 2, 6), Create("Black_Pawn", 3, 6), Create("Black_Pawn", 4, 6), Create("Black_Pawn", 5, 6), Create("Black_Pawn", 6, 6), Create("Black_Pawn", 7, 6), Create("Black_Bishop", 5, 7), Create("Black_Knight", 6, 7), Create("Black_Rook", 7, 7) };

        for (int i = 0; i < playerBlack.Length; i++)
        {
            SetPosition(playerBlack[i]);
            SetPosition(playerWhite[i]);
        }

    }

    public GameObject Create(string name, int x, int y)
    {
        GameObject obj = Instantiate(chesspiece, new Vector3(0, 0, -1), Quaternion.identity);
        Chessman cm = obj.GetComponent<Chessman>();
        cm.name = name;
        cm.SetXBoard(x);
        cm.SetYBoard(y);
        cm.Activate();
        return obj;
    }

    public void SetPosition(GameObject obj)
    {
        Chessman cm = obj.GetComponent<Chessman>();

        positions[cm.GetXBoard(), cm.GetYBoard()] = obj;
    }

    public void SetPositionEmpty(int x, int y)
    {
        positions[x, y] = null;
    }

    public GameObject GetPosition(int x, int y)
    {
        return positions[x, y];
    }

    public bool PositionOnBoard(int x, int y)
    {
        if (x < 0 || y < 0 || x >= positions.GetLength(0) || y >= positions.GetLength(1))
        {
            return false;
        }
        return true;
    }

    public string GetCurrentPlayer()
    {
        return currentplayer;
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    public void NextTurn()
    {
        if (currentplayer == "white")
        {
            currentplayer = "black";
        }
        else
        {
            currentplayer = "white";
        }
        reset.GetComponent<CountdownTimer>().Reset();
    }

    public void Update()
    {
        if (time.GetComponent<CountdownTimer>().GetCurrentTime() <= 0)
        {
            if (currentplayer == "white")
            {
                Winner("black");
            }
            else
            {
                Winner("white");
            }
        }

        if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            Scene sceneName = SceneManager.GetActiveScene();
            if (sceneName.name == "PvP")
            {
                Debug.Log("PvP");
                gameOver = false;
                SceneManager.LoadScene("PvP");
            }
            else
            {
                if(sceneName.name == "PvAI")
                {
                    Debug.Log("PvAI");
                    gameOver = false;
                    SceneManager.LoadScene("PvAI");
                }
            }
        }
    }

    public void Winner(string playerWinner)
    {
        gameOver = true;

        GameObject.FindGameObjectWithTag("WinnerText").GetComponent<Text>().enabled = true;

        GameObject.FindGameObjectWithTag("WinnerText").GetComponent<Text>().text = playerWinner + " wins";

        GameObject.FindGameObjectWithTag("RestartText").GetComponent<Text>().enabled = true;
    }
}