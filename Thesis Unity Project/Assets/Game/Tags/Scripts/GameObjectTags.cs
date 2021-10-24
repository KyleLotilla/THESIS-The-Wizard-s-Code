using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.Tags
{
    public class GameObjectTags : MonoBehaviour, IEnumerable<Tag>
    {
        [SerializeField]
        private List<Tag> tags;

        public IEnumerator<Tag> GetEnumerator()
        {
            return ((IEnumerable<Tag>)tags).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)tags).GetEnumerator();
        }
    }
}
