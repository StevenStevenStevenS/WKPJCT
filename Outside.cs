using Godot;
using System;

public class Outside : Node2D
{
    //VARIABLES

    //RichTextLabel _dialogueBox;

    KinematicBody2D Player;
    

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //_dialogueBox = GetNode<RichTextLabel>("KinematicBody2D/RichTextLabel");
        Player = GetNode<KinematicBody2D>("Player");
    }

    /*public void dialogueBox(string dialogue) {
        _dialogueBox.Clear();
        _dialogueBox.AddText(dialogue);
    }*/

    public void area(Node body) {
        GetTree().Quit();

        Player.Visible = false;
        GetViewport().AudioListenerEnable2d = false;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
