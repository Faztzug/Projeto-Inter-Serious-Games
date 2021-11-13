using UnityEngine;


[System.Serializable] public class Save
{
    [Range(0,1)]
    public float musicVolume = 1;
    [Range(0, 1)]
    public float SFXVolume = 1;
    [Range(30, 60)]
    public int frameRate = 30;
    [Range(1,15)]
    public float textTypingSpeed = 10;

    [Range(0, 1)] public float textBoxBoundsY = 0.9f;
    [Range(0, 1)] public float textBoxBoundsX = 0.8f;

    public ItemSlotData[] inventarioData;

    public int turno = 1;
    public int ato = 1;

    public string cenaAtual = "Laboratorio_1";

    public float _positionX;
    public float _positionY;
    public Vector2 novaPosicao
    {
        get
        {
            return new Vector2(_positionX, _positionY);
        }
        set
        {
            _positionX = value.x;
            _positionY = value.y;
        }
    }

    public bool conheceuGovernadorEEmpresario = false;
    public bool conheceuFazendeiro = false;

    public bool testeQuestBarrilVermelho = false;
    public bool testeBarrilVermelhoDestruido = false;
    public bool testColetouTerra = false;
    public bool testColetouPecaMaquinaria = false;

    //estrelas
    [Range(0, 5)] public int relacaoAssistente = 2;

    [Range(0, 5)] public int relacaoGovernador = 2;
    [Range(0, 5)] public int relacaoEmpresarioRuim = 2;
    [Range(0, 5)] public int relacaoEmpresarioBom = 2;
    [Range(0, 5)] public int relacaoFazendeiro = 2;
    [Range(0, 5)] public int relacaoVozDoPovo = 2;

    
}
