using Godot;
using System;

public partial class Level : Node2D
{
	[Export] public PackedScene MeteorScene;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetNode<Timer>("Timer").Timeout += OnTimerTimeout;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	private void OnTimerTimeout()
	{
		var Meteor = MeteorScene.Instantiate<Area2D>();

		Meteor.Position = new Vector2((float)GD.RandRange(0, 1000), -50);

		AddChild(Meteor);

		GD.Print("meteor spawned");
	}
}
