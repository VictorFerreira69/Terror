using UnityEngine;

public class PortaBotao : MonoBehaviour
{
    [Header("codigo da porta")]
    [SerializeField] private MonoBehaviour portaScript;

    [Header("Ação do Botão")]
    [SerializeField] private bool abrir;

    private IPorta porta;

    private void Awake()
    {
        porta = portaScript as IPorta;
    }

    private void OnMouseDown()
    {
        if (porta == null) return;

        if (abrir)
            porta.Open();
        else
            porta.Close();
    }
}
