using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerSO", menuName = "Tower/Tower Scriptable Object")]
public class TowerSO : ScriptableObject
{
    public int[] Cost = new int[3];
    public float[] AttackSpeed = new float[3];
    public float[] ProjectileSpeed = new float[3];
    public int[] ProjectileDamage = new int[3];
    public float[] Range = new float[3];
}
