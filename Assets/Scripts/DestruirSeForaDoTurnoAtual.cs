using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirSeForaDoTurnoAtual : MonoBehaviour
{
    VerificarTurnoAtual verificarTurnoAtual;

    // Start is called before the first frame update
    void Start()
    {
        verificarTurnoAtual = GetComponent<VerificarTurnoAtual>();

        if (verificarTurnoAtual.Verificar() == false)
            Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
