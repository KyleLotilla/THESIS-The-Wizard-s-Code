using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.Scoring
{
    public class FillUpStarScoring : MonoBehaviour
    {
        [SerializeField]
        private RectTransform maskTransform;
        [SerializeField]
        private List<RectTransform> maskStarTransforms;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void FillUp(int numberOfStars)
        {
            if (numberOfStars < 0)
            {
                numberOfStars = 0;
            }
            else if (numberOfStars >= maskStarTransforms.Count)
            {
                numberOfStars = maskStarTransforms.Count - 1;
            }
            maskTransform.sizeDelta = maskStarTransforms[numberOfStars].sizeDelta;
            maskTransform.position = maskStarTransforms[numberOfStars].position;
        }
    }

}
