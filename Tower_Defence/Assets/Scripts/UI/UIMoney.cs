using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMoney : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    public void UpdateMoneyText()
    {
        moneyText.text = "x " + MoneyManager.Instance.GetMoney();
    }
}
