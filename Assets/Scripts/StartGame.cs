using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // This function is attached to the Begin button on the instruction screen
    // so that the main game screen can be loaded when that button is clicked.
    public void StartNewGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}

