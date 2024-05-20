using OLL.Properties;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OLL
{
    public partial class MainForm : Form
    {
        public static string APIURL = "https://osu-server-list.com";
        public static ApplicationState STATE = ApplicationState.IDLE;
        public static string BASEURL = "https://osu-server-list.com";

        public const string VERSION = "1.1.2";

        public static List<ClientServer> clientServers = new List<ClientServer>();

        public enum ApplicationState
        {
            LOADING,
            IDLE
        }

        public MainForm()
        {

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);


            InitializeComponent();

            if (Settings.Default.favorites == null) Settings.Default.favorites = new System.Collections.Specialized.StringCollection();

            Settings.Default.Save();

            autoStartCheckBox.Checked = AutoStart.IsAutoStartEnabled();

            string savedValue = Settings.Default.showonstart;

            int index = showOnStartBox.FindString(savedValue);

            if (index != -1)
            {
                showOnStartBox.SelectedIndex = index;
            }

            if (Settings.Default.osupath.Length < 2)
            {
                string osuLocalAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\osu!";

                string osuExePath = Path.Combine(osuLocalAppDataPath, "osu!.exe");

                if (File.Exists(osuExePath))
                {
                    Settings.Default.osupath = osuExePath;
                    Settings.Default.Save();
                    FoundExe();
                }

                while (!File.Exists(osuExePath))
                {
                    MessageBox.Show("No osu!.exe found. Please choose the exe yourself.");

                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Executable Files|*.exe";
                    openFileDialog.Title = "Select osu!.exe";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string selectedFilePath = openFileDialog.FileName;
                        if (Path.GetFileName(selectedFilePath) == "osu!.exe")
                        {
                            Settings.Default.osupath = selectedFilePath;
                            FoundExe();
                            Settings.Default.Save();
                            MessageBox.Show("osu!.exe selected successfully.");
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Please select the osu!.exe file.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No file selected. Application will exit.");
                        Environment.Exit(0);
                    }
                }
            }
            else
            {
                FoundExe();
            }

            InitializeAsync().ConfigureAwait(false);


        }

        public void FoundExe()
        {
            exePanel.BackColor = Color.FromArgb(22, 163, 74);
            exeLabel.Text = "osu Executable found";
        }

        private bool alreadySorted = false;

        private void InitializeServersAsync()
        {

            InitializeServersOnUIThreadAsync();
            if (!alreadySorted)
            {
                switch (Settings.Default.showonstart)
                {
                    case "Players":
                        sort(false);
                        break;

                    case "Favorites":
                        ShowFavorites(true);
                        break;

                    default:
                        sort(true);
                        break;
                }
            }

        }

        private void ShowFavorites(bool favorites)
        {
            foreach (Control c in serverFlowLayout.Controls)
            {
                if (c is Server serv)
                {
                    if (favorites)
                    {
                        c.Visible = Settings.Default.favorites.Contains(serv.server.ID.ToString());
                    }
                    else
                    {
                        c.Visible = true;
                    }
                }
            }
        }

        private async void InitializeServersOnUIThreadAsync()
        {
            if (serverFlowLayout.InvokeRequired)
            {
                // If the current thread is not the UI thread, invoke this method on the UI thread
                serverFlowLayout.Invoke(new MethodInvoker(InitializeServersOnUIThreadAsync));
                return;
            }

            for (int i = 0; i < clientServers.Count(); i++)
            {
                ClientServer? sv = null;
                try
                {
                    sv = clientServers[i];


                }
                catch (Exception) { }

                if (sv != null)
                {
                    Server v = new Server(sv, selectedServerTracker);
                    if (Settings.Default.showonstart == "Favorites")
                    {
                        if (!Settings.Default.favorites.Contains(sv.ID.ToString())) v.Visible = false;
                        alreadySorted = true;
                        await Task.Delay(25);
                    }

                    serverFlowLayout.Controls.Add(v);
                }
            }

        }


        private Task InvokeAsync(Action action)
        {
            var tcs = new TaskCompletionSource<object>();
            Invoke((MethodInvoker)delegate
            {
                try
                {
                    action();
                    tcs.SetResult(Task.CompletedTask);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            });
            return tcs.Task;
        }

        private async Task HideLoader()
        {
            if (loaderImage.IsHandleCreated)
            {
                if (loaderImage.InvokeRequired)
                {
                    await InvokeAsync(async () => await HideLoader());
                    return;
                }
                loaderImage.Visible = false;
            }
            await Task.Delay(25);
        }

        private async Task InitializeAsync()
        {
            if (!(STATE == ApplicationState.LOADING))
            {
                STATE = ApplicationState.LOADING;
                try
                {
                    using (var httpClient = new HttpClient())
                    {

                        string userAgent = "OLL "+VERSION;
                        httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(userAgent);
                        HttpResponseMessage httpResponse = await httpClient.GetAsync(APIURL + "/api/v2/client/servers?key=" + Settings.Default.clientSecret).ConfigureAwait(false);

                        if (httpResponse.IsSuccessStatusCode)
                        {
                            var content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<ClientServer>>(content);

                            if (response == null) throw new Exception("Unauthorized");

                            foreach (ClientServer srv in response)
                            {
                                clientServers.Add(srv);

                            }


                            await HideLoader();
                            InitializeServersAsync();
                        }
                        else
                        {
                            MessageBox.Show("Error accessing API: Unauthorized");
                        }
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("HTTP request failed: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Main Form An error occurred: " + ex.Message);
                }
                STATE = ApplicationState.IDLE;
            }

        }



        private void voteSortButton_Click(object sender, EventArgs e)
        {
            sort(true);
        }

        private void sort(Boolean votes)
        {
            ShowFavorites(false);
            List<Server> serverControls = new List<Server>();

            foreach (Control c in serverFlowLayout.Controls)
            {
                if (c is Server serv)
                {
                    serverControls.Add(serv);
                }
            }

            if (votes)
            {
                serverControls.Sort((serv1, serv2) => serv2.server.Votes.CompareTo(serv1.server.Votes));
            }
            else
            {
                serverControls.Sort((serv1, serv2) => serv2.server.Players.CompareTo(serv1.server.Players));
            }

            serverFlowLayout.Controls.Clear();

            foreach (Server serverControl in serverControls)
            {
                serverFlowLayout.Controls.Add(serverControl);
            }
        }

        private void playerSortButton_Click(object sender, EventArgs e)
        {
            sort(false);
        }



        private void favoriteSortButton_Click(object sender, EventArgs e)
        {
            ShowFavorites(true);
        }
        private void playButton_Click(object sender, EventArgs e)
        {
            if (selectedServerTracker.server == null)
            {
                MessageBox.Show("No server selected");
                return;
            }

            string arguments = "-devserver " + selectedServerTracker.server.Devserver;
            Process process = new Process();

            try
            {

                process.StartInfo.FileName = Settings.Default.osupath;
                process.StartInfo.Arguments = arguments;
                process.StartInfo.UseShellExecute = false;
                process.Start();


            }
            catch (Exception ex)
            {
                if (process.StartInfo.WorkingDirectory != null && process.StartInfo.WorkingDirectory.ToLower() == Environment.SystemDirectory.ToLower())
                {

                    MessageBox.Show("Osu! couldn't be started due to the Maple loader not being injected, please inject BEFORE trying to start Osu!  : To Inject, press click on your Maple Loader and wait for the pop-up to appear and closes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Error: {ex.Message}. Could not start osu! Make sure the game is properly installed and accessible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        private void helpButton_Click(object sender, EventArgs e)
        {
            openDiscord();
        }

        private void openDiscord()
        {
            string url = "https://discord.gg/8R65jNbzQP";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openDiscord();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(BASEURL) { UseShellExecute = true });
        }

        private void button8_Click(object sender, EventArgs e)
        {
            settingsBox.Visible = !settingsBox.Visible;
        }

        private void autoStartCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AutoStart.ToggleAutoStart(autoStartCheckBox.Checked);
        }

        private void showOnStartBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (showOnStartBox.SelectedIndex != -1)
            {
                string? selectedValue = showOnStartBox.SelectedItem.ToString();
                Settings.Default.showonstart = selectedValue;
                Settings.Default.Save();
            }
        }
        private void desktopShortcutButton_Click(object sender, EventArgs e)
        {
            string shortcutLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "OLL.lnk");
            string targetPath = System.Windows.Forms.Application.ExecutablePath;

            CreateShortcut(shortcutLocation, targetPath);
        }
        private void CreateShortcut(string shortcutLocation, string targetPath)
        {

            object? shortcut = null;
            try
            {
                Type? type = Type.GetTypeFromProgID("WScript.Shell");

                if (type == null) throw new Exception("WScript.Shell Not Found");

                shortcut = Activator.CreateInstance(type);
                object? shortcutProperties = type.InvokeMember("CreateShortcut", BindingFlags.InvokeMethod, null, shortcut, new object[] { shortcutLocation });

                type.InvokeMember("TargetPath", BindingFlags.SetProperty, null, shortcutProperties, new object[] { targetPath });
                type.InvokeMember("Save", BindingFlags.InvokeMethod, null, shortcutProperties, null);

                MessageBox.Show("Shortcut created");
            }
            catch (Exception) { }

            finally
            {
                if (shortcut != null && Marshal.IsComObject(shortcut))
                {
                    Marshal.ReleaseComObject(shortcut);
                }
            }

        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowWarningMessage(string message)
        {
            MessageBox.Show(this, message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void changeOsuButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Executable Files|*.exe";
            openFileDialog.Title = "Select osu!.exe";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                if (Path.GetFileName(selectedFilePath) == "osu!.exe")
                {
                    Settings.Default.osupath = selectedFilePath;
                    FoundExe();
                    Settings.Default.Save();
                    MessageBox.Show("osu!.exe selected successfully.");

                }
                else
                {
                    MessageBox.Show("Please select the osu!.exe file.");
                }
            }


        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!(STATE == ApplicationState.LOADING))
            {
                loaderImage.Visible = true;
                clientServers.Clear();
                serverFlowLayout.Controls.Clear();
                await InitializeAsync();
            }
        }

        private void dataPolicyLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://osu-server-list.com/privacy-policy";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void selectedServerTracker_Paint(object sender, PaintEventArgs e)
        {
            using (Pen thinPen = new Pen(Color.White, 1))
            {
                Rectangle rect = selectedServerTracker.ClientRectangle;
                rect.Width -= 1;
                rect.Height -= 1;
                e.Graphics.DrawRectangle(thinPen, rect);
            }
        }
    }
}
