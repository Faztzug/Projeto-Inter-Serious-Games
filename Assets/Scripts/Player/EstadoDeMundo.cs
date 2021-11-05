using UnityEngine;

public class EstadoDeMundo : MonoBehaviour
{
    public float textTypingSpeed = 1;
    [Range(0, 1)]public float textBoxBoundsY;
    [Range(0, 1)] public float textBoxBoundsX;

    public int turno = 1;
    public int ato = 1;


    public bool conheceuGovernadorEEmpresario = false;
    public bool conheceuFazendeiro = false;

     
     public bool testeQuestBarrilVermelho = true;
     public bool testeBarrilVermelhoDestruido = true;

    //estrelas
    [Range(0,10)] public int relacaoAssistente;
    [Range(0, 10)] public int relacaoGovernador;
    [Range(0, 10)] public int relacaoEmpresarioRuim;
    [Range(0, 10)] public int relacaoEmpresarioBom;
    [Range(0, 10)] public int relacaoFazendeiro;
    [Range(0, 10)] public int relacaoVozDoPovo;

}

[SerializeField]
public class Save
{

}