using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void LoadNextScene()
    {
        // Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the next scene
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void QuitGame()
    {
        // This method will be called when the quit button is pressed
        Application.Quit();
    }

    public void RetryGame()
    {
        // This method will be called when the try again button is pressed
        // For simplicity, let's assume the first scene is the gameplay scene
        SceneManager.LoadScene(2);
    }
}
