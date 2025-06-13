using UnityEngine;

public class CaixaFusivel : MonoBehaviour
{
    [SerializeField] int quantidadeNecessaria = 3;
    private int fusiveisInseridos = 0;

 [SerializeField]  GameObject[] visuaisDosFusiveis; 
    [SerializeField]  GameObject luzParaLigar; 

    
 private bool luzLigada = false;
   private void OnTriggerStay(Collider other)
{
    if (other.CompareTag("Player") && Input.GetButtonDown("Fire1"))
    {
        if (IventarioFusivel.instancia.TemFusivel())
        {
            IventarioFusivel.instancia.UsarFusivel();
            fusiveisInseridos++;

            if (visuaisDosFusiveis != null && fusiveisInseridos - 1 < visuaisDosFusiveis.Length)
            {
                visuaisDosFusiveis[fusiveisInseridos - 1].SetActive(true);
            }

            if (fusiveisInseridos >= quantidadeNecessaria && !luzLigada)
            {
                luzLigada = true;

                if (luzParaLigar != null)
                    luzParaLigar.SetActive(true);

                ConfigurarLuz.instancia?.LigarTudo();
            }
        }
    }
}

}
