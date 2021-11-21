using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    [SerializeField] private Sound[] sounds;
    //[SerializeField] private string playThis;
    //private string CurrentPlaying;
    [Range(0, 1)]
    public float overallVolume = 1;
    private AudioSource[] allAudioSources;

    private void Awake()
    {
        foreach (SFXPlayer music in FindObjectsOfType<SFXPlayer>())
        {
            Debug.Log("Stop All SFX!");
            StopAll();
        }

        DontDestroy();
    }


    private void Start()
    {
        foreach (Sound sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
            sound.audioSource.loop = sound.loop;

        }

        

        allAudioSources = GetComponents<AudioSource>();

        UpdateVolume();
    }

    

    public void PlayAudio(string name)
    {
        foreach (Sound sound in sounds)
        {
            if (sound.name == name)
            {
                sound.audioSource.Play();
                //CurrentPlaying = sound.name;
            }

        }
    }

    public void StopAudio(string name)
    {
        foreach (Sound sound in sounds)
        {
            if (sound.name == name)
            {
                sound.audioSource.Stop();
                //CurrentPlaying = sound.name;
            }

        }
    }

    public void StopAll()
    {
        foreach (AudioSource sfx in GetComponents<AudioSource>())
        {
            sfx.Stop();
        }
    }

    public void UpdateVolume()
    {
        StartCoroutine(UpdateVolumeCourotine());
    }

    IEnumerator UpdateVolumeCourotine()
    {
        yield return new WaitForEndOfFrame();

        int length = allAudioSources.Length;
        Debug.Log("Update Volume");

        for (int i = 0; i < length; i++)
        {
            allAudioSources[i].volume = sounds[i].volume * overallVolume;
        }

        /*foreach (AudioSource music in GetComponents<AudioSource>())
        {
            music.volume = 1 * overallVolume;
        }*/
    }

    private void DontDestroy()
    {
        for (int i = 0; i < Object.FindObjectsOfType<SFXPlayer>().Length; i++)
        {
            if (Object.FindObjectsOfType<SFXPlayer>()[i] != this)
            {
                if (Object.FindObjectsOfType<SFXPlayer>()[i].gameObject.name == gameObject.name)
                {
                    //DestroyImmediate(this.gameObject);
                    gameObject.SetActive(false);
                    Destroy(this.gameObject);
                }

            }
        }


        DontDestroyOnLoad(gameObject);
    }

}
