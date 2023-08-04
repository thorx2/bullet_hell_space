using System;
using System.Collections.Generic;
using Godot;

public class BulletPoolManager : SingletonBase<BulletPoolManager>
{
    private const int MAX_PROJECTILE_COUNT = 100;
    
    // The bullet "Prefab"
    private PackedScene _bulletScene;
    private List<Bullet> _activeBullets;
    private List<Bullet> _inactiveBullets;
    
    protected override void Initialize()
    {
        base.Initialize();
        _activeBullets = new List<Bullet>();
        _inactiveBullets = new List<Bullet>();
        
        for (int i = 0; i < MAX_PROJECTILE_COUNT; i++)
        {
            var bullet = (Bullet)_bulletScene.Instantiate();
            _inactiveBullets.Add(bullet);
        }
    }
    
    public Bullet GetBullet()
    {
        if (_inactiveBullets.Count > 0)
        {
            var bullet = _inactiveBullets[0];
            _inactiveBullets.RemoveAt(0);
            _activeBullets.Add(bullet);
            bullet.Visible = true;
            return bullet;
        }
        else
        {
            var bullet = (Bullet)_bulletScene.Instantiate();
            _activeBullets.Add(bullet);
            return bullet;
        }
    }

    public void SetBulletScene(PackedScene packedScene)
    {
        _bulletScene = packedScene;
    }

    public void DeactivateBullet(Bullet bullet)
    {
        _activeBullets.Remove(bullet);
        _inactiveBullets.Add(bullet);
        bullet.Visible = false;
    }
}