using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private InputField inputField;
    [SerializeField] private Text displayText;

    public void SubmitText()
    {
        if(inputField != null)
        {
            string playerInput = inputField.text;
            
            if (displayText != null)
            {
                displayText.text = "you enterd: " + playerInput;
            }

            inputField.text = "";
        }
        else
        {
            Debug.LogWarning("input dield is not assigend");
        }
    }
}
