using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scrips {
    public class EnemyTurnControl : MonoBehaviour {
        public List<Parts> PlayerParts;

        private void Awake() {
            PlayerParts = new List<Parts>();
        }


        public void DamageRandomPart() {
            PlayerParts[Random.Range(0, 3)].TakeDamage(Random.Range(1, 4));
        }
    }

    public struct Parts {
        public PartName PartName;
        private int _life;

        public void TakeDamage(int damage) {
            _life += damage;
        }
    }

    public enum PartName {
        Ojos, Orejas, Boca, Nariz
    }
}