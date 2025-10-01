using Game.Registries;
using UnityEngine;
namespace Game.Repositories
{
    [CreateAssetMenu(fileName = "Entity Skin Repository", menuName = "Scriptable Objects/Entity/Skin Repository")]
    public class BattleEntitySkinRepository : IdentifiableRegistry<BattleEntitySkinSO>
    {

    }
    public interface IBattleEntitySkinRepository
    {
        public BattleEntitySkinSO GetSkin(string id);
    }
    public interface IWeaponRepository
    {
        public WeaponSO GetWeaponInfo(string id);
    }
}
