using System;
using UnityEngine;

namespace LastWarTest.Domain.Gameplay.Models
{
    [Serializable]
    public struct HeroCharacteristicsModel
    {
        [field: SerializeField] public int Health { get; set; }
        [field: SerializeField] public int Attack { get; set; }
        [field: SerializeField] public float MoveSpeed { get; set; }
        [field: SerializeField] public float AttackSpeed  { get; set; }
        
        public HeroCharacteristicsModel(int health, int attack, float moveSpeed, float attackSpeed)
        {
            Health = health;
            Attack = attack;
            MoveSpeed = moveSpeed;
            AttackSpeed = attackSpeed;
        }

        public static HeroCharacteristicsModel operator+(HeroCharacteristicsModel characteristics1, 
            HeroCharacteristicsModel characteristics2)
        {
            return new HeroCharacteristicsModel(
                characteristics1.Health + characteristics2.Health,
                characteristics1.Attack + characteristics2.Attack,
                characteristics1.MoveSpeed + characteristics2.MoveSpeed,
                characteristics1.AttackSpeed + characteristics2.AttackSpeed);
        }
    }
}