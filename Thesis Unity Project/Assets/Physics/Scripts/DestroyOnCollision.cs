using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DLSU.WizardCode.Physics
{
    public class DestroyOnCollision : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent onDestroy;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            DestroyGameObject();
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            DestroyGameObject();
        }

        private void DestroyGameObject()
        {
            onDestroy?.Invoke();
            Destroy(gameObject);
        }
    }

}
