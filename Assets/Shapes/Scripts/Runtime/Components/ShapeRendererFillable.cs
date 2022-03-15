using UnityEngine;

// Shapes © Freya Holmér - https://twitter.com/FreyaHolmer/
// Website & Documentation - https://acegikmo.com/shapes/
namespace Shapes {

	/// <summary>A base type for fillable shapes</summary>
	public abstract class ShapeRendererFillable : ShapeRenderer {

		// global color fill gradient shenanigans
		internal ShapeFill Fill => fill;
		[SerializeField] private protected ShapeFill fill = new ShapeFill();
		[SerializeField] private protected bool useFill;
		int FillTypeShaderInt => useFill ? fill.GetShaderFillModeInt() : ShapeFill.FILL_NONE;
		/// <summary>Whether or not to use the color fill overlay</summary>
		public bool UseFill {
			get => useFill;
			set {
				useFill = value;
				SetIntNow( ShapesMaterialUtils.propFillType, FillTypeShaderInt );
			}
		}
		/// <summary>What color fill type to use</summary>
		public FillType FillType {
			get => fill.type;
			set {
				fill.type = value;
				SetIntNow( ShapesMaterialUtils.propFillType, FillTypeShaderInt );
			}
		}
		/// <summary>Whether color fills should be in local or world space</summary>
		public FillSpace FillSpace {
			get => fill.space;
			set => SetIntNow( ShapesMaterialUtils.propFillSpace, (int)( fill.space = value ) );
		}
		/// <summary>The origin (in the given FillSpace) to use for radial gradients</summary>
		public Vector3 FillRadialOrigin {
			get => fill.radialOrigin;
			set {
				fill.radialOrigin = value;
				SetVector4Now( ShapesMaterialUtils.propFillStart, fill.GetShaderStartVector() );
			}
		}
		/// <summary>The radius (in the given FillSpace) to use for radial gradients</summary>
		public float FillRadialRadius {
			get => fill.radialRadius;
			set {
				fill.radialRadius = value;
				SetVector4Now( ShapesMaterialUtils.propFillStart, fill.GetShaderStartVector() );
			}
		}
		/// <summary>The start point (in the given FillSpace) to use for linear gradients</summary>
		public Vector3 FillLinearStart {
			get => fill.linearStart;
			set {
				fill.linearStart = value;
				SetVector4Now( ShapesMaterialUtils.propFillStart, fill.GetShaderStartVector() );
			}
		}
		/// <summary>The end point (in the given FillSpace) to use for linear gradients</summary>
		public Vector3 FillLinearEnd {
			get => fill.linearEnd;
			set => SetVector3Now( ShapesMaterialUtils.propFillEnd, fill.linearEnd = value );
		}
		/// <summary>The start color of linear gradients. The center color for radial gradients</summary>
		public Color FillColorStart {
			get => fill.colorStart;
			set => SetColorNow( ShapesMaterialUtils.propColor, fill.colorStart = value );
		}
		/// <summary>The end color of linear gradients. The outer color for radial gradients</summary>
		public Color FillColorEnd {
			get => fill.colorEnd;
			set => SetColorNow( ShapesMaterialUtils.propColorEnd, fill.colorEnd = value );
		}

		private protected void SetFillProperties() {
			if( useFill ) {
				SetInt( ShapesMaterialUtils.propFillSpace, (int)fill.space );
				SetVector4( ShapesMaterialUtils.propFillStart, fill.GetShaderStartVector() );
				SetVector3( ShapesMaterialUtils.propFillEnd, fill.linearEnd );
				SetColor( ShapesMaterialUtils.propColor, fill.colorStart );
				SetColor( ShapesMaterialUtils.propColorEnd, fill.colorEnd );
			}

			SetInt( ShapesMaterialUtils.propFillType, FillTypeShaderInt );
		}


	}

}