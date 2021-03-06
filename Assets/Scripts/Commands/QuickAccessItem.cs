using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickAccessItem : MonoBehaviour
{
    [SerializeField]
    private CommandHandler _handler = default;

    public string CommandName = string.Empty;

    public void CallCommand() => _handler.QuickCommand(CommandName);
}
