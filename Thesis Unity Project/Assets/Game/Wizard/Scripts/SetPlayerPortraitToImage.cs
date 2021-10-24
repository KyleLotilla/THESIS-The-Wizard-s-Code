using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DLSU.WizardCode.Save;

namespace DLSU.WizardCode.Wizard
{
    public class SetPlayerPortraitToImage : MonoBehaviour
    {
        [SerializeField]
        private Image image;
        [SerializeField]
        private Sprite maleSprite;
        [SerializeField]
        private Sprite femaleSprite;
        [SerializeField]
        private PlayerProfile playerProfile;
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void OnEnable()
        {
            if (playerProfile.Gender == Gender.MALE)
            {
                image.sprite = maleSprite;
            }
            else if (playerProfile.Gender == Gender.FEMALE)
            {
                image.sprite = femaleSprite;
            }
        }
    }

}
