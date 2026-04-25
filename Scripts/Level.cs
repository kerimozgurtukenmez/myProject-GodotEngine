using Godot;
using System;

public partial class Level : Node2D
{
	PackedScene meteorScene = GD.Load<PackedScene>("res://Scenes/meteor.tscn");
	PackedScene laserScene = GD.Load<PackedScene>("res://Scenes/laser.tscn");
	private void _on_meteor_timer_timeout()
	{
		var meteor = meteorScene.Instantiate();

		GetNode<Node2D>("Meteors").AddChild(meteor);
	}

	private void _on_player_laser(Vector2 pos)
	{
		var laser = laserScene.Instantiate<Area2D>();
		laser.Position = pos;
		GetNode<Node2D>("Lasers").AddChild(laser);


	}
}
