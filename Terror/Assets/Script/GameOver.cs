using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public void Recomecar()
    {
        SceneManager.LoadScene("Game");
    }
    public void VoltarMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
