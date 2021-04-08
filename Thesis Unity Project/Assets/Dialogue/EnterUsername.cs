using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnterUsername : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private InputField mainInputField;

    [SerializeField]
    private Text username;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setUsername()
    {
        username.text = mainInputField.text;
        SceneManager.LoadScene(2);
    }
}
