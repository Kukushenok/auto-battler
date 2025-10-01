using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoBattler
{
    public class BasicCompositeAttack : IAttack
    {
        private List<IAttack> m_Attacks;
        private readonly float m_TotalDamage;
        public BasicCompositeAttack(IEnumerable<IAttack> attacks)
        {
            m_Attacks = attacks.ToList();
            m_TotalDamage = m_Attacks.Sum(x => x.TotalDamage);
            if (m_TotalDamage < 0) m_TotalDamage = 0;
        }
        float IAttack.TotalDamage => m_TotalDamage;

        public async Task Visualize(IAttackPresenter presenter)
        {
            foreach(var attack in m_Attacks)
            {
                await attack.Visualize(presenter);
            }
        }
    }
}
