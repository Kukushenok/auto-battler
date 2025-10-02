using System.Threading.Tasks;

namespace AutoBattler
{
    public interface IAttackPresenter
    {
        public Task VisualiseBasicAttack(AttackAttributes attrs);
        public Task VisualiseOtherAttack(string animID, AttackAttributes attrs);
    }
}
