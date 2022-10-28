using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmory : MonoBehaviour
{
    [SerializeField] private List<Gun> _guns = new List<Gun>();
    public Gun CurrentGun;
    [SerializeField] int _gunIndex;

    private void Start() {
        TakeGunByIndex(_gunIndex);
        for (int i = 0; i < _guns.Count; i++) {
            _guns[i].Deactivate();
        }
        TakeGunByIndex(_gunIndex);
    }
    public void TakeGunByIndex(int gunIndex) {
        CurrentGun.Deactivate();
        CurrentGun = _guns[gunIndex];
        CurrentGun.Activate();
    }
    public void AddBullets(int gunIndex, int numberOfBullets) {
        _guns[gunIndex].AddBullets(numberOfBullets);
    }
    private void Update() {
        
        if (Input.mouseScrollDelta == Vector2.up) {
            _gunIndex++;
            ScrollGun();
        }
        else if (Input.mouseScrollDelta == Vector2.down) {
            _gunIndex--;
            ScrollGun();
        }
        
    }
    void ScrollGun() {

        if (_gunIndex >= _guns.Count) {
            _gunIndex = 0;
        } else if (_gunIndex < 0) {
            _gunIndex = _guns.Count - 1;
        }
        TakeGunByIndex(_gunIndex);
    }
}
