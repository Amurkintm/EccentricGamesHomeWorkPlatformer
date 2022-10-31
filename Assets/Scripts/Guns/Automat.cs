using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Automat : Gun
{

    [Header("Automat")]

    public int NumberOfBullets;
    [SerializeField] TMP_Text _bulletsText;
    [SerializeField] PlayerArmory _playerArmory;
    [SerializeField] Bullet _bullet;
    [SerializeField] int _damageValue;
    [SerializeField] float _mass;

    private void Start() {        
        UpdateText();
    }
    private void Update() {
        if (Input.GetKey(KeyCode.Mouse0) && BulletIsReady) {
            Shot();
        }
    }
    public override void Shot() {
        if (NumberOfBullets > 0) {

            if (!BulletIsReady) return;
            base.Shot();
            NumberOfBullets--;
            UpdateText();
        }
        else if(Input.GetMouseButtonDown(0)) {            
            NoShotSound.volume = .3f;
            NoShotSound.Play();            
        }
    }
    public override void Activate() {
        base.Activate();
        _bulletsText.enabled = true;
        UpdateText();
        _bullet.GetMass(_mass);
        _bullet.Damage = _damageValue;
    }
    public override void Deactivate() {
        base.Deactivate();
        _bulletsText.enabled = false;
    }
    void UpdateText() {
        _bulletsText.text = "Пули: " + NumberOfBullets.ToString();
    }
    public override void AddBullets(int numberOfBullets) {
        base.AddBullets(numberOfBullets);
        NumberOfBullets += numberOfBullets;
        _playerArmory.TakeGunByIndex(1);
        UpdateText();
    }
    private void OnDestroy() {
        NumberOfBullets = 0;
    }
}
