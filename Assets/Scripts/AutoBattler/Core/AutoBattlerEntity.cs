using AutoBattler.Utils;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace AutoBattler
{
    public interface IBattlerEntity
    {
        public void GetAttack();
    }
    public interface IEntityStats
    {
        public int Strength { get; }
        public int Dexterity { get; }
        public int Endurance { get; }
    }
    public interface IAutoBattlerEntity: IAttacker, IAttackable
    {
        public IEntityStats Stats { get; }

    }
    public interface IAutoBattlerEntityPresenter: IDisposable
    {
        public IAttackPresenter AttackPresenter { get; }
        public void OnHPChanged(float hp);
    }
    public interface IAutoBattlerEntityDescriptor
    {
        public IAutoBattlerEntity CreateEntity();
        public IAutoBattlerEntityPresenter CreateEntityPresenter();
    }
    public class MissFirstAttackDecorator : IAttackBuilder
    {
        private IAttackBuilder bldr;
        public MissFirstAttackDecorator(IAttackBuilder bldr)
        {
            this.bldr = bldr;
        }

        public IAttackBuilder Append(AttackSource src, float damage)
        {
            if(src != AttackSource.Ability)
            {
                damage = 0;
            }
            bldr = bldr.Append(src, damage);
            return this;
        }

        public IAttack Build()
        {
            return bldr.Build();
        }
    }
    public class AutoBattlerArena
    {
        private IRandom rnd;
        public AutoBattlerArena(IRandom rnd)
        {
            this.rnd = rnd.CreateOtherInstance();
        }
        public IEnumerable<BattleEvent> DoBattle(IAutoBattlerEntity entityA, IAutoBattlerEntity entityB)
        {
            bool isPlayer = true;
            while (!entityB.Health.IsDead)
            {
                bool check = GetRandomCheck(entityA.Stats, entityB.Stats, out var S);
                yield return new BattleEvent(S, isPlayer);
                var builder = entityB.GetAttackBuilder();
                if (!check)
                {
                    builder = new MissFirstAttackDecorator(builder);
                }
                var atk = entityA.DoAttack(builder).Build();
                yield return new BattleEvent(atk, isPlayer);
                entityB.Health.DoDamage(atk.TotalDamage);
                (entityA, entityB) = (entityB, entityA);
                isPlayer = !isPlayer;
            }
        }
        public bool GetRandomCheck(IEntityStats entityA, IEntityStats entityB, out IRandomCheck check)
        {
            int sum = entityA.Dexterity + entityB.Dexterity;
            bool result = BasicRandomCheck.Check(rnd, entityB.Dexterity, sum, out BasicRandomCheck c);
            check = c;
            return result;
        }
    }
    public interface IHealth
    {
        public float HP { get; }
        public float MaxHP { get; }
        public bool IsDead { get; }
        public void DoDamage(float damage);
        public void ResetHealth();
    }
    public interface IWeaponDescriptor
    {
        public IWeapon CreateWeapon();
        public IWeaponPresenter CreatePresenter(IWeapon weapon);
    }
    public interface IWeaponPresenter: IDisposable
    {

    }
    public interface IWeapon: IAttacker
    {
        public string Name { get; }
    }
    public class AutoBattlerPresenterSection
    {
        private IAutoBattlerEntity entityPlayer;
        private IAutoBattlerEntity entityEnemy;
        private IBattlerPresenter battlerPresenter;
        private IRandom rnd;
        public AutoBattlerPresenterSection(IRandom rnd, IBattlerPresenter battle, IAutoBattlerEntityDescriptor player, IAutoBattlerEntityDescriptor enemy)
        {
            rnd = rnd.CreateOtherInstance();
            battlerPresenter = battle;
            entityPlayer = player.CreateEntity();
            entityEnemy = enemy.CreateEntity();
            battlerPresenter.Setup(player, enemy);
        }

        public async Task Perform()
        {
            var battleResult = (new AutoBattlerArena(rnd)).DoBattle(entityPlayer, entityEnemy);
            await battlerPresenter.Run(battleResult);
            await battlerPresenter.ProcessEnd(!entityPlayer.Health.IsDead);
        }
    }
    
    public interface IAutoBattlerController
    {
        public void CreateGameController();
    }
    public class AutoBattler
    {
        public struct Settings
        {
            public int WinRoundsCount;
        }
    }
}
