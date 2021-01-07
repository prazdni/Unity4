using System;
using System.Collections.Generic;

namespace Unity4.Lesson8
{
    public class SimpleEnemyExecute : IExecute
    {
        private List<IEnemyViewModel> _enemies;
        
        public SimpleEnemyExecute(List<IEnemyViewModel> enemies)
        {
            _enemies = enemies;
        }
        
        public void Execute(float deltaTime)
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                _enemies[i].Execute(deltaTime);
            }
        }
    }
}