using Godot;
using System;

public partial class PlayerMovementController : Node
{
	[Export] public float Speed = 5;

	public CharacterBody3D Parent;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Parent = GetParent<CharacterBody3D>();
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector3 direction = new Vector3();
		
		if (Input.IsActionPressed("move_right"))
		{
			direction += new Vector3(1, 0, 0);
		}
		
		if (Input.IsActionPressed("move_left"))
		{
			direction += new Vector3(-1, 0, 0);
		}
		
		if (Input.IsActionPressed("move_forward"))
		{
			direction += new Vector3(0, 0, -1);
		}
		
		if (Input.IsActionPressed("move_back"))
		{
			direction += new Vector3(0, 0, 1);
		}

		if (direction == Vector3.Zero) return;
		
		var movement = direction.Normalized() * Speed * (float)delta;

		Parent.MoveAndCollide(movement);
		
		Parent.LookAt(Parent.GlobalPosition + direction.Normalized(), Vector3.Up);
	}
}
