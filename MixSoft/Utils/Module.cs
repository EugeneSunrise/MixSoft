using System;
using System.Diagnostics;

namespace MixSoft.Classes
{
    public class Module :
         IDisposable
    {
        #region Prop

        public Process Process { get; private set; }

        public ProcessModule ProcessModule { get; private set; }

        #endregion

        #region Ctor & Dispose

        public Module(Process process, ProcessModule processModule)
        {
            Process = process;
            ProcessModule = processModule;
        }

        public void Dispose()
        {
            Process = default;

            ProcessModule.Dispose();
            ProcessModule = default;
        }

        #endregion
    }
}
