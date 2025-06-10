using UnityEngine;
using System.Collections.Generic;

public class ControladorAnimatronic : MonoBehaviour
{
    public static ControladorAnimatronic instancia;

    private List<IAnimatronic> animatronics = new List<IAnimatronic>();

    private void Awake()
    {
        instancia = this;
    }

    public void Registrar(IAnimatronic animatronic)
    {
        if (!animatronics.Contains(animatronic))
            animatronics.Add(animatronic);
    }

    public void AtivarTodos()
    {
        foreach (var animatronic in animatronics)
        {
            animatronic.AtivarPatrulha();
        }
    }
}
