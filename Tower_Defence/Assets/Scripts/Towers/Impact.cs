using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact : MonoBehaviour
{
    public void Destroy(){
        Destroy(transform.parent.gameObject);
    }
}
