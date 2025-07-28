using System;
using R3;

namespace LastWarTest.Domain.Gameplay.Models
{
    [Serializable]
    public class HeroModel
    {
        public ReactiveProperty<int> Level { get; private set; } = new();
        public ReactiveProperty<HeroCharacteristicsModel> Characteristics { get; private set; } = new();

        public void IncreaseLevel(HeroCharacteristicsModel characteristicsIncrease)
        {
            Level.Value++;
            Characteristics.Value += characteristicsIncrease;
        }
    }
}
