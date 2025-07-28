using LastWarTest.Domain.Gameplay.MessagesDTO;
using LastWarTest.Domain.Gameplay.Models;
using LastWarTest.Interfaces.Repositories;
using MessagePipe;

namespace LastWarTest.UseCases
{
    public class UpgradeHeroUseCase
    {
        public UpgradeHeroUseCase(HeroModel heroModel, IHeroCharacteristicsRepository heroCharacteristicsRepository, 
            ISubscriber<UpgradeHeroMessage> updateHeroSubscriber)
        {
            updateHeroSubscriber.Subscribe(_ =>
                heroModel.IncreaseLevel(heroCharacteristicsRepository.GetLevelUpHeroCharacteristics()));
        }
    }
}