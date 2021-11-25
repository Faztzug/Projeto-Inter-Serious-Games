using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtualizarAvancoProjeto : MonoBehaviour
{
    [SerializeField]
    private Slider AvancoProjeto;

    private EstadoDeMundo estadoDeMundo;
    

    private void Start()
    {
        estadoDeMundo = FindObjectOfType<EstadoDeMundo>();
        AvancoProjeto = GameObject.FindGameObjectWithTag("Avanço Projeto").GetComponentInChildren<Slider>();

        if (estadoDeMundo.atualizarAvancoProjeto == null)
            estadoDeMundo.atualizarAvancoProjeto = this;

        this.gameObject.SetActive(false);
    }

    public void Atualizar()
    {
        AvancoProjeto.maxValue = estadoDeMundo.save.metaMinProjeto;
        AvancoProjeto.value = estadoDeMundo.save.avancoProjeto;
        
        
    }
}
