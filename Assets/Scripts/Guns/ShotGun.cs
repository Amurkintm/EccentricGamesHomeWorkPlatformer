using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShotGun : Gun
{
    public int NumberOfBullets;
    [SerializeField] protected TMP_Text _bulletsText;
    [SerializeField] PlayerArmory _playerArmory;
    [SerializeField] Bullet _bullet;
    [SerializeField] int _damageValue;
    [SerializeField] float _mass;
    [SerializeField] private Transform[] _spawnPoint;

    private void Start() {
        UpdateText();
    }
    private void Update() {
        if (Input.GetKey(KeyCode.Mouse0) && BulletIsReady) {
            Shot();
        }
    }
    protected override void GreatBullet() {
        for (int i = 0; i < _spawnPoint.Length; i++) {
            Rigidbody newBullet = Instantiate(BulletPref, _spawnPoint[i].position, _spawnPoint[i].rotation);
            newBullet.GetComponent<Rigidbody>().velocity = _spawnPoint[i].forward * BulletSpeed;
            BulletIsReady = false;
        }
    }
    public override void Shot() {
        if (NumberOfBullets > 0) {
            if (!BulletIsReady) return;
            base.Shot();
            NumberOfBullets--;
            UpdateText();
        } else {
            _playerArmory.TakeGunByIndex(0);
        }
    }
    public override void Activate() {
        base.Activate();
        UpdateText();
        _bulletsText.enabled = true;
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
        //base.AddBullets(numberOfBullets);
        NumberOfBullets += numberOfBullets;
        UpdateText();
        _playerArmory.TakeGunByIndex(2);
    }
    private void OnDestroy() {
        NumberOfBullets = 0;
    }
}


