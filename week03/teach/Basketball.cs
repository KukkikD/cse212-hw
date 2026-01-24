/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // ignore header row
        while (!reader.EndOfData) {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var points = int.Parse(fields[8]);
        // ถ้า playerId เคยมีอยู่แล้ว → บวกคะแนนเพิ่ม
            if (players.ContainsKey(playerId))
            {
                players[playerId] += points;
            }
            // ถ้ายังไม่เคยมี → เพิ่มผู้เล่นใหม่
            else
            {
                players[playerId] = points;
            }
        }

        //  convert Dictionary to Array that can be sort the top player
        KeyValuePair<string, int>[] playerArray = players.ToArray();

        // Sort from high to low point 
        Array.Sort(playerArray, (a, b) => b.Value - a.Value);

        // show Top 10 players
        Console.WriteLine("Top 10 Players by Total Points:");
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(
                $"Rank {i + 1}: Player {playerArray[i].Key} - {playerArray[i].Value} points"
            );
        }
    }
}