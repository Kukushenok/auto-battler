using AutoBattler;
using AutoBattler.External;
using System.Collections.Generic;

namespace Game.Repositories
{
    public class EntityRepository : IEntityRepository
    {
        private BattleEntitySO defaultPlayer;
        private FightRepository fightRepository;
        public EntityRepository(BattleEntitySO player, FightRepository f)
        {
            defaultPlayer = player;
            fightRepository = f;
        }
        public IEnumerable<IFightDescriptor> GetFights()
        {
            return fightRepository.GetFightDescriptors();
        }

        public IBattleEntityBuilder GetPlayer()
        {
            return defaultPlayer.Get();
        }
    }
}
