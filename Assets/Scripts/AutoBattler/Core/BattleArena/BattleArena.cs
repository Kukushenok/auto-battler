using AutoBattler.Battle;
using AutoBattler.Utils;
using System.Collections.Generic;

namespace AutoBattler
{
    internal class BattleArena
    {
        private IRandom rnd;
        public BattleArena(IRandom rnd)
        {
            this.rnd = rnd.CreateOtherInstance();
        }
        public IEnumerable<IBattleEvent> DoBattle(IBattleEntity entityA, IBattleEntity entityB)
        {
            bool isPlayer = true;
            if (entityA.Stats.Dexterity < entityB.Stats.Dexterity)
            {
                (entityA, entityB) = (entityB, entityA);
                isPlayer = !isPlayer;
            }
            while (!entityA.Health.IsDead && !entityB.Health.IsDead)
            {
                bool check = GetRandomCheck(entityA.Stats, entityB.Stats, isPlayer, out var S);
                yield return S;
                var builder = entityB.GetAttackBuilder();
                if (!check)
                {
                    builder = new MissAttackDecorator(builder);
                }
                var atk = entityA.DoAttack(builder).Build();
                yield return new AttackEvent(atk, isPlayer);
                entityB.Health.DoDamage(atk.TotalDamage);
                yield return new UpdateHealthEvent(entityB.Health, !isPlayer);
                (entityA, entityB) = (entityB, entityA);
                isPlayer = !isPlayer;
            }
        }
        public bool GetRandomCheck(IEntityStats entityA, IEntityStats entityB, bool isPlayer, out IBattleEvent check)
        {
            int sum = entityA.Dexterity + entityB.Dexterity;
            bool result = RandomCheckEvent.Check(rnd, entityB.Dexterity, sum, isPlayer, out RandomCheckEvent c);
            check = c;
            return result;
        }
    }
}
