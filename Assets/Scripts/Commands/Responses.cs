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

    public void Go()
    {

    }
}
