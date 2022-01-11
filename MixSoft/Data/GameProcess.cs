namespace MixSoft.Data;

public class GameProcess :
    ThreadedComponent
{
    #region Main Constants

    private const string NAME_PROCESS = "csgo";

    private const string NAME_MODULE_CLIENT = "client.dll";

    private const string NAME_MODULE_ENGINE = "engine.dll";

    private const string NAME_WINDOW = "Counter-Strike: Global Offensive - Direct3D 9";

    #endregion

    #region Properties

    protected override string ThreadName => nameof(GameProcess);

    protected override TimeSpan ThreadFrameSleep { get; set; } = new TimeSpan(0, 0, 0, 0, 500);


    /// Game process
    public Process Process { get; private set; }


    /// Client module
    public Module ModuleClient { get; private set; }


    /// Engine module
    public Module ModuleEngine { get; private set; }


    /// Game window handle
    private IntPtr WindowHwnd { get; set; }


    /// Game window client rectangle
    public Rectangle WindowRectangleClient { get; private set; }


    /// Whether game window is active
    private bool WindowActive { get; set; }


    /// Is game process valid?
    public bool IsValid => WindowActive && !(Process is null) && !(ModuleClient is null) && !(ModuleEngine is null);

    #endregion

    #region FrameAct & Dispose & Validation
    public override void Dispose()
    {
        InvalidateWindow();
        InvalidateModules();

        base.Dispose();
    }

    protected override void FrameAction()
    {
        if (!EnsureProcessAndModules())
        {
            InvalidateModules();
        }

        if (!EnsureWindow())
        {
            InvalidateWindow();
        }
    }


    /// Invalidate all game modules.
    /// </summary>
    private void InvalidateModules()
    {
        ModuleEngine?.Dispose();
        ModuleEngine = default;

        ModuleClient?.Dispose();
        ModuleClient = default;

        Process?.Dispose();
        Process = default;
    }


    /// Invalidate game window.
    /// </summary>
    private void InvalidateWindow()
    {
        WindowHwnd = IntPtr.Zero;
        WindowRectangleClient = Rectangle.Empty;
        WindowActive = false;
    }


    /// Ensure game process and modules.
    /// </summary>
    private bool EnsureProcessAndModules()
    {
        if (Process is null)
        {
            Process = Process.GetProcessesByName(NAME_PROCESS).FirstOrDefault();
        }
        if (Process is null || !Process.IsRunning())
        {
            return false;
        }

        if (ModuleClient is null)
        {
            ModuleClient = Process.GetModule1(NAME_MODULE_CLIENT);
        }
        if (ModuleClient is null)
        {
            return false;
        }

        if (ModuleEngine is null)
        {
            ModuleEngine = Process.GetModule1(NAME_MODULE_ENGINE);
        }
        if (ModuleEngine is null)
        {
            return false;
        }

        return true;
    }


    /// Ensure game window.
    /// </summary>
    private bool EnsureWindow()
    {
        WindowHwnd = User32.FindWindow(null, NAME_WINDOW);
        if (WindowHwnd == IntPtr.Zero)
        {
            return false;
        }

        WindowRectangleClient = Extensions.GetClientRectangle(WindowHwnd);
        if (WindowRectangleClient.Width <= 0 || WindowRectangleClient.Height <= 0)
        {
            return false;
        }

        WindowActive = WindowHwnd == User32.GetForegroundWindow();

        return WindowActive;
    }

    #endregion
}