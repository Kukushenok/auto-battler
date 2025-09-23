using UnityEngine;
using Game.Registries;
using System.Collections.Generic;
using System.Collections;
using AutoBattler;
namespace Game.Repositories
{
    [CreateAssetMenu(fileName = "EntityViewRepository", menuName = "Scriptable Objects/EntityViewRepository")]
    public class BattleEntitySkinRepository : IdentifiableRegistry<BattleEntitySkinSO>
    {

    }
    public class BattleEntitySkinSO: IdentifiableScriptableObject
    {
        [field: SerializeField] public GameObject SkinPrefab;
    }
    public interface IBattleEntitySkinRepository
    {
        public BattleEntitySkinSO GetSkin(string id);
    }
    public class BattleEntitySO: ScriptableObject
    {
        [field: SerializeField] private BattleEntitySkinSO Skin; // in future it is better to be just Skin ID
        [field: SerializeField] private float Health;
        [field: SerializeField] private float Strength;
        [field: SerializeField] private float Dexterity;
        [field: SerializeField] private float Endurance;
        
    }
    public class WeaponSO : ScriptableObject, IWeapon
    {
        [field: SerializeField] public AttackType Source { get; private set; }
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
    }
}
