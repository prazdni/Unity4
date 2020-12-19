namespace Unity4.Lesson8
{
    public interface ITupleFactory : ITupleFactory<GrenadeConfiguration, IGrenadeModel, IExplosionViewModel>, 
        ITupleFactory<MineConfiguration, IMineModel, IExplosionViewModel>
    {
        
    }
}