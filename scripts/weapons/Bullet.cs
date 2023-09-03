namespace BulletGame;
public partial class Bullet : RigidBody2D
{
    [Export] private Vector2 _bulletVelocity = Vector2.Zero;

    [Export] private VisibleOnScreenNotifier2D _onScreenNotifier;

    [Export] private Sprite2D _bulletSprite;

    public override void _Process(double delta)
    {
        Translate(_bulletVelocity * (float)delta);
        if (!_onScreenNotifier.IsOnScreen())
        {
            BulletPoolManager.Instance.DeactivateBullet(this);
        }
    }

    public float BulletHeight()
    {
        return (_bulletSprite.GetRect().Size * _bulletSprite.GlobalScale).Y;
    }
}