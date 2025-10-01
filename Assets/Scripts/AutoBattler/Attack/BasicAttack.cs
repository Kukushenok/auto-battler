using System.Threading.Tasks;

namespace AutoBattler
{
    public class BasicAttack : IAttack
    {
        private AttackType m_Source;

        public float TotalDamage { get; private set; }
        public BasicAttack(AttackType source, float totalDamage)
        {
            this.m_Source = source;
            TotalDamage = totalDamage;
        }

        public async Task Visualize(IAttackPresenter presenter)
        {
            await presenter.VisualiseBasicAttack(m_Source, TotalDamage);
        }
    }
}
