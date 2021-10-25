using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Tags;
using DLSU.WizardCode.ScriptableObjectVariables;
using DLSU.WizardCode.Levels;

namespace DLSU.WizardCode.Tutorial
{
    [Serializable]
    public class TutorialScene
    {
        private int tutorialProgression;
        public int TutorialProgression
        {
            get
            {
                return tutorialProgression;
            }
            set
            {
                tutorialProgression = value;
            }
        }
        [SerializeField]
        private Tag sceneTag;
        public Tag SceneTag
        {
            get
            {
                return sceneTag;
            }
        }
        [SerializeField]
        private string sceneName;
        public string SceneName
        {
            get
            {
                return sceneName;
            }
        }
        [SerializeField]
        private bool isALevelScene;
        public bool IsALevelSecene
        {
            get
            {
                return isALevelScene;
            }
        }
        [SerializeField]
        private Level level;
        public Level Level
        {
            get
            {
                return level;
            }
        }
    }
}
