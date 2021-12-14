using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider thisSlider;
    [SerializeField] private float masterVolume;
    [SerializeField] private AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Takes the value from the slider and updates the respective RTPC value
    /// </summary>
    public void SetMasterVolume()
    {
        Debug.Log("Called");
        masterVolume = thisSlider.value;
        sound.volume = masterVolume;
    }
}
