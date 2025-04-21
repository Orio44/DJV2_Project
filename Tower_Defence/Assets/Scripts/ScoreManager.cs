using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private int _score;

    [SerializeField] private UIScore text;
    void Awake()
    {
        if(Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;
    }

    void Start()
    {
        _score = 0;
        text.UpdateScoreText();
    }

    public int GetScore()
    {
        return _score;
    }

    public void ModifyScore(int value)
    {
        _score += MultiplyerManager.Instance.GetMultiplyer() * value;
        text.UpdateScoreText();
    }
}
