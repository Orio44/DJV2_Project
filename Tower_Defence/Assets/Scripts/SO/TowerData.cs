using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "ScriptableObjects/TowerData", order = 1)]
public class TowerData : ScriptableObject
{
    public int[] Cost = new int[3];
    public float[] AttackCooldown = new float[3];
    public float[] ProjectileSpeed = new float[3];
    public int[] ProjectileDamage = new int[3];
    public float[] Range = new float[3];
    public float[] AOE = new float[3];

    public int projectileType;

    public LayerMask maskToShoot;
}
