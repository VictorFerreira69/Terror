using UnityEngine;

public class MissaoLixo : MonoBehaviour,IMissao
{
    [Header("Qual a missao")]
    public string Descricao => "Limpe os lixo que ficou na mesa";

    [Header("Ver se esta completa")]
    public bool EstaCompleta { get; private set; }

    [Header("Quantos lixos  pra coletar")]
    [SerializeField] private int totalLixos = 3;
    public int lixosDepositados = 0;

    private void Start()
    {
       ConfigurarMissao.instancia.AdicionarMissao(this);
    }

    public void LixoDepositado()
    {
        lixosDepositados++;
        VerificarConclusao();
    }

    public void VerificarConclusao()
    {
        if (lixosDepositados >= totalLixos)
        {
            EstaCompleta = true;
           
        }
    }
}
