using System;
using UnityEngine;
using TMPro;
#if SHAPES_URP
using UnityEngine.Rendering.Universal;

#elif SHAPES_HDRP
using UnityEngine.Rendering.HighDefinition;
#else
using UnityEngine.Rendering;

#endif

// Shapes © Freya Holmér - https://twitter.com/FreyaHolmer/
// Website & Documentation - https://acegikmo.com/shapes/
namespace Shapes {

	/// <summary>The primary class in Shapes for all functionality to draw in immediate mode</summary>
	public static partial class Draw {


		/// <summary><para>Creates a DrawCommand for drawing in immediate mode.</para>
		/// <para>Example usage:</para>
		/// <para>using(Draw.Command(Camera.main)){ Draw.Line( a, b, Color.red ); }</para></summary>
		/// <param name="cam">The camera to draw in</param>
		/// <param name="cameraEvent">When during the render this command should execute</param>
		#if SHAPES_URP
		public static DrawCommand Command( Camera cam, RenderPassEvent cameraEvent = RenderPassEvent.BeforeRenderingPostProcessing ) => ObjectPool<DrawCommand>.Alloc().Initialize( cam, cameraEvent );
		#elif SHAPES_HDRP
		public static DrawCommand Command( Camera cam, CustomPassInjectionPoint cameraEvent = CustomPassInjectionPoint.BeforePostProcess ) => ObjectPool<DrawCommand>.Alloc().Initialize( cam, cameraEvent );
		#else
		public static DrawCommand Command( Camera cam, CameraEvent cameraEvent = CameraEvent.BeforeImageEffects ) => ObjectPool<DrawCommand>.Alloc().Initialize( cam, cameraEvent );
		#endif

		static MpbLine mpbLine = new MpbLine();

		[OvldGenCallTarget] static void Line_Internal( [OvldDefault( nameof(LineEndCaps) )] LineEndCap endCaps,
													   [OvldDefault( nameof(LineThicknessSpace) )] ThicknessSpace thicknessSpace,
													   Vector3 start,
													   Vector3 end,
													   [OvldDefault( nameof(Color) )] Color colorStart,
													   [OvldDefault( nameof(Color) )] Color colorEnd,
													   [OvldDefault( nameof(LineThickness) )] float thickness,
													   [OvldDefault( nameof(LineDashStyle) )] DashStyle dashStyle = null ) {
			using( new IMDrawer(
				metaMpb: mpbLine,
				sourceMat: ShapesMaterialUtils.GetLineMat( Draw.LineGeometry, endCaps )[Draw.BlendMode],
				sourceMesh: ShapesMeshUtils.GetLineMesh( Draw.LineGeometry, endCaps, DetailLevel ) ) ) {
				MetaMpb.ApplyDashSettings( mpbLine, dashStyle, thickness );
				mpbLine.color.Add( colorStart.ColorSpaceAdjusted() );
				mpbLine.colorEnd.Add( colorEnd.ColorSpaceAdjusted() );
				mpbLine.pointStart.Add( start );
				mpbLine.pointEnd.Add( end );
				mpbLine.thickness.Add( thickness );
				mpbLine.alignment.Add( (float)Draw.LineGeometry );
				mpbLine.thicknessSpace.Add( (float)thicknessSpace );
				mpbLine.scaleMode.Add( (float)ScaleMode );
			}
		}

		static MpbPolyline mpbPolyline = new MpbPolyline(); // they can use the same mpb structure
		static MpbPolyline mpbPolylineJoins = new MpbPolyline();

		[OvldGenCallTarget] static void Polyline_Internal( PolylinePath path,
														   [OvldDefault( "false" )] bool closed,
														   [OvldDefault( nameof(PolylineGeometry) )] PolylineGeometry geometry,
														   [OvldDefault( nameof(PolylineJoins) )] PolylineJoins joins,
														   [OvldDefault( nameof(LineThickness) )] float thickness,
														   [OvldDefault( nameof(LineThicknessSpace) )] ThicknessSpace thicknessSpace,
														   [OvldDefault( nameof(Color) )] Color color ) {
			if( path.EnsureMeshIsReadyToRender( closed, joins, out Mesh mesh ) == false )
				return; // no points defined in the mesh

			switch( path.Count ) {
				case 0:
					Debug.LogWarning( "Tried to draw polyline with no points" );
					return;
				case 1:
					Debug.LogWarning( "Tried to draw polyline with only one point" );
					return;
			}

			void ApplyToMpb( MpbPolyline mpb ) {
				mpb.thickness.Add( thickness );
				mpb.thicknessSpace.Add( (int)thicknessSpace );
				mpb.color.Add( color.ColorSpaceAdjusted() );
				mpb.alignment.Add( (int)geometry );
				mpb.scaleMode.Add( (int)ScaleMode );
			}

			if( DrawCommand.IsAddingDrawCommandsToBuffer ) // mark as used by this command to prevent destroy in dispose
				path.lastCommandUsedIn = DrawCommand.CurrentWritingCommandBuffer;

			using( new IMDrawer( mpbPolyline, ShapesMaterialUtils.GetPolylineMat( joins )[Draw.BlendMode], mesh, 0 ) )
				ApplyToMpb( mpbPolyline );

			if( joins.HasJoinMesh() ) {
				using( new IMDrawer( mpbPolylineJoins, ShapesMaterialUtils.GetPolylineJoinsMat( joins )[Draw.BlendMode], mesh, 1 ) )
					ApplyToMpb( mpbPolylineJoins );
			}
		}

		static MpbPolygon mpbPolygon = new MpbPolygon();

		[OvldGenCallTarget] static void Polygon_Internal( PolygonPath path,
														  [OvldDefault( nameof(PolygonTriangulation) )] PolygonTriangulation triangulation,
														  [OvldDefault( nameof(Color) )] Color color,
														  [OvldDefault( nameof(PolygonShapeFill) )] ShapeFill fill ) {
			if( path.EnsureMeshIsReadyToRender( triangulation, out Mesh mesh ) == false )
				return; // no points defined in the mesh

			switch( path.Count ) {
				case 0:
					Debug.LogWarning( "Tried to draw polygon with no points" );
					return;
				case 1:
					Debug.LogWarning( "Tried to draw polygon with only one point" );
					return;
				case 2:
					Debug.LogWarning( "Tried to draw polygon with only two points" );
					return;
			}

			if( DrawCommand.IsAddingDrawCommandsToBuffer ) // mark as used by this command to prevent destroy in dispose
				path.lastCommandUsedIn = DrawCommand.CurrentWritingCommandBuffer;

			using( new IMDrawer( mpbPolygon, ShapesMaterialUtils.matPolygon[Draw.BlendMode], mesh ) ) {
				MetaMpb.ApplyColorOrFill( mpbPolygon, fill, color );
			}
		}

		[OvldGenCallTarget] static void Disc_Internal( [OvldDefault( nameof(DiscRadius) )] float radius,
													   [OvldDefault( nameof(Color) )] Color colorInnerStart,
													   [OvldDefault( nameof(Color) )] Color colorOuterStart,
													   [OvldDefault( nameof(Color) )] Color colorInnerEnd,
													   [OvldDefault( nameof(Color) )] Color colorOuterEnd ) {
			DiscCore( false, false, radius, 0f, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd );
		}

		[OvldGenCallTarget] static void Ring_Internal( [OvldDefault( nameof(DiscRadius) )] float radius,
													   [OvldDefault( nameof(RingThickness) )] float thickness,
													   [OvldDefault( nameof(Color) )] Color colorInnerStart,
													   [OvldDefault( nameof(Color) )] Color colorOuterStart,
													   [OvldDefault( nameof(Color) )] Color colorInnerEnd,
													   [OvldDefault( nameof(Color) )] Color colorOuterEnd,
													   [OvldDefault( nameof(RingDashStyle) )] DashStyle dashStyle = null ) {
			DiscCore( true, false, radius, thickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, dashStyle );
		}

		[OvldGenCallTarget] static void Pie_Internal( [OvldDefault( nameof(DiscRadius) )] float radius,
													  [OvldDefault( nameof(Color) )] Color colorInnerStart,
													  [OvldDefault( nameof(Color) )] Color colorOuterStart,
													  [OvldDefault( nameof(Color) )] Color colorInnerEnd,
													  [OvldDefault( nameof(Color) )] Color colorOuterEnd,
													  float angleRadStart,
													  float angleRadEnd ) {
			DiscCore( false, true, radius, 0f, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, null, angleRadStart, angleRadEnd );
		}

		[OvldGenCallTarget] static void Arc_Internal( [OvldDefault( nameof(DiscRadius) )] float radius,
													  [OvldDefault( nameof(RingThickness) )] float thickness,
													  [OvldDefault( nameof(Color) )] Color colorInnerStart,
													  [OvldDefault( nameof(Color) )] Color colorOuterStart,
													  [OvldDefault( nameof(Color) )] Color colorInnerEnd,
													  [OvldDefault( nameof(Color) )] Color colorOuterEnd,
													  float angleRadStart,
													  float angleRadEnd,
													  [OvldDefault( nameof(ArcEndCap) + "." + nameof(ArcEndCap.None) )] ArcEndCap endCaps,
													  [OvldDefault( nameof(RingDashStyle) )] DashStyle dashStyle = null ) {
			DiscCore( true, true, radius, thickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, dashStyle, angleRadStart, angleRadEnd, endCaps );
		}

		static readonly MpbDisc mpbDisc = new MpbDisc();

		static void DiscCore( bool hollow, bool sector, float radius, float thickness, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd, DashStyle dashStyle = null, float angleRadStart = 0f, float angleRadEnd = 0f, ArcEndCap arcEndCaps = ArcEndCap.None ) {
			if( sector && Mathf.Abs( angleRadEnd - angleRadStart ) < 0.0001f )
				return;

			using( new IMDrawer( mpbDisc, ShapesMaterialUtils.GetDiscMaterial( hollow, sector )[Draw.BlendMode], ShapesMeshUtils.QuadMesh[0] ) ) {
				MetaMpb.ApplyDashSettings( mpbDisc, dashStyle, thickness );
				mpbDisc.radius.Add( radius );
				mpbDisc.radiusSpace.Add( (int)Draw.DiscRadiusSpace );
				mpbDisc.alignment.Add( (int)Draw.DiscGeometry );
				mpbDisc.thicknessSpace.Add( (int)Draw.RingThicknessSpace );
				mpbDisc.thickness.Add( thickness );
				mpbDisc.scaleMode.Add( (int)ScaleMode );
				mpbDisc.angStart.Add( angleRadStart );
				mpbDisc.angEnd.Add( angleRadEnd );
				mpbDisc.roundCaps.Add( (int)arcEndCaps );
				mpbDisc.color.Add( colorInnerStart.ColorSpaceAdjusted() );
				mpbDisc.colorOuterStart.Add( colorOuterStart.ColorSpaceAdjusted() );
				mpbDisc.colorInnerEnd.Add( colorInnerEnd.ColorSpaceAdjusted() );
				mpbDisc.colorOuterEnd.Add( colorOuterEnd.ColorSpaceAdjusted() );
			}
		}

		static readonly MpbRegularPolygon mpbRegularPolygon = new MpbRegularPolygon();

		[OvldGenCallTarget] static void RegularPolygon_Internal( [OvldDefault( nameof(RegularPolygonSideCount) )] int sideCount,
																 [OvldDefault( nameof(RegularPolygonRadius) )] float radius,
																 [OvldDefault( nameof(RegularPolygonThickness) )] float thickness,
																 [OvldDefault( nameof(Color) )] Color color,
																 bool hollow,
																 [OvldDefault( "0f" )] float roundness,
																 [OvldDefault( "0f" )] float angle,
																 [OvldDefault( nameof(PolygonShapeFill) )] ShapeFill fill ) {
			using( new IMDrawer( mpbRegularPolygon, ShapesMaterialUtils.matRegularPolygon[Draw.BlendMode], ShapesMeshUtils.QuadMesh[0] ) ) {
				MetaMpb.ApplyColorOrFill( mpbRegularPolygon, fill, color );
				mpbRegularPolygon.radius.Add( radius );
				mpbRegularPolygon.radiusSpace.Add( (int)Draw.RegularPolygonRadiusSpace );
				mpbRegularPolygon.geometry.Add( (int)Draw.RegularPolygonGeometry );
				mpbRegularPolygon.sides.Add( Mathf.Max( 3, sideCount ) );
				mpbRegularPolygon.angle.Add( angle );
				mpbRegularPolygon.roundness.Add( roundness );
				mpbRegularPolygon.hollow.Add( hollow.AsInt() );
				mpbRegularPolygon.thicknessSpace.Add( (int)Draw.RegularPolygonThicknessSpace );
				mpbRegularPolygon.thickness.Add( thickness );
				mpbRegularPolygon.scaleMode.Add( (int)ScaleMode );
			}
		}

		static readonly MpbRectangle mpbRectangle = new MpbRectangle();

		[OvldGenCallTarget] static void Rectangle_Internal( [OvldDefault( nameof(BlendMode) )] ShapesBlendMode blendMode,
															[OvldDefault( "false" )] bool hollow,
															Rect rect,
															[OvldDefault( nameof(Color) )] Color color,
															[OvldDefault( nameof(RectangleThickness) )] float thickness,
															[OvldDefault( "default" )] Vector4 cornerRadii,
															[OvldDefault( nameof(PolygonShapeFill) )] ShapeFill fill ) {
			bool rounded = ShapesMath.MaxComp( cornerRadii ) >= 0.0001f;

			// positive vibes only
			if( rect.width < 0 ) rect.x -= rect.width *= -1;
			if( rect.height < 0 ) rect.y -= rect.height *= -1;

			if( hollow && thickness * 2 >= Mathf.Min( rect.width, rect.height ) ) hollow = false;

			using( new IMDrawer( mpbRectangle, ShapesMaterialUtils.GetRectMaterial( hollow, rounded )[blendMode], ShapesMeshUtils.QuadMesh[0] ) ) {
				MetaMpb.ApplyColorOrFill( mpbRectangle, fill, color );
				mpbRectangle.rect.Add( rect.ToVector4() );
				mpbRectangle.cornerRadii.Add( cornerRadii );
				mpbRectangle.thickness.Add( thickness );
				mpbRectangle.thicknessSpace.Add( (int)Draw.RegularPolygonThicknessSpace );
				mpbRectangle.scaleMode.Add( (int)ScaleMode );
			}
		}

		static MpbTriangle mpbTriangle = new MpbTriangle();

		[OvldGenCallTarget] static void Triangle_Internal( Vector3 a,
														   Vector3 b,
														   Vector3 c,
														   bool hollow,
														   [OvldDefault( nameof(TriangleThickness) )] float thickness,
														   [OvldDefault( "0f" )] float roundness,
														   [OvldDefault( nameof(Color) )] Color colorA,
														   [OvldDefault( nameof(Color) )] Color colorB,
														   [OvldDefault( nameof(Color) )] Color colorC ) {
			using( new IMDrawer( mpbTriangle, ShapesMaterialUtils.matTriangle[Draw.BlendMode], ShapesMeshUtils.TriangleMesh[0] ) ) {
				mpbTriangle.a.Add( a );
				mpbTriangle.b.Add( b );
				mpbTriangle.c.Add( c );
				mpbTriangle.color.Add( colorA.ColorSpaceAdjusted() );
				mpbTriangle.colorB.Add( colorB.ColorSpaceAdjusted() );
				mpbTriangle.colorC.Add( colorC.ColorSpaceAdjusted() );
				mpbTriangle.roundness.Add( roundness );
				mpbTriangle.hollow.Add( hollow.AsInt() );
				mpbTriangle.thicknessSpace.Add( (int)Draw.RegularPolygonThicknessSpace );
				mpbTriangle.thickness.Add( thickness );
				mpbTriangle.scaleMode.Add( (int)ScaleMode );
			}
		}

		static MpbQuad mpbQuad = new MpbQuad();

		[OvldGenCallTarget] static void Quad_Internal( Vector3 a,
													   Vector3 b,
													   Vector3 c,
													   [OvldDefault( "a + ( c - b )" )] Vector3 d,
													   [OvldDefault( nameof(Color) )] Color colorA,
													   [OvldDefault( nameof(Color) )] Color colorB,
													   [OvldDefault( nameof(Color) )] Color colorC,
													   [OvldDefault( nameof(Color) )] Color colorD ) {
			using( new IMDrawer( mpbQuad, ShapesMaterialUtils.matQuad[Draw.BlendMode], ShapesMeshUtils.QuadMesh[0] ) ) {
				mpbQuad.a.Add( a );
				mpbQuad.b.Add( b );
				mpbQuad.c.Add( c );
				mpbQuad.d.Add( d );
				mpbQuad.color.Add( colorA.ColorSpaceAdjusted() );
				mpbQuad.colorB.Add( colorB.ColorSpaceAdjusted() );
				mpbQuad.colorC.Add( colorC.ColorSpaceAdjusted() );
				mpbQuad.colorD.Add( colorD.ColorSpaceAdjusted() );
			}
		}


		static readonly MpbSphere metaMpbSphere = new MpbSphere();

		[OvldGenCallTarget] static void Sphere_Internal( [OvldDefault( nameof(SphereRadius) )] float radius,
														 [OvldDefault( nameof(Color) )] Color color ) {
			using( new IMDrawer( metaMpbSphere, ShapesMaterialUtils.matSphere[Draw.BlendMode], ShapesMeshUtils.SphereMesh[(int)DetailLevel] ) ) {
				metaMpbSphere.color.Add( color.ColorSpaceAdjusted() );
				metaMpbSphere.radius.Add( radius );
				metaMpbSphere.radiusSpace.Add( (float)Draw.SphereRadiusSpace );
			}
		}

		static readonly MpbCone mpbCone = new MpbCone();

		[OvldGenCallTarget] static void Cone_Internal( float radius,
													   float length,
													   [OvldDefault( "true" )] bool fillCap,
													   [OvldDefault( nameof(Color) )] Color color ) {
			Mesh mesh = fillCap ? ShapesMeshUtils.ConeMesh[(int)DetailLevel] : ShapesMeshUtils.ConeMeshUncapped[(int)DetailLevel];
			using( new IMDrawer( mpbCone, ShapesMaterialUtils.matCone[Draw.BlendMode], mesh ) ) {
				mpbCone.color.Add( color.ColorSpaceAdjusted() );
				mpbCone.radius.Add( radius );
				mpbCone.length.Add( length );
				mpbCone.sizeSpace.Add( (float)Draw.ConeSizeSpace );
			}
		}

		static readonly MpbCuboid mpbCuboid = new MpbCuboid();

		[OvldGenCallTarget] static void Cuboid_Internal( Vector3 size,
														 [OvldDefault( nameof(Color) )] Color color ) {
			using( new IMDrawer( mpbCuboid, ShapesMaterialUtils.matCuboid[Draw.BlendMode], ShapesMeshUtils.CuboidMesh[0] ) ) {
				mpbCuboid.color.Add( color.ColorSpaceAdjusted() );
				mpbCuboid.size.Add( size );
				mpbCuboid.sizeSpace.Add( (float)Draw.CuboidSizeSpace );
			}
		}

		static MpbTorus mpbTorus = new MpbTorus();

		[OvldGenCallTarget] static void Torus_Internal( float radius,
														float thickness,
														[OvldDefault( nameof(Color) )] Color color ) {
			if( thickness < 0.0001f )
				return;
			if( radius < 0.00001f ) {
				ThicknessSpace cached = Draw.SphereRadiusSpace;
				Draw.SphereRadiusSpace = Draw.TorusThicknessSpace;
				Sphere( thickness / 2, color );
				Draw.SphereRadiusSpace = cached;
				return;
			}

			using( new IMDrawer( mpbTorus, ShapesMaterialUtils.matTorus[Draw.BlendMode], ShapesMeshUtils.TorusMesh[(int)DetailLevel] ) ) {
				mpbTorus.color.Add( color.ColorSpaceAdjusted() );
				mpbTorus.radius.Add( radius );
				mpbTorus.thickness.Add( thickness );
				mpbTorus.spaceRadius.Add( (int)Draw.TorusRadiusSpace );
				mpbTorus.spaceThickness.Add( (int)Draw.TorusThicknessSpace );
				mpbTorus.scaleMode.Add( (int)Draw.ScaleMode );
			}
		}

		static MpbText mpbText = new MpbText();

		[OvldGenCallTarget] static void Text_Internal( string content,
													   [OvldDefault( nameof(Font) )] TMP_FontAsset font,
													   [OvldDefault( nameof(FontSize) )] float fontSize,
													   [OvldDefault( nameof(TextAlign) )] TextAlign align,
													   [OvldDefault( nameof(Color) )] Color color ) {
			TextMeshPro tmp = ShapesTextDrawer.Instance.tmp;
			// Statics
			tmp.font = font;
			tmp.color = color;
			tmp.fontSize = fontSize;

			// Per-instance
			tmp.text = content;
			tmp.alignment = align.GetTMPAlignment();
			tmp.rectTransform.pivot = align.GetPivot();
			tmp.transform.position = Matrix.GetColumn( 3 );
			tmp.rectTransform.rotation = Matrix.rotation;
			tmp.ForceMeshUpdate();

			using( new IMDrawer( mpbText, font.material, tmp.mesh, cachedTMP: true ) ) {
				// will draw on dispose
			}
		}


	}

	// these are used by CodegenDrawOverloads
	[AttributeUsage( AttributeTargets.Method )]
	internal class OvldGenCallTarget : Attribute {
	}

	[AttributeUsage( AttributeTargets.Parameter )]
	internal class OvldDefault : Attribute {
		public string @default;
		public OvldDefault( string @default ) => this.@default = @default;
	}

}