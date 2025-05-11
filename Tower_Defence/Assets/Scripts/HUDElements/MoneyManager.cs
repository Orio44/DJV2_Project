using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;

    private int _money;

    [SerializeField] private UIMoney text;
    void Awake()
    {
        if (Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;
    }

    void Start()
    {
        _money = 100;
        text.UpdateMoneyText();
    }

    public int GetMoney()
    {
        return _money;
    }

    public void EarnMoney(int value)
    {
        _money += value;
        text.UpdateMoneyText();
    }

    public void BuyTower(int cost)
    {
        _money -= cost;
        text.UpdateMoneyText();
    }
}
