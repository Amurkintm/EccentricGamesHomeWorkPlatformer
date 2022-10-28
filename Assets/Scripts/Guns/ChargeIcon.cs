using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChargeIcon : MonoBehaviour
{
    [SerializeField] Image _backGround;
    [SerializeField] Image _foreGround;
    [SerializeField] TMP_Text _text;

    private void Start() {
        _backGround.color = new Color(1f, 1f, 1f, 0.2f);
    }
    public void StarCharge() {
        _backGround.color = new Color(1f, 1f, 1f, 0.2f);
        _foreGround.enabled = true;
        _text.enabled = true;
    }
    public void StopCharge() {
        _backGround.color = new Color(1f, 1f, 1f, 1f);
        _foreGround.enabled = false;
        _text.enabled = false;
    }
    public void SetChargeValue(float currrentCharge,float maxCharge) {
        _foreGround.fillAmount = currrentCharge / maxCharge;
        _text.text = Mathf.Ceil(maxCharge - currrentCharge).ToString();
    }
}
