using Godot;
using System;

public partial class PlayerController : CharacterBody3D
{
	public HealthController Health;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Health = GetNode<HealthController>("health");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
