using Godot;

public partial class Player : RigidBody2D
{
    [Export] private int Speed = 400;
    [Export] private Sprite2D _shipImage;

    private Vector2 _screenSize;
    private Vector2 _modelSize;

    public override void _Ready()
    {
        _screenSize = GetViewportRect().Size;
        _modelSize = _shipImage.GetRect().Size * _shipImage.GlobalScale;
    }

    public override void _Process(double delta)
    {
        var dir = Input.GetVector("move_left", "move_right", "move_up", "move_down");

		if (dir != Vector2.Zero)
            LinearVelocity = dir.Normalized() * Speed;

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