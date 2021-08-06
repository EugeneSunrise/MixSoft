using Microsoft.DirectX;
using MixSoft.Classes;
using MixSoft.Data.Raw;
using MixSoft.Gfx.Math;
using System;
using System.Runtime.InteropServices;

namespace MixSoft.Data.Internal
{
    public class Entity :
        EntityBase
    {
        #region Properties

         
        // Index in entity list.
        public int Index { get; }

         
        // Dormant state.
        public bool Dormant { get; private set; } = true;

         
        // Pointer to studio hrd.
        private IntPtr AddressStudioHdr { get; set; }

        public studiohdr_t StudioHdr { get; private set; }

        public mstudiohitboxset_t StudioHitBoxSet { get; private set; }

        public mstudiobbox_t[] StudioHitBoxes { get; }

        public mstudiobone_t[] StudioBones { get; }

         
        // Bone model to world matrices.
        public Matrix[] BonesMatrices { get; }

         
        // Bone positions in world.
        public Vector3[] BonesPos { get; }

         
        // Skeleton bones.
        public (int from, int to)[] Skeleton { get; }

        #endregion

        #region Updates
        public Entity(int index)
        {
            Index = index;
            StudioHitBoxes = new mstudiobbox_t[Offsets.Offsets.MAXSTUDIOBONES];
            StudioBones = new mstudiobone_t[Offsets.Offsets.MAXSTUDIOBONES];
            BonesMatrices = new Matrix[Offsets.Offsets.MAXSTUDIOBONES];
            BonesPos = new Vector3[Offsets.Offsets.MAXSTUDIOBONES];
            Skeleton = new (int, int)[Offsets.Offsets.MAXSTUDIOBONES];
        }


        public override bool IsAlive()
        {
            return base.IsAlive() && !Dormant;
        }

        // Entity List
        protected override IntPtr ReadAddressBase(GameProcess gameProcess)
        {
            return gameProcess.ModuleClient.Read<IntPtr>(Offsets.Offsets.dwEntityList + Index * 0x10 /* size */);
        }

        public override bool Update(GameProcess gameProcess)
        {
            if (!base.Update(gameProcess))
            {
                return false;
            }

            Dormant = gameProcess.Process.Read<bool>(AddressBase + Offsets.Offsets.m_bDormant);

            if (!IsAlive())
            {
                return true;
            }
            UpdateStudioHdr(gameProcess);
            UpdateStudioHitBoxes(gameProcess);
            UpdateStudioBones(gameProcess);
            UpdateBonesMatricesAndPos(gameProcess);

            return true;
        }

         
        private void UpdateStudioHdr(GameProcess gameProcess)
        {
            var addressToAddressStudioHdr = gameProcess.Process.Read<IntPtr>(AddressBase + Offsets.Offsets.m_pStudioHdr);
            AddressStudioHdr = gameProcess.Process.Read<IntPtr>(addressToAddressStudioHdr); // deref
            StudioHdr = gameProcess.Process.Read<studiohdr_t>(AddressStudioHdr);
        }

        private void UpdateStudioHitBoxes(GameProcess gameProcess)
        {
            var addressHitBoxSet = AddressStudioHdr + StudioHdr.hitboxsetindex;
            StudioHitBoxSet = gameProcess.Process.Read<mstudiohitboxset_t>(addressHitBoxSet);

            for (var i = 0; i < StudioHitBoxSet.numhitboxes; i++)
            {
                StudioHitBoxes[i] = gameProcess.Process.Read<mstudiobbox_t>(addressHitBoxSet + StudioHitBoxSet.hitboxindex + i * Marshal.SizeOf<mstudiobbox_t>());             
            }
        }

        private void UpdateStudioBones(GameProcess gameProcess)
        {
            for (var i = 0; i < StudioHdr.numbones; i++)
            {
                StudioBones[i] = gameProcess.Process.Read<mstudiobone_t>(AddressStudioHdr + StudioHdr.boneindex + i * Marshal.SizeOf<mstudiobone_t>());              
            }
        }
         
        private void UpdateBonesMatricesAndPos(GameProcess gameProcess)
        {
            var addressBoneMatrix = gameProcess.Process.Read<IntPtr>(AddressBase + Offsets.Offsets.m_dwBoneMatrix);
            for (var boneId = 0; boneId < BonesPos.Length; boneId++)
            {
                var matrix = gameProcess.Process.Read<matrix3x4_t>(addressBoneMatrix + boneId * Marshal.SizeOf<matrix3x4_t>());                
                BonesMatrices[boneId] = matrix.ToMatrix();
                BonesPos[boneId] = new Vector3(matrix.m30, matrix.m31, matrix.m32);
            }
        }
        #endregion
    }
}
