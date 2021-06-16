using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (playerProfile.tutorialProgression < tutorialScenes.Count)
        {
            SceneManager.LoadScene(tutorialScenes[playerProfile.tutorialProgression]);
        }
        else
        {
            SceneManager.LoadScene(defaultScene);
        }
    }
}
