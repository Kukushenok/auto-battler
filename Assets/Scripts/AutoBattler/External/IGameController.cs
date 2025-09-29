using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoBattler.External
{
    public interface IGameController
    {
        public IBattlerPresenter Battle();
        public Task<ISkillDescriptor> ChooseGameSkill(IEnumerable<ISkillDescriptor> descriptors);
        public Task<IWeapon> ChooseWeapon(IWeapon first, IWeapon alternative);
        public Task ShowStartingStats(IEntityStats stats);
        public Task ShowStage(int stage);
        public Task ShowGameOver(bool isGameWon);

    }
}
