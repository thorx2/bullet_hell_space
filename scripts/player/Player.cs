using Godot;

public partial class Player : RigidBody2D
{
    [Export] private int Speed = 400;
    [Export] private Sprite2D _shipImage;

    private Vector2 _screenSize;
    private Vector2 _modelSize;

    private BulletPoolManager _bulletPoolManager;

    public override void _Ready()
    {
        _screenSize = GetViewportRect().Size;
        _modelSize = _shipImage.GetRect().Size * _shipImage.GlobalScale;
        _bulletPoolManager = BulletPoolManager.Instance;
    }

    public override void _Process(double delta)
    {
        var velocity = Vector2.Zero; // The player's movement vector.

        if (Input.IsActionPressed("move_right"))
        {
            velocity.X += 1;
        }

        if (Input.IsActionPressed("move_left"))
        {
            velocity.X -= 1;
        }

        if (Input.IsActionPressed("move_down"))
        {
            velocity.Y += 1;
        }

        if (Input.IsActionPressed("move_up"))
        {
            velocity.Y -= 1;
        }

        if (velocity.Length() > 0)
        {
            LinearVelocity = velocity.Normalized() * Speed;
        }

        if (Position.X < _modelSize.X / 2 || Position.X > _screenSize.X - _modelSize.X / 2 ||
            Position.Y < _modelSize.Y / 2 || Position.Y > _screenSize.Y - _modelSize.Y / 2)
        {
            LinearVelocity = Vector2.Zero;

            Position = new Vector2(
                x: Mathf.Clamp(Position.X, _modelSize.X / 2, _screenSize.X - _modelSize.X / 2),
                y: Mathf.Clamp(Position.Y, _modelSize.Y / 2, _screenSize.Y - _modelSize.Y / 2)
            );
        }
    }
}