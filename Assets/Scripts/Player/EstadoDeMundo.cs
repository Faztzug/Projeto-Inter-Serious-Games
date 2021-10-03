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

     
     public bool testeQuestBarrilVermelho = false;
     public bool testeBarrilVermelhoDestruido = false;




}