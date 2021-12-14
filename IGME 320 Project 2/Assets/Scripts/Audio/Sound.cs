using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    // Fields
    // Inspector Fields
    [SerializeField] private string name;
    [SerializeField] private AudioClip clip;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float volume;

    // Private Fields
    private AudioSource source;

    // Properties

    public string Name
    {
        get { return name; }
    }

    public AudioSource Source
    {
        get { return source; }
        set { source = value; }
    }

    public AudioClip Clip
    {
        get { return clip; }
        set { clip = value; }
    }

    public float Volume
    {
        get { return volume; }
        set { volume = value; }
    }
}
