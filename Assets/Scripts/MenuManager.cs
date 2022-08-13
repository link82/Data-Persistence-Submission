using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuManager : MonoBehaviour
{
    public TMP_InputField nameField;
    // Start is called before the first frame update

    public void SetName()
    {
        StoreManager.Instance.SetName(nameField.text);
        SceneManager.LoadScene("main");
    }

    public void Quit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
