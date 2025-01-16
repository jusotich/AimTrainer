using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class InputHandler : MonoBehaviour
{
    public static InputHandler Instance;
    public TMP_InputField inputField;
    public string playerName;
    private void Awake()
    {
        // Make sure this GameObject persists between scenes
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make this object persistent
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }
    public void OnConfirmButtonClick()
    {
        // Get the player's name from the input field
        playerName = inputField.text;

        if (!string.IsNullOrEmpty(playerName))
        {
            Debug.Log("Player Name Confirmed: " + playerName);
            // You can save the name or use it for gameplay here
            SceneManager.LoadScene("Game");
        }
        else
        {
            Debug.LogWarning("Name field is empty. Please enter a name!");
        }
    }
}
