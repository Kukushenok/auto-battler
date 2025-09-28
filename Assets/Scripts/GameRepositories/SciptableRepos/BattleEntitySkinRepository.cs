using UnityEngine;
using Game.Registries;
using System.Collections.Generic;
using System.Collections;
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
