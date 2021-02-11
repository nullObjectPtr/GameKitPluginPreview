using System;
using System.IO;

public class RockPaperScissorsGameState
{
    public int round { get; private set; }
    public int numRounds { get; private set; }
    
    public readonly string[] moves = new string[2];
    public readonly int[] score = new int[2];

    public RockPaperScissorsGameState(){}
    public RockPaperScissorsGameState(int numRounds)
    {
        if (numRounds <= 0)
            throw new ArgumentOutOfRangeException();

        round = 0;
        this.numRounds = numRounds;
        moves[0] = "";
        moves[1] = "";
    }
    
    public void Serialize(BinaryWriter writer)
    {
        writer.Write(round);
        writer.Write(numRounds);
        writer.Write(moves[0]);
        writer.Write(moves[1]);
        writer.Write(score[0]);
        writer.Write(score[1]);
    }

    public void Deserialize(BinaryReader reader)
    {
        round = reader.ReadInt32();
        numRounds = reader.ReadInt32();
        moves[0] = reader.ReadString();
        moves[1] = reader.ReadString();
        score[0] = reader.ReadInt32();
        score[1] = reader.ReadInt32();
    }

    public byte[] toByteArray()
    {
        var memoryStream = new MemoryStream();
        var binaryWriter = new BinaryWriter(memoryStream);
        Serialize(binaryWriter);
        return memoryStream.ToArray();
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
            $"GameState:\n  numRounds:{numRounds}\n round: {round}\n  player1Move:{moves[0]}\n  player2Move:{moves[1]}\n  player1Score:{score[0]}\n  player2Score:{score[1]}";
    }
}
