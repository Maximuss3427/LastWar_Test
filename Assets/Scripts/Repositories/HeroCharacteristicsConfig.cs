using LastWarTest.Domain.Gameplay.Models;
using UnityEngine;

namespace LastWarTest.Repositories
{
    [CreateAssetMenu(fileName = "HeroCharacteristicsConfig", menuName = "LastWarTest/Hero Characteristics Config")]
    public class HeroCharacteristicsConfig : ScriptableObject
    {
        public HeroCharacteristicsModel baseHeroCharacteristics;
        public HeroCharacteristicsModel levelUpHeroCharacteristics;
    }
}