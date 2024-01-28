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
      public int healthPoints = 8;

      private void Awake()
      {
         _facePart = gameObject;
         _buttonPart = gameObject.GetComponent<Button>();
         name = _facePart.name;
      }
   

      public void TakeDamage(int damage)
      {
         healthPoints -= damage;
         if (healthPoints <= 0)
         {
            _buttonPart.interactable = false;
         }
      }

      public void Heal()
      {
         healthPoints += 1;
      }
   
   }
}
