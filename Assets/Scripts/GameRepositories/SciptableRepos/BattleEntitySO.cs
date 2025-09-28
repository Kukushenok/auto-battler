using AutoBattler;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Repositories
{
    public interface IBattleEntityGetter 
    {
        public IBattleEntityBuilder Get();
    }
    [CreateAssetMenu(fileName = "Entity Object", menuName = "Scriptable Objects/Entity/Object")]
    public class BattleEntitySO: ScriptableObject, IBattleEntityGetter
    {
        [SerializeField] private BattleEntitySkinSO Skin; // in future it is better to be just Skin ID
        [SerializeField] private float Health;
        [SerializeField] private int Strength;
        [SerializeField] private int Dexterity;
        [SerializeField] private int Endurance;
        [SerializeField] private List<SkillDescriptorSO> DefaultSkills;

        public IBattleEntityBuilder Get()
        {
            IBattleEntityBuilder builder = new SkillfulEntityBuilder(Skin.ID);
            builder.OverrideHealth(new Health(Health));
            builder.OverrideStats(new EntityStats(Strength, Dexterity, Endurance));
            DefaultSkills.ForEach(S => builder.AddSkill(S.CreateSkill()));
            return builder;
        }
    }
}
