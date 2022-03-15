using System;
using UnityEngine;

// Shapes © Freya Holmér - https://twitter.com/FreyaHolmer/
// Website & Documentation - https://acegikmo.com/shapes/
namespace Shapes {

	public class DisposableMesh : IDisposable {

		static int activeMeshCount;
		public static int ActiveMeshCount => activeMeshCount;

		protected Mesh mesh;
		protected bool meshDirty = false;
		bool hasMesh = false; // used to detect if mesh needs to update on the fly on draw

		internal DrawCommand lastCommandUsedIn = null;

		protected void EnsureMeshExists() {
			if( hasMesh == false || mesh == null ) {
				mesh = new Mesh { hideFlags = HideFlags.DontSave };
				activeMeshCount++;
				hasMesh = true;
			}
		}

		public void Dispose() {
			if( hasMesh ) {
				if( lastCommandUsedIn != null && lastCommandUsedIn.hasRendered == false )
					lastCommandUsedIn.cachedAssets.Add( mesh ); // we need to keep the mesh around in the draw command, so, don't destroy it just yet
				else
					mesh.DestroyBranched();

				activeMeshCount--;
				hasMesh = false;
			}
		}

		protected void ClearMesh() {
			if( hasMesh )
				mesh.Clear();
		}

		protected virtual bool ExternallyDirty() => false;
		protected virtual void UpdateMesh() => _ = 0;

		protected bool EnsureMeshIsReadyToRender( out Mesh outMesh, Action updateMesh ) {
			if( hasMesh == false ) {
				// no mesh exists because no points were added
				outMesh = null;
				return false;
			}

			updateMesh();
			outMesh = mesh;
			return hasMesh;
		}

	}

}