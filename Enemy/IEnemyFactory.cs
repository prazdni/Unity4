namespace Asteroids
{
    public interface IEnemyFactory
    {
        IEnemy CreateHiddenEnemy(EnemyData enemyData);
    }
}