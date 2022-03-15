using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System;
using UnityEngine.EventSystems;

namespace HeathenEngineering.UX.uGUIExtras
{
    [AddComponentMenu("UX/Reorderable Layout Group/Reorderable (Horizontal)")]
    [RequireComponent(typeof(UnityEngine.UI.HorizontalLayoutGroup))]
    public class ReorderableHorizontalLayoutGroup : HeathenUIBehaviour, ICollection<RectTransform>
    {
        private UnityEngine.UI.HorizontalLayoutGroup layoutGroup;

        public int Count => SelfTransform.childCount;

        public bool IsReadOnly => false;

        private void Awake()
        {
            layoutGroup = GetComponent<UnityEngine.UI.HorizontalLayoutGroup>();
        }

        public void Insert(RectTransform item, int index)
        {
            item.SetParent(SelfTransform);
            item.SetSiblingIndex(index);
        }

        public void Insert(Transform item, int index)
        {
            item.SetParent(SelfTransform);
            item.SetSiblingIndex(index);
        }

        public void Insert(GameObject item, int index)
        {
            item.transform.SetParent(SelfTransform);
            item.transform.SetSiblingIndex(index);
        }

        public void Add(RectTransform item)
        {
            item.SetParent(SelfTransform);
        }

        public void Add(Transform item)
        {
            item.SetParent(SelfTransform);
        }

        public void Add(GameObject item)
        {
            item.transform.SetParent(SelfTransform);
        }

        public void Clear()
        {
            foreach (Transform trans in SelfTransform)
                Destroy(trans.gameObject);
        }

        public bool Contains(RectTransform item)
        {
            if (item.parent == SelfTransform)
                return true;
            else
                return false;
        }

        public bool Contains(Transform item)
        {
            if (item.parent == SelfTransform)
                return true;
            else
                return false;
        }

        public bool Contains(GameObject item)
        {
            if (item.transform.parent == SelfTransform)
                return true;
            else
                return false;
        }

        public void CopyTo(RectTransform[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("array is null");
            if (SelfTransform == null)
                throw new ArgumentNullException("collection is null");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("arrayIndex is less than 0");
            if (array.Length - arrayIndex < SelfTransform.childCount)
                throw new ArgumentException("The number of elements in the collection is greater than the available space from " + arrayIndex.ToString() + " to the end of the destination array");

            for (int i = 0; i < SelfTransform.childCount; i++)
                array[arrayIndex + i] = SelfTransform.GetChild(i) as RectTransform;
        }

        public void CopyTo(Transform[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("array is null");
            if (SelfTransform == null)
                throw new ArgumentNullException("collection is null");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("arrayIndex is less than 0");
            if (array.Length - arrayIndex < SelfTransform.childCount)
                throw new ArgumentException("The number of elements in the collection is greater than the available space from " + arrayIndex.ToString() + " to the end of the destination array");

            for (int i = 0; i < SelfTransform.childCount; i++)
                array[arrayIndex + i] = SelfTransform.GetChild(i);
        }

        public void CopyTo(GameObject[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("array is null");
            if (SelfTransform == null)
                throw new ArgumentNullException("collection is null");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("arrayIndex is less than 0");
            if (array.Length - arrayIndex < SelfTransform.childCount)
                throw new ArgumentException("The number of elements in the collection is greater than the available space from " + arrayIndex.ToString() + " to the end of the destination array");

            for (int i = 0; i < SelfTransform.childCount; i++)
                array[arrayIndex + i] = SelfTransform.GetChild(i).gameObject;
        }

        public IEnumerator<RectTransform> GetEnumerator()
        {
            return SelfTransform.GetEnumerator() as IEnumerator<RectTransform>;
        }

        public bool Remove(RectTransform item)
        {
            if (item != null
                && item.parent == SelfTransform)
            {
                Destroy(item.gameObject);
                return true;
            }
            else
                return false;
        }

        public bool Remove(Transform item)
        {
            if (item != null
                && item.parent == SelfTransform)
            {
                Destroy(item.gameObject);
                return true;
            }
            else
                return false;
        }

        public bool Remove(GameObject item)
        {
            if (item != null
                && item.transform.parent == SelfTransform)
            {
                Destroy(item);
                return true;
            }
            else
                return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return SelfTransform.GetEnumerator();
        }
    }
}
