using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    
    public void ReplayScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitScene()
    {
        Application.Quit();
    }
}
