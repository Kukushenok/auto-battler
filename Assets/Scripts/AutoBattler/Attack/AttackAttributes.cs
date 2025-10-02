using System.Threading.Tasks;

namespace AutoBattler
{
    public class AttackAttributes: IAttack
    {
        public readonly float Damage;
        public readonly AttackType Type;
        public readonly bool IsMissable = false;
        public AttackAttributes(AttackType type, float damage, bool isMissable = false)
        {
            Type = type;
            Damage = damage;
            IsMissable = isMissable;
        }
        public float TotalDamage => Damage;
        public async Task Visualize(IAttackPresenter presenter)
        {
            await presenter.VisualiseBasicAttack(this);
        }
        public AttackAttributes WithDamage(float newDamage)
        {
            return new AttackAttributes(Type, newDamage, IsMissable);
        }
        public AttackAttributes WithTypeAndDamage(AttackType newType, float newDamage)
        {
            return new AttackAttributes(newType, newDamage, IsMissable);
        }
        public static AttackAttributes SkillDamage(float damage)
        {
            return new AttackAttributes(AttackType.Ability, damage, false);
        }
    }
}
