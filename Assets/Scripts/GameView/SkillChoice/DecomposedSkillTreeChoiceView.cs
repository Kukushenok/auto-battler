using AutoBattler;
using Cysharp.Threading.Tasks;
using Game.Registries;
using Game.Repositories;
using UnityEngine;
using VContainer;

namespace Game.View
{
    public class DecomposedSkillTreeChoiceView : MonoBehaviourView<SkillTreeChoice>
    {
        [SerializeField] private MonoBehaviourView<Choice> choicer;
        [SerializeField] private MonoBehaviourView<WeaponSO> weaponView;
        [SerializeField] private MonoBehaviourView<SkillDescriptorSO> skillDescriptor;
        [SerializeField] private MonoBehaviourView<string> labelTextView;
        [SerializeField] private MonoBehaviourView<float> bonusHPView;
        [SerializeField] private MonoBehaviorSection section;
        private IRegistry<WeaponSO> weapons;
        private IRegistry<SkillDescriptorSO> skills;

        protected override async UniTask DoHide()
        {
            await UniTask.WhenAll(
                choicer.TryHide(),
                weaponView.TryHide(),
                skillDescriptor.TryHide(),
                labelTextView.TryHide(),
                bonusHPView.TryHide(),
                section.TryHide()
                );
        }

        protected override async UniTask DoInit(SkillTreeChoice value)
        {
            await UniTask.WhenAll(
                choicer.TryInit(value),
                InitForWeapon(value.SkillTree.GetWeapon()),
                skillDescriptor.TryInit(skills.Get(value.SkillTree.GetCurrentSkill().ID)),
                labelTextView.TryInit(value.SkillTree.LabelName),
                bonusHPView.TryInit(value.SkillTree.HealthBonus),
                section.TryShow()
                );
        }
        private UniTask InitForWeapon(IWeapon weapon)
        {
            if (weapon == null) return UniTask.CompletedTask;
            return weaponView.TryInit(weapons.Get(weapon.ID));
        }
        private UniTask UpdateForWeapon(IWeapon weapon)
        {
            if (weapon == null) return UniTask.CompletedTask;
            return weaponView.TryUpdate(weapons.Get(weapon.ID));
        }

        protected override async UniTask DoUpdate(SkillTreeChoice value)
        {
            await UniTask.WhenAll(
                choicer.TryUpdate(value),
                UpdateForWeapon(value.SkillTree.GetWeapon()),
                skillDescriptor.TryUpdate(skills.Get(value.SkillTree.GetCurrentSkill().ID)),
                labelTextView.TryUpdate(value.SkillTree.LabelName),
                bonusHPView.TryUpdate(value.SkillTree.HealthBonus)
                );
        }

        [Inject]
        private void Construct(IRegistry<WeaponSO> weapons, IRegistry<SkillDescriptorSO> skills)
        {
            this.weapons = weapons;
            this.skills = skills;
        }
    }
}
