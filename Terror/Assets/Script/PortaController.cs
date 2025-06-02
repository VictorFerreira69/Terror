using UnityEngine;

public class PortaController : MonoBehaviour,IPorta
{
    [Header("Referência a Porta")]
    [SerializeField] private Transform porta;

    [Header("Posião")]
    [SerializeField] private Vector3 posicaoAberta;
    [SerializeField] private Vector3 posicaoFechada;

    [Header("Configuração")]
    [SerializeField] private float velocidade = 2f;

    private Vector3 destino;

    private void Start()
    {
        destino = posicaoFechada;
    }

    private void Update()
    {
        porta.localPosition = Vector3.Lerp(porta.localPosition, destino, Time.deltaTime * velocidade);
    }

    public void Open()
    {
        destino = posicaoAberta;
    }

    public void Close()
    {
        destino = posicaoFechada;
    }
}
