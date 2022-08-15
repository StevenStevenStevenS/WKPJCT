using Godot;
using System;

public class node : Node
{
    // VARIABLES
    private transition transition;
    public transition Transition {
        get {return transition;}
    }


    // CONSTRUCTOR
    public node(transition transition) {
        this.transition = transition;
    }
}