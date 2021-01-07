using UnityEngine;

namespace Unity4.Lesson8
{
    public class SimpleEnemyFactory :  IFactory<SimpleEnemyConfiguration, IEnemyViewModel>
    {
        public IEnemyViewModel Create(SimpleEnemyConfiguration obj)
        {
            var objTransform = Object.Instantiate(obj.Prefab);
            var enemyViewModel = new EnemyViewModel(new SimpleEnemyModel(objTransform, obj.HealthModel, obj.WayPoints,
                obj.Speed, obj.Damage));
            
            var enemyCollisionView = objTransform.GetOrAddComponent<EnemyCollisionView>();
            var enemyHealthView = objTransform.GetOrAddComponent<EnemyHealthView>();
            
            enemyCollisionView.Initialize(enemyViewModel);
            enemyHealthView.Initialize(enemyViewModel);
            
            return enemyViewModel;
        }
    }
}