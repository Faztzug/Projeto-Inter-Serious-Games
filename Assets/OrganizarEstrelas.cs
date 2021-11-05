using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganizarEstrelas : MonoBehaviour
{
    public string nome;

    public void Organizar(int estrelas)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).transform.GetChild(0).gameObject.SetActive(false);
        }

        for (int i = 0; i < estrelas; i++)
        {
            transform.GetChild(i).transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
