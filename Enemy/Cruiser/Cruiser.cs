﻿using UnityEngine;

namespace Asteroids
{
    public class Cruiser : Enemy
    {
        private IExecute _cruiserMovement;
        private CruiserBulletManager _cruiserBulletManager;
        private IExecute _collisionChecker;
        
        public Cruiser(Transform sceneEnemy, CruiserData cruiserData , IShip ship) : 
            base(sceneEnemy, cruiserData, ship)
        {
            _cruiserBulletManager = new CruiserBulletManager(this, cruiserData.Bullet, ship,10.0f);
            _cruiserMovement = new CruiserMovement(this, _speed.Current, ship);
        }

        public override void Execute(float deltaTime)
        {
            base.Execute(deltaTime);
            _cruiserMovement.Execute(deltaTime);
            _cruiserBulletManager.Execute(deltaTime);
        }
    }
}