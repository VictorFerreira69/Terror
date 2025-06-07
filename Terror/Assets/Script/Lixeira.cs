using UnityEngine;

public class Lixeira : MonoBehaviour,IDepositavel
{
    [Header("Distancia para colocar na lixeira")]
    [SerializeField] private float distanciaDeposito = 2f;

    private void Update()
    {
         if (Input.GetButtonDown("Fire1"))
          TentarDepositarLixo();
    }
    
     private void TentarDepositarLixo()
    {
        PlayerColetar player = FindObjectOfType<PlayerColetar>();

        if (player != null && player.TemSacola())
        {
            float distancia = Vector3.Distance(player.transform.position, transform.position);
            if (distancia <= distanciaDeposito)
            {
                Depositar(player);
            }
        }
    }

    public void Depositar(PlayerColetar player)
    {
        player.RemoverSacola();
        
    }
}