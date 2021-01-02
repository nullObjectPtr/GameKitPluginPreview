using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RockPaperScissorsGameState
{
    public int round { get; private set; }
    public string[] moves = new string[2];
    public int[] score = new int[2];

    public RockPaperScissorsGameState()
    {
        round = 1;
        moves[0] = "";
        moves[1] = "";
    }
    
    public void Serialize(BinaryWriter writer)
    {
        writer.Write(round);
        writer.Write(moves[0]);
        writer.Write(moves[1]);
        writer.Write(score[0]);
        writer.Write(score[1]);
    }

    public void Deserialize(BinaryReader reader)
    {
        round = reader.ReadInt32();
        moves[0] = reader.ReadString();
        moves[1] = reader.ReadString();
        score[0] = reader.ReadInt32();
        score[1] = reader.ReadInt32();
    }

    public bool BothPlayersTookTurns()
    {
        return !string.IsNullOrEmpty(moves[0]) && !string.IsNullOrEmpty(moves[1]);
    }

    public void ClearTurns()
    {
        moves[0] = "";
        moves[1] = "";
    }

    public void NextRound()
    {
        round++;
    }

    public override string ToString()
    {
        return
            $"GameState:\n  round: {round}\n  player1Move:{moves[0]}\n  player2Move{moves[1]}\n  player1Score:{score[0]}\n  player2Score{score[1]}";
    }
}
