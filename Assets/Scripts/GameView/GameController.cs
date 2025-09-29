using AutoBattler;
using AutoBattler.External;
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.View
{
    public class GameController: MonoBehaviour, IGameController
    {
        [SerializeField] private BaseBattlePresenter presenter;
        [SerializeField] private SkillChooser skillChooser;
        [SerializeField] private WeaponChooser weaponChooser;
        [SerializeField] private MonoBehaviourProcess<bool> gameResultsScreen;
        [SerializeField] private MonoBehaviourProcess<IEntityStats> startStatsScreen;
        public IBattlerPresenter Battle()
        {
            return presenter;
        }

        public Task<ISkillDescriptor> ChooseGameSkill(IEnumerable<ISkillDescriptor> descriptors)
        {
            return skillChooser.ChooseFrom(descriptors).AsTask();
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
            Debug.Log("—“¿ƒ»ﬂ: " + stage);
            return Task.CompletedTask;
        }

        public Task ShowStartingStats(IEntityStats stats)
        {
            return startStatsScreen.Process(stats).AsTask();
        }
    }
}
