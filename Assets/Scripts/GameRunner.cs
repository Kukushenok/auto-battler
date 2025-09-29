using AutoBattler.External;
using AutoBattler.Looped;
using AutoBattler.Utils;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using System.Threading.Tasks;
using VContainer;
using VContainer.Unity;
public class GameRunner : IAsyncStartable, ILoopHandler
{
    private IGameController controller;
    private Func<IEntityRepository> entityRepoCreator;
    private Func<ISkillRepository> skillRepoCreator;
    private IRandom random;
    [Inject]
    public GameRunner(IGameController cnt, Func<IEntityRepository> entRepo, Func<ISkillRepository> skRepo, IRandom rnd)
    {
        controller = cnt;
        entityRepoCreator = entRepo;
        skillRepoCreator = skRepo;
        random = rnd;
    }

    public Task<bool> DecideToContinuePlaying()
    {
        return Task.FromResult(true);
    }

    public AutoBattler.AutoBattler.Settings GetSettings()
    {
        return new AutoBattler.AutoBattler.Settings()
        {
            Random = random,
            Controller = controller,
            WinRoundsCount = 5,
            EntityRepository = entityRepoCreator(),
            SkillRepository = skillRepoCreator()
        };
    }

    public async UniTask StartAsync(CancellationToken cancellation = default)
    {
        var battler = new AutoBattlerLoop(this);
        await battler.Play();
    }
}
