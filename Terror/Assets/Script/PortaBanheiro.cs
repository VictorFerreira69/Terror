using UnityEngine;

public class PortaBanheiro : MonoBehaviour,IPorta
{
    [Header("Player")]
    [SerializeField] private Transform jogador;

    [Header("Rotação da Porta")]
    [SerializeField] private float portaAberta = 90f;
    [SerializeField] private float portaFechada = 0f;
    [SerializeField] private float velocidade = 2f;

    [Header("Distância para interagir")]
    [SerializeField] private float distanciaInteracao = 3.5f;

    private bool aberta = false;

    private void Update()
    {
        if (jogador == null) return;

       
        float alvo = aberta ? portaAberta : portaFechada;
        Vector3 rotacaoAtual = transform.localEulerAngles;
        rotacaoAtual.y = Mathf.LerpAngle(rotacaoAtual.y, alvo, Time.deltaTime * velocidade);
        transform.localEulerAngles = rotacaoAtual;

        if (Vector3.Distance(jogador.position, transform.position) <= distanciaInteracao)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (aberta)
                    Close();
                else
                    Open();
            }
        }
    }

    public void Open()
    {
        aberta = true;
    }

    public void Close()
    {
        aberta = false;
    }
}