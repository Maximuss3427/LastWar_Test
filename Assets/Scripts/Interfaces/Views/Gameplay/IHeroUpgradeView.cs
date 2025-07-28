using System;
using LastWarTest.Domain.Gameplay.Models;

namespace LastWarTest.Interfaces.Views.Gameplay
{
    public interface IHeroUpgradeView
    {
        void ShowHeroUpgradeInfo(int heroLevel, HeroCharacteristicsModel heroCharacteristics, 
            HeroCharacteristicsModel upgrade);
        void SubscribeToUpgradeRequest(Action subscriber);
        void UnsubscribeFromUpgradeRequest(Action subscriber);
    }
}
