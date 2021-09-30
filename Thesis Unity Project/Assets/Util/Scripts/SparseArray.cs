using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DLSU.WizardCode.Util
{
    public class SparseArray<TKey, TValue> : IEnumerable<TValue>
    {
        private Dictionary<TKey, int> keyIndexMap;
        private List<TKey> keys;
        private List<TValue> values;

        public SparseArray()
        {
            keyIndexMap = new Dictionary<TKey, int>();
            values = new List<TValue>();
            keys = new List<TKey>();
        }

        public TValue this[TKey key]
        {
            get
            {
                return GetValue(key);
            }
            set
            {
                if (keyIndexMap.ContainsKey(key))
                {
                    SetValue(key, value);
                }
                else
                {
                    AddNewKey(key, value);
                }
            }
        }

        public TValue GetValue(TKey key)
        {
            Debug.Assert(keyIndexMap.ContainsKey(key), "SparseArray: \"" + key.ToString() + "\" key not found");
            if (keyIndexMap.ContainsKey(key))
            {
                Debug.Assert(keyIndexMap[key] >= 0 && keyIndexMap[key] < values.Count, "SparseArray: Index of key \"" + key.ToString() + "\" Out of Bounds");
                if (keyIndexMap[key] >= 0 && keyIndexMap[key] < values.Count)
                {
                    return values[keyIndexMap[key]];
                }
            }
            return default(TValue);
        }

        public void SetValue(TKey key, TValue value)
        {
            Debug.Assert(keyIndexMap.ContainsKey(key), "SparseArray: \"" + key.ToString() + "\" key not found");
            if (keyIndexMap.ContainsKey(key))
            {
                Debug.Assert(keyIndexMap[key] >= 0 && keyIndexMap[key] < values.Count, "SparseArray: Index of key \"" + key.ToString() + "\" Out of Bounds");
                if (keyIndexMap[key] >= 0 && keyIndexMap[key] < values.Count)
                {
                    values[keyIndexMap[key]] = value;
                }
            }
        }

        public void AddNewKey(TKey key, TValue value)
        {
            Debug.Assert(!keyIndexMap.ContainsKey(key), "SparseArray: \"" + key.ToString() + "\" key already created");
            if (!keyIndexMap.ContainsKey(key))
            {
                values.Add(value);
                keys.Add(key);
                keyIndexMap[key] = values.Count - 1;
            }
        }

        public bool hasKey(TKey key)
        {
            return keyIndexMap.ContainsKey(key);
        }

        public void Remove(TKey key)
        {
            Debug.Assert(keyIndexMap.ContainsKey(key), "SparseArray: \"" + key.ToString() + "\" key not found");
            if (keyIndexMap.ContainsKey(key))
            {
                Debug.Assert(keyIndexMap[key] >= 0 && keyIndexMap[key] < values.Count, "SparseArray: Index of key \"" + key.ToString() + "\" Out of Bounds");
                if (keyIndexMap[key] >= 0 && keyIndexMap[key] < values.Count)
                {
                    int removedElementIndex = keyIndexMap[key];
                    int lastElementIndex = values.Count - 1;
                    values[removedElementIndex] = values[lastElementIndex];
                    keyIndexMap[keys[lastElementIndex]] = removedElementIndex;
                    keys[removedElementIndex] = keys[lastElementIndex];
                    keys.RemoveAt(lastElementIndex);
                    values.RemoveAt(lastElementIndex);
                    keyIndexMap.Remove(key);
                }
            }
        }

        public IEnumerator<TValue> GetEnumerator()
        {
            return ((IEnumerable<TValue>)values).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)values).GetEnumerator();
        }
    }

}
