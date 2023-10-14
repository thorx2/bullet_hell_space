namespace BulletGame;

public partial class Player : CharacterBody2D
{
    [Export] private int Speed = 400;
    [Export] private int Drag = 400;
    [Export] private Sprite2D _shipImage;

    [Export] private Node2D _muzzle;

    private BulletPoolManager _bulletPoolManager;

    public override void _Ready()
    {
        _bulletPoolManager = BulletPoolManager.Instance;
    }

    public override void _PhysicsProcess(double delta)
    {
        var dir = Input.GetVector("move_left", "move_right", "move_up", "move_down");

		if (dir != Vector2.Zero)
        {
            Velocity = dir * Speed;
        }
        else if (!Velocity.IsZeroApprox())
        {
            Velocity -= Velocity.Normalized() * Drag;
        }
        MoveAndSlide();
    }

    public override void _Process(double delta)
    {
        //TODO To be replaced by automatic shooting with fire rate and patterns.
        if (Input.IsActionJustPressed("shoot_gun"))
        {
            _bulletPoolManager.GetBullet(_muzzle.GlobalPosition);
        }
    }
}