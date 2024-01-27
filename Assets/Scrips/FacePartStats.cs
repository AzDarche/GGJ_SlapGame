using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FacePartStats : MonoBehaviour
{
   public string name;
   private Button _BttnPart;
   private GameObject facepart;
   public int healtpoints = 8;

   private void Awake()
   {
      facepart = gameObject;
      _BttnPart = gameObject.GetComponent<Button>();
      name = facepart.name;
   }
   

   public void TakeDamage(int damage)
   {
      healtpoints -= damage;
      if (healtpoints <= 0)
      {
         _BttnPart.interactable = false;
      }
   }

   public void Heal()
   {
      healtpoints += 1;
   }
   
}
