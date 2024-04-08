using Godot;
using System;

public partial class CameraFollow : Node3D
{
	[Export] public Node3D Target;
	
	public float OffsetX = 0;
	
	public float OffsetY = 0;
	
	public float OffsetZ = 0;
	
	public override void _Ready()
	{
		OffsetX = GlobalPosition.X - Target.GlobalPosition.X;
		
		OffsetY = GlobalPosition.Y - Target.GlobalPosition.Y;
		
		OffsetZ = GlobalPosition.Z - Target.GlobalPosition.Z;
	}

	public override void _Process(double delta)
	{
		GlobalPosition = Target.GlobalPosition + new Vector3(OffsetX, OffsetY, OffsetZ);
	}
}
