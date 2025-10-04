using AutoBattler.External;
using AutoBattler.Looped;
using AutoBattler.Utils;
using Cysharp.Threading.Tasks;
using Game.View;
using System;
using System.Threading;
using System.Threading.Tasks;
using VContainer;
using VContainer.Unity;
public class GameRunner : IAsyncStartable, ILoopHandler
{
#if UNITY_WEBGL
    private const bool DISABLE_QUIT = true;
#else
    private const bool DISABLE_QUIT = false;
#endif
    private IGameController controller;
    private Func<IEntityRepository> entityRepoCreator;
    private Func<ISkillRepository> skillRepoCreator;
    private IRandom random;
    private IMainMenu mainMenu;
    [Inject]
    public GameRunner(IGameController cnt, Func<IEntityRepository> entRepo, Func<ISkillRepository> skRepo, IRandom rnd, IMainMenu menu)
    {
        controller = cnt;
        entityRepoCreator = entRepo;
        skillRepoCreator = skRepo;
        random = rnd;
        mainMenu = menu;
    }

    public async Task<bool> DecideToContinuePlaying()
    {
        return (await mainMenu.Show(DISABLE_QUIT)) == IMainMenu.Move.PlayGame;
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
