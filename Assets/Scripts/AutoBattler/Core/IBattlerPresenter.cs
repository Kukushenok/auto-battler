using AutoBattler.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoBattler
{
    public class BattleEvent
    {
        public IAttack Attack { get; } = null;
        public IRandomCheck RandomCheck { get; } = null;
        public bool IsPlayerTurn { get; }
        public BattleEvent(IAttack attack, bool isPlayer)
        {
            Attack = attack;
            IsPlayerTurn = isPlayer;
        }
        public BattleEvent(IRandomCheck check, bool isPlayer)
        {
            RandomCheck = check;
            IsPlayerTurn = isPlayer;
        }
    }
    public interface IRandomCheckPresenter
    {
        public Task ReportDexterity(int wanted, int got);
    }
    public interface IRandomCheck
    {
        public Task Visualize(IRandomCheckPresenter presenter);
    }
    public class BasicRandomCheck : IRandomCheck
    {
        private int m_Wanted;
        private int m_Got;
        public BasicRandomCheck(int wanted, int got)
        {
            m_Wanted = wanted;
            m_Got = got;
        }
        public Task Visualize(IRandomCheckPresenter presenter)
        {
            return presenter.ReportDexterity(m_Wanted, m_Got);
        }
        public static bool Check(IRandom rnd, int want, int max, out BasicRandomCheck check, int min = 1)
        {
            int x = rnd.GetRange(min, max + 1);
            check = new BasicRandomCheck(want, x);
            return want < x;
        }
    }
    public interface IBattlerPresenter
    {
        public void Setup(IAutoBattlerEntityDescriptor player, IAutoBattlerEntityDescriptor enemy);
        public Task Run(IEnumerable<BattleEvent> events);
        public Task ProcessEnd(bool winSide);
    }
}
