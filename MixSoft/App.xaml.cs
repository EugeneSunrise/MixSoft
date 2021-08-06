using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;

namespace MixSoft
{

    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region LegacyV2RuntimeEnabledSuccessfully
        public static bool LegacyV2RuntimeEnabledSuccessfully { get; private set; }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var clrRuntimeInfo =
                (ICLRRuntimeInfo)RuntimeEnvironment.GetRuntimeInterfaceAsObject(
                    Guid.Empty,
                    typeof(ICLRRuntimeInfo).GUID);
            try
            {
                clrRuntimeInfo.BindAsLegacyV2Runtime();
                LegacyV2RuntimeEnabledSuccessfully = true;
            }
            catch (COMException)
            {
                LegacyV2RuntimeEnabledSuccessfully = false;
            }

        }


        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("BD39D1D2-BA2F-486A-89B0-B4B0CB466891")]
        private interface ICLRRuntimeInfo
        {
            void xGetVersionString();
            void xGetRuntimeDirectory();
            void xIsLoaded();
            void xIsLoadable();
            void xLoadErrorString();
            void xLoadLibrary();
            void xGetProcAddress();
            void xGetInterface();
            void xSetDefaultStartupFlags();
            void xGetDefaultStartupFlags();

            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            void BindAsLegacyV2Runtime();
        }
        #endregion
    }
}
