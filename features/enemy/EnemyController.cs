using Godot;
using System;
using System.Diagnostics;

public partial class EnemyController : CharacterBody3D
{
    [Export] public int Damage = 10;

    [Export] public AttackController AttackController;

    [Export] public WeaponController WeaponController;


    private void _on_movement_on_collision(KinematicCollision3D collision)
    {
        var collider = collision.GetCollider();

        if (collider is not PlayerController) return;

        if (AttackController == null || WeaponController == null) return;

        AttackController.Attack(WeaponController);
    }
}
