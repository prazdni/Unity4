using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids
{
    public class BulletManager
    {
        private Queue<Rigidbody2D> _bulletsQueue;
        private Timer _timer;
        
        public BulletManager()
        {
            _bulletsQueue = new Queue<Rigidbody2D>();
            _timer = new Timer();
        }

        public void Shoot(Rigidbody2D bullet, Transform barrel, float force)
        {
            var temAmmunition = Object.Instantiate(bullet, barrel.position, barrel.rotation);
            temAmmunition.AddForce(barrel.up * force);
            _bulletsQueue.Enqueue(temAmmunition);
        }

        public void QuantityOfBulletsCheck(float deltaTime)
        {
            if (_bulletsQueue.Count > 0)
            {
                if (!_timer.IsTimerStarted && Mathf.Approximately(_timer.CurrentTime, 1.0f) )
                {
                    _timer.StartTimeCount();
                }

                _timer.TimerTick(deltaTime);

                if (!_timer.IsTimerStarted)
                {
                    Object.Destroy(_bulletsQueue.Dequeue().gameObject);
                    _timer.ResetTimeCount();
                }
            }
        }
    }
}