using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDeProgresso : MonoBehaviour
{
    EstadoDeMundo estado;
    [SerializeField] private string[] nomes;

    private void Start()
    {
        estado = FindObjectOfType<EstadoDeMundo>();
        int i = 0;
        foreach (OrganizarEstrelas npc in transform.GetComponentsInChildren<OrganizarEstrelas>())
        {
            nomes[i] = npc.nome;
            i++;
        }

        AtulizarProgreso();

    }

    public void AtulizarProgreso()
    {
        foreach (OrganizarEstrelas npc in transform.GetComponentsInChildren<OrganizarEstrelas>())
        {
            if (npc.nome == nomes[0])
                npc.Organizar(estado.save.relacaoGovernador);
            else if (npc.nome == nomes[1])
                npc.Organizar(estado.save.relacaoEmpresarioRuim);
            else if (npc.nome == nomes[2])
                npc.Organizar(estado.save.relacaoEmpresarioBom);
            else if (npc.nome == nomes[3])
                npc.Organizar(estado.save.relacaoFazendeiro);
            else if (npc.nome == nomes[4])
                npc.Organizar(estado.save.relacaoVozDoPovo);
        }   
    }
}
