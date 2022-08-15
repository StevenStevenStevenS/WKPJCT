/*using Godot;
using System;

public class node : Node
{
    // VARIABLES
    public bool instaPlay = false;
    public bool stop = false;

    public node next;


    public override void _Ready()
    {

    }


    public virtual void _init(bool instaPlay, bool stop, node next) {
        this.instaPlay = instaPlay;
        this.stop = stop;
        this.next = next;
    }




    public virtual void activate() {}


    public virtual node getNext() {
        return next;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}*/



using Godot;
using System;

public class storyNode : node
{
    // VARIABLES
    private string text;
    public string Text {
        get {return text;}
    }


    // CONSTRUCTOR
    public storyNode(string text, transition transition): base(transition) {
        this.text = text;
    }
}
