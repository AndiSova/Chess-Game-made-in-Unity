using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : MonoBehaviour
{
    public GameObject controller;
    public GameObject reset;
    public GameObject pauseUI;

    GameObject reference = null;

    int matrixX;
    int matrixY;
    private int pause = 0;

    public bool attack = false;

    public void Start()
    {
        if (attack)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
    }

    IEnumerator CoroutineAction()
    {
        yield return new WaitForSeconds(2);
    }

    int i;

    public void Update()
    {
        pauseUI = GameObject.FindGameObjectWithTag("PauseMenu");
        if (pauseUI == null)
        {
            return;
        }
        if (pauseUI.activeSelf)
        {
            pause = 1;
        }
        else
        {
            pause = 0;
        }
    }

    public void OnMouseUp()
    {
        if(pause != 1)
        {
            controller = GameObject.FindGameObjectWithTag("GameController");
            if(attack)
            {
                GameObject cp = controller.GetComponent<Game>().GetPosition(matrixX, matrixY);
                if (cp.name == "White_King")
                {
                    controller.GetComponent<Game>().Winner("black");
                }
                if (cp.name == "Black_King")
                {
                    controller.GetComponent<Game>().Winner("white");
                }
                Destroy(cp);
            }
            controller.GetComponent<Game>().SetPositionEmpty(reference.GetComponent<Chessman>().GetXBoard(), reference.GetComponent<Chessman>().GetYBoard());
            reference.GetComponent<Chessman>().SetXBoard(matrixX);
            reference.GetComponent<Chessman>().SetYBoard(matrixY);
            reference.GetComponent<Chessman>().SetCoords();
            reference.GetComponent<Chessman>().moves++;

            controller.GetComponent<Game>().SetPosition(reference);

            controller.GetComponent<Game>().NextTurn();

            reference.GetComponent<Chessman>().DestroyMovePlates();
        }
    }

    public void SetCoords(int x,int y)
    {
        matrixX = x;
        matrixY = y;
    }

    public void SetReference(GameObject obj)
    {
        reference = obj;
    }

    public GameObject GetReference()
    {
        return reference;
    }
}
