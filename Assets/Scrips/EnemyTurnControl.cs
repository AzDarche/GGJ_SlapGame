
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scrips {
    public class EnemyTurnControl : MonoBehaviour {
        [SerializeField] private List<Parts> playerParts;

        private void Awake() {
            playerParts = new List<Parts>();
        }


        public void DamageRandomPart() {
            playerParts[Random.Range(0, 3)].TakeDamage(Random.Range(1, 4));
        }
    }
    
    [System.Serializable]
    public class Parts {
        public PartName PartName = PartName.Ojos;
        public int life = 8;

        public void TakeDamage(int damage) {
            life += damage;
        }
    }

    public enum PartName {
        Ojos, Orejas, Boca, Nariz
    }
}