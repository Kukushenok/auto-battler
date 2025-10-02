using AutoBattler.External;
using AutoBattler.Utils;
using Game.Registries;
using Game.Repositories;
using Game.View.Audio;
using Game.View.ColorScheme;
using UnityEngine;
using VContainer;
using VContainer.Unity;
public class RootLifetimeScope : LifetimeScope
{
    [SerializeField] private BattleEntitySO player;
    [SerializeField] private ColorSchemeSO colorSchemeSO;
    [SerializeField] private FightRepository fightRepository;
    [SerializeField] private BattleEntitySkinRepository battleEntitySkins;
    [SerializeField] private WeaponRepository weaponRepository;
    [SerializeField] private PlayerSkillChooseRepository skillChooseRepository;
    [SerializeField] private SkillDescriptorRepository skillRepository;
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<IRandom, BasicRandom>(Lifetime.Transient);
        builder.RegisterInstance<IRegistry<BattleEntitySkinSO>>(battleEntitySkins);
        builder.RegisterInstance<IRegistry<WeaponSO>>(weaponRepository);
        builder.RegisterInstance<IRegistry<SkillDescriptorSO>>(skillRepository);
        builder.RegisterFactory<IEntityRepository>(() => new EntityRepository(player, fightRepository));
        builder.RegisterFactory<ISkillRepository>(skillChooseRepository.CreateRepo);
        builder.Register<IColorSchemeRepository>((rsv) => new ColorSchemeRepository(rsv.Resolve<IRandom>(), colorSchemeSO), Lifetime.Singleton);
        builder.Register<IColorSchemeManager, ColorSchemeManager>(Lifetime.Singleton);
        builder.RegisterEntryPoint<AudioSourceAudioManager>(Lifetime.Singleton);
    }
}
