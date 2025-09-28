using UnityEngine;
using Game.Registries;
namespace Game.Repositories
{
    [CreateAssetMenu(fileName = "Entity Skin", menuName = "Scriptable Objects/Entity/Skin")]
    public class BattleEntitySkinSO: IdentifiableScriptableObject
    {
        [field: SerializeField] public GameObject Skin { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
    }
}
