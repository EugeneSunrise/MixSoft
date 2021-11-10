using MixSoft;
using System.Security;

// Token: 0x02000001 RID: 1
internal class ModuleOld
{
    // Token: 0x06000001 RID: 1 RVA: 0x0001B39E File Offset: 0x0001A79E
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public static extern uint GetLastError();

    // Token: 0x06000002 RID: 2 RVA: 0x0001B3C1 File Offset: 0x0001A7C1
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern ushort* DXGetErrorString8W(int lol);

    // Token: 0x06000003 RID: 3 RVA: 0x0001F198 File Offset: 0x0001E598
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXMATRIX* D3DXMatrixMultiply(D3DXMATRIX* lol, D3DXMATRIX* lol2, D3DXMATRIX* lol3);

    // Token: 0x06000004 RID: 4 RVA: 0x00021591 File Offset: 0x00020991
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXQUATERNION* D3DXQuaternionMultiply(D3DXQUATERNION* lol, D3DXQUATERNION* lol2, D3DXQUATERNION* lol3);

    // Token: 0x06000005 RID: 5 RVA: 0x0001DDC7 File Offset: 0x0001D1C7
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXFLOAT16* D3DXFloat32To16Array(D3DXFLOAT16* lol, float* lol2, uint lol3);

    // Token: 0x06000006 RID: 6 RVA: 0x0001B3B6 File Offset: 0x0001A7B6
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern int memcmp(void* lol, void* lol2, uint lol3);

    // Token: 0x06000007 RID: 7 RVA: 0x0001DF55 File Offset: 0x0001D355
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXVECTOR2* D3DXVec2Normalize(D3DXVECTOR2* lol, D3DXVECTOR2* lol2);

    // Token: 0x06000008 RID: 8 RVA: 0x0001DF91 File Offset: 0x0001D391
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXVECTOR2* D3DXVec2Hermite(D3DXVECTOR2* lol, D3DXVECTOR2* lol2, D3DXVECTOR2* lol3, D3DXVECTOR2* lol4, D3DXVECTOR2* lol5, float lol6);

    // Token: 0x06000009 RID: 9 RVA: 0x0001E062 File Offset: 0x0001D462
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXVECTOR2* D3DXVec2CatmullRom(D3DXVECTOR2* lol, D3DXVECTOR2* lol2, D3DXVECTOR2* lol3, D3DXVECTOR2* lol4, D3DXVECTOR2* lol5, float lol6);

    // Token: 0x0600000A RID: 10 RVA: 0x0001E159 File Offset: 0x0001D559
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXVECTOR2* D3DXVec2BaryCentric(D3DXVECTOR2* lol, D3DXVECTOR2* lol2, D3DXVECTOR2* lol3, D3DXVECTOR2* lol4, float lol5, float lol6);

    

    // Token: 0x0600000C RID: 12 RVA: 0x0001E20C File Offset: 0x0001D60C
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXVECTOR2* D3DXVec2TransformCoord(D3DXVECTOR2* lol, D3DXVECTOR2* lol2, D3DXMATRIX* lol3);

    // Token: 0x0600000D RID: 13 RVA: 0x0001E252 File Offset: 0x0001D652
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXVECTOR2* D3DXVec2TransformNormal(D3DXVECTOR2* lol, D3DXVECTOR2* lol2, D3DXMATRIX* lol3);

    

    // Token: 0x0600000F RID: 15 RVA: 0x0001E22F File Offset: 0x0001D62F
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXVECTOR2* D3DXVec2TransformCoordArray(D3DXVECTOR2* lol, uint lol2, D3DXVECTOR2* lol3, uint lol4, D3DXMATRIX* lol5, uint lol6);

    // Token: 0x06000010 RID: 16 RVA: 0x0001E2C0 File Offset: 0x0001D6C0
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXVECTOR2* D3DXVec2TransformNormalArray(D3DXVECTOR2* lol, uint lol2, D3DXVECTOR2* lol3, uint lol4, D3DXMATRIX* lol5, uint lol6);

    // Token: 0x06000011 RID: 17 RVA: 0x0001E33E File Offset: 0x0001D73E
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXVECTOR3* D3DXVec3Normalize(D3DXVECTOR3* lol, D3DXVECTOR3* lol2);

    // Token: 0x06000012 RID: 18 RVA: 0x0001E37A File Offset: 0x0001D77A
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXVECTOR3* D3DXVec3Hermite(D3DXVECTOR3* lol, D3DXVECTOR3* lol2, D3DXVECTOR3* lol3, D3DXVECTOR3* lol4, D3DXVECTOR3* lol5, float lol6);

    // Token: 0x06000013 RID: 19 RVA: 0x0001E46B File Offset: 0x0001D86B
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXVECTOR3* D3DXVec3CatmullRom(D3DXVECTOR3* lol, D3DXVECTOR3* lol2, D3DXVECTOR3* lol3, D3DXVECTOR3* lol4, D3DXVECTOR3* lol5, float lol6);

    // Token: 0x06000014 RID: 20 RVA: 0x0001E584 File Offset: 0x0001D984
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXVECTOR3* D3DXVec3BaryCentric(D3DXVECTOR3* lol, D3DXVECTOR3* lol2, D3DXVECTOR3* lol3, D3DXVECTOR3* lol4, float lol5, float lol6);

    

    // Token: 0x06000016 RID: 22 RVA: 0x0001E791 File Offset: 0x0001DB91
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXVECTOR3* D3DXVec3TransformCoord(D3DXVECTOR3* lol, D3DXVECTOR3* lol2, D3DXMATRIX* lol3);

    // Token: 0x06000017 RID: 23 RVA: 0x0001E8BD File Offset: 0x0001DCBD
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXVECTOR3* D3DXVec3TransformNormal(D3DXVECTOR3* lol, D3DXVECTOR3* lol2, D3DXMATRIX* lol3);

    

    

    // Token: 0x0600001B RID: 27 RVA: 0x0001E7B4 File Offset: 0x0001DBB4
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXVECTOR3* D3DXVec3TransformCoordArray(D3DXVECTOR3* lol, uint lol2, D3DXVECTOR3* lol3, uint lol4, D3DXMATRIX* lol5, uint lol6);

    // Token: 0x0600001C RID: 28 RVA: 0x0001E94D File Offset: 0x0001DD4D
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXVECTOR3* D3DXVec3TransformNormalArray(D3DXVECTOR3* lol, uint lol2, D3DXVECTOR3* lol3, uint lol4, D3DXMATRIX* lol5, uint lol6);

    

    // Token: 0x06000024 RID: 36 RVA: 0x0001F3F8 File Offset: 0x0001E7F8
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXMATRIX* D3DXMatrixTranspose(D3DXMATRIX* lol, D3DXMATRIX* lol2);

    // Token: 0x06000025 RID: 37 RVA: 0x0001F491 File Offset: 0x0001E891
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXMATRIX* D3DXMatrixMultiplyTranspose(D3DXMATRIX* lol, D3DXMATRIX* lol2, D3DXMATRIX* lol3);

    // Token: 0x06000026 RID: 38 RVA: 0x0001F6F1 File Offset: 0x0001EAF1
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXMATRIX* D3DXMatrixInverse(D3DXMATRIX* lol, float* lol2, D3DXMATRIX* lol3);

    // Token: 0x06000027 RID: 39 RVA: 0x0001FADD File Offset: 0x0001EEDD
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXMATRIX* D3DXMatrixScaling(D3DXMATRIX* lol, float lol2, float lol3, float lol4);

    // Token: 0x06000028 RID: 40 RVA: 0x0001FB80 File Offset: 0x0001EF80
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXMATRIX* D3DXMatrixTranslation(D3DXMATRIX* lol, float lol2, float lol3, float lol4);

    // Token: 0x06000029 RID: 41 RVA: 0x0001FC13 File Offset: 0x0001F013
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXMATRIX* D3DXMatrixRotationX(D3DXMATRIX* lol, float lol2);

    // Token: 0x0600002A RID: 42 RVA: 0x0001FCC4 File Offset: 0x0001F0C4
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXMATRIX* D3DXMatrixRotationY(D3DXMATRIX* lol, float lol2);

    // Token: 0x0600002B RID: 43 RVA: 0x0001FD76 File Offset: 0x0001F176
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXMATRIX* D3DXMatrixRotationZ(D3DXMATRIX* lol, float lol2);

    // Token: 0x0600002C RID: 44 RVA: 0x0001FE2C File Offset: 0x0001F22C
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXMATRIX* D3DXMatrixRotationAxis(D3DXMATRIX* lol, D3DXVECTOR3* lol2, float lol3);

    // Token: 0x0600002D RID: 45 RVA: 0x0001FF55 File Offset: 0x0001F355
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXMATRIX* D3DXMatrixRotationQuaternion(D3DXMATRIX* lol, D3DXQUATERNION* lol3);

    // Token: 0x0600002E RID: 46 RVA: 0x0002007E File Offset: 0x0001F47E
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXMATRIX* D3DXMatrixRotationYawPitchRoll(D3DXMATRIX* lol, float lol2, float lol3, float lol4);

    // Token: 0x0600002F RID: 47 RVA: 0x000200A1 File Offset: 0x0001F4A1
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXMATRIX* D3DXMatrixTransformation(D3DXMATRIX* lol, D3DXVECTOR3* lol2, D3DXQUATERNION* lol3, D3DXVECTOR3* lol4, D3DXVECTOR3* lol5, D3DXQUATERNION* lol6, D3DXVECTOR3* lol7);

    // Token: 0x06000030 RID: 48 RVA: 0x0002072C File Offset: 0x0001FB2C
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXMATRIX* D3DXMatrixAffineTransformation(D3DXMATRIX* lol, float lol2, D3DXVECTOR3* lol3, D3DXQUATERNION* lol4, D3DXVECTOR3* lol5);

    // Token: 0x06000031 RID: 49 RVA: 0x00020955 File Offset: 0x0001FD55
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXMATRIX* D3DXMatrixLookAtRH(D3DXMATRIX* lol, D3DXVECTOR3* lol2, D3DXVECTOR3* lol3, D3DXVECTOR3* lol4);

    // Token: 0x06000032 RID: 50 RVA: 0x00020AB2 File Offset: 0x0001FEB2
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXMATRIX* D3DXMatrixLookAtLH(D3DXMATRIX* lol, D3DXVECTOR3* lol2, D3DXVECTOR3* lol3, D3DXVECTOR3* lol4);

    // Token: 0x06000033 RID: 51 RVA: 0x00020C0F File Offset: 0x0002000F
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXMATRIX* D3DXMatrixPerspectiveRH(D3DXMATRIX* lol, float lol2, float lol3, float lol4, float lol5);

    // Token: 0x06000034 RID: 52 RVA: 0x00020C82 File Offset: 0x00020082
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXMATRIX* D3DXMatrixPerspectiveLH(D3DXMATRIX* lol, float lol2, float lol3, float lol4, float lol5);

    // Token: 0x06000035 RID: 53 RVA: 0x00020CF5 File Offset: 0x000200F5
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXMATRIX* D3DXMatrixPerspectiveFovRH(D3DXMATRIX* lol, float lol2, float lol3, float lol4, float lol5);

    // Token: 0x06000036 RID: 54 RVA: 0x00020D90 File Offset: 0x00020190
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXMATRIX* D3DXMatrixPerspectiveFovLH(D3DXMATRIX* lol, float lol2, float lol3, float lol4, float lol5);

    // Token: 0x06000037 RID: 55 RVA: 0x00020E2B File Offset: 0x0002022B
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXMATRIX* D3DXMatrixPerspectiveOffCenterRH(D3DXMATRIX* lol, float lol2, float lol3, float lol4, float lol5, float lol6, float lol7);

    // Token: 0x06000038 RID: 56 RVA: 0x00020ECF File Offset: 0x000202CF
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXMATRIX* D3DXMatrixPerspectiveOffCenterLH(D3DXMATRIX* lol, float lol2, float lol3, float lol4, float lol5, float lol6, float lol7);

    // Token: 0x06000039 RID: 57 RVA: 0x00020F77 File Offset: 0x00020377
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXMATRIX* D3DXMatrixOrthoRH(D3DXMATRIX* lol, float lol2, float lol3, float lol4, float lol5);

    // Token: 0x0600003A RID: 58 RVA: 0x00020FF0 File Offset: 0x000203F0
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXMATRIX* D3DXMatrixOrthoLH(D3DXMATRIX* lol, float lol2, float lol3, float lol4, float lol5);

    // Token: 0x0600003B RID: 59 RVA: 0x0002106B File Offset: 0x0002046B
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXMATRIX* D3DXMatrixOrthoOffCenterRH(D3DXMATRIX* lol, float lol2, float lol3, float lol4, float lol5, float lol6, float lol7);

    // Token: 0x0600003C RID: 60 RVA: 0x00021114 File Offset: 0x00020514
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXMATRIX* D3DXMatrixOrthoOffCenterLH(D3DXMATRIX* lol, float lol2, float lol3, float lol4, float lol5, float lol6, float lol7);

    // Token: 0x0600003D RID: 61 RVA: 0x000203F5 File Offset: 0x0001F7F5
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXMATRIX* D3DXMatrixTransformation2D(D3DXMATRIX* lol, D3DXVECTOR2* lol2, float lol3, D3DXVECTOR2* lol4, D3DXVECTOR2* lol5, float lol6, D3DXVECTOR2* lol7);

    // Token: 0x0600003E RID: 62 RVA: 0x0002085E File Offset: 0x0001FC5E
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXMATRIX* D3DXMatrixAffineTransformation2D(D3DXMATRIX* lol, float lol2, D3DXVECTOR2* lol4, float lol5, D3DXVECTOR2* lol6);

   

    // Token: 0x06000040 RID: 64 RVA: 0x000211FA File Offset: 0x000205FA
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXMATRIX* D3DXMatrixReflect(D3DXMATRIX* lol, D3DXPLANE* lol2);

    // Token: 0x06000041 RID: 65 RVA: 0x0001F063 File Offset: 0x0001E463
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern float D3DXMatrixDeterminant(D3DXMATRIX* lol);

    // Token: 0x06000042 RID: 66 RVA: 0x0002121D File Offset: 0x0002061D
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern void D3DXQuaternionToAxisAngle(D3DXQUATERNION* lol, D3DXVECTOR3* lol2, float* lol3);

    // Token: 0x06000043 RID: 67 RVA: 0x0002127D File Offset: 0x0002067D
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXQUATERNION* D3DXQuaternionRotationMatrix(D3DXQUATERNION* lol, D3DXMATRIX* lol2);

    // Token: 0x06000044 RID: 68 RVA: 0x000213EB File Offset: 0x000207EB
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXQUATERNION* D3DXQuaternionRotationAxis(D3DXQUATERNION* lol, D3DXVECTOR3* lol2, float lol3);

    // Token: 0x06000045 RID: 69 RVA: 0x0002148E File Offset: 0x0002088E
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXQUATERNION* D3DXQuaternionRotationYawPitchRoll(D3DXQUATERNION* lol, float lol2, float lol3, float lol4);

    // Token: 0x06000046 RID: 70 RVA: 0x00021651 File Offset: 0x00020A51
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXQUATERNION* D3DXQuaternionNormalize(D3DXQUATERNION* lol, D3DXQUATERNION* lol2);

    // Token: 0x06000047 RID: 71 RVA: 0x00021674 File Offset: 0x00020A74
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXQUATERNION* D3DXQuaternionInverse(D3DXQUATERNION* lol, D3DXQUATERNION* lol2);

    // Token: 0x06000048 RID: 72 RVA: 0x0002174F File Offset: 0x00020B4F
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXQUATERNION* D3DXQuaternionLn(D3DXQUATERNION* lol, D3DXQUATERNION* lol2);

    // Token: 0x06000049 RID: 73 RVA: 0x000217F4 File Offset: 0x00020BF4
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXQUATERNION* D3DXQuaternionExp(D3DXQUATERNION* lol, D3DXQUATERNION* lol2);

    // Token: 0x0600004A RID: 74 RVA: 0x000218C9 File Offset: 0x00020CC9
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXQUATERNION* D3DXQuaternionSlerp(D3DXQUATERNION* lol, D3DXQUATERNION* lol2, D3DXQUATERNION* lol3, float lol4);

    // Token: 0x0600004B RID: 75 RVA: 0x000219EF File Offset: 0x00020DEF
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXQUATERNION* D3DXQuaternionSquad(D3DXQUATERNION* lol, D3DXQUATERNION* lol2, D3DXQUATERNION* lol3, D3DXQUATERNION* lol4, D3DXQUATERNION* lol5, float lol6);

    // Token: 0x0600004C RID: 76 RVA: 0x00021AB1 File Offset: 0x00020EB1
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXQUATERNION* D3DXQuaternionBaryCentric(D3DXQUATERNION* lol, D3DXQUATERNION* lol2, D3DXQUATERNION* lol3, D3DXQUATERNION* lol4, float lol5, float lol6);

    // Token: 0x0600004D RID: 77 RVA: 0x00021A70 File Offset: 0x00020E70
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern void D3DXQuaternionSquadSetup(D3DXQUATERNION* lol, D3DXQUATERNION* lol2, D3DXQUATERNION* lol3, D3DXQUATERNION* lol4, D3DXQUATERNION* lol5, D3DXQUATERNION* lol6, D3DXQUATERNION* lol7);

    // Token: 0x0600004E RID: 78 RVA: 0x00021B63 File Offset: 0x00020F63
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXPLANE* D3DXPlaneNormalize(D3DXPLANE* lol, D3DXPLANE* lol2);

    // Token: 0x0600004F RID: 79 RVA: 0x00021C2E File Offset: 0x0002102E
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXVECTOR3* D3DXPlaneIntersectLine(D3DXVECTOR3* lol, D3DXPLANE* lol2, D3DXVECTOR3* lol3, D3DXVECTOR3* lol4);

    // Token: 0x06000050 RID: 80 RVA: 0x00021D0C File Offset: 0x0002110C
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXPLANE* D3DXPlaneFromPointNormal(D3DXPLANE* lol, D3DXVECTOR3* lol2, D3DXVECTOR3* lol3);

    // Token: 0x06000051 RID: 81 RVA: 0x00021D6F File Offset: 0x0002116F
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXPLANE* D3DXPlaneFromPoints(D3DXPLANE* lol, D3DXVECTOR3* lol2, D3DXVECTOR3* lol3, D3DXVECTOR3* lol4);

    // Token: 0x06000052 RID: 82 RVA: 0x00021E3B File Offset: 0x0002123B
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXPLANE* D3DXPlaneTransform(D3DXPLANE* lol, D3DXPLANE* lol2, D3DXMATRIX* lol3);

    // Token: 0x06000053 RID: 83 RVA: 0x0001B3AA File Offset: 0x0001A7AA
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public static extern void SetLastError(uint lol);

    

    // Token: 0x06000055 RID: 85 RVA: 0x00021F04 File Offset: 0x00021304
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(132)]
    public unsafe static extern D3DXPLANE* D3DXPlaneTransformArray(D3DXPLANE* lol, uint lol2, D3DXPLANE* lol3, uint lol4, D3DXMATRIX* lo5, uint lol6);
}
