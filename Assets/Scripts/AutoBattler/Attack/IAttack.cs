using System.Threading.Tasks;

namespace AutoBattler
{
    public interface IAttack
    {
        public float TotalDamage { get; }
        public Task Visualize(IAttackPresenter presenter);
    }
}
