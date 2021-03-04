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
            FormatCommand();
            InvokeCommand(CommandName, null);
            CreateMessage();
        }
        catch
        {
            
        }
    }

    private void FormatCommand()
    {
        CommandName = CommandName.Trim();
        CommandName = CommandName.ToLower();
    }

    private void CreateMessage()
    {
        GameObject newItem = Instantiate(_item, _commandsContainer);
        newItem.GetComponentInChildren<Text>().text = CommandText;
        _inputCommand.text = null;
    }

    private void InvokeCommand(string name, object[] args)
    {
        MethodInfo command = Commands.GetType().GetMethod(CommandName);
        command.Invoke(Commands, null);
    }
}
