global using Godot;
global using System;

namespace BulletGame;

public partial class GameWorld : Node2D
{
    [Export] private PackedScene _bulletScene;

    [Export] private ParallaxBackground _background;

    [Export] private Vector2 _scrollSpeed;
    public override void _Ready()
    {
        BulletPoolManager.Instance.SetBulletScene(_bulletScene, this);
    }

    public override void _Process(double delta)
    {
        _background.ScrollOffset += _scrollSpeed * (float) delta;
    }
}
