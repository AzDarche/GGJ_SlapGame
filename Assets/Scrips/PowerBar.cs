using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
    [SerializeField] private Image barra;
    [SerializeField] private TextMeshProUGUI contador;
    [SerializeField] private TextMeshProUGUI daño;
    [Range(1f,5f)][SerializeField] private int dificultad; 
    private float _time = 0f;
    private float _fill = 0f;

    private bool _timeStop;
    // Start is called before the first frame update
    void Start()
    {
        barra.fillAmount = _fill;
        contador.text = "0";
        _timeStop = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (_timeStop)
        {
            if (_fill > 0.01)
            {
                _fill -= dificultad*(0.12f * Time.deltaTime);
            }
            
            _time += (1f * Time.deltaTime);
            contador.text = _time.ToString("F0");
            barra.fillAmount = _fill;
            Charge();
        }
        else
        {
            daño.text = (_fill * 4 ).ToString("F0");
        }
    }
    
    private void Charge()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _fill += 0.05f + (dificultad/150f);
        }
        if (_time >= 5.00f)
        {
            _timeStop = false;
        }
    }
}
