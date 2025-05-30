using UnityEngine;

public class Lanterna : MonoBehaviour
{
    [SerializeField] private GameObject lanterna;

    [SerializeField]  Light luzLanterna;
    private bool lanternaAtiva = false;

    void Start()
    {
        luzLanterna = lanterna.GetComponent<Light>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            lanternaAtiva = !lanternaAtiva;
            lanterna.SetActive(lanternaAtiva);
            if (luzLanterna != null)
            {
                luzLanterna.enabled = lanternaAtiva;
            }
        }
    }
}