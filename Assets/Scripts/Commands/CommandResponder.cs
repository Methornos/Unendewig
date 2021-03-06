using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class CommandResponder : MonoBehaviour, IMessaging
{
    [SerializeField]
    private GameObject _item = default;
    [SerializeField]
    private RectTransform _commandsContainer = default;

    private Responses Responses = default;

    public string RespondName = default;
    public string RespondText = default;

    private void Awake()
    {
        Responses = GetComponent<Responses>();
    }

    public void Respond()
    {
        InvokeRespond(RespondName, null);
        CreateMessage(RespondText);
    }

    public void CreateMessage(string name)
    {
        GameObject newItem = Instantiate(_item, _commandsContainer);
        newItem.GetComponentInChildren<Text>().text = name;
    }

    public void InvokeRespond(string name, object[] args)
    {
        MethodInfo command = Responses.GetType().GetMethod(name);
        command.Invoke(Responses, null);
    }
}
