using UnityEngine;

public class LuzMapa : MonoBehaviour,ILuz
{
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
}