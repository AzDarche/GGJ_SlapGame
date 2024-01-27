using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PrecisionBar : MonoBehaviour {

    public float damage;
    [SerializeField] private int damageAccumulated = 1;
    [SerializeField] private GameObject difficultyBar;
    [SerializeField] private GameObject cursor;
    private float _missFactor;
    private bool _isStopped;
    private float _maxYPos = 2.6f;
    private float _minScale = 0.35f;
    private float _cursorSpeed = 2f;
    private float _cursorVelocity;
    private Transform _cursorTransform;
    private Transform _difficultyTransform;
    
    private void Awake() {
        _missFactor = 5 - damageAccumulated;
        SetDifficultyBar();
        SetCursor();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && !_isStopped){
            CalculateDamage();
            _isStopped = true;
        }
    }

    private void FixedUpdate() {
        if (_isStopped)
            return;
        MoveCursor();
    }

    private void SetCursor() {
        _cursorSpeed *= 2 + damageAccumulated;
        _cursorTransform = cursor.transform;
        _cursorVelocity = _cursorSpeed;
    }

    private void MoveCursor() {
        var position = _cursorTransform.position;
        _cursorVelocity = position.y switch {
            > 2.6f => _cursorSpeed * -1f,
            < -2.6f => _cursorSpeed,
            _ => _cursorVelocity
        };
        position.y += _cursorVelocity * Time.fixedDeltaTime;
        _cursorTransform.position = position;
    }
    
    private void SetDifficultyBar() {
        _difficultyTransform = difficultyBar.transform;
        var scaleMultiplayer = (_missFactor*_missFactor * 5 / 100) + 1;
        _difficultyTransform.localScale = new Vector3(1f, _minScale * scaleMultiplayer, 1);
        _difficultyTransform.position = new Vector3(0f, Random.Range(-_maxYPos, _maxYPos), -1);
    }

    private void CalculateDamage() {
        var cursorPosition = _cursorTransform.position.y;
        var difficultyPosition = _difficultyTransform.position.y;
        var difference = Math.Abs(difficultyPosition - cursorPosition);
        damage = (2 + _missFactor - difference) * 100 / (2 + _missFactor);
        damage = damage switch {
            > 89 => 100,
            > 74 => 75,
            > 40 => 50,
            _ => 0
        };

        damage = damage / 100 * damageAccumulated;
    }
    
}
