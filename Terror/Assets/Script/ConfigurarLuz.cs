using UnityEngine;
using System.Collections.Generic;
public class ConfigurarLuz : MonoBehaviour
{
    public static ConfigurarLuz instancia;

    private List<ILuz> luzes = new List<ILuz>();

    [Header("Quando a luz desliga vai ativa isso")]
    [SerializeField] private Dialogo dialogo;

    private void Awake()
    {
        instancia = this;
    }

    public void Registrar(ILuz luz)
    {
        if (!luzes.Contains(luz))
            luzes.Add(luz);
    }

    public void DesligarTudo()
    {
        foreach (ILuz luz in luzes)
        {
            luz.Desligar();
        }

        if (ControladorAnimatronic.instancia != null)
        {
            ControladorAnimatronic.instancia.AtivarTodos();
        }

        if (dialogo != null)
        {
            dialogo.IniciarDialogoPosLuz();
        }
    }
}

