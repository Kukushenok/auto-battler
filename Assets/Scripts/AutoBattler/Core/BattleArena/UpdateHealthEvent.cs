using AutoBattler.External;
using System.Threading.Tasks;

namespace AutoBattler.Battle
{
    internal class UpdateHealthEvent : IBattleEvent
    {
        private float m_Health;
        private float m_MaxHealth;
        private bool m_isPlayer;
        public UpdateHealthEvent(IHealth currHP, bool isPlayer)
        {
            m_Health = currHP.HP;
            m_MaxHealth = currHP.MaxHP;
            m_isPlayer = isPlayer;
        }
        public async Task Visualize(IBattleEventReporter presenter)
        {
            await presenter.UpdateHealth(m_Health, m_isPlayer);
        }
    }
}
