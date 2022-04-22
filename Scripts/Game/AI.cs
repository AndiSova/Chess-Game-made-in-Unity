using UnityEngine;
using System.Collections.Generic;
using System.Collections;

//I tried to make it work but it was way to hard and I would have to radically change my entire project which was not something I would have been able to do in the remaining weeks, so I didn't work much more on the AI script and so I deleted most of what I wrote

public class AI : MonoBehaviour
{
    /*GameObject controller;
    public int minimax(Chessman[,] board, int depth, bool maximizingPlayer, bool WhiteToPlay)
    {
        
        if (depth == 0)
        {
            return result;
        }

        var moves = MovePlates();
        if (maximizingPlayer)
        {
            int value = int.MinValue;
            foreach (var move in moves)
            {
                int minmaxResult = minimax(move, depth - 1, false, !WhiteToPlay);
                value = Math.Max(value, minmaxResult);
                if (depth == depthB)
                {
                }
            }
            return value;
        }
        else
        {
            int value = int.MaxValue;
            foreach (var move in moves)
            {
                int minmaxResult = minimax(move, depth - 1, true, !WhiteToPlay);
                value = Math.Min(value, minmaxResult);
                if (depth == depthB)
                {
                }
            }
            return value;
        }
    }*/
}