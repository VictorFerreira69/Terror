using UnityEngine;

public class Fusivel : MonoBehaviour
{
    [Header("Numero do fusivel")]
   [SerializeField] int idFusivel; 
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetButtonDown("Fire1"))
        {
            IventarioFusivel.instancia.PegarFusivel(this);
            gameObject.SetActive(false);
        }
    }
}