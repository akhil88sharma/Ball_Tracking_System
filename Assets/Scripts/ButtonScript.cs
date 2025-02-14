using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    
    public void ReplayScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitScene()
    {
        Application.Quit();
    }

    public void NextScene()
    {
        SceneManager.LoadScene("L2");
    }

    public void PrevScene()
    {
        SceneManager.LoadScene("L1");
    }
}
