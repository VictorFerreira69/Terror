using UnityEngine;

public class LuzRender : MonoBehaviour,ILuz
{
    private void Awake()
    {
        ConfigurarLuz.instancia.Registrar(this);
    }

    public void Desligar()
    {
        RenderSettings.ambientIntensity = 0.92f; 
    }
}