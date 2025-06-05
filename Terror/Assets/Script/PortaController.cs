using UnityEngine;

public class PortaController : MonoBehaviour,IPorta
{
    [System.Serializable]
    public class PortaData
    {
        public Transform porta;
        public Vector3 posicaoAberta;
        public Vector3 posicaoFechada;
        public Vector3 destino;
    }

    [Header("Portas de segurança")]
    [SerializeField] private PortaData[] portas;

    [Header("Configuração")]
    [SerializeField] private float velocidade = 2f;

    private void Start()
    {
       
        foreach (var p in portas)
        {
            p.destino = p.posicaoAberta;
        }
    }

    private void Update()
    {
        foreach (var p in portas)
        {
            if (p.porta != null)
                p.porta.localPosition = Vector3.Lerp(p.porta.localPosition, p.destino, Time.deltaTime * velocidade);
        }
    }

    public void Open()
    {
        foreach (var p in portas)
        {
            p.destino = p.posicaoAberta;
        }
    }

    public void Close()
    {
        foreach (var p in portas)
        {
            p.destino = p.posicaoFechada;
        }
    }
}
