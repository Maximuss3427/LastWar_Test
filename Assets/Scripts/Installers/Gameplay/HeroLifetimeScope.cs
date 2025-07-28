using LastWarTest.Domain.Gameplay.Models;
using LastWarTest.Interfaces.Repositories;
using LastWarTest.Interfaces.Views.Gameplay;
using LastWarTest.Presentation.Gameplay.Presenters;
using LastWarTest.Presentation.Gameplay.Views.Gameplay;
using LastWarTest.Repositories;
using LastWarTest.UseCases;
using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace LastWarTest.Installers.Gameplay
{
    public class HeroLifetimeScope : LifetimeScope
    {
        [field: SerializeField] 
        private HeroCharacteristicsConfigRepository heroCharacteristicsConfigRepository { get; set; }
        [field: SerializeField] private HeroUpgradeView heroUpgradeView { get; set; }
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterMessagePipe();
            builder.RegisterInstance<IHeroCharacteristicsRepository>(heroCharacteristicsConfigRepository);
            builder.Register<HeroModel>(Lifetime.Singleton);
            builder.RegisterEntryPoint<InitializeHeroUseCase>();
            builder.RegisterEntryPoint<UpgradeHeroUseCase>();
            
            builder.RegisterInstance<IHeroUpgradeView>(heroUpgradeView);
            builder.RegisterEntryPoint<HeroUpgradePresenter>();
        }
    }
}
