using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIWave : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private TextMeshProUGUI enemiesText;
    
    public void UpdateWave()
    {
        waveText.text = "Wave " + WaveManager.Instance.GetWave();
    }

    public void UpdateRemainingEnemies()
    {
        enemiesText.text = WaveManager.Instance.GetRemainingEnemies() + " remaining enemies";
    }
}
