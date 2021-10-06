using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Collections;

namespace DLSU.WizardCode.Tags
{
    public class GameObjectTagsCollision : MonoBehaviour
    {
        [SerializeField]
        private List<TagCollisionListener> initialTagCollisionListeners;
        private SparseArray<Tag, TagCollisionListener> tagCollisionListeners;

        private void Awake()
        {
            tagCollisionListeners = new SparseArray<Tag, TagCollisionListener>();
            foreach (TagCollisionListener tagCollisionListener in initialTagCollisionListeners)
            {
                Tag tag = tagCollisionListener.Tag;
                tagCollisionListeners[tag] = tagCollisionListener;
            }
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            GameObjectTags collidedGameObjectTags = collision.gameObject.GetComponent<GameObjectTags>();
            if (collidedGameObjectTags != null)
            {
                CheckTagsForCollision(collidedGameObjectTags);
            }
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            GameObjectTags collidedGameObjectTags = collision.gameObject.GetComponent<GameObjectTags>();
            if (collidedGameObjectTags != null)
            {
                CheckTagsForCollision(collidedGameObjectTags);
            }
        }

        private void CheckTagsForCollision(GameObjectTags gameObjectTags)
        {
            GameObject collided = gameObjectTags.gameObject;
            foreach (Tag tag in gameObjectTags)
            {
                if (tagCollisionListeners.HasKey(tag))
                {
                    TagCollisionListener collisionListenerOfCurrentTag = tagCollisionListeners[tag];
                    collisionListenerOfCurrentTag.OnTagCollision(collided);
                }
            }
        }
    }
}

