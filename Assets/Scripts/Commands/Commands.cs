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

    public void Attack()
    {
        _handler.CommandText = "You: Attacked kogo blyat";
    }

    public void Sleep()
    {
        _handler.CommandText = "For You: Son is useless";
    }

    public void Walk()
    {
        _handler.CommandText = "You: Walk ne ptica";
    }

    public void Stay()
    {
        _handler.CommandText = "You: You stay like a boss";
    }

    public void Feed()
    {
        _handler.CommandText = "You: Feed good boich one time";
    }

    public void Go()
    {

    }
}
