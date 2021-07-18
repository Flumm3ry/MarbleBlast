using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void OnHost()
    {
        PlayerPrefs.SetInt("ConnectionType", (int) ConnectionTypes.HOST);
        LoadNextScene();
    }

    public void OnConnect() 
    {
        PlayerPrefs.SetInt("ConnectionType", (int) ConnectionTypes.CLIENT);
        LoadNextScene();
    }
    public void OnQuit()
    {
        Application.Quit();
    }

    private void LoadNextScene() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }
}
