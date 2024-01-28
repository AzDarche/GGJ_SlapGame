using System.Collections.Generic;
using UnityEngine;

namespace Scrips {
    public class EnemyTurnControl : MonoBehaviour {
        private List<FacePartStats> _playerFaceParts;

        private void Awake() {
            PopulateParts();
        }

        private void PopulateParts() {
            var namae = "";
            for (var i = 0; i < 4; i++) {
                namae = i switch {
                    0 => "Orejas",
                    1 => "Ojos",
                    2 => "Boca",
                    3 => "Nariz",
                    _ => namae
                };
                _playerFaceParts.Add(new FacePartStats(namae));
            }
        }

        public void DamageRandomPart() {
            _playerFaceParts[Random.Range(0, 3)].TakeDamage(Random.Range(1, 4));
        }
    }
}