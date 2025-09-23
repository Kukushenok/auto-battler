using System.Threading.Tasks;

namespace AutoBattler
{
    public interface IAttackPresenter
    {
        public Task VisualiseBasicAttack(AttackType src, float damage)=> Task.CompletedTask;
        public Task VisualiseOtherAttack(string animID, AttackType src, float damage) => Task.CompletedTask;
    }
}
