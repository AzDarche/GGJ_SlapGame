using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FacepartSelector : MonoBehaviour
{
    private int selectedPart;
    private FacePartStats Part;
    [SerializeField] private TextMeshProUGUI HealtStat;
    [SerializeField] private TextMeshProUGUI Name;

    public void GetButtonName()
    {
        Part = EventSystem.current.currentSelectedGameObject.GetComponent<FacePartStats>();
        ShowStats();
    }

    private void ShowStats()
    {
        HealtStat.text = ((Part.healtpoints * 100) / 8).ToString();
        Name.text = Part.name;

    }

    public void DamageSelectedPart(int damage)
    {
        Part.TakeDamage(damage);
    }

}
