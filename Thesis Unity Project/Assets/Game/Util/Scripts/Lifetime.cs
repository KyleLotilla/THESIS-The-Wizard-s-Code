using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DLSU.WizardCode.Util
{
    public class Lifetime : MonoBehaviour
    {
        [SerializeField]
        private float lifetime;
        [SerializeField]
        private UnityEvent onLifetimeEnded;
        private float ticks = 0.0f;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            ticks += Time.deltaTime;
            if (this.ticks >= lifetime)
            {
                onLifetimeEnded?.Invoke();
                Destroy(gameObject);
            }
        }
    }

}
