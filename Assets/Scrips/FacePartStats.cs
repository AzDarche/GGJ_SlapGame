using System;
using UnityEngine;
using UnityEngine.UI;

namespace Scrips {
   public class FacePartStats : MonoBehaviour {

      public FacePartStats(string namae) {
         name = namae;
      }
      
      public new string name;
      private Button _buttonPart;
      private GameObject _facePart;
      [SerializeField] private Sprite normalStage;
      [SerializeField] private Sprite damageStage;
      [SerializeField] private Sprite extremeStage;
      [SerializeField] private Image imageSprite;
      [SerializeField] private SpriteRenderer baseSprite;
      
      public int healthPoints = 8;

      private void Awake()
      {
         _facePart = gameObject;
         imageSprite = gameObject.GetComponent<Image>();
         _buttonPart = gameObject.GetComponent<Button>();
         name = _facePart.name;
         GameObject go =  GameObject.Find(name + " Base");
         baseSprite = go.GetComponent<SpriteRenderer>();
      }
   

      public void TakeDamage(int damage)
      {
         healthPoints -= damage;
         RefreshSprite();
         if (healthPoints <= 0)
         {
            _buttonPart.interactable = false;
         }
      }

      private void RefreshSprite()
      {
         switch (healthPoints)
         {
            case > 4:
               imageSprite.sprite = normalStage;
               baseSprite.sprite = normalStage;
               break;
            case > 0 and <= 4:
               imageSprite.sprite = damageStage;
               baseSprite.sprite = damageStage;
               break;
            case <= 0:
               imageSprite.sprite = extremeStage;
               baseSprite.sprite = extremeStage;
               break;
         }
         imageSprite.SetNativeSize();
      }

      public void Heal()
      {
         healthPoints += 1;
      }
   
   }
}
