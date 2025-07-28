using System;
using LastWarTest.Domain.Gameplay.MessagesDTO;
using LastWarTest.Domain.Gameplay.Models;
using LastWarTest.Interfaces.Repositories;
using LastWarTest.Interfaces.Views.Gameplay;
using MessagePipe;
using R3;
using VContainer.Unity;
using DisposableBag = MessagePipe.DisposableBag;

namespace LastWarTest.Presentation.Gameplay.Presenters
{
    public class HeroUpgradePresenter : IStartable, IDisposable
    {
        private readonly HeroModel _heroModel;
        private readonly IHeroCharacteristicsRepository _heroCharacteristicsRepository;
        private readonly IHeroUpgradeView _heroUpgradeView;
        private readonly IPublisher<UpgradeHeroMessage> _heroUpgradePublisher;
        
        private IDisposable _heroCharacteristicsSubscription;

        public HeroUpgradePresenter(HeroModel heroModel, IHeroCharacteristicsRepository heroCharacteristicsRepository, 
            IHeroUpgradeView heroUpgradeView, IPublisher<UpgradeHeroMessage> heroUpgradePublisher)
        {
            _heroModel = heroModel;
            _heroCharacteristicsRepository = heroCharacteristicsRepository;
            _heroUpgradeView = heroUpgradeView;
            _heroUpgradePublisher = heroUpgradePublisher;
        }

        public void Start()
        {
            var disposableBag = DisposableBag.CreateBuilder();
            _heroModel.Characteristics.Subscribe(_ => ShowHeroUpgrade()).AddTo(disposableBag);
            _heroCharacteristicsSubscription = disposableBag.Build();
            
            _heroUpgradeView.SubscribeToUpgradeRequest(SendUpgradeMessage);
        }

        public void Dispose()
        {
            _heroCharacteristicsSubscription.Dispose();
            _heroUpgradeView.UnsubscribeFromUpgradeRequest(SendUpgradeMessage);
        }

        public void ShowHeroUpgrade()
        {
            _heroUpgradeView.ShowHeroUpgradeInfo(_heroModel.Level.Value, _heroModel.Characteristics.Value, 
                _heroCharacteristicsRepository.GetLevelUpHeroCharacteristics());
        }

        private void SendUpgradeMessage()
        {
            _heroUpgradePublisher.Publish(new UpgradeHeroMessage());
        }
    }
}