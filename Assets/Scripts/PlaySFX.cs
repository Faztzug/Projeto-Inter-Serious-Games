using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFX : MonoBehaviour
{
    [SerializeField]
    private string SFXname;
    SFXPlayer sfxPlayer;

    private void Start()
    {
        sfxPlayer = FindObjectOfType<SFXPlayer>();
        sfxPlayer.PlayAudio(SFXname);
    }
}
