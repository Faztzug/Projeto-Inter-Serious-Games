using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarContaminacaoRio : MonoBehaviour
{
    [SerializeField]
    private GameObject rioNormal;
    [SerializeField]
    private GameObject rioPoluido;
    private EstadoDeMundo estado;

    private void Start()
    {
        estado = FindObjectOfType<EstadoDeMundo>();

        if(estado.save.turno == 4 && estado.save.alarmePoluicaoRio4 == true)
        {
            Poluir();
        }
    }

    public void Poluir()
    {
        rioNormal.SetActive(false);
        rioPoluido.SetActive(true);
    }

    public void Despoluir()
    {
        rioNormal.SetActive(true);
        rioPoluido.SetActive(false);
    }
}
