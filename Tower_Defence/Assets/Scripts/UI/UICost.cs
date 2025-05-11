using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICost : MonoBehaviour
{
    [SerializeField] TowerSO data;
    [SerializeField] TextMeshProUGUI costText;
    // Start is called before the first frame update
    void OnEnable()
    {
        costText.text = "" + data.Cost[0];
    }
}
