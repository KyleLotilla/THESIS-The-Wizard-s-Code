using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DLSU.WizardCode.Save;

public class PlayGame : MonoBehaviour
{
    [SerializeField]
    private PlayerProfile playerProfile;
    [SerializeField]
    private List<int> tutorialScenes;
    [SerializeField]
    private int defaultScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextScene()
    {
        if (playerProfile.TutorialProgression < tutorialScenes.Count)
        {
            SceneManager.LoadScene(tutorialScenes[playerProfile.TutorialProgression]);
        }
        else
        {
            SceneManager.LoadScene(defaultScene);
        }
    }
}
