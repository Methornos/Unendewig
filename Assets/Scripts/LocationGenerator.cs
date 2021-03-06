using System.Collections.Generic;
using UnityEngine;

public class LocationGenerator : MonoBehaviour
{
    private Path _path = default;

    private int _lastId = -1;

    private void Awake()
    {
        _path = GetComponent<Path>();
    }

    public void GenerateLocation()
    {
        string[] sides = GenerateSides();
        Location location = new Location(sides);
        _path.AddLocation(location);
        _lastId++;
    }

    private string[] GenerateSides()
    {
        List<string> sides = new List<string>();

        int left = Random.Range(0, 2);
        if (left == 1)
        {
            sides.Add("Go left");
            sides.Add("To left");
            sides.Add("Left");
        }

        int forward = Random.Range(0, 2);
        if (forward == 1)
        {
            sides.Add("Go forward");
            sides.Add("Forward");
        }

        int right = Random.Range(0, 2);
        if (right == 1)
        {
            sides.Add("Go right");
            sides.Add("To right");
            sides.Add("Right");
        }

        sides.Add("Back");

        return sides.ToArray();
    }
}
