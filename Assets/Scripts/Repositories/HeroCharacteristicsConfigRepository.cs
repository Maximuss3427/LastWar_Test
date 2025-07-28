using LastWarTest.Domain.Gameplay.Models;
using LastWarTest.Interfaces.Repositories;
using UnityEngine;

namespace LastWarTest.Repositories
{
    public class HeroCharacteristicsConfigRepository : MonoBehaviour, IHeroCharacteristicsRepository
    {
        [field: SerializeField] public HeroCharacteristicsConfig config { get; private set; }

        public HeroCharacteristicsModel GetBaseHeroCharacteristics()
        {
            return config.baseHeroCharacteristics;
        }

        public HeroCharacteristicsModel GetLevelUpHeroCharacteristics()
        {
            return config.levelUpHeroCharacteristics;
        }
    }
}