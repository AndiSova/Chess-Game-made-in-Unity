using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Concede : MonoBehaviour
{
    public GameObject concede;

    public void concedePlayer()
    {
        if (concede.GetComponent<Game>().GetCurrentPlayer() == "white")
        {
            concede.GetComponent<Game>().Winner("black");
        }
        else
        {
            concede.GetComponent<Game>().Winner("white");
        }    
    }
}
