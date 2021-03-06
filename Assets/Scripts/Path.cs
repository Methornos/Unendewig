using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public List<Location> Pass = default; //просто массив наших локаций, чтобы были
    public List<int> LocationsId = default; //по этому массиву мы смотрим, есть ли уже такой id, чтобы не создавать заново, когда путь проложен
    public List<int> LastLocationsId = default; //по этому массиву мы выстраиваем путь, как можно вернуться назад

    private Location CurrentLocation = default;

    public void AddLocation(Location location)
    {
        Pass.Add(location);
        LocationsId.Add(location.Id);
        LastLocationsId.Add(location.Id);
        CurrentLocation = Pass[LastLocationsId.Count - 1];
    }

    public void GoBack()
    {
        LastLocationsId.Remove(CurrentLocation.Id);
        CurrentLocation = Pass[LastLocationsId.Count - 1];
    }
}
