using Godot;
using System;

public partial class GameManager : Node
{
	public static GameManager Instance;

	public GameplayManager Gameplay;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
	}

	public void SetCurrentGameplayManager(GameplayManager gameplayManager)
	{
		Gameplay = gameplayManager;
	}
}
