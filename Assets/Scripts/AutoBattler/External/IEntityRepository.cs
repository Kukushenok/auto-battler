using System.Collections.Generic;

namespace AutoBattler.External
{
    public interface IFightDescriptor
    {
        public IBattleEntityBuilder GetOpposingEntity();
        public IWeapon GetReward();
    }
    public interface IEntityRepository
    {
        public IBattleEntityBuilder GetPlayer();
        public IEnumerable<IFightDescriptor> GetFights();
    }
}
