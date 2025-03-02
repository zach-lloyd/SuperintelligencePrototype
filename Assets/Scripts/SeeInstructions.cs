using UnityEngine;
using UnityEngine.SceneManagement;

public class SeeInstructions : MonoBehaviour
{
    public void ViewInstructions()
    {
        SceneManager.LoadScene("InstructionScene");
    }
}
