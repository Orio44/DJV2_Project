using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EnemiesData", order = 1)]
public class EnemiesData : ScriptableObject
{
    public string monsterName;
    public int typeMonster;

    public int maxHealth;
    public float speed;
    public int score;
    public int money;

    public AudioClip clipMove;
    public AudioClip clipDeath;
}