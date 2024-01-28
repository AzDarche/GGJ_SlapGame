using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scrips {
    public class EnemyTurnControl : MonoBehaviour {
        [SerializeField] private List<Parts> playerParts;

        public void DamageRandomPart() {
            playerParts[Random.Range(0, 3)].TakeDamage(Random.Range(1, 3));
        }

        public int GetPlayerLife() => playerParts.Sum(part => part.life);
    }
    
    [System.Serializable]
    public class Parts {
        public PartName PartName = PartName.Ojos;
        public int life = 8;
        [SerializeField] private SpriteRenderer baseSprite;
        [SerializeField] private Sprite normalStage;
        [SerializeField] private Sprite damageStage;
        [SerializeField] private Sprite extremeStage;

        
        public void TakeDamage(int damage) {
            life -= damage;
            RefreshSprite();
        }
        private void RefreshSprite()
        {
            switch (life)
            {
                case > 4:
                    baseSprite.sprite = normalStage;
                    break;
                case > 0 and <= 4:
                    baseSprite.sprite = damageStage;
                    break;
                case <= 0:
                    baseSprite.sprite = extremeStage;
                    break;
            }
        }
    }

    public enum PartName {
        Ojos, Orejas, Boca, Nariz
    }
}