using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] protected Rigidbody BulletPref;
    [SerializeField] protected AudioSource ShotSound;
    [SerializeField] protected Transform SpawnBullet;
    [SerializeField] GameObject _flash;
    [SerializeField] protected float BulletSpeed;   
    [SerializeField] protected float ReloadTime = 1f;
    public bool BulletIsReady { get; protected set; } = true;
    //public float BulletSpeedPublic => BulletSpeed;
    private void OnEnable() {
        if (!BulletIsReady) {
            StartCoroutine(Reload());
        }
    }
    private IEnumerator SetFlash() {
        _flash.SetActive(true);
        yield return new WaitForSecondsRealtime(0.1f);
        _flash.SetActive(false);
    }

    private IEnumerator Reload() {       
        yield return new WaitForSecondsRealtime(ReloadTime);
        BulletIsReady = true;
    }
    protected virtual void GreatBullet() {
        Rigidbody newBullet = Instantiate(BulletPref, SpawnBullet.position, SpawnBullet.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = SpawnBullet.forward * BulletSpeed;
        BulletIsReady = false;
    }
    public virtual void Shot() {        
        ShotSound.pitch = Random.Range(1f, 1.2f);
        ShotSound.Play();
        GreatBullet();
        StartCoroutine(SetFlash());
        StartCoroutine(Reload());
    }
    public virtual void Activate() {                
        gameObject.SetActive(true);
    }
    public virtual void Deactivate() {
        gameObject.SetActive(false);
        _flash.SetActive(false);
    }
    public virtual void AddBullets(int NumberOfBullets) {

    }
}
