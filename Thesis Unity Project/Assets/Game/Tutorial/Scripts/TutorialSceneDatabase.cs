using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Tags;

namespace DLSU.WizardCode.Tutorial
{
    [CreateAssetMenu(menuName="Tutorial/TutorialSceneDatabase")]
    public class TutorialSceneDatabase : ScriptableObject
    {
        [SerializeField]
        private List<TutorialScene> tutorialScenes;
        private Dictionary<Tag, TutorialScene> tutorialTagTutorialSceneMap;

        private void OnEnable()
        {
            tutorialTagTutorialSceneMap = new Dictionary<Tag, TutorialScene>();
            for (int i = 0; i < tutorialScenes.Count; i++)
            {
                if (tutorialScenes[i] != null)
                {
                    if (tutorialScenes[i].SceneTag != null)
                    {
                        tutorialTagTutorialSceneMap[tutorialScenes[i].SceneTag] = tutorialScenes[i];
                        tutorialScenes[i].TutorialProgression = i;
                    }
                }
            }

        }

        public TutorialScene GetTutorialScene(Tag sceneTag)
        {
            TutorialScene tutorialScene = null;
            if (tutorialTagTutorialSceneMap.ContainsKey(sceneTag))
            {
                tutorialScene = tutorialTagTutorialSceneMap[sceneTag];
            }
            return tutorialScene;
        }

        public TutorialScene GetTutorialSceneWithTutorialProgression(int tutorialProgression)
        {
            TutorialScene tutorialScene = null;
            if (tutorialProgression >= 0 && tutorialProgression < tutorialScenes.Count)
            {
                tutorialScene = tutorialScenes[tutorialProgression];
            }
            return tutorialScene;
        }

        public int GetTutorialProgression(Tag sceneTag)
        {
            int tutorialProgression = -1;
            if (tutorialTagTutorialSceneMap.ContainsKey(sceneTag))
            {
                tutorialProgression = tutorialTagTutorialSceneMap[sceneTag].TutorialProgression;
            }
            return tutorialProgression;
        }

        public bool IsTutorialProgressionEnded(int tutorialProgression)
        {
            return tutorialProgression >= tutorialScenes.Count;
        }

        public int GetTutorialProgressionEnd()
        {
            return tutorialScenes.Count;
        }
    }
}
