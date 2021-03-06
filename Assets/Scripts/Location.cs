using System.Collections.Generic;

public class Location
{
    public List<string> AvailableCommands = default;

    public int Id = 0;

    public bool HaveEnemy = false;

    public Location(string[] sides)
    {
        for(int i = 0; i < sides.Length; i++)
        {
            AvailableCommands.Add(sides[i]);
        }
    }
}
