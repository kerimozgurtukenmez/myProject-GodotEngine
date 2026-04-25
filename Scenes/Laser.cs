using Godot;
using System;

public partial class Laser : Area2D
{
	[Export] private int speed = 500;
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector2 pos = Position;
		pos.Y -= speed * (float)delta;
		Position = pos;
	}
}
