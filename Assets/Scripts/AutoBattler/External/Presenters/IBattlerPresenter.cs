using AutoBattler.Battle;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoBattler.External
{
    public interface IBattlerPresenter
    {
        public IBattleEntityPresenter GetPlayerPresenter();
        public IBattleEntityPresenter GetEnemyPresenter();
        public Task Run(IEnumerable<IBattleEvent> events);
        public Task ProcessEnd(bool winSide);
    }
}
