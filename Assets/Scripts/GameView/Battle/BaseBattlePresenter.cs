using AutoBattler;
using AutoBattler.Battle;
using AutoBattler.External;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.View
{
    public class BaseBattlePresenter : MonoBehaviour, IBattlerPresenter, IBattleEventReporter
    {
        [SerializeField] private BattleEntityPresenter player;
        [SerializeField] private BattleEntityPresenter enemy;
        [SerializeField] private MonoBehaviourView<DexterityCheck> DexterityCheckView;
        public IBattleEntityPresenter GetEnemyPresenter() => enemy;

        public IBattleEntityPresenter GetPlayerPresenter() => player;

        public async Task PerformAttack(IAttack attack, bool isPlayer)
        {
            await attack.Visualize((isPlayer ? player : enemy).AttackPresenter);
        }

        public async Task ProcessEnd(bool winSide)
        {
            await (winSide ? enemy : player).Die();
            await UniTask.WhenAll(player.Hide(), enemy.Hide());
        }

        public async Task ReportDexterity(int wanted, int got, bool isPlayer)
        {
            await DexterityCheckView.InitValueAsync(new DexterityCheck(got, wanted, isPlayer));
            await DexterityCheckView.Hide();
        }

        public async Task Run(IEnumerable<IBattleEvent> events)
        {
            foreach(var x in events)
            {
                await x.Visualize(this);
            }
        }

        public async Task UpdateHealth(float healthNow, bool isPlayer)
        {
            await (isPlayer ? player: enemy).UpdateHealth(healthNow);
        }
    }
}
