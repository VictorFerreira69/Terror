using UnityEngine;
using System.Collections;
public class Marcelline : MonoBehaviour,IAjustar
{
    [Header("Player")]
    [SerializeField] private Transform player;

    [Header("Distância que ela vai aparecer")]
    [SerializeField] private float distanciaNaFrente = 2f;

    [Header("Tempo até desaparecer")]
    [SerializeField] private float tempoAteSumir = 3f;

    public void Ajustar()
    {
        if (player != null)
        {
           
            Vector3 posicaoNaFrente = player.position + player.forward * distanciaNaFrente;
            posicaoNaFrente.y = transform.position.y;
            transform.position = posicaoNaFrente;

          
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));

         
            StartCoroutine(SumirDepoisDeTempo());
        }
    }

    private IEnumerator SumirDepoisDeTempo()
    {
        yield return new WaitForSeconds(tempoAteSumir);
        gameObject.SetActive(false);
    }
}