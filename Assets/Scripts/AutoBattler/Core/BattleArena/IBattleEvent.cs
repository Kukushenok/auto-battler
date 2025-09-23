using AutoBattler.External;
using System.Threading.Tasks;

namespace AutoBattler.Battle
{
    public interface IBattleEvent
    {
        public Task Visualize(IBattleEventReporter presenter);
    }
}
