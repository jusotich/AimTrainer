using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inputField;
    [SerializeField] private Text displayText;
    private void Awake()
    {
        // Make sure this GameObject persists between scenes
        DontDestroyOnLoad(gameObject);
    }
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

            SceneManager.LoadScene("Game");
        }
        else
        {
            Debug.LogWarning("input field is not assigend");
        }
    }
}
