using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetCameraToCanvas : MonoBehaviour
{
    private Canvas canvas;
    [SerializeField]
    private float taxaAtualizacao = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        SetCameraToCanvas();
    }

    public void SetCameraToCanvas()
    {
        StartCoroutine(EsperarUmPouco());
    }

    IEnumerator EsperarUmPouco()
    {
        yield return new WaitForSeconds(taxaAtualizacao);

        Debug.Log("Set Camera To Canvas Agora!");
        canvas = GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        canvas.sortingLayerName = "Canvas";

        if(canvas.worldCamera == null)
        {
            StartCoroutine(EsperarUmPouco());
        }
    }

    
}
