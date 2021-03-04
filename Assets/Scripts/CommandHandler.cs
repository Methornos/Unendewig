using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class CommandHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject _item = default;
    [SerializeField]
    private RectTransform _commandsContainer = default;
    [SerializeField]
    private Text _inputCommand;

    private Commands Commands = default;

    public string CommandName = default;
    public string CommandText = default;

    private void Awake()
    {
        Commands = GetComponent<Commands>();
    }

    public void SetCommandName()
    {
        CommandName = _inputCommand.text;
    }

    public void SendCommand()
    {
        try
        {
            MethodInfo command = GetType().GetMethod(CommandName);
            command.Invoke(Commands, null);
            CreateMessage();
        }
        catch
        {
            Debug.LogError("Incorrect command!");
        }
    }

    private void InvokeMethod(string name, List<object> args)
    {

    }

    private void CreateMessage()
    {
        GameObject newItem = Instantiate(_item, _commandsContainer);
        newItem.GetComponentInChildren<Text>().text = CommandText;
    }
}
