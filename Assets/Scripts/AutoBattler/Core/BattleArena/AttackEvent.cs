using AutoBattler.External;
using System.Threading.Tasks;

namespace AutoBattler.Battle
{
    internal class AttackEvent: IBattleEvent
    {
        private IAttack m_Attack;
        private bool m_isPlayer;

        public AttackEvent(IAttack attack, bool isPlayer)
        {
            m_Attack = attack;
            m_isPlayer = isPlayer;
        }

        public async Task Visualize(IBattleEventReporter presenter)
        {
            await presenter.PerformAttack(m_Attack, m_isPlayer);
        }
    }
}
