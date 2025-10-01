using AutoBattler.External;
using Game.View;
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
