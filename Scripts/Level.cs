using Godot;
using System;

public partial class Level : Node2D
{
	PackedScene meteorScene = GD.Load<PackedScene>("res://Scenes/meteor.tscn");
	private void _on_meteor_timer_timeout()
	{
		var meteor = meteorScene.Instantiate();

		GetNode<Node2D>("Meteors").AddChild(meteor);
	}
}
