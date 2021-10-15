using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCharacterUI : MonoBehaviour
{
    [SerializeField]
    private PlayerProfile playerProfile;
    /*
    [SerializeField]
    private DialoguePanel dialoguePanel;
    */
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseMale()
    {
        ChooseGender(Gender.MALE);
    }

    public void ChooseFemale()
    {
        ChooseGender(Gender.FEMALE);
    }

    private void ChooseGender(Gender gender)
    {
        playerProfile.gender = gender;
        //dialoguePanel.ShowDialogue(0);
        this.gameObject.SetActive(false);
    }
}
