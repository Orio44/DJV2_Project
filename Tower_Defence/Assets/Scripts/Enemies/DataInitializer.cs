using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataInitializer : MonoBehaviour
{
    [SerializeField] EnemiesData data;
    // Start is called before the first frame update
    void Start()
    {
        if (TryGetComponent<Move>(out var script))
        {
            script.SetData(data);
        }
    }

}
