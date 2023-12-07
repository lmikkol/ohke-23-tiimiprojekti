using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TabNavigation : MonoBehaviour
{
    public TMP_InputField usernameField;
    public TMP_InputField passwordField;
    public TMP_InputField otherField; // Add more fields as needed

    //Registration registration;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (usernameField.isFocused)
            {
                SelectNextField(passwordField);
            }
            else if (passwordField.isFocused)
            {
                SelectNextField(otherField);
            }
            // Add more conditions for other fields
        }
    }

    private void SelectNextField(TMP_InputField nextField)
    {
        if (nextField != null)
        {
            nextField.Select();
            nextField.ActivateInputField();
        }
    }
}
