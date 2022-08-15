using Godot;
using System;
using System.Collections.Generic;

public class transition : Node
{
    // VARIABLES
    private int type;
    private node next;
    public node Next {
        get{return next;}
    }


    // CONSTRUCTOR
    public transition(int type, node next) {
        this.type = type;
        this.next = next;
    }
}
