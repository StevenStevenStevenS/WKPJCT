using Godot;
using System;

public class Area : Area2D
{
    [Signal]
    delegate void printDialogue(string dialogue);

    // VARIABLES
    Manny player;

    [Export]
    //storyNode dialogue = (storyNode) DialogueTree.start;
    storyNode dialogue;
    bool canAct = false;

    public override void _Ready()
    {
        //dialogue  = (storyNode) GetNode<dialogueTree>("/root/DialogueTree").Start;
    }


    // Functions for one-player dialogue interaction
    public void bodyEntered(Node body) {
        // If the node is the player
        if (body is Manny)
        {
            // Give player permission to print more dialogue
            //canAct = true;
            player = (Manny)body;
            player.Partner = this;
        }
    }

    public void bodyExited(Node body) {
        if (body == player)
        {
            //canAct = false;
            player.Partner = null;
            player = null;
        }
    }

    public void activate() {
        if (dialogue != null) {
            player.canMove = false;
            EmitSignal("printDialogue", dialogue.Text);
            dialogue = (storyNode)dialogue.Transition.Next;
        } else {
            player.canMove = true;
        }
    }

    public override void _Input(InputEvent inputEvent)
    {
        if (canAct && inputEvent.IsActionPressed("ui_select"))
        {
            

        }
    }


    /*public void speak(){
        // When the player presses interaction key,


        // Print Dialogue
        //EmitSignal("printDialogue", nextdialogue);
    }*/


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
