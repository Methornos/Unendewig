using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class CommandResponder : MonoBehaviour, IMessaging
{
    [SerializeField]
    private GameObject _item = default;
    [SerializeField]
    private RectTransform _commandsContainer = default;

    public string CommandName = default;

    public void Respond()
    {

    }

    public void CreateMessage(string name)
    {
        GameObject newItem = Instantiate(_item, _commandsContainer);
        newItem.GetComponentInChildren<Text>().text = name;
    }
}
