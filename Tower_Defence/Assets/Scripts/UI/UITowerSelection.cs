using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITowerSelection : MonoBehaviour
{
    [SerializeField] GameObject tile;
    [SerializeField] TowerData bow;
    [SerializeField] GameObject bowTower;
    [SerializeField] TowerData slingshot;
    [SerializeField] GameObject slingshotTower;
    [SerializeField] TowerData catapult;
    [SerializeField] GameObject catapultTower;
    [SerializeField] TowerData magic;
    [SerializeField] GameObject magicTower;
    public void close()
    {
        gameObject.SetActive(false);
    }

    private void BuyTower(int cost, GameObject tower)
    {
        int currentMoney = MoneyManager.Instance.GetMoney();
        if (currentMoney < cost) return;
        MoneyManager.Instance.BuyTower(cost);
        GameObject newTower = Instantiate(tower, transform.position, Quaternion.identity);
        Destroy(tile);
    }

    public void BuyBow()
    {
        BuyTower(bow.Cost[0], bowTower);
    }

    public void BuySlingshot()
    {
        BuyTower(slingshot.Cost[0], slingshotTower);
    }

    public void BuyCatapult()
    {
        BuyTower(catapult.Cost[0], catapultTower);
    }

    public void BuyMagic()
    {
        BuyTower(magic.Cost[0], magicTower);
    }
}
