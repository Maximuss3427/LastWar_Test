using System;
using LastWarTest.Domain.Gameplay.MessagesDTO;
using LastWarTest.Domain.Gameplay.Models;
using LastWarTest.Interfaces.Repositories;
using MessagePipe;
using VContainer.Unity;

namespace LastWarTest.UseCases
{
    public class UpgradeHeroUseCase : IStartable, IDisposable
    {
        private readonly HeroModel _heroModel;
        private readonly IHeroCharacteristicsRepository _heroCharacteristicsRepository;
        private readonly ISubscriber<UpgradeHeroMessage> _upgradeHeroSubscriber;
        
        private IDisposable _subscription;
        
        public UpgradeHeroUseCase(HeroModel heroModel, IHeroCharacteristicsRepository heroCharacteristicsRepository, 
            ISubscriber<UpgradeHeroMessage> upgradeHeroSubscriber)
        {
            _heroModel = heroModel;
            _heroCharacteristicsRepository = heroCharacteristicsRepository;
            _upgradeHeroSubscriber = upgradeHeroSubscriber;
        }

        public void Start()
        {
            var disposableBagBuilder = DisposableBag.CreateBuilder();
            _upgradeHeroSubscriber.Subscribe(_ =>
                _heroModel.IncreaseLevel(_heroCharacteristicsRepository.GetLevelUpHeroCharacteristics()))
                .AddTo(disposableBagBuilder);
            _subscription = disposableBagBuilder.Build();
        }

        public void Dispose()
        {
            _subscription.Dispose();
        }
    }
}