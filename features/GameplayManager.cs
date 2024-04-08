using Godot;
using System;

public partial class GameplayManager : Node
{
	public PlayerController Player;
	public override void _Ready()
	{
		Player = GetTree().GetFirstNodeInGroup("player") as PlayerController;
		GameManager.Instance.SetCurrentGameplayManager(this);
	}

	public void DamagePlayer(EnemyController source)
	{
		Player.Health.CurrentHealth -= source.Damage;
	}
}
