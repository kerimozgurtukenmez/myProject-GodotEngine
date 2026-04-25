using Godot;
using System;

public partial class Meteor : Area2D
{
    private int speed;
    private int rotation_speed;
    private float direction_x;
    private void _ready()
    {
        RandomNumberGenerator rng = new RandomNumberGenerator();

        string path = Utils.GetRandomMeteorPath();
        Texture2D tex = GD.Load<Texture2D>(path);
        GetNode<Sprite2D>("MeteorImage").Texture = tex;

        var width = GetViewport().GetVisibleRect().Size[0];
        var random_x = rng.RandiRange(0, (int)width);
        var random_Y = rng.RandiRange(-150, -50);
        Position = new Vector2(random_x, random_Y);

        speed = rng.RandiRange(250, 500);
        direction_x = rng.RandfRange(-1, 1);
        rotation_speed = rng.RandiRange(40, 100);
    }

    private void _process(float delta)
    {
        Position += new Vector2(direction_x, 1.0f) * speed * delta;
        RotationDegrees += rotation_speed * delta;
    }
    private void _on_body_entered(Node2D body)
    {
        GD.Print("Collision detected: " + body.Name);
    }
}
