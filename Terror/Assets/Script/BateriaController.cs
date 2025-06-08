using UnityEngine;
using TMPro;

public class BateriaController : MonoBehaviour
{
    [Header("Portas")]
    public PortaController porta1;
    public PortaController porta2;

    [Header("Energia Bateria")]
    public float energiaMaxima = 100f;
    public float energiaAtual;

    [Header("Energia recarregada  quando as  portas  estao abertas")]
    public float recargaPorSegundo = 5f;

    [Header("Energia consumida  quando uma porta esta  fechada")]
    public float consumoPorSegundo = 10f;

    [Header("Energia consumida quando as  duas portas estao fechadas")]
    public float consumoRapidoPorSegundo = 20f;

    [Header("UI")]
    public TextMeshProUGUI textoBateria;

   private void Start()
    {
        energiaAtual = energiaMaxima;
    }

    private void Update()
    {
        bool porta1Aberta = porta1 != null && porta1.IsOpen();
        bool porta2Aberta = porta2 != null && porta2.IsOpen();

        if (porta1Aberta && porta2Aberta)
        {
            energiaAtual += recargaPorSegundo * Time.deltaTime;
        }
        else if (!porta1Aberta && !porta2Aberta)
        {
            energiaAtual -= consumoRapidoPorSegundo * Time.deltaTime;
        }
        else
        {
            energiaAtual -= consumoPorSegundo * Time.deltaTime;
        }

        energiaAtual = Mathf.Clamp(energiaAtual, 0, energiaMaxima);

        
        float porcentagem = (energiaAtual / energiaMaxima) * 200f;
        textoBateria.text = $"Bateria: {porcentagem.ToString("F0")}%";

  
        if (energiaAtual <= 0)
        {
            porta1.TryClose(false);
            porta2.TryClose(false);
        }
         else if (energiaAtual >= energiaMaxima)
        {
           
        }
       
    }
    
}