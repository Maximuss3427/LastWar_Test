using LastWarTest.Domain.Gameplay.Models;
using LastWarTest.Interfaces.Repositories;
using VContainer.Unity;

namespace LastWarTest.UseCases
{
    public class InitializeHeroUseCase : IStartable
    {
        private readonly HeroModel _heroModel;
        private readonly IHeroCharacteristicsRepository _heroCharacteristicsRepository;

        public InitializeHeroUseCase(HeroModel heroModel, IHeroCharacteristicsRepository heroCharacteristicsRepository)
        {
            _heroModel = heroModel;
            _heroCharacteristicsRepository = heroCharacteristicsRepository;
        }

        public void Start()
        {
            _heroModel.Characteristics.Value = _heroCharacteristicsRepository.GetBaseHeroCharacteristics();
        }
    }
}