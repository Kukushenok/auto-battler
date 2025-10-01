using UnityEngine;
namespace Game.Registries
{
    public abstract class IdentifiableScriptableObject : ScriptableObject, IIdentifiable
    {
        public string ID => name;
    }
}