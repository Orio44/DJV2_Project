using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMultiplyer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI multiplyerText;

    public void UpdateMultiplyerText()
    {
        multiplyerText.text = "x" + MultiplyerManager.Instance.GetMultiplyer();
    }
}
