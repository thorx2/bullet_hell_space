namespace BulletGame;

public partial class Player : RigidBody2D
{
    [Export] int speed = 400;

    BulletPoolManager bulletPoolManager;

    public override void _Ready()
    {
        bulletPoolManager = BulletPoolManager.Instance;
    }

    public override void _PhysicsProcess(double delta)
    {
        Movement();
    }

    void Movement()
    {
        Vector2 inputDirection = Input.GetVector(
            negativeX: "move_left",
            positiveX: "move_right",
            negativeY: "move_up",
            positiveY: "move_down");

        // Only apply velocity when movement keys are pressed
        if (inputDirection != Vector2.Zero)
            // Normalized to prevent faster diagonal movement
            LinearVelocity = inputDirection.Normalized() * speed;
    }
}