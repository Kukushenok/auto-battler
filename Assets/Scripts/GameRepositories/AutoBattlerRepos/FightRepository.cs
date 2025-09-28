using AutoBattler;
using AutoBattler.External;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Repositories
{
    [CreateAssetMenu(fileName = "Fight Repository", menuName = "Scriptable Objects/Entity/Fight Repository")]
    public class FightRepository : ScriptableObject
    {
        [Serializable]
        private struct Fight: IFightDescriptor
        {
            public BattleEntitySO BattleEntity;
            public WeaponSO Reward;

            public IBattleEntityBuilder GetOpposingEntity()
            {
                return BattleEntity.Get();
            }

            public IWeapon GetReward()
            {
                return Reward;
            }
        }
        [SerializeField] private Fight[] Fights;
        public IEnumerable<IFightDescriptor> GetFightDescriptors()
        {
            foreach(var F in Fights)
            {
                yield return F;
            }
        }
    }
}
