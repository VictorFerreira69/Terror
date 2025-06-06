using UnityEngine;
using System.Linq;
public class PlayerLuz : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lixo"))
        {
          ConfigurarLuz.instancia.DesligarTudo();
        }
    }
}