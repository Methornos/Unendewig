using System.Reflection;
using UnityEngine;

public class Commands : MonoBehaviour
{
    private CommandHandler _handler = default;
    private Path _path = default;

    private void Awake()
    {
        _handler = GetComponent<CommandHandler>();
        _path = GameObject.Find("LocationPathGenerator").GetComponent<Path>();
    }

    public void Command(string name)
    {
        string command = string.Empty;

        if (name == "Go left" ||
            name == "To left" ||
            name == "Left")
        {
            command = "MoveLeft";
        }
        else if (name == "Go forward" ||
            name == "Forward")
        {
            command = "MoveForward";
        }
        else if (name == "Go right" ||
            name == "To right" ||
            name == "Right")
        {
            command = "MoveRight";
        }
        else if(name == "Back")
        {
            command = "Back";
        }

        InvokeCommand(command, null);
    }

    public void InvokeCommand(string name, object[] args)
    {
        MethodInfo command = GetType().GetMethod(name);
        command.Invoke(this, null);
    }

/*------------------------------------------------------------------------------*/

    public void MoveLeft()
    {
        _handler.CommandText = "You: I go left";
        _path.LocationCheck("left");
    }

    public void MoveForward()
    {
        _handler.CommandText = "You: I go forward";
        _path.LocationCheck("forward");
    }

    public void MoveRight()
    {
        _handler.CommandText = "You: I go right";
        _path.LocationCheck("right");
    }

    public void Back()
    {
        switch(Random.Range(0, 3))
        {
            case 0:
                _handler.CommandText = "You: I go back";
                break;
            case 1:
                _handler.CommandText = "You: I think it's better to go back";
                break;
            case 2:
                _handler.CommandText = "You: I'll go back";
                break;
        }
        
    }

    public void Go()
    {

    }
}
