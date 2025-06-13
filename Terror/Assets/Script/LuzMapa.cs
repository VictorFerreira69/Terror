using UnityEngine;

public class LuzMapa : MonoBehaviour,ILuz
{
    [Header("Luz")]
    private Light luz;

    private void Awake()
    {
        luz = GetComponent<Light>();
    }

    private void Start()
    {
      
        if (ConfigurarLuz.instancia != null)
        {
           ConfigurarLuz.instancia.Registrar(this);
        }
       
    }
   public void Desligar()
    {
        if (luz != null)
            luz.enabled = false;
    }
   public void Ligar()
{
    if (luz != null)
            luz.enabled = true;
}
}