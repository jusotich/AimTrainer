using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private InputField inputField; // Drag your Input Field here in the Inspector
    [SerializeField] private Text displayText; // Optional: A Text UI element to show the entered text

    public void SubmitText()
    {
        if (inputField != null)
        {
            string playerInput = inputField.text; // Get the entered text
            Debug.Log("Player entered: " + playerInput);

            if (displayText != null)
            {
                displayText.text = "You entered: " + playerInput;
            }

            // Optionally, clear the input field after submission
            inputField.text = "";
        }
        else
        {
            Debug.LogWarning("Input Field is not assigned.");
        }
    }
}
