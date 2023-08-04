using Godot;
using System;

public partial class Bullet : RigidBody2D
{
    [Export] private Vector2 _bulletVelocity = Vector2.Zero;

    [Export] private VisibleOnScreenNotifier2D _onScreenNotifier;

    public override void _Process(double delta)
    {
        Translate(_bulletVelocity * (float)delta);
        if (!_onScreenNotifier.IsOnScreen())
        {
            BulletPoolManager.Instance.DeactivateBullet(this);
        }
    }
}