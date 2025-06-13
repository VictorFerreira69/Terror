using UnityEngine;
using System.Collections.Generic;
public class IventarioFusivel : MonoBehaviour
{
    public static IventarioFusivel instancia;

    private List<Fusivel> fusiveisPegos = new List<Fusivel>();

    private void Awake()
    {
        instancia = this;
    }

    public void PegarFusivel(Fusivel fusivel)
    {
        if (!fusiveisPegos.Contains(fusivel))
        {
            fusiveisPegos.Add(fusivel);
        }
    }

    public bool TemFusivel()
    {
        return fusiveisPegos.Count > 0;
    }

    public Fusivel UsarFusivel()
    {
        if (fusiveisPegos.Count > 0)
        {
            Fusivel usado = fusiveisPegos[0];
            fusiveisPegos.RemoveAt(0);
            return usado;
        }
        return null;
    }

    public int TotalFusiveis()
    {
        return fusiveisPegos.Count;
    }
}
