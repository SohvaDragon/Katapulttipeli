using UnityEngine;
using UnityEngine.SceneManagement;

public class pelaanappi : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
