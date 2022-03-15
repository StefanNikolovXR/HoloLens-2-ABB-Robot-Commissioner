using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Shapes © Freya Holmér - https://twitter.com/FreyaHolmer/
// Website & Documentation - https://acegikmo.com/shapes/
namespace Shapes {

	class MpbSphere : MetaMpb {
		internal List<float> radius = InitList<float>();
		internal List<float> radiusSpace = InitList<float>();

		protected override void TransferShapeProperties() {
			Transfer( ShapesMaterialUtils.propRadius, radius );
			Transfer( ShapesMaterialUtils.propRadiusSpace, radiusSpace );
		}
	}

	class MpbCone : MetaMpb {
		internal List<float> radius = InitList<float>();
		internal List<float> length = InitList<float>();
		internal List<float> sizeSpace = InitList<float>();

		protected override void TransferShapeProperties() {
			Transfer( ShapesMaterialUtils.propRadius, radius );
			Transfer( ShapesMaterialUtils.propLength, length );
			Transfer( ShapesMaterialUtils.propSizeSpace, sizeSpace );
		}

	}

	class MpbCuboid : MetaMpb {
		internal List<Vector4> size = InitList<Vector4>();
		internal List<float> sizeSpace = InitList<float>();

		protected override void TransferShapeProperties() {
			Transfer( ShapesMaterialUtils.propSize, size );
			Transfer( ShapesMaterialUtils.propSizeSpace, sizeSpace );
		}
	}

	class MpbTorus : MetaMpb {
		internal List<float> radius = InitList<float>();
		internal List<float> thickness = InitList<float>();
		internal List<float> spaceRadius = InitList<float>();
		internal List<float> spaceThickness = InitList<float>();
		internal List<float> scaleMode = InitList<float>();

		protected override void TransferShapeProperties() {
			Transfer( ShapesMaterialUtils.propRadius, radius );
			Transfer( ShapesMaterialUtils.propThickness, thickness );
			Transfer( ShapesMaterialUtils.propRadiusSpace, spaceRadius );
			Transfer( ShapesMaterialUtils.propThicknessSpace, spaceThickness );
			Transfer( ShapesMaterialUtils.propScaleMode, scaleMode );
		}
	}

	class MpbQuad : MetaMpb {
		internal List<Vector4> a = InitList<Vector4>();
		internal List<Vector4> b = InitList<Vector4>();
		internal List<Vector4> c = InitList<Vector4>();
		internal List<Vector4> d = InitList<Vector4>();

		// color A is in the base type as color
		internal List<Vector4> colorB = InitList<Vector4>();
		internal List<Vector4> colorC = InitList<Vector4>();
		internal List<Vector4> colorD = InitList<Vector4>();

		protected override void TransferShapeProperties() {
			Transfer( ShapesMaterialUtils.propA, a );
			Transfer( ShapesMaterialUtils.propB, b );
			Transfer( ShapesMaterialUtils.propC, c );
			Transfer( ShapesMaterialUtils.propD, d );

			// color A is in the base type as color
			Transfer( ShapesMaterialUtils.propColorB, colorB );
			Transfer( ShapesMaterialUtils.propColorC, colorC );
			Transfer( ShapesMaterialUtils.propColorD, colorD );
		}
	}

	class MpbTriangle : MetaMpb {
		internal List<Vector4> a = InitList<Vector4>();
		internal List<Vector4> b = InitList<Vector4>();
		internal List<Vector4> c = InitList<Vector4>();

		// color A is in the base type as color
		internal List<Vector4> colorB = InitList<Vector4>();
		internal List<Vector4> colorC = InitList<Vector4>();
		
		internal List<float> roundness = InitList<float>();
		internal List<float> hollow = InitList<float>();
		internal List<float> thicknessSpace = InitList<float>();
		internal List<float> thickness = InitList<float>();
		internal List<float> scaleMode = InitList<float>();

		protected override void TransferShapeProperties() {
			Transfer( ShapesMaterialUtils.propA, a );
			Transfer( ShapesMaterialUtils.propB, b );
			Transfer( ShapesMaterialUtils.propC, c );

			// color A is in the base type as color
			Transfer( ShapesMaterialUtils.propColorB, colorB );
			Transfer( ShapesMaterialUtils.propColorC, colorC );
			
			Transfer( ShapesMaterialUtils.propRoundness, roundness );
			Transfer( ShapesMaterialUtils.propHollow, hollow );
			Transfer( ShapesMaterialUtils.propThicknessSpace, thicknessSpace );
			Transfer( ShapesMaterialUtils.propThickness, thickness );
			Transfer( ShapesMaterialUtils.propScaleMode, scaleMode );
		}
	}

	class MpbRectangle : MetaMpb, IFillable {

		internal List<Vector4> rect = InitList<Vector4>();
		internal List<Vector4> cornerRadii = InitList<Vector4>();
		internal List<float> thickness = InitList<float>();
		internal List<float> thicknessSpace = InitList<float>();
		internal List<float> scaleMode = InitList<float>();

		// fill boilerplate
		List<float> IFillable.fillType { get; } = InitList<float>();
		List<float> IFillable.fillSpace { get; } = InitList<float>();
		List<Vector4> IFillable.fillStart { get; } = InitList<Vector4>();
		List<Vector4> IFillable.fillEnd { get; } = InitList<Vector4>();
		List<Vector4> IFillable.fillColorEnd { get; } = InitList<Vector4>();

		protected override void TransferShapeProperties() {
			Transfer( ShapesMaterialUtils.propRect, rect );
			Transfer( ShapesMaterialUtils.propCornerRadii, cornerRadii );
			Transfer( ShapesMaterialUtils.propThickness, thickness );
			Transfer( ShapesMaterialUtils.propThicknessSpace, thicknessSpace );
			Transfer( ShapesMaterialUtils.propScaleMode, scaleMode );
		}
	}

	class MpbDisc : MetaMpb, IDashable {

		internal List<float> radius = InitList<float>();
		internal List<float> radiusSpace = InitList<float>();
		internal List<float> alignment = InitList<float>();
		internal List<float> thicknessSpace = InitList<float>();
		internal List<float> thickness = InitList<float>();
		internal List<float> scaleMode = InitList<float>();
		internal List<float> angStart = InitList<float>();
		internal List<float> angEnd = InitList<float>();
		internal List<float> roundCaps = InitList<float>();
		internal List<Vector4> colorOuterStart = InitList<Vector4>();
		internal List<Vector4> colorInnerEnd = InitList<Vector4>();
		internal List<Vector4> colorOuterEnd = InitList<Vector4>();

		// dash boilerplate
		List<float> IDashable.dashSize { get; } = InitList<float>();
		List<float> IDashable.dashType { get; } = InitList<float>();
		List<float> IDashable.dashShapeModifier { get; } = InitList<float>();
		List<float> IDashable.dashSpace { get; } = InitList<float>();
		List<float> IDashable.dashSnap { get; } = InitList<float>();
		List<float> IDashable.dashOffset { get; } = InitList<float>();
		List<float> IDashable.dashSpacing { get; } = InitList<float>();

		protected override void TransferShapeProperties() {
			Transfer( ShapesMaterialUtils.propRadius, radius );
			Transfer( ShapesMaterialUtils.propRadiusSpace, radiusSpace );
			Transfer( ShapesMaterialUtils.propAlignment, alignment );
			Transfer( ShapesMaterialUtils.propThicknessSpace, thicknessSpace );
			Transfer( ShapesMaterialUtils.propThickness, thickness );
			Transfer( ShapesMaterialUtils.propScaleMode, scaleMode );
			Transfer( ShapesMaterialUtils.propAngStart, angStart );
			Transfer( ShapesMaterialUtils.propAngEnd, angEnd );
			Transfer( ShapesMaterialUtils.propRoundCaps, roundCaps );
			Transfer( ShapesMaterialUtils.propColorOuterStart, colorOuterStart );
			Transfer( ShapesMaterialUtils.propColorInnerEnd, colorInnerEnd );
			Transfer( ShapesMaterialUtils.propColorOuterEnd, colorOuterEnd );
		}


	}

	class MpbLine : MetaMpb, IDashable {

		internal List<Vector4> colorEnd = InitList<Vector4>();
		internal List<Vector4> pointStart = InitList<Vector4>();
		internal List<Vector4> pointEnd = InitList<Vector4>();
		internal List<float> thickness = InitList<float>();
		internal List<float> alignment = InitList<float>();
		internal List<float> thicknessSpace = InitList<float>();
		internal List<float> scaleMode = InitList<float>();

		// dash boilerplate
		List<float> IDashable.dashSize { get; } = InitList<float>();
		List<float> IDashable.dashType { get; } = InitList<float>();
		List<float> IDashable.dashShapeModifier { get; } = InitList<float>();
		List<float> IDashable.dashSpace { get; } = InitList<float>();
		List<float> IDashable.dashSnap { get; } = InitList<float>();
		List<float> IDashable.dashOffset { get; } = InitList<float>();
		List<float> IDashable.dashSpacing { get; } = InitList<float>();

		protected override void TransferShapeProperties() {
			Transfer( ShapesMaterialUtils.propColorEnd, colorEnd );
			Transfer( ShapesMaterialUtils.propPointStart, pointStart );
			Transfer( ShapesMaterialUtils.propPointEnd, pointEnd );
			Transfer( ShapesMaterialUtils.propThickness, thickness );
			Transfer( ShapesMaterialUtils.propAlignment, alignment );
			Transfer( ShapesMaterialUtils.propThicknessSpace, thicknessSpace );
			Transfer( ShapesMaterialUtils.propScaleMode, scaleMode );
		}


	}

	class MpbPolyline : MetaMpb {

		internal List<float> thickness = InitList<float>();
		internal List<float> thicknessSpace = InitList<float>();
		internal List<float> alignment = InitList<float>();
		internal List<float> scaleMode = InitList<float>();

		protected override void TransferShapeProperties() {
			Transfer( ShapesMaterialUtils.propThickness, thickness );
			Transfer( ShapesMaterialUtils.propThicknessSpace, thicknessSpace );
			Transfer( ShapesMaterialUtils.propAlignment, alignment );
			Transfer( ShapesMaterialUtils.propScaleMode, scaleMode );
		}

	}

	class MpbPolygon : MetaMpb, IFillable {

		// fill boilerplate
		List<float> IFillable.fillType { get; } = InitList<float>();
		List<float> IFillable.fillSpace { get; } = InitList<float>();
		List<Vector4> IFillable.fillStart { get; } = InitList<Vector4>();
		List<Vector4> IFillable.fillEnd { get; } = InitList<Vector4>();
		List<Vector4> IFillable.fillColorEnd { get; } = InitList<Vector4>();

		protected override void TransferShapeProperties() => _ = 0; // :>

	}

	class MpbRegularPolygon : MetaMpb, IFillable {

		internal List<float> radius = InitList<float>();
		internal List<float> radiusSpace = InitList<float>();
		internal List<float> geometry = InitList<float>();
		internal List<float> sides = InitList<float>();
		internal List<float> angle = InitList<float>();
		internal List<float> roundness = InitList<float>();
		internal List<float> hollow = InitList<float>();
		internal List<float> thicknessSpace = InitList<float>();
		internal List<float> thickness = InitList<float>();
		internal List<float> scaleMode = InitList<float>();

		// fill boilerplate
		List<float> IFillable.fillType { get; } = InitList<float>();
		List<float> IFillable.fillSpace { get; } = InitList<float>();
		List<Vector4> IFillable.fillStart { get; } = InitList<Vector4>();
		List<Vector4> IFillable.fillEnd { get; } = InitList<Vector4>();
		List<Vector4> IFillable.fillColorEnd { get; } = InitList<Vector4>();

		protected override void TransferShapeProperties() {
			Transfer( ShapesMaterialUtils.propRadius, radius );
			Transfer( ShapesMaterialUtils.propRadiusSpace, radiusSpace );
			Transfer( ShapesMaterialUtils.propAlignment, geometry );
			Transfer( ShapesMaterialUtils.propSides, sides );
			Transfer( ShapesMaterialUtils.propAng, angle );
			Transfer( ShapesMaterialUtils.propRoundness, roundness );
			Transfer( ShapesMaterialUtils.propHollow, hollow );
			Transfer( ShapesMaterialUtils.propThicknessSpace, thicknessSpace );
			Transfer( ShapesMaterialUtils.propThickness, thickness );
			Transfer( ShapesMaterialUtils.propScaleMode, scaleMode );
		}

	}

	class MpbText : MetaMpb {
		protected override void TransferShapeProperties() => _ = 0; // :>
	}

	interface IFillable {
		List<float> fillType { get; }
		List<float> fillSpace { get; }
		List<Vector4> fillStart { get; }
		List<Vector4> fillEnd { get; }
		List<Vector4> fillColorEnd { get; }
	}

	interface IDashable {
		List<float> dashSize { get; }
		List<float> dashType { get; }
		List<float> dashShapeModifier { get; }
		List<float> dashSpace { get; }
		List<float> dashSnap { get; }
		List<float> dashOffset { get; }
		List<float> dashSpacing { get; }
	}

}