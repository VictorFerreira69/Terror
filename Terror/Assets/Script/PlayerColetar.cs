using UnityEngine;

public class PlayerColetar : MonoBehaviour
{
    [Header("Coletar")]
    [SerializeField] private int lixosParaSacola = 3;
    [SerializeField] private float alcanceColeta = 2f;
    private int lixosColetados = 0;

    [Header("Sacola de lixo")]
    [SerializeField] private GameObject sacolaPrefab;
    [SerializeField] private Transform pontoDaSacola;
    private GameObject sacolaInstanciada;

    [Header("Camera do player")]
    [SerializeField] private Camera camera;

    private void Update()
    {
         if (Input.GetButtonDown("Fire1"))
        {
         TentarDepositar();
         TentarColetar();
         TentarAjustarCadeira();
        }

       
    }
    

    private void TentarColetar()
    {
        Ray ray = new Ray(camera.transform.position, camera.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, alcanceColeta))
        {
            IColetavel coletavel = hit.collider.GetComponent<IColetavel>();
            if (coletavel != null)
            {
                coletavel.Coletar(this);
            }
        }
    }
     private void TentarAjustarCadeira()
   {
     Ray ray = new Ray(camera.transform.position, camera.transform.forward);
     if (Physics.Raycast(ray, out RaycastHit hit, alcanceColeta))
     {
        IAjustar ajustavel = hit.collider.GetComponent<IAjustar>();
        if (ajustavel != null)
        {
            ajustavel.Ajustar();
        }
     }
    }

    public void AdicionarLixo()
    {
        lixosColetados++;

        if (lixosColetados >= lixosParaSacola && sacolaInstanciada == null)
        {
            sacolaInstanciada = Instantiate(sacolaPrefab, pontoDaSacola.position, pontoDaSacola.rotation, pontoDaSacola);
        }
    }

    public void RemoverSacola()
    {
        if (sacolaInstanciada != null)
        {
            Destroy(sacolaInstanciada);
            sacolaInstanciada = null;
            lixosColetados = 0;
        }
    }
    public bool TemSacola()
{
    return sacolaInstanciada != null;
}
private void TentarDepositar()
{
    Ray ray = new Ray(camera.transform.position, camera.transform.forward);
    if (Physics.Raycast(ray, out RaycastHit hit, alcanceColeta))
    {
        IDepositavel depositavel = hit.collider.GetComponent<IDepositavel>();
        if (depositavel != null && TemSacola())
        {
            depositavel.Depositar(this);
        }
    }
}

}