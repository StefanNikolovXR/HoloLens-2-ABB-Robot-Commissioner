using UnityEngine;
using System.Collections.Generic;

namespace HeathenEngineering.UX
{
    [AddComponentMenu("UX/Helpers/Scroll Rect Helper")]
    [RequireComponent(typeof(UnityEngine.UI.ScrollRect))]
    public class ScrollRectHelper : MonoBehaviour
    {
        /// <summary>
        /// The managed scroll rect element
        /// </summary>
        public UnityEngine.UI.ScrollRect scrollRect
        {
            get;
            private set;
        }

        /// <summary>
        /// The list of elements in this rect
        /// </summary>
        public List<GameObject> elements
        {
            get;
            private set;
        }

        /// <summary>
        /// The current relative offset height of a page
        /// </summary>
        public float pageHeight
        {
            get;
            private set;
        }

        /// <summary>
        /// The current relative offset width of a page
        /// </summary>
        public float pageWidth
        {
            get;
            private set;
        }

        /// <summary>
        /// A pointer to the transform; this is faster than calling gameObject.transform
        /// </summary>
        public Transform selfTransform
        {
            get;
            private set;
        }

        /// <summary>
        /// A pre-casted pointer to the RectTransform this is faster than calling (RectTransform)gameObject.transform
        /// </summary>
        public RectTransform selfRectTransform
        {
            get;
            private set;
        }

        private RectTransform trans;
        private float vMinScrollPoint;
        private float hMinScrollPoint;
        private float elementHeight;
        private float elementWidth;


        void Start()
        {
            scrollRect = GetComponent<UnityEngine.UI.ScrollRect>();
            selfTransform = GetComponent<Transform>();
            selfRectTransform = GetComponent<RectTransform>();
            pageHeight = selfRectTransform.rect.height / scrollRect.content.rect.height;
            pageWidth = selfRectTransform.rect.width / scrollRect.content.rect.width;

            RefreshElements();
        }

        void Update()
        {
            pageHeight = selfRectTransform.rect.height / scrollRect.content.rect.height;
            pageWidth = selfRectTransform.rect.width / scrollRect.content.rect.width;
        }

        /// <summary>
        /// Scrolls the rect up the height of 1 page
        /// </summary>
        public void PageUp()
        {
            if (scrollRect.vertical)
            {
                if (scrollRect.verticalScrollbar != null)
                {
                    if (scrollRect.verticalScrollbar.direction == UnityEngine.UI.Scrollbar.Direction.BottomToTop)
                        scrollRect.verticalScrollbar.value = scrollRect.verticalScrollbar.value + pageHeight;
                    else
                        scrollRect.verticalScrollbar.value = scrollRect.verticalScrollbar.value - pageHeight;
                }
                else
                {
                    trans.localPosition = new Vector3(scrollRect.content.localPosition.x, scrollRect.content.localPosition.y - (scrollRect.content.rect.height * pageHeight), scrollRect.content.localPosition.z);
                }
            }
        }

        /// <summary>
        /// Scrolls the rect down the height of 1 page
        /// </summary>
        public void PageDown()
        {
            if (scrollRect.vertical)
            {
                if (scrollRect.verticalScrollbar != null)
                {
                    if (scrollRect.verticalScrollbar.direction == UnityEngine.UI.Scrollbar.Direction.BottomToTop)
                        scrollRect.verticalScrollbar.value = scrollRect.verticalScrollbar.value - pageHeight;
                    else
                        scrollRect.verticalScrollbar.value = scrollRect.verticalScrollbar.value + pageHeight;
                }
                else
                {
                    trans.localPosition = new Vector3(scrollRect.content.localPosition.x, scrollRect.content.localPosition.y + (scrollRect.content.rect.height * pageHeight), scrollRect.content.localPosition.z);
                }
            }
        }

        /// <summary>
        /// Scrolls the rect left the width of 1 page
        /// </summary>
        public void PageLeft()
        {
            if (scrollRect.horizontal)
            {
                if (scrollRect.horizontalScrollbar != null)
                {
                    if (scrollRect.horizontalScrollbar.direction == UnityEngine.UI.Scrollbar.Direction.RightToLeft)
                        scrollRect.horizontalScrollbar.value = scrollRect.horizontalScrollbar.value + pageWidth;
                    else
                        scrollRect.horizontalScrollbar.value = scrollRect.horizontalScrollbar.value - pageWidth;
                }
                else
                {
                    trans.localPosition = new Vector3(scrollRect.content.localPosition.x + (scrollRect.content.rect.width * pageWidth), scrollRect.content.localPosition.y, scrollRect.content.localPosition.z);
                }
            }
        }

        /// <summary>
        /// Scrolls the rect right the width of 1 page
        /// </summary>
        public void PageRight()
        {
            if (scrollRect.horizontal)
            {
                if (scrollRect.horizontalScrollbar != null)
                {
                    if (scrollRect.horizontalScrollbar.direction == UnityEngine.UI.Scrollbar.Direction.RightToLeft)
                        scrollRect.horizontalScrollbar.value = scrollRect.horizontalScrollbar.value - pageWidth;
                    else
                        scrollRect.horizontalScrollbar.value = scrollRect.horizontalScrollbar.value + pageWidth;
                }
                else
                {
                    trans.localPosition = new Vector3(scrollRect.content.localPosition.x - (scrollRect.content.rect.width * pageWidth), scrollRect.content.localPosition.y, scrollRect.content.localPosition.z);
                }
            }
        }

        /// <summary>
        /// Rebuilds the elements list based on the elements within the content transform
        /// This only considers active transforms and should be called on any change to child elements 
        /// It is preferable to add and remove items by using the AddElement and RemoveElement functions
        /// </summary>
        public void RefreshElements()
        {
            if (elements == null)
            {
                elements = new List<GameObject>();
            }

            elements.Clear();

            foreach (Transform trans in scrollRect.content)
            {
                if (trans.gameObject.activeSelf)
                    elements.Add(trans.gameObject);
            }
        }

        /// <summary>
        /// Adds an element to the scroll window if its not alredy present; this will force a refresh on the elements list
        /// </summary>
        /// <param name="element"></param>
        public void AddElement(GameObject element)
        {
            RefreshElements();

            if (!elements.Contains(element))
            {
                elements.Add(element);
                element.transform.SetParent(scrollRect.content, false);
            }
        }

        /// <summary>
        /// Removes an element from the list and re-parents the element to the indicated transform; this will force a refresh on the elements list
        /// </summary>
        /// <param name="element"></param>
        /// <param name="newParent"></param>
        public void RemoveElement(GameObject element, Transform newParent = null)
        {
            RefreshElements();

            if (elements.Contains(element))
            {
                elements.Remove(element);
                element.transform.SetParent(newParent, true);
            }
        }

        /// <summary>
        /// Returns the horizontal and vertical scroll offset for the indicated element
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public Vector2 GetScrollToPosition(GameObject element)
        {
            if (elements.Contains(element))
            {
                trans = element.GetComponent<RectTransform>();
                vMinScrollPoint = -(trans.localPosition.y - trans.rect.yMin) / scrollRect.content.rect.height;
                hMinScrollPoint = (trans.localPosition.x + trans.rect.xMin) / scrollRect.content.rect.width;
                elementHeight = trans.rect.height / scrollRect.content.rect.height;
                elementWidth = trans.rect.width / scrollRect.content.rect.width;

                vMinScrollPoint = vMinScrollPoint + (vMinScrollPoint > 0.5f ? elementHeight : 0);
                hMinScrollPoint = hMinScrollPoint + (hMinScrollPoint > 0.5f ? elementWidth : 0);

                return new Vector2(hMinScrollPoint, vMinScrollPoint);
            }
            else
                return Vector2.zero;
        }

        /// <summary>
        /// Returns the horizontal and vertical scroll offset for the indicated element
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public Vector2 GetScrollToPosition(int index)
        {
            if (index >= 0 && index < elements.Count)
                return GetScrollToPosition(elements[index]);
            else
                return Vector2.zero;
        }

        /// <summary>
        /// Scrolls to the position indicated
        /// </summary>
        /// <param name="position">The offset to scroll to; x and y shoudl be between 0 and 1</param>
        public void ScrollToPosition(Vector2 position)
        {
            if (scrollRect.horizontal)
            {
                if (scrollRect.horizontalScrollbar != null)
                {
                    if (scrollRect.horizontalScrollbar.direction == UnityEngine.UI.Scrollbar.Direction.RightToLeft)
                        scrollRect.horizontalScrollbar.value = 1 - position.x;
                    else
                        scrollRect.horizontalScrollbar.value = position.x;
                }
                else
                {
                    trans.localPosition = new Vector3(-(scrollRect.content.rect.width * position.x), scrollRect.content.localPosition.y, scrollRect.content.localPosition.z);
                }
            }

            if (scrollRect.vertical)
            {
                if (scrollRect.verticalScrollbar != null)
                {
                    if (scrollRect.verticalScrollbar.direction == UnityEngine.UI.Scrollbar.Direction.BottomToTop)
                        scrollRect.verticalScrollbar.value = 1 - position.y;
                    else
                        scrollRect.verticalScrollbar.value = position.y;
                }
                else
                {
                    trans.localPosition = new Vector3(scrollRect.content.localPosition.x, -(scrollRect.content.rect.height * position.y), scrollRect.content.localPosition.z);
                }
            }
        }

        /// <summary>
        /// Scrolls the rect to the relative position of the indicated element
        /// </summary>
        /// <param name="element">The element to find</param>
        public void ScrollToElement(GameObject element)
        {
            ScrollToPosition(GetScrollToPosition(element));
        }

        /// <summary>
        /// Scrolls the rect to the relative position of the indicated element
        /// </summary>
        /// <param name="index">The index to find</param>
        public void ScrollToElement(int index)
        {
            ScrollToPosition(GetScrollToPosition(index));
        }

        /// <summary>
        /// Scrolls the rect to the relative position of the indicated element
        /// This convenance function takes the index as a string and performs a safe cast
        /// </summary>
        /// <param name="indexAsString">The index to find as a string e.g. "0" for the first element</param>
        public void ScrollToElement(string indexAsString)
        {
            int index = 0;

            if (int.TryParse(indexAsString, out index))
                ScrollToPosition(GetScrollToPosition(index));
        }
    }
}
