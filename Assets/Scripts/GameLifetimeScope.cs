using AutoBattler.External;
using Game.Repositories;
using Game.View;
using System.Threading.Tasks;
using UnityEngine;
using VContainer;
using VContainer.Unity;
public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] GameController controller;
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance<IGameController>(controller);
        builder.RegisterEntryPoint<GameRunner>(Lifetime.Singleton);
    }
}
