using Godot;
using System;
using System.Collections.Generic;

public class dialogueTree : Node
{
    private IDictionary<string, node> tags = new Dictionary<string, node>();
    private node start;
    public node Start {
        get {return start;}
    }
    node currentNode;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // Set all of the nodes to whatever they should be

        // Find the pattern in which I can instantiate all of them
        /*tags.Add(
            "start",
                new node("Hello!", false, false,
                new node("Welcome to Heaven.", false, true,
                null
                
                )));
        tags.Add(
            ""
        );*/

        start = new storyNode("Hello!", new transition(0,
                    new storyNode("Welcome to Heaven.", new transition(0,
                    null

                    ))));
        
    }

}