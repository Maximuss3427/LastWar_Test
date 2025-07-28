using LastWarTest.Domain.Gameplay.Models;
using LastWarTest.Interfaces.Repositories;
using LastWarTest.Repositories;
using LastWarTest.UseCases;
using VContainer;
using VContainer.Unity;

namespace LastWarTest.Installers.Gameplay
{
    public class HeroLifetimeScope : LifetimeScope
    {
        public HeroCharacteristicsConfigRepository heroCharacteristicsConfigRepository;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance<IHeroCharacteristicsRepository>(heroCharacteristicsConfigRepository);
            builder.Register<HeroModel>(Lifetime.Singleton);
            builder.Register<InitializeHeroUseCase>(Lifetime.Singleton);
            builder.Register<UpgradeHeroUseCase>(Lifetime.Singleton);
        }
    }
}
