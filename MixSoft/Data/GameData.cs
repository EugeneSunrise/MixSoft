namespace MixSoft.Data;

public class GameData :
     ThreadedComponent
{
    #region Properties

    protected override string ThreadName => nameof(GameData);

    private GameProcess GameProcess { get; set; }

    public Player Player { get; set; }

    public Entity[] Entities { get; private set; }

    #endregion

    #region FrameAct & Dispose

    public GameData(GameProcess gameProcess)
    {
        GameProcess = gameProcess;
        Player = new Player();
        // 64
        Entities = Enumerable.Range(0, 64).Select(index => new Entity(index)).ToArray();
    }

    public override void Dispose()
    {
        base.Dispose();

        Entities = default;
        Player = default;
        GameProcess = default;
    }

    protected override void FrameAction()
    {
        if (!GameProcess.IsValid)
        {
            return;
        }

        Player.Update(GameProcess);
        foreach (var entity in Entities)
        {
            entity.Update(GameProcess);
        }
    }
    #endregion
}