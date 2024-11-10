using UnityEngine;

public class ConsoleMessages : MonoBehaviour
{
    // Show in the console which key was pressed
    public void ShowConsoleMessage(char key)
    {
        Debug.Log($"{key} was pressed");
    }
}