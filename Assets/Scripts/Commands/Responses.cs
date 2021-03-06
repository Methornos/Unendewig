using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Responses : MonoBehaviour
{
    private CommandResponder _responder = default;
    private LocationGenerator _generator = default;

    private void Awake()
    {
        _responder = GetComponent<CommandResponder>();
        _generator = GameObject.Find("LocationPathGenerator").GetComponent<LocationGenerator>();
    }

    public void Attack()
    {
        _responder.RespondText = "Enemy: Fuck you, leatherman";
    }

    public void Sleep()
    {
        _responder.RespondText = "Brain: Wake the fuck up samurai";
    }

    public void Walk()
    {
        _responder.RespondText = "Walk: pizdato hodim";
    }

    public void Stay()
    {
        _responder.RespondText = "Stray: ya ne Stay";
    }

    public void Feed()
    {
        _responder.RespondText = "Pohuy paebat";
    }

    public void Go()
    {

    }
}
