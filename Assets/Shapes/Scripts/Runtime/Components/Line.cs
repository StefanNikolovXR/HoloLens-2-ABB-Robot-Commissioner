using UnityEngine;

// Shapes © Freya Holmér - https://twitter.com/FreyaHolmer/
// Website & Documentation - https://acegikmo.com/shapes/
namespace Shapes {

	/// <summary>A Line segment shape component</summary>
	[ExecuteAlways]
	[AddComponentMenu( "Shapes/Line" )]
	public class Line : ShapeRenderer {

		/// <summary>The color modes for line shapes</summary>
		public enum LineColorMode {
			/// <summary>A single color across the whole line</summary>
			Single,

			/// <summary>Separate start and end colors</summary>
			Double
		}

		/// <summary>Get or set the start/end point by index (0 = start, 1 = end)</summary>
		public Vector3 this[ int i ] {
			get => i > 0 ? End : Start;
			set => _ = i > 0 ? End = value : Start = value;
		}

		// also called alignment for 2D lines
		[SerializeField] LineGeometry geometry = LineGeometry.Billboard;
		/// <summary>Get or set the type of geometry used (flat, billboarded, volumetric)</summary>
		public LineGeometry Geometry {
			get => geometry;
			set {
				geometry = value;
				SetIntNow( ShapesMaterialUtils.propAlignment, (int)geometry );
				UpdateMesh( true );
				UpdateMaterial();
				ApplyProperties();
			}
		}
		[SerializeField] LineColorMode colorMode = LineColorMode.Single;
		/// <summary>Whether or not to use one a single color or two colors, one at each end of the line</summary>
		public LineColorMode ColorMode {
			get => colorMode;
			set => SetColorNow( ShapesMaterialUtils.propColorEnd, ( colorMode = value ) == LineColorMode.Double ? colorEnd : base.Color );
		}
		/// <summary>The color of this shape. The alpha channel is used for opacity/intensity in all blend modes</summary>
		public override Color Color {
			get => color;
			set {
				SetColor( ShapesMaterialUtils.propColor, color = value );
				SetColorNow( ShapesMaterialUtils.propColorEnd, colorEnd = value );
			}
		}
		/// <summary>The color to use at the start of the line (when ColorMode is set to Double)</summary>
		public Color ColorStart {
			get => color;
			set => SetColorNow( ShapesMaterialUtils.propColor, color = value );
		}
		[SerializeField] [ShapesColorField( true )] Color colorEnd = Color.white;
		/// <summary>The color to use at the end of the line (when ColorMode is set to Double)</summary>
		public Color ColorEnd {
			get => colorEnd;
			set => SetColorNow( ShapesMaterialUtils.propColorEnd, colorEnd = value );
		}
		[SerializeField] Vector3 start = Vector3.zero;
		/// <summary>The start point of this line in local space</summary>
		public Vector3 Start {
			get => start;
			set => SetVector3Now( ShapesMaterialUtils.propPointStart, start = value );
		}
		[SerializeField] Vector3 end = Vector3.right;
		/// <summary>The endpoint of this line in local space</summary>
		public Vector3 End {
			get => end;
			set => SetVector3Now( ShapesMaterialUtils.propPointEnd, end = value );
		}
		[SerializeField] float thickness = 0.125f;
		/// <summary>The thickness of this line in the given ThicknessSpace</summary>
		public float Thickness {
			get => thickness;
			set {
				SetFloatNow( ShapesMaterialUtils.propThickness, thickness = value );
				if( dashed && dashStyle.space == DashSpace.Relative )
					SetAllDashValues( now: true );
			}
		}
		[SerializeField] ThicknessSpace thicknessSpace = Shapes.ThicknessSpace.Meters;
		/// <summary>The space in which Thickness is defined</summary>
		public ThicknessSpace ThicknessSpace {
			get => thicknessSpace;
			set => SetIntNow( ShapesMaterialUtils.propThicknessSpace, (int)( thicknessSpace = value ) );
		}
		[SerializeField] LineEndCap endCaps = LineEndCap.Round;
		/// <summary>What end caps to use</summary>
		public LineEndCap EndCaps {
			get => endCaps;
			set {
				endCaps = value;
				UpdateMaterial();
			}
		}
		[SerializeField] bool matchDashSpacingToSize = true;
		/// <summary>Get or set whether or not dash spacing should be auto-set to the dash size</summary>
		public bool MatchDashSpacingToSize {
			get => matchDashSpacingToSize;
			set {
				matchDashSpacingToSize = value;
				SetAllDashValues( now: true );
			}
		}
		[SerializeField] bool dashed = false;
		/// <summary>Get or set whether or not this line should be dashed</summary>
		public bool Dashed {
			get => dashed;
			set {
				dashed = value;
				SetAllDashValues( now: true );
			}
		}
		[SerializeField] DashStyle dashStyle = DashStyle.DefaultDashStyleLine;
		/// <summary>Size of dashes in the specified dash space. When using DashSpace.FixedCount, this is the number of dashes</summary>
		public float DashSize {
			get => dashStyle.size;
			set {
				dashStyle.size = value;
				float netDashSize = dashStyle.GetNetAbsoluteSize( dashed, thickness );
				if( matchDashSpacingToSize )
					SetFloat( ShapesMaterialUtils.propDashSpacing, GetNetDashSpacing() );
				SetFloatNow( ShapesMaterialUtils.propDashSize, netDashSize );
			}
		}
		/// <summary>Size of spacing between each dash, in the specified dash space. When using DashSpace.FixedCount, this is the dash:space ratio</summary>
		public float DashSpacing {
			get => dashStyle.spacing;
			set {
				dashStyle.spacing = value;
				SetFloatNow( ShapesMaterialUtils.propDashSpacing, GetNetDashSpacing() );
			}
		}
		/// <summary>Offset for dashes. An offset of 1 is the size of a whole dash+space period</summary>
		public float DashOffset {
			get => dashStyle.offset;
			set => SetFloatNow( ShapesMaterialUtils.propDashOffset, dashStyle.offset = value );
		}
		/// <summary>The space in which dash lengths are defined</summary>
		public DashSpace DashSpace {
			get => dashStyle.space;
			set {
				SetInt( ShapesMaterialUtils.propDashSpace, (int)( dashStyle.space = value ) );
				SetFloatNow( ShapesMaterialUtils.propDashSize, dashStyle.GetNetAbsoluteSize( dashed, thickness ) );
			}
		}
		/// <summary>What snapping type to use for dashes</summary>
		public DashSnapping DashSnap {
			get => dashStyle.snap;
			set => SetIntNow( ShapesMaterialUtils.propDashSnap, (int)( dashStyle.snap = value ) );
		}
		/// <summary>What dash type to use for dashed lines</summary>
		public DashType DashType {
			get => dashStyle.type;
			set => SetIntNow( ShapesMaterialUtils.propDashType, (int)( dashStyle.type = value ) );
		}
		/// <summary>A -1 to 1 modifier that allows you to tweak or mirror certain dash types in dashed lines</summary>
		public float DashShapeModifier {
			get => dashStyle.shapeModifier;
			set => SetFloatNow( ShapesMaterialUtils.propDashShapeModifier, dashStyle.shapeModifier = value );
		}

		void SetAllDashValues( bool now ) => SetAllDashValues( dashStyle, Dashed, matchDashSpacingToSize, thickness, Geometry != LineGeometry.Volumetric3D, now );
		float GetNetDashSpacing() => GetNetDashSpacing( dashStyle, dashed, matchDashSpacingToSize, thickness );

		private protected override void SetAllMaterialProperties() {
			SetVector3( ShapesMaterialUtils.propPointStart, start );
			SetVector3( ShapesMaterialUtils.propPointEnd, end );
			SetFloat( ShapesMaterialUtils.propThickness, thickness );
			SetInt( ShapesMaterialUtils.propThicknessSpace, (int)thicknessSpace );
			SetInt( ShapesMaterialUtils.propAlignment, (int)geometry );
			SetColor( ShapesMaterialUtils.propColorEnd, colorMode == LineColorMode.Double ? colorEnd : base.Color );
			SetAllDashValues( now: false );
		}


		private protected override Bounds GetBounds_Internal() {
			// presume 0 world space padding when pixels or noots are used
			float padding = thicknessSpace == ThicknessSpace.Meters ? thickness : 0f;
			Vector3 center = ( start + end ) / 2f;
			Vector3 size = ShapesMath.Abs( start - end ) + new Vector3( padding, padding, padding );
			return new Bounds( center, size );
		}

		private protected override Material[] GetMaterials() => new[] { ShapesMaterialUtils.GetLineMat( geometry, endCaps )[BlendMode] };
		private protected override Mesh GetInitialMeshAsset() => ShapesMeshUtils.GetLineMesh( geometry, endCaps, detailLevel );
		internal override bool HasDetailLevels => true;

		private protected override void ShapeClampRanges() {
			thickness = Mathf.Max( 0, thickness );
			DashSpacing = DashSpace == DashSpace.FixedCount ? Mathf.Clamp01( DashSpacing ) : Mathf.Max( 0f, DashSpacing );
		}

	}

}