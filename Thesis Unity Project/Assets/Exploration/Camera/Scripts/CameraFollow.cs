using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.Exploration.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField]
        private GameObjectVariable mainCamera;
        [SerializeField]
        private Vector3 offset;

        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            
            FollowObject();
        }

        public void FollowObject()
        {
            Vector3 cameraPosition = transform.position + offset;
            mainCamera.Value.transform.position = cameraPosition;
        }
    }

}

