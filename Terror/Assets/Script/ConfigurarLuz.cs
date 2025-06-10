using UnityEngine;
using System.Collections.Generic;
public class ConfigurarLuz : MonoBehaviour
{
    public static ConfigurarLuz instancia;

    private List<ILuz> luzes = new List<ILuz>();

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
    }
}
