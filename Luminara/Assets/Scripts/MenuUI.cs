using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public TMP_InputField inputField;
    private KeyCode pickupKey = KeyCode.E; // The active key
    private KeyCode tempPickupKey; // Temporary key for editing

    private bool isListeningForKey = false;

    private void Start()
    {
        tempPickupKey = pickupKey;
        inputField.text = pickupKey.ToString();
        inputField.onSelect.AddListener(delegate { StartListeningForKey(); });
    }

    void Update()
    {
        if (isListeningForKey)
        {
            foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
            {
        //KeyCode keyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), pickUpKey);
                if (Input.GetKeyDown(keyCode))
                {
                    if (IsKeyboardKey(keyCode))
                    {
                        Debug.Log($"Keyboard key selected: {keyCode}");
                        tempPickupKey = keyCode;
                        inputField.text = tempPickupKey.ToString();
                        isListeningForKey = false;
                        EventSystem.current.SetSelectedGameObject(null); // Deselect
                        break;
                    }
                    else
                    {
                        Debug.Log("Non-keyboard input ignored");
                    }
                }
            }
        }
    }

    private bool IsKeyboardKey(KeyCode key)
    {
        return key < KeyCode.Mouse0;
    }


    public void StartListeningForKey()
    {
        isListeningForKey = true;
    }

    public void SaveChanges()
    {
        pickupKey = tempPickupKey;
        Debug.Log($"Saved key: {pickupKey}");
    }

    public void CancelChanges()
    {
        tempPickupKey = pickupKey;
        inputField.text = pickupKey.ToString();
        Debug.Log("Changes canceled");

    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Haunted Castle");
    }
}
