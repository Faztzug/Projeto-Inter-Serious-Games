using UnityEngine;
using UnityEngine.UI;

public class AtualizarConfiguracoes : MonoBehaviour
{
    private Dropdown fps;
    [SerializeField] private Slider[] sliders;
    private Slider music;
    private Slider sfx;
    private Slider typing;
    private EstadoDeMundo estadoDeMundo;

    private void Start()
    {
        fps = GetComponentInChildren<Dropdown>();
        estadoDeMundo = FindObjectOfType<EstadoDeMundo>();
        sliders = GetComponentsInChildren<Slider>();
        music = sliders[0];
        sfx = sliders[1];
        typing = sliders[2];

        this.gameObject.SetActive(false);
    }

    public void Atualizar()
    {
        if (fps.value == 0)
            estadoDeMundo.save.frameRate = 30;
        else if (fps.value == 1)
            estadoDeMundo.save.frameRate = 60;

        estadoDeMundo.save.musicVolume = music.value;
        estadoDeMundo.save.SFXVolume = sfx.value;
        estadoDeMundo.save.textTypingSpeed = typing.value;

        estadoDeMundo.UpdateSettings();
    }
}