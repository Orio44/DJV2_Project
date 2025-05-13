using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyerManager : MonoBehaviour
{
    public static MultiplyerManager Instance;

    private int _currentMultiplyer;
    private int _enemyCount;
    [SerializeField] private int maxMultiplyer;
    [SerializeField] private int enemyCountToGrow;

    [SerializeField] private UIMultiplyer text;

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
        _currentMultiplyer = 1;
        text.UpdateMultiplyerText();
    }
    public int GetMultiplyer()
    {
        return _currentMultiplyer;
    }



    public void EnemyKilled(){
        if (_currentMultiplyer > 0)
        {
            _enemyCount++;
            if (_enemyCount>=enemyCountToGrow){
                _enemyCount=0;
                if (_currentMultiplyer< maxMultiplyer){
                    _currentMultiplyer++;
                }
            }
        }
        else
        {
            _currentMultiplyer = 1;
            _enemyCount = 1;
        } 
        
        text.UpdateMultiplyerText();
    }
    public void EnemyPassed(){
        if (_currentMultiplyer < 0)
        {
            _enemyCount++;
            if (_enemyCount>=enemyCountToGrow){
                _enemyCount=0;
                if (_currentMultiplyer> -maxMultiplyer){
                    _currentMultiplyer--;
                }
            }
        }
        else
        {
            _currentMultiplyer = 1;
            _enemyCount = 1;
        } 
        
        text.UpdateMultiplyerText();
    }
}
