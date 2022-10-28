using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthsUI : MonoBehaviour
{
    public GameObject HealthIconPrefab;
    public List<GameObject> HealthsIcons = new List<GameObject>();
    public void Setup(int maxHeaths) {
        for (int i = 0; i < maxHeaths; i++) {
            GameObject newIcons = Instantiate(HealthIconPrefab, transform);
            HealthsIcons.Add(newIcons);
        }
    }
    public void DisplayHealths(int healths) {
        for (int i = 0; i < HealthsIcons.Count; i++) {
            if(i < healths) {
                HealthsIcons[i].SetActive(true);
            } else {
                HealthsIcons[i].SetActive(false);
            }
        }
    }
}
