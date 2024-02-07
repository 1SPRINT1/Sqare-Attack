using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
   [SerializeField] private AudioSource[] audioSource;
   [SerializeField] private Slider volumeSlider;
   [SerializeField] private GameObject SoundSetPanel;

   private void Start()
   {
       for (int i = 0; i < audioSource.Length; i++)
       {
           volumeSlider.value = audioSource[i].volume;   
       }
   }

   void Update()
    {
        audioSource = FindObjectsOfType<AudioSource>();
        for (int i = 0; i < audioSource.Length; i++)
        {
            // Установите начальное значение слайдера равным текущему значению громкости
            // Добавьте обработчик события изменения значения слайдера
            volumeSlider.onValueChanged.AddListener(delegate { ChangeVolume(); });
        }
    }

    void ChangeVolume()
    {
        // Измените громкость AudioSource в соответствии со значением слайдера
        for (int i = 0; i < audioSource.Length; i++)
        {
            audioSource[i].volume = volumeSlider.value;
        }
    }

    public void OpenSetting()
    {
        SoundSetPanel.SetActive(true);
    }

    public void CloseSetting()
    {
        SoundSetPanel.SetActive(false);
    }
}
