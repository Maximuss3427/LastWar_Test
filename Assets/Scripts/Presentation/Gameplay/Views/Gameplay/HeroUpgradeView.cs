using System;
using LastWarTest.Domain.Gameplay.Models;
using LastWarTest.Interfaces.Views.Gameplay;
using UnityEngine;
using UnityEngine.UIElements;

namespace LastWarTest.Presentation.Gameplay.Views.Gameplay
{
    public class HeroUpgradeView : MonoBehaviour, IHeroUpgradeView
    {
        [field: SerializeField] public UIDocument heroUpgradeDocument { get; private set; }

        private Label _levelLabel;
        private Label _healthLabel;
        private Label _attackLabel;
        private Label _moveSpeedLabel;
        private Label _attackSpeedLabel;
        private Button _upgradeButton;
        
        private void Awake()
        {
            _levelLabel = heroUpgradeDocument.rootVisualElement.Q<Label>("Level");
            _healthLabel = heroUpgradeDocument.rootVisualElement.Q<Label>("CharacteristicHealth");
            _attackLabel = heroUpgradeDocument.rootVisualElement.Q<Label>("CharacteristicAttack");
            _moveSpeedLabel = heroUpgradeDocument.rootVisualElement.Q<Label>("CharacteristicMoveSpeed");
            _attackSpeedLabel = heroUpgradeDocument.rootVisualElement.Q<Label>("CharacteristicAttackSpeed");
            _upgradeButton = heroUpgradeDocument.rootVisualElement.Q<Button>("UpgradeButton");
        }

        public void ShowHeroUpgradeInfo(int level, HeroCharacteristicsModel heroCharacteristics, 
            HeroCharacteristicsModel upgrade)
        {
            _levelLabel.text = $"Level: {level}";
            _healthLabel.text = $"Hero health: {heroCharacteristics.Health} <color=#ee3>+{upgrade.Health}</color>";
            _attackLabel.text = $"Hero attack: {heroCharacteristics.Attack} <color=#ee3>+{upgrade.Attack}</color>";
            _moveSpeedLabel.text = $"Hero move speed: {heroCharacteristics.MoveSpeed:0.##} " +
                                   $"<color=#ee3>+{upgrade.MoveSpeed:0.##}</color>";
            _attackSpeedLabel.text = $"Hero attack speed: {heroCharacteristics.AttackSpeed:0.##} " +
                                     $"<color=#ee3>+{upgrade.AttackSpeed:0.##}</color>";
        }

        public void SubscribeToUpgradeRequest(Action subscriber)
        {
            _upgradeButton.clicked += subscriber;
        }

        public void UnsubscribeFromUpgradeRequest(Action subscriber)
        {
            _upgradeButton.clicked -= subscriber;
        }
    }
}
