using Godot;
using System;
using System.Reflection.Metadata;
using System.Threading.Tasks.Dataflow;

public partial class Player : CharacterBody2D
{

	[Export] private int Speed = 250;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Position = new Vector2(50, 120);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		float fdelta = (float)delta;
		var direction = Input.GetVector("left", "right", "up", "down");
		Velocity = direction * Speed;
		MoveAndSlide();

	}
}
