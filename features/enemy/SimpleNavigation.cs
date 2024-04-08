using Godot;
using System;
using System.Diagnostics;

public partial class SimpleNavigation : Node
{
	[Export] public int Speed = 5;

    [Signal]
    public delegate void OnCollisionEventHandler(KinematicCollision3D collision);

	public NavigationAgent3D Agent;

	public CharacterBody3D Parent;

	public PlayerController Player;
	
	public override void _Ready()
	{
		Parent = GetParent<CharacterBody3D>();

		Player = GetTree().GetFirstNodeInGroup("player") as PlayerController;

		Agent = GetParent().GetNode<NavigationAgent3D>("navigation");
	}

	public override void _Process(double delta)
	{
		Agent.TargetPosition = Player.GlobalPosition;
	}

	public override void _PhysicsProcess(double delta)
	{
		if (Player == null) return;

		if (Agent.DistanceToTarget() < 0.1f) return;

		var destination = Agent.GetNextPathPosition();

		var direction = (destination - Parent.GlobalPosition).Normalized();

		var movement = direction * Speed * (float)delta;

		var collision = Parent.MoveAndCollide(movement);

		if (Parent.GlobalPosition.DistanceTo(destination) > 0.1f)
		{
			Parent.LookAt(destination + direction);
		}

		if (collision != null)
		{
			EmitSignal(SignalName.OnCollision, collision);
		}
	}
}
