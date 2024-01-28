using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Scrips.States;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scrips {
    public class FacePartSelector : MonoBehaviour {
        
        private int _selectedPart;
        private StateMachine _stateMachine;
        private FacePartStats _part;
        [SerializeField] private List<FacePartStats> _partsList;
        [SerializeField] private TextMeshProUGUI healthStat;
        [SerializeField] private TextMeshProUGUI Name;

        private void Awake() {
            _stateMachine = StateMachine.Instance;
        }

        public int GetEnemyLife() => _partsList.Sum(part => part.healthPoints);

        public void GetButtonName()
        {
            _part = EventSystem.current.currentSelectedGameObject.GetComponent<FacePartStats>();
            _stateMachine.SetObjective(_part);
            StartCoroutine(ChangeState());
            ShowStats();
        }

        private void ShowStats()
        {
            healthStat.text = ((_part.healthPoints * 100) / 8).ToString();
            Name.text = _part.name;

        }

        public void DamageSelectedPart(int damage) {
            _part.TakeDamage(damage);
        }

        private IEnumerator ChangeState() {
            yield return new WaitForSeconds(2);
            _stateMachine.ChangeState(new PowerBarState(_stateMachine));
        }
    }
}
