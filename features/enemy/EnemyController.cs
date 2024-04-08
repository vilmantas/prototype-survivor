using Godot;
using System;
using System.Diagnostics;

public partial class EnemyController : CharacterBody3D
{
    [Export] public int Damage = 10;

    private void _on_movement_on_collision(KinematicCollision3D collision)
    {
        var collider = collision.GetCollider();

        if (collider is not PlayerController) return;

        GameManager.Instance.Gameplay.DamagePlayer(this);

        QueueFree();
    }
}
