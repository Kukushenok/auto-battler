using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
