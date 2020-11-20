namespace Asteroids
{
    public interface IUnitFactory
    {
        Unit GetUnit(UnitType type);
    }
}