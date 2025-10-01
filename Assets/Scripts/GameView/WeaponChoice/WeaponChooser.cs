using AutoBattler;
using Cysharp.Threading.Tasks;
using Game.Registries;
using Game.Repositories;
using UnityEngine;
using VContainer;

namespace Game.View
{
    public class WeaponChooser : MonoBehaviour
    {
        [SerializeField] private MonoBehaviourView<WeaponChoice> currentWeaponView;
        [SerializeField] private MonoBehaviourView<WeaponChoice> alternativeWeaponView;
        [SerializeField] private MonoBehaviorSection WindowAnimator;

        private IRegistry<WeaponSO> Weapons;
        [Inject]
        private void Construct(IRegistry<WeaponSO> descriptors)
        {
            Weapons = descriptors;
        }
        public async UniTask<IWeapon> ChooseFrom(IWeapon current, IWeapon alternate)
        {
            await WindowAnimator.Show();
            UniTaskCompletionSource<IWeapon> select = new UniTaskCompletionSource<IWeapon>();
            var currentSO = Weapons.Get(current.ID);
            var alternateSO = Weapons.Get(alternate.ID);
            await UniTask.WhenAll(
                currentWeaponView.InitValueAsync(new WeaponChoice(() => select.TrySetResult(current), currentSO)),
                alternativeWeaponView.InitValueAsync(new WeaponChoice(() => select.TrySetResult(alternate), alternateSO))
            );
            var result = await select.Task;
            await UniTask.WhenAll(
                currentWeaponView.Hide(),
                alternativeWeaponView.Hide()
            );

            await WindowAnimator.Hide();
            return result;
        }
    }
}
