using TMPro;
using UnityEngine;

// Shapes © Freya Holmér - https://twitter.com/FreyaHolmer/
// Website & Documentation - https://acegikmo.com/shapes/
namespace Shapes {

	internal struct DrawStyle {

		const float DEFAULT_THICKNESS = 0.05f;
		const ThicknessSpace DEFAULT_THICKNESS_SPACE = ThicknessSpace.Meters;

		public static DrawStyle @default = new DrawStyle {
			color = Color.white,
			renderState = new RenderState {
				zTest = ShapeRenderer.DEFAULT_ZTEST,
				zOffsetFactor = ShapeRenderer.DEFAULT_ZOFS_FACTOR,
				zOffsetUnits = ShapeRenderer.DEFAULT_ZOFS_UNITS,
				stencilComp = ShapeRenderer.DEFAULT_STENCIL_COMP,
				stencilOpPass = ShapeRenderer.DEFAULT_STENCIL_OP,
				stencilRefID = ShapeRenderer.DEFAULT_STENCIL_REF_ID,
				stencilReadMask = ShapeRenderer.DEFAULT_STENCIL_MASK,
				stencilWriteMask = ShapeRenderer.DEFAULT_STENCIL_MASK
			},
			blendMode = ShapesBlendMode.Transparent,
			scaleMode = ScaleMode.Uniform,
			detailLevel = DetailLevel.Medium,
			lineThickness = DEFAULT_THICKNESS,
			lineThicknessSpace = DEFAULT_THICKNESS_SPACE,
			lineDashStyle = DashStyle.DefaultDashStyleLine,
			lineEndCaps = LineEndCap.Round,
			lineGeometry = LineGeometry.Billboard,
			polygonTriangulation = PolygonTriangulation.EarClipping,
			polygonShapeFill = new ShapeFill(),
			polylineGeometry = PolylineGeometry.Billboard,
			polylineJoins = PolylineJoins.Round,

			// disc
			discGeometry = DiscGeometry.Flat2D,
			discRadius = 1f,
			ringThickness = DEFAULT_THICKNESS,
			ringThicknessSpace = DEFAULT_THICKNESS_SPACE,
			discRadiusSpace = DEFAULT_THICKNESS_SPACE,
			ringDashStyle = DashStyle.DefaultDashStyleRing,

			// regular polygon
			regularPolygonRadius = 1f,
			regularPolygonSideCount = 6,
			regularPolygonGeometry = RegularPolygonGeometry.Flat2D,
			regularPolygonThickness = DEFAULT_THICKNESS,
			regularPolygonThicknessSpace = DEFAULT_THICKNESS_SPACE,
			regularPolygonRadiusSpace = DEFAULT_THICKNESS_SPACE,
			regularPolygonShapeFill = new ShapeFill(),
			
			// rectangles
			rectangleThickness = DEFAULT_THICKNESS,
			rectangleThicknessSpace = DEFAULT_THICKNESS_SPACE,
			rectangleShapeFill = new ShapeFill(),

			// hollow triangles
			triangleThickness = DEFAULT_THICKNESS,
			triangleThicknessSpace = DEFAULT_THICKNESS_SPACE,

			sphereRadius = 1f,
			sphereRadiusSpace = DEFAULT_THICKNESS_SPACE,
			cuboidSizeSpace = DEFAULT_THICKNESS_SPACE,
			torusThicknessSpace = DEFAULT_THICKNESS_SPACE,
			torusRadiusSpace = DEFAULT_THICKNESS_SPACE,
			coneSizeSpace = DEFAULT_THICKNESS_SPACE,
			font = ShapesAssets.Instance.defaultFont,
			fontSize = 1f,
			textAlign = TextAlign.Center
		};

		// globally shared render state styles
		public RenderState renderState;
		public Color color;
		public ShapesBlendMode blendMode; // technically a render state rather than property, but we swap shaders here instead
		public ScaleMode scaleMode;
		public DetailLevel detailLevel;

		// shared line & polyline states
		public float lineThickness;
		public ThicknessSpace lineThicknessSpace;

		// line states
		public LineEndCap lineEndCaps;
		public LineGeometry lineGeometry;

		// polygon states
		public PolygonTriangulation polygonTriangulation;
		public ShapeFill polygonShapeFill;

		// line dashes
		public DashStyle lineDashStyle;
		public DashStyle ringDashStyle;

		// polyline states
		public PolylineGeometry polylineGeometry;
		public PolylineJoins polylineJoins;

		// disc & ring states
		public float discRadius;
		public DiscGeometry discGeometry;
		public float ringThickness;
		public ThicknessSpace ringThicknessSpace;
		public ThicknessSpace discRadiusSpace;

		// regular polygon states
		public float regularPolygonRadius;
		public int regularPolygonSideCount;
		public RegularPolygonGeometry regularPolygonGeometry;
		public float regularPolygonThickness;
		public ThicknessSpace regularPolygonThicknessSpace;
		public ThicknessSpace regularPolygonRadiusSpace;
		public ShapeFill regularPolygonShapeFill;
		
		// Rectangle states
		public float rectangleThickness;
		public ThicknessSpace rectangleThicknessSpace;
		public ShapeFill rectangleShapeFill;

		// Triangle states
		public float triangleThickness;
		public ThicknessSpace triangleThicknessSpace;

		// 3D shape states
		public float sphereRadius;
		public ThicknessSpace sphereRadiusSpace;
		public ThicknessSpace cuboidSizeSpace;
		public ThicknessSpace torusThicknessSpace;
		public ThicknessSpace torusRadiusSpace;
		public ThicknessSpace coneSizeSpace;

		// text states
		public TMP_FontAsset font;
		public float fontSize;
		public TextAlign textAlign;
	}

}