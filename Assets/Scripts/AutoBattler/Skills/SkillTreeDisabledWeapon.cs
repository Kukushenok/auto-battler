using AutoBattler.External;

namespace AutoBattler
{
    internal class SkillTreeDisabledWeapon : ISkillTree
    {
        private ISkillTree decorating;

        public bool IsExausted => decorating.IsExausted;

        public int Level => decorating.Level;

        public float HealthBonus => decorating.HealthBonus;

        public string LabelName => decorating.LabelName;

        public string ID => decorating.ID;

        public ISkillDescriptor GetCurrentSkill()
        {
            return decorating.GetCurrentSkill();
        }

        public IWeapon GetWeapon()
        {
            return null;
        }
        public SkillTreeDisabledWeapon(ISkillTree decorating)
        {
            this.decorating = decorating;
        }
    }
}
