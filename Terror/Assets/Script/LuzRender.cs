using UnityEngine;

public class LuzRender : MonoBehaviour,ILuz
{
   
     private void Start()
    {
      
        if (ConfigurarLuz.instancia != null)
        {
           ConfigurarLuz.instancia.Registrar(this);
        }
       
    }

    public void Desligar()
    {
        RenderSettings.ambientIntensity = 0.92f; 
    }
     public void Ligar()
    {
        RenderSettings.ambientIntensity = 2.71f;
    }
}