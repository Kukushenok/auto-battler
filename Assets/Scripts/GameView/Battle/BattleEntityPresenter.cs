using AutoBattler;
using AutoBattler.External;
using Cysharp.Threading.Tasks;
using Game.Registries;
using Game.Repositories;
using UnityEngine;
using VContainer;

namespace Game.View
{
    public class BattleEntityPresenter : MonoBehaviour, IBattleEntityPresenter
    {
        public IAttackPresenter AttackPresenter => entityView;
        [SerializeField] private MonoBehaviourView<HealthStats> healthView;
        [SerializeField] private MonoBehaviourView<IEntityStats> statsView;
        [SerializeField] private MonoBehaviourView<WeaponSO> weaponView;
        [SerializeField] private EntityView entityView;
        private IRegistry<BattleEntitySkinSO> skinRepo;
        private IRegistry<WeaponSO> weaponRepo;
        private HealthStats lastHealthStats;
        [Inject]
        private void Construct(IRegistry<WeaponSO> descriptors, IRegistry<BattleEntitySkinSO> skins)
        {
            weaponRepo = descriptors;
            skinRepo = skins;
        }


        public async UniTask Die()
        {
            await entityView.Die();
        }
        public UniTask Hide()
        {
            return UniTask.WhenAll(healthView.TryHide(), statsView.TryHide(), weaponView.TryHide(), entityView.TryHide());
        }
        public UniTask UpdateHealth(float newHP)
        {
            lastHealthStats.HP = newHP;
            return healthView.UpdateValue(lastHealthStats);
        }
        void IBattleEntityPresenter.UseSkin(string skin)
        {
            var x = skinRepo.Get(skin);
            entityView.InitValueAsync(x).Forget();
        }

        void IBattleEntityPresenter.UseVisualModifier(string modifier)
        {

        }

        void IBattleEntityPresenter.WithHealth(IHealth health)
        {
            lastHealthStats = new HealthStats(health);
            healthView.InitValueAsync(lastHealthStats).Forget();
        }

        void IBattleEntityPresenter.WithStats(IEntityStats stats)
        {
            statsView.InitValueAsync(stats).Forget();
        }

        void IBattleEntityPresenter.WithWeapon(IWeapon weapon)
        {
            var x = weaponRepo.Get(weapon.ID);
            weaponView.InitValueAsync(x).Forget();
        }

    }
}
