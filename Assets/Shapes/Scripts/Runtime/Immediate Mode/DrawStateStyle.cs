using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

// Shapes © Freya Holmér - https://twitter.com/FreyaHolmer/
// Website & Documentation - https://acegikmo.com/shapes/
namespace Shapes {

	public static partial class Draw {

		internal static DrawStyle style;

		/// <summary><para>Resets draw style states, including color, but not the drawing matrix</para><para>See <see cref="Draw.ResetAllDrawStates()"/> to reset everything</para></summary>
		public static void ResetStyle() => style = DrawStyle.@default;

		/// <summary>using( StyleScope ){ /*code*/ } lets you modify the draw style state within that scope, automatically restoring the previous state once you leave the scope</summary>
		public static StyleStack StyleScope => new StyleStack( Draw.style );

		/// <summary>Pushes the current draw style state onto the style stack. Calling <see cref="Draw.PopStyle()"/> will restore this state</summary>
		public static void PushStyle() => StyleStack.Push( Draw.style );

		/// <summary>Restores the draw style state to the previously pushed state from the stack</summary>
		public static void PopStyle() => StyleStack.Pop();

		/// <summary>using( ColorScope ){ /*code*/ } lets you modify the color state within that scope, automatically restoring the previously saved color once you leave the scope</summary>
		public static ColorStack ColorScope => new ColorStack( Draw.style.color );

		/// <summary>Pushes the current draw color onto the matrix stack. Calling <see cref="Draw.PopColor()"/> will restore this state</summary>
		public static void PushColor() => ColorStack.Push( Draw.style.color );

		/// <summary>Restores the draw color state to the previously pushed state from the stack</summary>
		public static void PopColor() => ColorStack.Pop();

		/// <summary>Current depth buffer compare function. Default is CompareFunction.LessEqual</summary>
		public static CompareFunction ZTest {
			get => style.renderState.zTest;
			set => style.renderState.zTest = value;
		}
		/// <summary>This ZOffsetFactor scales the maximum Z slope, with respect to X or Y of the polygon, while the other ZOffsetUnits, scales the minimum resolvable depth buffer value.
		/// This allows you to force one polygon to be drawn on top of another although they are actually in the same position.
		/// For example, if ZOffsetFactor = 0 &amp; ZOffsetUnits = -1, it pulls the polygon closer to the camera,
		/// ignoring the polygon’s slope, whereas if ZOffsetFactor = -1 &amp; ZOffsetUnits = -1, it will pull the polygon even closer when looking at a grazing angle.</summary>
		public static float ZOffsetFactor {
			get => style.renderState.zOffsetFactor;
			set => style.renderState.zOffsetFactor = value;
		}
		/// <summary>this ZOffsetUnits value scales the minimum resolvable depth buffer value, while the other ZOffsetFactor scales the maximum Z slope, with respect to X or Y of the polygon.
		/// This allows you to force one polygon to be drawn on top of another although they are actually in the same position.
		/// For example, if ZOffsetFactor = 0 &amp; ZOffsetUnits = -1, it pulls the polygon closer to the camera,
		/// ignoring the polygon’s slope, whereas if ZOffsetFactor = -1 &amp; ZOffsetUnits = -1, it will pull the polygon even closer when looking at a grazing angle.</summary>
		public static int ZOffsetUnits {
			get => style.renderState.zOffsetUnits;
			set => style.renderState.zOffsetUnits = value;
		}
		/// <summary> The stencil buffer function used to compare the reference value to the current contents of the buffer. Default: always </summary>
		public static CompareFunction StencilComp {
			get => style.renderState.stencilComp;
			set => style.renderState.stencilComp = value;
		}
		/// <summary>What to do with the contents of the stencil buffer if the stencil test (and the depth test) passes. Default: keep</summary>
		public static StencilOp StencilOpPass {
			get => style.renderState.stencilOpPass;
			set => style.renderState.stencilOpPass = value;
		}
		/// <summary>The stencil buffer id/reference value to be compared against</summary>
		public static byte StencilRefID {
			get => style.renderState.stencilRefID;
			set => style.renderState.stencilRefID = value;
		}
		/// <summary>A stencil buffer 8 bit mask as an 0–255 integer, used when comparing the reference value with the contents of the buffer. Default: 255</summary>
		public static byte StencilReadMask {
			get => style.renderState.stencilReadMask;
			set => style.renderState.stencilReadMask = value;
		}
		/// <summary>A stencil buffer 8 bit mask as an 0–255 integer, used when writing to the buffer. Note that, like other write masks, it specifies which bits of stencil buffer will be affected by write (i.e. WriteMask 0 means that no bits are affected and not that 0 will be written). Default: 255</summary>
		public static byte StencilWriteMask {
			get => style.renderState.stencilWriteMask;
			set => style.renderState.stencilWriteMask = value;
		}

		// common shared style states
		/// <summary>The color to use when drawing. The alpha channel is used for opacity/intensity in all blend modes</summary>
		public static Color Color {
			get => style.color;
			set => style.color = value;
		}

		/// <summary>The opacity/intensity of the color. This is just a wrapper function for the alpha channel of Color. It's equivalent to getting/setting Color.a</summary>
		public static float Opacity {
			get => Color.a;
			set {
				Color c = Color;
				c.a = value;
				Color = c;
			}
		}

		/// <summary>What blending mode to use</summary>
		public static ShapesBlendMode BlendMode {
			get => style.blendMode;
			set => style.blendMode = value;
		} // technically a render state, but we swap shaders here instead

		/// <summary>Sets how shapes should behave when scaled</summary>
		public static ScaleMode ScaleMode {
			get => style.scaleMode;
			set => style.scaleMode = value;
		}

		/// <summary>What detail level to use for 3D primitives (3D Lines/Sphere/Torus/Cone)</summary>
		public static DetailLevel DetailLevel {
			get => style.detailLevel;
			set => style.detailLevel = value;
		}

		// shared line & polyline states
		/// <summary>Thickness of lines and polylines</summary>
		public static float LineThickness {
			get => style.lineThickness;
			set => style.lineThickness = value;
		}

		/// <summary>Thickness space of lines and polylines</summary>
		public static ThicknessSpace LineThicknessSpace {
			get => style.lineThicknessSpace;
			set => style.lineThicknessSpace = value;
		}

		// line states
		/// <summary>End caps of lines</summary>
		public static LineEndCap LineEndCaps {
			get => style.lineEndCaps;
			set => style.lineEndCaps = value;
		}

		/// <summary>Type of geometry for lines</summary>
		public static LineGeometry LineGeometry {
			get => style.lineGeometry;
			set => style.lineGeometry = value;
		}

		// polygon states
		/// <summary>The triangulation method to use. Some of these are computationally faster than others, but only works for certain shapes</summary>
		public static PolygonTriangulation PolygonTriangulation {
			get => style.polygonTriangulation;
			set => style.polygonTriangulation = value;
		}

		/// <summary>The color fill style to use on polygons</summary>
		public static ShapeFill PolygonShapeFill {
			get => style.polygonShapeFill;
			set => style.polygonShapeFill = value;
		}

		// line dashes
		/// <summary>What dash style to use for lines</summary>
		public static DashStyle LineDashStyle {
			get => style.lineDashStyle;
			set => style.lineDashStyle = value;
		}

		/// <summary>What dash style to use for rings and arcs</summary>
		public static DashStyle RingDashStyle {
			get => style.ringDashStyle;
			set => style.ringDashStyle = value;
		}

		[System.Obsolete( "please use Draw.LineDashStyle.UniformSize or Draw.LineDashStyle.size instead", false )]
		public static float LineDashSize {
			get => LineDashStyle.UniformSize;
			set => LineDashStyle.UniformSize = value;
		}

		// polyline states
		/// <summary>Type of geometry for polylines</summary>
		public static PolylineGeometry PolylineGeometry {
			get => style.polylineGeometry;
			set => style.polylineGeometry = value;
		}

		/// <summary>The joins to use for polylines</summary>
		public static PolylineJoins PolylineJoins {
			get => style.polylineJoins;
			set => style.polylineJoins = value;
		}

		// disc & ring states
		/// <summary>Radius of discs, rings, pies &amp; arcs</summary>
		public static float DiscRadius {
			get => style.discRadius;
			set => style.discRadius = value;
		}

		/// <summary>Whether or not discs, rings, pies &amp; arcs should be billboarded</summary>
		public static DiscGeometry DiscGeometry {
			get => style.discGeometry;
			set => style.discGeometry = value;
		}

		/// <summary>Thickness of rings &amp; arcs</summary>
		public static float RingThickness {
			get => style.ringThickness;
			set => style.ringThickness = value;
		}

		/// <summary>Thickness space of rings &amp; arcs</summary>
		public static ThicknessSpace RingThicknessSpace {
			get => style.ringThicknessSpace;
			set => style.ringThicknessSpace = value;
		}

		/// <summary>Radius space of discs, rings, pies &amp; arcs</summary>
		public static ThicknessSpace DiscRadiusSpace {
			get => style.discRadiusSpace;
			set => style.discRadiusSpace = value;
		}

		// regular polygon states
		/// <summary>Vertex radius of regular polygons</summary>
		public static float RegularPolygonRadius {
			get => style.regularPolygonRadius;
			set => style.regularPolygonRadius = value;
		}

		/// <summary>The number of sides on regular polygons</summary>
		public static int RegularPolygonSideCount {
			get => style.regularPolygonSideCount;
			set => style.regularPolygonSideCount = value;
		}

		/// <summary>Whether or not regular polygons should be billboarded</summary>
		public static RegularPolygonGeometry RegularPolygonGeometry {
			get => style.regularPolygonGeometry;
			set => style.regularPolygonGeometry = value;
		}

		/// <summary>Thickness of hollow regular polygons</summary>
		public static float RegularPolygonThickness {
			get => style.regularPolygonThickness;
			set => style.regularPolygonThickness = value;
		}

		/// <summary>Thickness space of hollow regular polygons</summary>
		public static ThicknessSpace RegularPolygonThicknessSpace {
			get => style.regularPolygonThicknessSpace;
			set => style.regularPolygonThicknessSpace = value;
		}

		/// <summary>Radius space of regular polygons</summary>
		public static ThicknessSpace RegularPolygonRadiusSpace {
			get => style.regularPolygonRadiusSpace;
			set => style.regularPolygonRadiusSpace = value;
		}

		/// <summary>The color fill style to use on regular polygons</summary>
		public static ShapeFill RegularPolygonShapeFill {
			get => style.regularPolygonShapeFill;
			set => style.regularPolygonShapeFill = value;
		}
		
		/// <summary>Thickness of hollow rectangles</summary>
		public static float RectangleThickness {
			get => style.rectangleThickness;
			set => style.rectangleThickness = value;
		}
		
		/// <summary>Thickness space of hollow regular polygons</summary>
		public static ThicknessSpace RectangleThicknessSpace {
			get => style.rectangleThicknessSpace;
			set => style.rectangleThicknessSpace = value;
		}
		
		/// <summary>The color fill style to use on rectangles</summary>
		public static ShapeFill RectangleShapeFill {
			get => style.rectangleShapeFill;
			set => style.rectangleShapeFill = value;
		}
		
		/// <summary>Thickness of hollow triangles</summary>
		public static float TriangleThickness {
			get => style.triangleThickness;
			set => style.triangleThickness = value;
		}
		
		/// <summary>Thickness space of hollow triangles</summary>
		public static ThicknessSpace TriangleThicknessSpace {
			get => style.triangleThicknessSpace;
			set => style.triangleThicknessSpace = value;
		}

		// 3D shape states
		/// <summary>Radius of spheres</summary>
		public static float SphereRadius {
			get => style.sphereRadius;
			set => style.sphereRadius = value;
		}

		/// <summary>Radius space of spheres</summary>
		public static ThicknessSpace SphereRadiusSpace {
			get => style.sphereRadiusSpace;
			set => style.sphereRadiusSpace = value;
		}

		/// <summary>Size space of cuboids</summary>
		public static ThicknessSpace CuboidSizeSpace {
			get => style.cuboidSizeSpace;
			set => style.cuboidSizeSpace = value;
		}

		/// <summary>Thickness space of tori (toruses)</summary>
		public static ThicknessSpace TorusThicknessSpace {
			get => style.torusThicknessSpace;
			set => style.torusThicknessSpace = value;
		}

		/// <summary>Radius space of tori (toruses)</summary>
		public static ThicknessSpace TorusRadiusSpace {
			get => style.torusRadiusSpace;
			set => style.torusRadiusSpace = value;
		}

		/// <summary>Size space of cones</summary>
		public static ThicknessSpace ConeSizeSpace {
			get => style.coneSizeSpace;
			set => style.coneSizeSpace = value;
		}

		// text states
		/// <summary>The TMP font to use when drawing text</summary>
		public static TMP_FontAsset Font {
			get => style.font;
			set => style.font = value;
		}

		/// <summary>The font size to use when drawing text</summary>
		public static float FontSize {
			get => style.fontSize;
			set => style.fontSize = value;
		}

		/// <summary>The text alignment to use when drawing text</summary>
		public static TextAlign TextAlign {
			get => style.textAlign;
			set => style.textAlign = value;
		}


	}

}