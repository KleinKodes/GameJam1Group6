using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class GlobalEvents
{
    private static Event _playerDeath = new("player death", "indicates if player has died on current level");

    public static Event PlayerDeath { get { return _playerDeath; } }

}

public class Event
{
    private bool invoked = false;

    private string name;


    private string description;

    public Event(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    public string Name() { return name; }

    public string Description() { return description; }

    public bool Invoked() { return invoked; }
    public override string ToString() { return "EVENT: " + name + " - " + description; }

    public void invoke()
    {
        this.invoked = true;
    }

    public void uninvoke()
    {
        this.invoked = false;
    }

}
