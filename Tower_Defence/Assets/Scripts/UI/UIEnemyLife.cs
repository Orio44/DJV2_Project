using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnemyLife : MonoBehaviour
{
    [SerializeField] private Slider bar;
    // Start is called before the first frame update
    void Start()
    {
        bar.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSlider(int maxHealth, int currentHealth)
    {
        bar.value = currentHealth /(float) maxHealth;
    }
}
