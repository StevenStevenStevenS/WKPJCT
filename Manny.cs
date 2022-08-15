using Godot;
using System;

public class Manny : KinematicBody2D
{
    // VARIABLES

    // CONSTANTS
    // Body
    Sprite sp;
    AnimationPlayer anim;

    // Physics
    float ACCELMULT = 50;
    float DECCEL = 80;
    double MAXSPEED = 30;


    // co-interacter
    private Area partner;
    public Area Partner
    {
        get {return partner;}
        set {partner = value;}
    }


    Vector2 moveVelocity = Vector2.Zero;
    Vector2 velocity = Vector2.Zero;


    public bool canMove = true;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        sp = GetNode<Sprite>("Sprite");
        anim = GetNode<AnimationPlayer>("AnimationPlayer");
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(float delta)
    {
        if (canMove) {
            walk(delta);
        }


        MoveAndSlide(moveVelocity);
    }

    public override void _Process(float delta)
    {
        if (Input.IsActionJustPressed("ui_select")) {
            interact();
        }
    }


    // Interaction
    private void interact() {
        if (partner != null) {
            partner.activate();
        }
    }


    // Player Movement
    private void walk(float delta)
    {
        Vector2 acceleration = Vector2.Zero; // This is just acceleration
        
        // 2-D Movement
        acceleration = new Vector2(Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left"),
                                    Input.GetActionStrength("ui_down") - Input.GetActionStrength("ui_up"));
        acceleration = ACCELMULT * acceleration.Normalized();


        // Animation
        if (acceleration != Vector2.Zero) {
            anim.Play("Walk_Right");
        }
        if (acceleration.x > 0) {
            sp.FlipH = false;
        }
        if (acceleration.x < 0) {
            sp.FlipH = true;
        }


        // Deccel
        if (acceleration == Vector2.Zero && moveVelocity != Vector2.Zero)
        {
            Vector2 normalized = moveVelocity.Normalized();
            moveVelocity -= DECCEL * normalized * delta;

            if (Mathf.Abs(moveVelocity.x) < DECCEL*normalized.x)
            {
                moveVelocity.x = 0;
            }
            if (Mathf.Abs(moveVelocity.y) < DECCEL*normalized.y)
            {
                moveVelocity.y = 0;
            }
        }
        
        
        else
        {
            moveVelocity += acceleration * delta;

            // Max Speed    // Added in _PhysicsProcess
            double magnitude = Math.Sqrt(Math.Pow(moveVelocity.x, 2) + Math.Pow(moveVelocity.y, 2));
            if (magnitude > MAXSPEED) {
                moveVelocity = (float) MAXSPEED * moveVelocity.Normalized();
                
        }   }

        if (moveVelocity == Vector2.Zero) {
            anim.Play("Right_Idle");
        }
}   }
