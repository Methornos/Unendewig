using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class CommandHandler : MonoBehaviour, IMessaging
{
    [Header("Managers"), SerializeField]
    private QuickAccess _quickAccess = default;

    [Space, Header("Components"), SerializeField]
    private GameObject _item = default;
    [SerializeField]
    private RectTransform _commandsContainer = default;
    [SerializeField]
    private InputField _inputCommand = default;
    [SerializeField]
    private Animation _warning = default;

    private Commands Commands = default;
    private CommandResponder _responder = default;

    public string CommandName = default;
    public string CommandText = default;

    private void Awake()
    {
        Commands = GetComponent<Commands>();
        _responder = GetComponent<CommandResponder>();
    }

    public void SetCommandName()
    {
        CommandName = _inputCommand.text;
        _responder.RespondName = _inputCommand.text;
    }

    public void SendCommand()
    {
        try
        {
            InvokeCommand(CommandName, null);
            CreateMessage(CommandText);
            _quickAccess.SaveLastCommand(CommandName);
            _responder.Respond();
        }
        catch
        {
            Warning();
        }
        _inputCommand.text = string.Empty;
    }

    public void CreateMessage(string name)
    {
        GameObject newItem = Instantiate(_item, _commandsContainer);
        newItem.GetComponentInChildren<Text>().text = name;
    }

    public void InvokeCommand(string name, object[] args)
    {
        MethodInfo command = Commands.GetType().GetMethod(name);
        command.Invoke(Commands, null);
    }

    public void QuickCommand(string name)
    {
        InvokeCommand(name, null);
        CreateMessage(CommandText);
        _responder.Respond();
    }

    private void Warning()
    {
        _warning.Play();
    }
}
