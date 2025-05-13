using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject option;

    public void Open()
    {
        option.SetActive(true);
        Time.timeScale = 0;
    }
}
