using UnityEngine;


[System.Serializable] public class Save
{

    [Range(1,10)]
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

    public bool conheceuGovernador = false;
    public bool conheceuEmpresarioRuim = false;
    public bool conheceuFazendeiro = false;

    public bool coletouTerra = false;
    public bool coletouFusivel = false;

    public bool AceitouAOfertaDoEmpresarioRuim = false;
    public bool AceitouLiberarAguasParaFazendeiro = false;

    public bool alarmeIncendio2 = false;
    public bool apagouIncendio2 = false;
    public bool turno2Concluido = false;

    public bool fimIntroducaoTurno2 = false;

    public bool aceitouPlantacaoDePlantaNaFloresta = false;
    public bool aceitouCompartilharMaquinasFazendeiro = false;

    public bool fimIntroducaoTurno3 = false;

    public bool puzzleExaustores3Resolvido = false;

    public bool aceitouCompraERDoProjeto = false;
    public bool investiuHidreletrica = false;
    public bool investiuMaquinas = false;

    public bool fimIntroducaoTurno4 = false;
    public bool fimDialogoGovernadorTurno4 = false;

    public bool alarmePoluicaoRio4 = false;
    public bool playerGanhouFrasco4 = false;
    public bool rioPurificado4 = false;
    public bool olhouCamerasSeguranca4 = false;
    public bool puzzleTurno4Concluido = false;

    public bool aceitouDoarDinheiroER = false;
    public bool aceitouEBComprarTerrenoFazendeiro = false;
    public bool aceitouEBParticiparProjetoRemedios = false;

    public bool fimIntroducaoTurno5 = false;

    public bool conversouComGovernador5 = false;

    public bool ONUInvestiuSalaContorle5 = false;
    public bool ONUInvestiuMaquinaria5 = false;
    public bool ONUInvestiuHidreletrica5 = false;
    public bool ONUInvestiuExaustores5 = false;

    public bool fimIntroducaoTurno6 = false;

    public bool conversouEB6 = false;
    public bool conversouFazendeiro6 = false;
    public bool conversouVozDoPovo6 = false;
    public bool coletouCamera6 = false;
    public bool coletouMicrofone6 = false;

    public bool posicionouCameraEsquerda6 = false;
    public bool posicionouCameraMeio6 = false;
    public bool posicionouCameraDireita6 = false;
    public bool posicionouMicrofone6 = false;

    public bool fimDialogoER6 = false;
    public bool coletouProvasContraER6 = false;
    public bool fimDialogoAssistente6 = false;

    public bool fimIntroducaoTurno7 = false;

    public bool mostrouProvasGovernador7 = false;

    public bool aceitouDarAguaFazendeiro7 = false;
    public bool biancaInvestiuHidreletrica7 = false;
    public bool biancaInvestiuMaquinas7 = false;


    public bool fimIntroducaoTurno8 = false;

    public bool InvestiuSalaContorle8 = false;
    public bool InvestiuMaquinaria8 = false;
    public bool InvestiuHidreletrica8 = false;
    public bool InvestiuExaustores8 = false;

    public bool fimIntroducaoTurno9 = false;

    public bool projetoSucesso = false;

    public bool fimIntroducaoTurno10 = false;

    [Range(0,100)]
    public int avancoProjeto = 0;

    //estrelas
    [Range(0, 5)] public int relacaoAssistente = 2;

    [Range(0, 5)] public int relacaoGovernador = 2;
    [Range(0, 5)] public int relacaoEmpresarioRuim = 2;
    [Range(0, 5)] public int relacaoEmpresarioBom = 2;
    [Range(0, 5)] public int relacaoFazendeiro = 2;
    [Range(0, 5)] public int relacaoVozDoPovo = 2;

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
    
    public bool testeQuestBarrilVermelho = false;
    public bool testeBarrilVermelhoDestruido = false;
}
