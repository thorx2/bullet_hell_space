using System.Diagnostics;

namespace BulletGame;

public partial class Bullet : CharacterBody2D
{
    [Export] private Vector2 _bulletVelocity = Vector2.Zero;

    [Export] private VisibleOnScreenNotifier2D _onScreenNotifier;

    public override void _Process(double delta)
    {
        if (Visible)
        {
            Translate(_bulletVelocity * (float)delta);
        }
    }

    public void OnScreenExited()
    {
        BulletPoolManager.Instance.DeactivateBullet(this);
    }
}