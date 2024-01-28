using System;
using System.Collections;
using Scrips.States;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace Scrips {
    public class PowerBar : MonoBehaviour
    {
        [SerializeField] private Image barra;
        [SerializeField] private TextMeshProUGUI contador;
        [SerializeField] private TextMeshProUGUI daño;
        [Range(1f,5f)][SerializeField] private int dificultad; 
        private float _time;
        private float _fill;
        private StateMachine _stateMachine;
        private int _storedDamage;

        private bool _timeStop;

        private void Awake() {
            _stateMachine = StateMachine.Instance;
        }

        private void OnEnable()
        {
            _fill = 0;
            _time = 0;
            _timeStop = true;
        }

        // Start is called before the first frame update
        private void Start() {
            barra.fillAmount = _fill;
            contador.text = "0";
            _timeStop = true;
        }

        // Update is called once per frame
        private void Update() {
        
            if (_timeStop) {
                if (_fill > 0.01)
                    _fill -= dificultad*(0.12f * Time.deltaTime);

                _time += (1f * Time.deltaTime);
                contador.text = _time.ToString("F0");
                barra.fillAmount = _fill;
                Charge();
            }
            else {
                _storedDamage = (int)math.floor(_fill * 4f);
                daño.text = (_storedDamage).ToString("F0");
                if (_storedDamage > 4)
                {
                    _storedDamage = 4;
                }
                StateMachine.Instance.damage = _storedDamage;
                Debug.Log(_stateMachine.damage +" " + _storedDamage );
            }
        }
    
        private void Charge() {
            if (Input.GetKeyDown(KeyCode.Space))
                _fill += (0.05f + dificultad/150f) * Time.timeScale;
            if (_time >= 5.00f) {
                _timeStop = false;
                StartCoroutine(ChangeState());
            }
        }
        
        private IEnumerator ChangeState() {
            yield return new WaitForSeconds(2);
            _stateMachine.ChangeState(new  PrecisionBarState(_stateMachine));
        }
    }
}
