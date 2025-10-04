using AutoBattler;
using AutoBattler.External;
using Cysharp.Threading.Tasks;
using Game.View.ColorScheme;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using VContainer;

namespace Game.View
{
    public class GameController : MonoBehaviour, IGameController
    {
        [SerializeField] private BaseBattlePresenter presenter;
        [SerializeField] private SkillLineChooser skillChooser;
        [SerializeField] private WeaponChooser weaponChooser;
        [SerializeField] private MonoBehaviourProcess<bool> gameResultsScreen;
        [SerializeField] private MonoBehaviourProcess<IEntityStats> startStatsScreen;
        private IColorSchemeManager colorSchemeManager;
        [Inject]
        private void Construct(IColorSchemeManager mng)
        {
            colorSchemeManager = mng;
        }
        public IBattlerPresenter Battle()
        {
            return presenter;
        }

        public Task<IWeapon> ChooseWeapon(IWeapon first, IWeapon alternative)
        {
            return weaponChooser.ChooseFrom(first, alternative).AsTask();
        }

        public Task ShowGameOver(bool isGameWon)
        {
            return gameResultsScreen.Process(isGameWon).AsTask();
        }

        public Task ShowStage(int stage)
        {
            colorSchemeManager.ChangeColorScheme();
            return Task.CompletedTask;
        }

        public Task ShowStartingStats(IEntityStats stats)
        {
            return startStatsScreen.Process(stats).AsTask();
        }

        public Task<ISkillTree> ChooseSkillTree(IEnumerable<ISkillTree> descriptors)
        {
            return skillChooser.ChooseFrom(descriptors).AsTask();
        }
    }
}
