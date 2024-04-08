using Godot;
using System;

public partial class HealthController : Node
{
	[Export] public int MaxHealth = 100;

	[Export] public int CurrentHealth = 100;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		CurrentHealth = Math.Min(MaxHealth, CurrentHealth);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
