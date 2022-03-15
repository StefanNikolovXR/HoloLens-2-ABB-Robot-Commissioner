using UnityEngine;
using UnityEngine.UI;

namespace HeathenEngineering.UX.uGUIExtras
{
    /// <summary>
    /// An empty graphic to enable non graphical elements to respond to pointer events without incuring a draw call.
    /// </summary>
    [AddComponentMenu("Tools/UX/uGUI/Ray Catcher")]
    public class RayCatcher : Graphic
    {
        private RectTransform _selfTransform;
        public RectTransform SelfTransform
        {
            get
            {
                if (_selfTransform == null)
                    _selfTransform = GetComponent<RectTransform>();
                return _selfTransform;
            }
        }

        public override void SetMaterialDirty() { return; }
        public override void SetVerticesDirty() { return; }
        
        protected override void OnPopulateMesh(VertexHelper vh)
        {
            vh.Clear();
            return;
        }
    }
}
