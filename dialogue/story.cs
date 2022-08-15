using Godot;
using System;
using System.Collections.Generic;   // Not needed

public class Primary : dialogueTree
{
    // Create a dialogueTree

    node start;

    public override void _Ready()
    {
        // Set all of the nodes to whatever they should be
        start = new storyNode("Hello!", new transition(0,
                    new storyNode("Welcome to Heaven.", new transition(0,
                    null

                    ))));
    }
}
