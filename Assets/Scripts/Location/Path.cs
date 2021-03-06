using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    private LocationGenerator _generator = default;

    private Location CurrentLocation = default;

    public List<Location> Pass = default; //просто массив наших локаций, чтобы были
    public List<Vector2> LocationsPositions = default; //по этому массиву мы смотрим, есть ли уже такой id, чтобы не создавать заново, когда путь проложен
    public List<int> LastLocationsId = default; //по этому массиву мы выстраиваем путь, как можно вернуться назад

    private void Awake()
    {
        _generator = GetComponent<LocationGenerator>();
    }

    public void LocationCheck(string side)
    {
        Vector2 nextPosition = CurrentLocation.Position;
        switch (side)
        {
            case "left":
                nextPosition = new Vector2(nextPosition.x - 1, nextPosition.y);
                break;
            case "forward":
                nextPosition = new Vector2(nextPosition.x, nextPosition.y + 1);
                break;
            case "right":
                nextPosition = new Vector2(nextPosition.x + 1, nextPosition.y);
                break;
        }

        int index = LocationsPositions.IndexOf(nextPosition);

        if (index >= 0) GoOverLocation(index);
        else _generator.GenerateLocation(nextPosition);
    }

    public void AddLocation(Location location)
    {
        Pass.Add(location);
        LocationsPositions.Add(location.Position);
        LastLocationsId.Add(location.Id);

        CurrentLocation = location;
    }

    public void GoOverLocation(int index)
    {
        LastLocationsId.Add(Pass[index].Id);

        CurrentLocation = Pass[index];
    }

    public void GoBack()
    {
        LastLocationsId.Remove(CurrentLocation.Id);
        CurrentLocation = Pass[LastLocationsId[LastLocationsId.Count - 1]];
    }
}
