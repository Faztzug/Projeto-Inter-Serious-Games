using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //torna a classe inteira Seriavel
public class Dialogue //não herda de Monobehavior, é para ser usada dentro de outros scripts como um tipo de construtor
{
    public Color textColor = new Color (1f,1f,1f,1f);
    public string characterName = "Nome Padrão";
    public Vector2 textPosition;
    [TextArea(3,10)]
    public string[] sentences;

}
