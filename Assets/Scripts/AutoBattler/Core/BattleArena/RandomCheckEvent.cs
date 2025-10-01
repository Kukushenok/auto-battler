using AutoBattler.External;
using AutoBattler.Utils;
using System.Threading.Tasks;

namespace AutoBattler.Battle
{
    internal class RandomCheckEvent : IBattleEvent
    {
        private int m_Wanted;
        private int m_Got;
        private bool m_IsPlayer;
        public RandomCheckEvent(int wanted, int got, bool isPlayer)
        {
            m_Wanted = wanted;
            m_Got = got;
            m_IsPlayer = isPlayer;
        }
        public Task Visualize(IBattleEventReporter presenter)
        {
            return presenter.ReportDexterity(m_Wanted, m_Got, m_IsPlayer);
        }
        public static bool Check(IRandom rnd, int want, int max, bool isPlayer, out RandomCheckEvent check, int min = 1)
        {
            int x = rnd.GetRange(min, max + 1);
            check = new RandomCheckEvent(want, x, isPlayer);
            return want < x;
        }
    }
}
