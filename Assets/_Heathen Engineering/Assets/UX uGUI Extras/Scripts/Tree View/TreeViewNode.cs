using HeathenEngineering.UX;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace HeathenEngineering.UX.uGUIExtras
{
    [AddComponentMenu("UX/Tree View/Tree View Node")]
    [ExecuteInEditMode]
    public class TreeViewNode : HeathenUIBehaviour, ICollection<TreeViewNode>
    {
        public TreeViewCollection tree;
        public TreeViewNode parent;
        [FormerlySerializedAs("Content")]
        public RectTransform content;
        [FormerlySerializedAs("Collection")]
        public RectTransform collection;
        [SerializeField]
        private bool isExpanded = false;
        public bool IsExpanded
        {
            get { return isExpanded; }
            set
            {
                if (value != isExpanded)
                {
                    isExpanded = value;
                    collection.gameObject.SetActive(isExpanded);
                    if (value)
                        expanded.Invoke();
                    else
                        collapsed.Invoke();
                }
            }
        }
        [FormerlySerializedAs("Expanded")]
        public UnityEvent expanded;
        [FormerlySerializedAs("Collapsed")]
        public UnityEvent collapsed;
        public int Count { get { return collection == null ? 0 : collection.childCount; } }

        public bool IsReadOnly { get { return false; } }

        private void Start()
        {
            if(Refresh())
            {
                if (isExpanded)
                    expanded.Invoke();
                else
                    collapsed.Invoke();
            }
        }

        private void Update()
        {
            if (Refresh())
            {
                if (isExpanded)
                    expanded.Invoke();
                else
                    collapsed.Invoke();
            }
        }

        public bool Refresh()
        {
            if (collection == null)
                return false;

            if (collection.gameObject.activeSelf != isExpanded)
            {
                collection.gameObject.SetActive(isExpanded);
                return true;
            }
            else
                return false;
        }

        [ContextMenu("Add Child Node")]
        public TreeViewNode CreateChildNode()
        {
            if (tree == null || tree.nodePrototype == null || collection == null)
                return null;
            else
            {
                var go = Instantiate(tree.nodePrototype.gameObject, collection);
                var tvn = go.GetComponent<TreeViewNode>();
                tvn.tree = tree;
                tvn.parent = this;
                return tvn;
            }
        }

        [ContextMenu("Move Up")]
        public bool MoveUp()
        {
            if (SelfTransform.GetSiblingIndex() > 0)
            {
                SelfTransform.SetSiblingIndex(SelfTransform.GetSiblingIndex() - 1);
                return true;
            }
            else
                return false;
        }

        [ContextMenu("Move Down")]
        public bool MoveDown()
        {
            if (SelfTransform.GetSiblingIndex() < SelfTransform.parent.childCount - 1)
            {
                SelfTransform.SetSiblingIndex(SelfTransform.GetSiblingIndex() + 1);
                return true;
            }
            else
                return false;
        }

        [ContextMenu("Promote")]
        public bool Promote()
        {
            if (parent != null)
            {
                if (parent.parent != null && parent.parent.collection != null)
                {
                    //Our parent's parent is not the tree so we need to move to a node collection
                    SelfTransform.SetParent(parent.parent.collection);
                    SelfTransform.SetSiblingIndex(parent.SelfTransform.GetSiblingIndex() + 1);
                    parent = parent.parent;
                }
                else
                {
                    //Our parent's parent is a tree so we are moving to the tree collection
                    SelfTransform.SetParent(tree.root);
                    SelfTransform.SetSiblingIndex(parent.SelfTransform.GetSiblingIndex()+1);
                    parent = null;
                }
                return true;
            }
            else
                return false;
        }

        [ContextMenu("Demote")]
        public bool Demote()
        {
            if (SelfTransform.GetSiblingIndex() > 0)
            {
                var stvn = SelfTransform.parent.GetChild(SelfTransform.GetSiblingIndex() - 1).GetComponent<TreeViewNode>();
                if (stvn != null && stvn.collection != null)
                {
                    SelfTransform.SetParent(stvn.collection);
                    parent = stvn;
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public void Add(TreeViewNode item)
        {
            item.parent = this;
            item.SelfTransform.SetParent(collection);
        }

        public void Clear()
        {
            foreach (GameObject go in collection)
                Destroy(go);
        }

        public bool Contains(TreeViewNode item)
        {
            if (item.SelfTransform.parent == collection)
                return true;
            else
                return false;
        }

        public void CopyTo(TreeViewNode[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("array is null");
            if (collection == null)
                throw new ArgumentNullException("collection is null");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("arrayIndex is less than 0");
            if (array.Length - arrayIndex < collection.childCount)
                throw new ArgumentException("The number of elements in the collection is greater than the available space from "+ arrayIndex.ToString() + " to the end of the destination array");

            for (int i = 0; i < collection.childCount; i++)
                array[arrayIndex + i] = collection.GetChild(i).GetComponent<TreeViewNode>();
        }

        public bool Remove(TreeViewNode item)
        {
            if (item != null
                && item.parent == collection)
            {
                Destroy(item.gameObject);
                return true;
            }
            else
                return false;
        }

        public IEnumerator<TreeViewNode> GetEnumerator()
        {
            if (collection == null)
                throw new ArgumentNullException("collection is null");

            return collection.GetEnumerator() as IEnumerator<TreeViewNode>;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            if (collection == null)
                throw new ArgumentNullException("collection is null");

            return collection.GetEnumerator();
        }
    }
}
