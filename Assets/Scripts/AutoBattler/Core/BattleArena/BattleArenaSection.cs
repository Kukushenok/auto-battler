using AutoBattler.External;
using AutoBattler.Utils;
using System.Threading.Tasks;

namespace AutoBattler
{
    internal class BattleArenaSection: IPlayable
    {
        private IBattleEntity entityPlayer;
        private IBattleEntity entityEnemy;
        private IBattlerPresenter battlerPresenter;
        private IRandom random;
        public BattleArenaSection(IRandom rnd, IBattlerPresenter battle, IBattleEntity player, IBattleEntity enemy)
        {
            random = rnd.CreateOtherInstance();
            battlerPresenter = battle;
            entityPlayer = player;
            entityEnemy = enemy;
        }

        public async Task Play()
        {
            var battleResult = (new BattleArena(random)).DoBattle(entityPlayer, entityEnemy);
            entityPlayer.Visualize(battlerPresenter.GetPlayerPresenter());
            entityEnemy.Visualize(battlerPresenter.GetEnemyPresenter());
            await battlerPresenter.Run(battleResult);
            await battlerPresenter.ProcessEnd(!entityPlayer.Health.IsDead);
        }
    }
}
