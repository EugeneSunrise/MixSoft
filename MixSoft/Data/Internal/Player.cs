namespace MixSoft.Data.Internal;
public class Player :
    EntityBase
{
    #region Properties

    // Matrix from world space to clipping space
    public Matrix MatrixViewProjection { get; private set; }


    // Matrix from clipping space to screen space
    public Matrix MatrixViewport { get; private set; }


    // Matrix from world space to screen space
    public Matrix MatrixViewProjectionViewport { get; private set; }


    // Local offset from model origin to player eyes
    public Vector3 ViewOffset { get; private set; }


    // Eye position (in world)
    public Vector3 EyePosition { get; private set; }


    // Eye direction (in world)
    public Vector3 EyeDirection { get; private set; }


    // View angles (in degrees)
    public Vector3 ViewAngles { get; private set; }


    // Aim punch angles (in degrees)
    public Vector3 AimPunchAngle { get; private set; }


    // Aim direction (in world)
    public Vector3 AimDirection { get; private set; }


    // Player vertical field of view (in degrees)
    public int Fov { get; private set; }
    #endregion

    #region Updates

    protected override IntPtr ReadAddressBase(GameProcess gameProcess)
    {
        return gameProcess.ModuleClient.Read<IntPtr>(Offsets.Offsets.dwLocalPlayer);
    }

    public Vector3 FUckingAssHole(Vector3 fir, Vector3 sec)
    {
        Vector3 zalupa = new Vector3();
        zalupa.X = fir.X + sec.X;
        zalupa.Y = fir.Y + sec.Y;
        zalupa.Z = fir.Z + sec.Z;
        return zalupa;
    }
    public override bool Update(GameProcess gameProcess)
    {
        if (!base.Update(gameProcess))
        {
            return false;
        }
        //////////////////////////////////////
        //Matrix test = gameProcess.ModuleClient.Read<Matrix>(Offsets.Offsets.dwViewMatrix);
        //Dictionary<string, object> kek = new Dictionary<string, object>();

        //foreach (var item in test.GetType().GetFields())
        //{
        //    kek.Add(item.Name, item.GetValue(test));
           
        //}
        //Matrix testfuck = gameProcess.ModuleClient.Read<Matrix>(Offsets.Offsets.dwViewMatrix);
        //var a = test.GetType();
        //// get matrices
        //Matrix lol = new Matrix();
        //var c = Matrix.TransposeMatrix(test);
        ////////////////////////////////////////////
        MatrixViewProjection = gameProcess.ModuleClient.Read<Matrix>(Offsets.Offsets.dwViewMatrix);

        // read data
        ViewOffset = gameProcess.Process.Read<Vector3>(AddressBase + Offsets.Offsets.m_vecViewOffset);

        //EyePosition = Origin + ViewOffset;
        EyePosition = FUckingAssHole(Origin, ViewOffset);
        //Vector3 test = Origin.X + ViewOffset.X;
        int b = 1;
        //EyePosition.X = Origin.X + ViewOffset.X;
        //EyePosition.X = Origin.X + ViewOffset.X;
        ViewAngles = gameProcess.Process.Read<Vector3>(gameProcess.ModuleEngine.Read<IntPtr>(Offsets.Offsets.dwClientState) + Offsets.Offsets.dwClientState_ViewAngles);
        AimPunchAngle = gameProcess.Process.Read<Vector3>(AddressBase + Offsets.Offsets.m_aimPunchAngle);
        Fov = gameProcess.Process.Read<int>(AddressBase + Offsets.Offsets.m_iFOV);

        if (Fov == 0) Fov = 90; // correct for default

        // calc data
        EyeDirection = GfxMath.GetVectorFromEulerAngles(ViewAngles.X.DegreeToRadian(), ViewAngles.Y.DegreeToRadian());
        AimDirection = GfxMath.GetVectorFromEulerAngles
        (
            (ViewAngles.X + AimPunchAngle.X * Offsets.Offsets.weapon_recoil_scale).DegreeToRadian(),
            (ViewAngles.Y + AimPunchAngle.Y * Offsets.Offsets.weapon_recoil_scale).DegreeToRadian()
        );
        return true;
    }
    #endregion
}