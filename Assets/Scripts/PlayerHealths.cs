using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerHealths : MonoBehaviour
{    
    [SerializeField] int _health = 5;
    [SerializeField] TargetManager _targetManager;
    [SerializeField] int _maxHealth = 8;
    bool _inVulnerable = false;
    [SerializeField] AudioSource _AddHealthsSound;
    [SerializeField] HealthsUI _healthsIcon;    
    public UnityEvent EventOnTakeDamege;    
    private void Start() {
        _targetManager.StartGame();
        _healthsIcon.Setup(_maxHealth);
        _healthsIcon.DisplayHealths(_health);
    }
    public void TakeDamage(int damageValue) {
        if (!_inVulnerable) {
            _health -= damageValue;
            if (_health <= 0) {                
                _health = 0;
                Die();
                _healthsIcon.DisplayHealths(_health);
                _targetManager.GameOver();
                return;
            }
            EventOnTakeDamege?.Invoke();
            _healthsIcon.DisplayHealths(_health);
            _inVulnerable = true;
            Invoke(nameof(StopInVulnerable),1f) ;
        }
    }
    void StopInVulnerable() {
        _inVulnerable = false;
    }
    public void AddHeaths(int heathValue) {
        _health += heathValue;
        if (_health > _maxHealth) {
            _health = _maxHealth;
        }
        _healthsIcon.DisplayHealths(_health);
        _AddHealthsSound.Play();
    }
    public void Die() {
        //Debug.Log("You Lose!!!");        
        Destroy(gameObject);        
        //gameObject.SetActive(false);
    }    
}
