global using Godot;
global using System;

namespace BulletGame;

public partial class GameWorld : Node2D
{
    [Export] private PackedScene _bulletScene;

    [Export] private PackedScene _playerScene;

    [Export] private Node2D _spawnLocation;
    
    public override void _Ready()
    {
        BulletPoolManager.Instance.SetBulletScene(_bulletScene, this);
        
        AddWorldBoundaries();
    }

    void AddWorldBoundaries()
    {
        Vector2 viewportSize = GetViewportRect().Size;

        // Left boundary
        AddWorldBoundary(
            position: Vector2.Zero,
            normal: new Vector2(1, 0));

        // Right boundary
        AddWorldBoundary(
            position: new Vector2(viewportSize.X, 0),
            normal: new Vector2(-1, 0));

        // Top boundary
        AddWorldBoundary(
            position: Vector2.Zero,
            normal: new Vector2(0, 1));

        // Bottom boundary
        AddWorldBoundary(
            position: new Vector2(0, viewportSize.Y),
            normal: new Vector2(0, -1));
    }

    void AddWorldBoundary(Vector2 position, Vector2 normal)
    {
        StaticBody2D staticBody2D = new()
        {
            PhysicsMaterialOverride = new PhysicsMaterial
            {
                // Prevent the spaceship from getting stuck
                Friction = 0,
                // Seems to help prevent subtle bounciness
                Rough = true
            },
            Position = position
        };

        CollisionShape2D collisionShape2D = new()
        {
            Shape = new WorldBoundaryShape2D
            {
                Normal = normal
            }
        };

        staticBody2D.AddChild(collisionShape2D);
        AddChild(staticBody2D);
    }
}
