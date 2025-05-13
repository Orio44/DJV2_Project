using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnemyLife : MonoBehaviour
{
    [SerializeField] private Slider bar;
    public void UpdateSlider(int maxHealth, int currentHealth)
    {
        bar.value = currentHealth /(float) maxHealth;
    }
}
