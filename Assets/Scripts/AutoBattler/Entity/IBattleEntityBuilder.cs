using System.Collections.Generic;

namespace AutoBattler
{
    public interface IBattleEntityBuilder
    {
        public IBattleEntity Build();
        public IBattleEntityBuilder OverrideHealth(IHealth health);
        public IBattleEntityBuilder OverrideStats(IEntityStats stats);
        public IBattleEntityBuilder OverrideWeapon(IWeapon weapon);
        public IBattleEntityBuilder AddSkill(IGameSkill skill);
    }
}
