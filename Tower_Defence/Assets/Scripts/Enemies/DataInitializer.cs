using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataInitializer : MonoBehaviour
{
    [SerializeField] EnemiesData data;
    // Start is called before the first frame update
    void Start()
    {
        if (TryGetComponent<Move>(out var move))
        {
            move.SetData(data);
        }
        if (TryGetComponent<Health>(out var health))
        {
            health.SetData(data);
        }
    }

}
