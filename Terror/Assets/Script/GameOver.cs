using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public void Recomeçar()
    {
        SceneManager.LoadScene("Game");
    }
    public void VoltarMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
