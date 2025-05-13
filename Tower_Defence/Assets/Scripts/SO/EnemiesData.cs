using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EnemiesData", order = 1)]
public class EnemiesData : ScriptableObject
{
    public string monsterName;

    public int maxHealth;
    public float speed;
    public int score;

    public AudioClip clipMove;
    public AudioClip clipDeath;
}