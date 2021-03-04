using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commands : MonoBehaviour
{
    private CommandHandler _handler = default;

    private void Awake()
    {
        _handler = GetComponent<CommandHandler>();
    }

    public void attack()
    {
        _handler.CommandText = "You: Attacked kogo blyat";
    }
}
