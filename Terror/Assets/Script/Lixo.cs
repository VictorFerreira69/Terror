using UnityEngine;

public class Lixo : MonoBehaviour,IColetavel
{
   public void Coletar(PlayerColetar player)
    {
        player.AdicionarLixo();
        Destroy(gameObject);
    }
}
