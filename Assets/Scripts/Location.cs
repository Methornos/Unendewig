using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public List<string> AvailableCommands = default;

    public int Id = 0;

    public Vector2 Position = default;

    public Location(string[] sides, Vector2 position)
    {
        for(int i = 0; i < sides.Length; i++)
        {
            AvailableCommands.Add(sides[i]);
        }

        Position = position;
    }
}
