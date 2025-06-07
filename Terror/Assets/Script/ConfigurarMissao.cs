using UnityEngine;
using System.Collections.Generic;
public class ConfigurarMissao : MonoBehaviour
{
    public static ConfigurarMissao instancia;

    private List<IMissao> missoes = new List<IMissao>();

    private bool luzesDesligadas = false; 
    
    private void Awake()
    {
        instancia = this;
    }

    private void Update()
    {
        VerificarMissoes();
    }

    public void AdicionarMissao(IMissao missao)
    {
        missoes.Add(missao);
    }

    private void VerificarMissoes()
    {
        foreach (var missao in missoes)
        {
            missao.VerificarConclusao();
        }

        if (TodasCompletas() && !luzesDesligadas)
        {
            ConfigurarLuz.instancia.DesligarTudo();
            luzesDesligadas = true;
        }
    }

    private bool TodasCompletas()
    {
        foreach (var missao in missoes)
        {
            if (!missao.EstaCompleta)
                return false;
        }

        return true;
    }
}