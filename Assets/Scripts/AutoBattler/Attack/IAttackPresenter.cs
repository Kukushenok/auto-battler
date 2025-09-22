using System.Threading.Tasks;

namespace AutoBattler
{
    public interface IAttackPresenter
    {
        public Task VisualiseBasicAttack(AttackSource src, float damage)=> Task.CompletedTask;
    }
}
