using System;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using MixSoft.Hacks;
using MixSoft.Data;
using System.Windows.Controls;
using MixSoft.Classes;
using MixSoft.Offsets;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Collections.Generic;
using MixSoft.Objects;
using System.Linq;
using MixSoft.Objects.Structs;
using System.Reflection;
using System.IO;
using static MixSoft.Objects.Globals;
using System.Diagnostics;

namespace MixSoft
{
    public partial class HackWindow : Window
    {
        #region Tokens
        CancellationTokenSource cancelTokenSourceBhop = null;
        CancellationTokenSource cancelTokenSourceRadar = null;
        CancellationTokenSource cancelTokenSourceWh = null;
        CancellationTokenSource cancelTokenSourceAntiFlash = null;
        CancellationTokenSource cancelTokenSourceSkinChanger = null;
        CancellationTokenSource cancelTokenSourceKnifeChanger = null;
        CancellationTokenSource cancelTokenSourceKnifeAnimationChanger = null;
        #endregion

        #region Global HotKey
        [DllImport("User32.dll")]
        private static extern bool RegisterHotKey(
    [In] IntPtr hWnd,
    [In] int id,
    [In] uint fsModifiers,
    [In] uint vk);

        [DllImport("User32.dll")]
        private static extern bool UnregisterHotKey(
            [In] IntPtr hWnd,
            [In] int id);

        private HwndSource _source;
        private const int HOTKEY_ID = 9000;

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            var helper = new WindowInteropHelper(this);
            _source = HwndSource.FromHwnd(helper.Handle);
            _source.AddHook(HwndHook);
            RegisterHotKey();
        }

        protected override void OnClosed(EventArgs e)
        {
            _source.RemoveHook(HwndHook);
            _source = null;
            UnregisterHotKey();
            base.OnClosed(e);
        }

        private void RegisterHotKey()
        {
            var helper = new WindowInteropHelper(this);
            //const uint VK_F10 = 0x79;
            //const uint VK_F11 = 0x7A;
            //const uint VK_OEM_PLUS = 0xBB;
            //const uint VK_HOME = 0x24;
            const uint L_KEY = 0x4C;

            //const uint MOD_ALT = 0x12;
            //const uint MOD_CTRL = 0x0002;
            //const uint MOD_NULL = 0x0000;
            const uint MOD_SHIFT = 0x0004;


            if (!RegisterHotKey(helper.Handle, HOTKEY_ID, MOD_SHIFT, L_KEY))
            {
                // handle error
            }
        }

        private void UnregisterHotKey()
        {
            var helper = new WindowInteropHelper(this);
            UnregisterHotKey(helper.Handle, HOTKEY_ID);
        }

        private IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            const int WM_HOTKEY = 0x0312;
            switch (msg)
            {
                case WM_HOTKEY:
                    switch (wParam.ToInt32())
                    {
                        case HOTKEY_ID:
                            OnHotKeyPressed();
                            handled = true;
                            break;
                    }
                    break;
            }
            return IntPtr.Zero;
        }

        private void OnHotKeyPressed()
        {
            // do stuff
            if (aimOnOff == true)
            {
                checkAimBot.IsChecked = false;
            }
            else
            {
                checkAimBot.IsChecked = true;
            }
        }
        #endregion

        #region WindowShit
        public HackWindow()
        {
            Memory.Init();
            NetvarManager.LoadOffsets();
            OffsetManager.ScanOffsets();
            NetvarManager.netvarList.Clear();
            LoadSkins();
            InitializeComponent();

            try
            {
                Process process = Process.GetProcesses().First((Process p) => p.ProcessName == "csgo");
                if (process == null)
                {
                    Environment.Exit(0);
                }
                process.EnableRaisingEvents = true;
                process.Exited += delegate (object s, EventArgs e)
                {
                    Environment.Exit(0);
                };
            }
            catch (Exception)
            {
                MessageBox.Show("First of all start CS:GO!");
                Environment.Exit(0);
            }

            List<string> res = CsgoSkinList.Keys.ToList();
            res.Sort();

            foreach (string s in res) comboSkinSelector.Items.Add(s);
            List<string> ids = Enum.GetNames(typeof(ItemDefinitionIndex)).ToList();
            foreach (string s in ids)
            {
                comboWeaponSelector.Items.Add(s);
            }

            List<string> knives = Constants.KnifeList.Keys.ToList();
            foreach (string s in knives) comboKnifeSelector.Items.Add(s);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }
        private void SoftGrid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btn_hide_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void btnFSApply_Click(object sender, RoutedEventArgs e)
        {
            int num;
            bool isNumFov = int.TryParse(textboxFOV.Text, out num);
            bool isNumSmooth = int.TryParse(textboxSmooth.Text, out num);
            bool isNumBones = int.TryParse(textboxBones.Text, out num);

            if (isNumFov & isNumSmooth & isNumBones)
            {
                AimBot.AimBotFov = float.Parse(textboxFOV.Text).DegreeToRadian();
                AimBot.AimBotSmoothing = float.Parse(textboxSmooth.Text);
                AimBot.AimBoneId = int.Parse(textboxBones.Text);
            }
            else
            {
                MessageBox.Show("Fields must only contain whole numbers! Hover over the tooltip (?*)");
            }
        }
        #endregion

        #region Wh
        private async void checkWallhack_Checked(object sender, RoutedEventArgs e)
        {
            cancelTokenSourceWh = new CancellationTokenSource();
            var token = cancelTokenSourceWh.Token;
            try
            {
                WallHack wallHack = new WallHack();
                await Task.Run(() => wallHack.Rendering((CancellationToken)token));
            }
            catch (OperationCanceledException)
            {
                //MessageBox.Show("Wh OFF");
            }
            finally
            {
                cancelTokenSourceWh.Dispose();
            }
        }
        private void checkWallhack_Unchecked(object sender, RoutedEventArgs e)
        {
            cancelTokenSourceWh.Cancel();
        }
        #endregion

        #region NoFlash
        private async void checkAntiFlash_Checked(object sender, RoutedEventArgs e)
        {
            cancelTokenSourceAntiFlash = new CancellationTokenSource();
            var token = cancelTokenSourceAntiFlash.Token;
            try
            {
                AntiFlash antiFlash = new AntiFlash();
                await Task.Run(() => antiFlash.AntiFuckinFlash((CancellationToken)token));
            }
            catch (OperationCanceledException)
            {
                //MessageBox.Show("Anti Flash OFF");
            }
            finally
            {
                cancelTokenSourceAntiFlash.Dispose();
            }
        }
        private void checkAntiFlash_Unchecked(object sender, RoutedEventArgs e)
        {
            cancelTokenSourceAntiFlash.Cancel();
        }
        #endregion

        #region Aim
        public bool aimOnOff = false;
        private GameProcess GameProcess { get; set; }
        private GameData GameData { get; set; }
        private AimBot AimBot { get; set; }
        //[STAThread]
        public void AimOn()
        {
            aimOnOff = true;
            textboxBones.IsEnabled = true;
            textboxFOV.IsEnabled = true;
            textboxSmooth.IsEnabled = true;
            btnFSApply.IsEnabled = true;


            GameProcess = new GameProcess();
            GameData = new GameData(GameProcess);
            AimBot = new AimBot(GameProcess, GameData);

            GameProcess.Start();
            GameData.Start();
            AimBot.Start();

            textboxBones.Text = AimBot.AimBoneId.ToString();
            textboxFOV.Text = AimBot.AimBotFov.RadianToDegree().ToString();
            textboxSmooth.Text = AimBot.AimBotSmoothing.ToString();
        }

        public void AimOff()
        {
            aimOnOff = false;
            textboxFOV.IsEnabled = false;
            textboxSmooth.IsEnabled = false;
            textboxBones.IsEnabled = false;
            btnFSApply.IsEnabled = false;

            AimBot.Dispose();
            AimBot = default;

            GameData.Dispose();
            GameData = default;

            GameProcess.Dispose();
            GameProcess = default;

            textboxBones.Text = "";
            textboxFOV.Text = "";
            textboxSmooth.Text = "";
        }
        private void checkAimBot_Checked(object sender, RoutedEventArgs e)
        {
            AimOn();
        }
        private void checkAimBot_Unchecked(object sender, RoutedEventArgs e)
        {
            AimOff();
        }
        #endregion

        #region Radar
        private async void checkRadar_Checked(object sender, RoutedEventArgs e)
        {
            cancelTokenSourceRadar = new CancellationTokenSource();
            var token = cancelTokenSourceRadar.Token;
            try
            {
                RadarHack radar = new RadarHack();
                await Task.Run(() => radar.Radar((CancellationToken)token));
            }
            catch (OperationCanceledException)
            {
                //MessageBox.Show("Radar OFF");
            }
            finally
            {
                cancelTokenSourceRadar.Dispose();
            }
        }
        private void checkRadar_Unchecked(object sender, RoutedEventArgs e)
        {
            cancelTokenSourceRadar.Cancel();
        }
        #endregion

        #region Bhop
        private async void checkBhop_Checked(object sender, RoutedEventArgs e)
        {
            cancelTokenSourceBhop = new CancellationTokenSource();
            var token = cancelTokenSourceBhop.Token;
            try
            {
                BunnyHop bunnyHop = new BunnyHop();
                await Task.Run(() => bunnyHop.Bhop((CancellationToken)token));
            }
            catch (OperationCanceledException)
            {
                //MessageBox.Show("BHOP OFF");
            }
            finally
            {
                cancelTokenSourceBhop.Dispose();
            }
        }
        private void checkBhop_Unchecked(object sender, RoutedEventArgs e)
        {
            cancelTokenSourceBhop.Cancel();
        }
        #endregion

        #region SkinChanger

        private void LoadSkins()
        {
            var assembly = Assembly.GetExecutingAssembly();
            string resourcePath = "MixSoft.Resources.Skins.dat";

            using (StreamReader reader = new StreamReader(assembly.GetManifestResourceStream(resourcePath)))
            {
                while (!reader.EndOfStream)
                {
                    string raw = reader.ReadLine();
                    string[] splitted = raw.Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries);
                    int count = 0;
                    foreach (SkinObj s in Globals.CsgoSkinList.Values)
                    {
                        if (s.SkinName == splitted[1])
                        {
                            count += 1;
                        }
                    }
                    Globals.CsgoSkinList.Add(splitted[1] + (count == 0 ? "" : count.ToString()), new SkinObj(Convert.ToInt32(splitted[0]), splitted[1]));
                }
            }

            try
            {
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string programDataPath = Path.Combine(appDataPath, "MixSoftCFG");
                string fullSavePath = Path.Combine(programDataPath, "SkinChanger");

                if (!Directory.Exists(fullSavePath))
                    Directory.CreateDirectory(fullSavePath);

                string[] files = Directory.GetFiles(fullSavePath);

                foreach (string file in files)
                {
                    string[] lines2 = File.ReadAllLines(file);
                    Globals.LoadedPresets.Add(new Skin(Convert.ToInt32(file.Split(new string[] { ".dat" }, StringSplitOptions.RemoveEmptyEntries)[0].Substring(fullSavePath.Length + 1)),
                                                       Convert.ToInt32(lines2[0]),
                                                       lines2[1] != "" && lines2[1] != null ? Convert.ToInt32(lines2[1]) : -1,
                                                       Convert.ToSingle(lines2[2]),
                                                       lines2[3]));
                }
            }
            catch
            {
                MessageBox.Show("IO Error.\n This usually happens once in your lifetime.\n Simply restarting will fix the issue.");
            }
        }
        private async void checkSkinChanger_Checked(object sender, RoutedEventArgs e)
        {
            SkinChangerEnabled = true;
            comboSkinSelector.IsEnabled = true;
            comboWeaponSelector.IsEnabled = true;
            textboxTag.IsEnabled = true;
            btnSKApply.IsEnabled = true;
            cancelTokenSourceSkinChanger = new CancellationTokenSource();
            var token = cancelTokenSourceSkinChanger.Token;
            try
            {
                SkinChanger skinChanger = new SkinChanger();
                await Task.Run(() => skinChanger.SkinChangerThread((CancellationToken)token));
            }
            catch (OperationCanceledException)
            {
                //MessageBox.Show("Skin Changer OFF");
            }
            finally
            {
                cancelTokenSourceSkinChanger.Dispose();
            }
        }

        private void checkSkinChanger_Unchecked(object sender, RoutedEventArgs e)
        {
            comboSkinSelector.IsEnabled = false;
            comboWeaponSelector.IsEnabled = false;
            SkinChangerEnabled = false;
            textboxTag.IsEnabled = false;
            btnSKApply.IsEnabled = false;
            cancelTokenSourceSkinChanger.Cancel();
        }

        private void btnSKApply_Click(object sender, RoutedEventArgs e)
        {

            if (Enum.Parse(typeof(ItemDefinitionIndex), (string)comboWeaponSelector.SelectedItem) == null ||
                Globals.CsgoSkinList[(string)comboSkinSelector.SelectedItem] == null)
            {
                MessageBox.Show("Both WeaponID and SkinID should be declared.");
                return;
            }

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string programDataPath = Path.Combine(appDataPath, "MixSoftCFG");
            string fullSavePath = Path.Combine(programDataPath, "SkinChanger");

            string[] conts = new string[] { Globals.CsgoSkinList[(string)comboSkinSelector.SelectedItem].SkinID.ToString(),
                                            "0",
                                            "0",
                                            textboxTag.Text};


            File.WriteAllLines(Path.Combine(fullSavePath, ((int)Enum.Parse(typeof(ItemDefinitionIndex), (string)comboWeaponSelector.SelectedItem)).ToString() + ".dat"), conts);


            LoadedPresets.Clear();

            try
            {
                if (!Directory.Exists(fullSavePath))
                    Directory.CreateDirectory(fullSavePath);

                string[] files = Directory.GetFiles(fullSavePath);

                foreach (string file in files)
                {
                    string[] lines2 = File.ReadAllLines(file);
                    Globals.LoadedPresets.Add(new Skin(Convert.ToInt32(file.Split(new string[] { ".dat" }, StringSplitOptions.RemoveEmptyEntries)[0].Substring(fullSavePath.Length + 1)),
                                                       Convert.ToInt32(lines2[0]),
                                                       lines2[1] != "" && lines2[1] != null ? Convert.ToInt32(lines2[1]) : -1,
                                                       Convert.ToSingle(lines2[2]),
                                                       lines2[3]));
                }
            }
            catch
            {
                MessageBox.Show("IO Error (0x3)");
            }
        }
        #endregion

        #region KnifeChanger
        private async void checkKnifeChanger_Checked(object sender, RoutedEventArgs e)
        {
            comboKnifeSelector.IsEnabled = true;
            comboKnifeSelector.SelectedItem = SelectedKnife;
            KnifeChangerAnimFixEnabled = true;
            KnifeChangerEnabled = true;
            cancelTokenSourceKnifeChanger = new CancellationTokenSource();
            cancelTokenSourceKnifeAnimationChanger = new CancellationTokenSource();

            var tokenKnife = cancelTokenSourceKnifeChanger.Token;
            var tokenAnimKnife = cancelTokenSourceKnifeAnimationChanger.Token;
            try
            {
                KnifeChanger knifeChanger = new KnifeChanger();
                KnifeChangerAnimationFix knifeChangerAnimationFix = new KnifeChangerAnimationFix();

                var taskKnifeChanger = Task.Run(() => knifeChanger.KnifeChangerThread((CancellationToken)tokenKnife));
                var KnifeAnimation = Task.Run(() => knifeChangerAnimationFix.KnifeChangerAnimationFixThread((CancellationToken)tokenAnimKnife));

                await Task.WhenAll(taskKnifeChanger, KnifeAnimation);
                //await Task.WhenAll(taskKnifeChanger);


            }
            catch (OperationCanceledException)
            {
                //MessageBox.Show("Knife Changer OFF");
            }
            finally
            {
                cancelTokenSourceKnifeChanger.Dispose();
                cancelTokenSourceKnifeAnimationChanger.Dispose();
            }
        }
        private void checkKnifeChanger_Unchecked(object sender, RoutedEventArgs e)
        {
            comboKnifeSelector.IsEnabled = false;
            KnifeChangerEnabled = false;
            KnifeChangerAnimFixEnabled = false;
        }
        private void comboKnifeSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboKnifeSelector.SelectedItem != null) Globals.SelectedKnife = (string)comboKnifeSelector.SelectedItem;
            else Globals.SelectedKnife = "Talon";
        }
        #endregion
    }
}
