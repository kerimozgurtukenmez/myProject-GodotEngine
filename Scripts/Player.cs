using Godot;
using System;
using System.Reflection.Metadata;
using System.Threading.Tasks.Dataflow;

public partial class Player : CharacterBody2D
{

	[Export] private int Speed = 250;
	[Signal] public delegate void LaserEventHandler(Vector2 pos);

	private bool canShoot = true;
	private Marker2D _centerMarker;
	private Marker2D _rightMarker;
	private Marker2D _leftMarker;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_centerMarker = GetNode<Marker2D>("LaserStartPosition");
		_rightMarker = GetNode<Marker2D>("LaserStartPositionRight");
		_leftMarker = GetNode<Marker2D>("LaserStartPositionLeft");

		Position = new Vector2(50, 120);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		float fdelta = (float)delta;
		var direction = Input.GetVector("left", "right", "up", "down");
		Velocity = direction * Speed;
		MoveAndSlide();

		if (Input.IsActionJustPressed("shoot") & canShoot)
		{
			EmitSignal(SignalName.Laser, _centerMarker.GlobalPosition);
			EmitSignal(SignalName.Laser, _rightMarker.GlobalPosition);
			EmitSignal(SignalName.Laser, _leftMarker.GlobalPosition);

			canShoot = false;
			GetNode<Timer>("LaserTimer").Start();
		}
	}

	private void _on_laser_timer_timeout()
	{
		canShoot = true;
	}

}
