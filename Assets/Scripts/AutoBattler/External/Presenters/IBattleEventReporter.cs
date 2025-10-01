using System.Threading.Tasks;

namespace AutoBattler.External
{
    public interface IBattleEventReporter
    {
        public Task ReportDexterity(int wanted, int got, bool isPlayer);
        public Task PerformAttack(IAttack attack, bool isPlayer);
        public Task UpdateHealth(float healthNow, bool isPlayer);
    }
}
