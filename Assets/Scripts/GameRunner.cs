using AutoBattler.External;
using AutoBattler.Utils;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using VContainer;
using VContainer.Unity;

public class GameRunner : IAsyncStartable
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
    public async UniTask StartAsync(CancellationToken cancellation = default)
    {
        var battler = new AutoBattler.AutoBattler(
            new AutoBattler.AutoBattler.Settings()
            {
                Random = random,
                Controller = controller,
                WinRoundsCount = 5,
                EntityRepository = entityRepoCreator(),
                SkillRepository = skillRepoCreator()
            }
        );
        await battler.Play();
    }
}
