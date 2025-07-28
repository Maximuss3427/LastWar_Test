using LastWarTest.Domain.Gameplay.Models;

namespace LastWarTest.Interfaces.Repositories
{
    public interface IHeroCharacteristicsRepository
    {
        HeroCharacteristicsModel GetBaseHeroCharacteristics();
        HeroCharacteristicsModel GetLevelUpHeroCharacteristics();
    }
}
