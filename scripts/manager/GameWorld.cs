global using Godot;
global using System;
using System.Diagnostics;

namespace BulletGame;

public partial class GameWorld : Node2D
{
    [Export] private PackedScene _bulletScene;

    [Export] private PackedScene _playerScene;

    [Export] private Node2D _spawnLocation;
    
    public override void _Ready()
    {
        BulletPoolManager.Instance.SetBulletScene(_bulletScene, this);
    }
}
