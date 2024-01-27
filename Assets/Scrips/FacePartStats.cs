using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FacePartStats : MonoBehaviour
{
   public int _ID;
   public string name;
   private Button _part;
   private GameObject facepart;
   public int _healtpoints = 8;

   private void Awake()
   {
      facepart = gameObject;
      _part = gameObject.GetComponent<Button>();
      SetID();
      name = facepart.name;
   }

   private void SetID()
   {
      switch (facepart.name)
      {
         case "Ojos":
            _ID = 1;
            break;
         case "Orejas":
            _ID = 2;
            break;
         case "Nariz":
            _ID = 3;
            break;
         case "Boca":
            _ID = 4;
            break;
      }
   }

   public void TakeDamage(int damage)
   {
      _healtpoints -= damage;
      if (_healtpoints <= 0)
      {
         _part.interactable = false;
      }
   }

   public void Heal()
   {
      _healtpoints += 1;
   }
   
}
