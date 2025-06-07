using UnityEngine;

public interface IMissao
{
    string Descricao { get; }
    bool EstaCompleta { get; }
    void VerificarConclusao();
}
