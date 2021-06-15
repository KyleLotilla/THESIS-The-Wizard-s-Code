using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitializeGame : MonoBehaviour
{
    [SerializeField]
    private SaveReader saveReader;
    [SerializeField]
    private SaveWriter saveWriter;
    [SerializeField]
    private GameObject messageWindowPrefab;
    [SerializeField]
    private Transform canvasTransform;

    // Start is called before the first frame update
    void Start()
    {
        if (saveReader.ReadSaveFile())
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            string previousVersion = saveReader.ImportPreviousFile();
            if (!previousVersion.Equals("0.0"))
            {
                ShowMessage("Imported Save File From Version " + previousVersion);
            }
            else
            {
                saveWriter.CreateFile();
                saveReader.ReadSaveFile();
                ShowMessage("Created New Save File");
            }
        }
        
    }

    private void ShowMessage(string message)
    {
        GameObject messageWindowObject = Instantiate(messageWindowPrefab, canvasTransform);
        if (messageWindowObject != null)
        {
            MessageWindow messageWindow = messageWindowObject.GetComponent<MessageWindow>();
            if (messageWindow != null)
            {
                messageWindow.SetMessage(message);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
