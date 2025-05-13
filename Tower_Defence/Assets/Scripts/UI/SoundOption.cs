using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundOption : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider music;
    [SerializeField] private Slider sfx;
    private void Update()
    {
        SetVolume(music.value, "Music");
        SetVolume(sfx.value, "SFX");
    }
    private void SetVolume(float value, string name)
    {
        mixer.SetFloat(name , Mathf.Log10(value) * 20);
    }

    public void close()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
