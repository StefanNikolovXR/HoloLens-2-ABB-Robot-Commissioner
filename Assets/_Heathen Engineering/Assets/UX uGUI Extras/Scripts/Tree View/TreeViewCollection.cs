using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Serialization;

namespace HeathenEngineering.UX.uGUIExtras
{
    [AddComponentMenu("UX/Tree View/Tree View Collection")]
    public class TreeViewCollection : HeathenUIBehaviour, ICollection<TreeViewNode>
    {
        [FormerlySerializedAs("NodePrototype")]
        public TreeViewNode nodePrototype;
        [FormerlySerializedAs("Root")]
        public RectTransform root;
        public int Count { get{ return root == null ? 0 : root.childCount; } }

        public bool IsReadOnly { get { return false; } }
        
        public TreeViewNode CreateNode(TreeViewNode parent)
        {
            if (root == null)
                return null;
            else
            {
                var go = Instantiate(nodePrototype.gameObject, parent == null || parent.collection == null ? root : parent.collection);
                var tvn = go.GetComponent<TreeViewNode>();
                tvn.tree = this;
                tvn.parent = parent;
                return tvn;
            }
        }

        [ContextMenu("Add Root Node")]
        public TreeViewNode CreateNode()
        {
            return CreateNode(null);
        }

        public void Add(TreeViewNode item)
        {
            item.parent = null;
            item.SelfTransform.SetParent(root);
        }

        public void Clear()
        {
            foreach (GameObject go in root)
                Destroy(go);
        }

        public bool Contains(TreeViewNode item)
        {
            if (item.SelfTransform.parent == root)
                return true;
            else
                return false;
        }

        public void CopyTo(TreeViewNode[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("array is null");
            if (root == null)
                throw new ArgumentNullException("collection is null");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("arrayIndex is less than 0");
            if (array.Length - arrayIndex < root.childCount)
                throw new ArgumentException("The number of elements in the collection is greater than the available space from " + arrayIndex.ToString() + " to the end of the destination array");

            for (int i = 0; i < root.childCount; i++)
                array[arrayIndex + i] = root.GetChild(i).GetComponent<TreeViewNode>();
        }

        public bool Remove(TreeViewNode item)
        {
            if (item != null
                && item.parent == root)
            {
                Destroy(item.gameObject);
                return true;
            }
            else
                return false;
        }

        public IEnumerator<TreeViewNode> GetEnumerator()
        {
            if (root == null)
                throw new ArgumentNullException("collection is null");

            return root.GetEnumerator() as IEnumerator<TreeViewNode>;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            if (root == null)
                throw new ArgumentNullException("collection is null");

            return root.GetEnumerator();
        }
    }
}
