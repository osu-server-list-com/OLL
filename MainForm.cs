using OLL.Properties;
using System;
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
        public static string BASEURL = "https://osu-server-list.com";

        public static List<ClientServer> clientServers = new List<ClientServer>();

        public MainForm()
        {
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

            InitializeAsync();
        

        }

        public void FoundExe()
        {
            exePanel.BackColor = Color.FromArgb(22, 163, 74);
            exeLabel.Text = "osu Executable found";
        }

        private void InitializeServersAsync()
        {
      
            InitializeServersOnUIThreadAsync();
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

        private async void InitializeServersOnUIThreadAsync()
        {
            if (flowLayoutPanel1.InvokeRequired)
            {
                // If the current thread is not the UI thread, invoke this method on the UI thread
                flowLayoutPanel1.Invoke(new MethodInvoker(InitializeServersOnUIThreadAsync));
                return;
            }

            for(int i = 0; i < clientServers.Count(); i++)
            {
                ClientServer sv = null;
                try
                {
                    sv = clientServers[i];
                }catch(Exception) { }

                if(sv != null)
                {
                    Server v = new Server(sv, selectedServerTracker);
                    HideTabsOnStart(v);
              
                    flowLayoutPanel1.Controls.Add(v);
                }
            }

        }

        private async Task HideTabsOnStart(Server v)
        {
            if (v.IsHandleCreated)
            {
                if (v.InvokeRequired)
                {
                    await InvokeAsync(() => HideTabsOnStart(v));
                    return;
                }
                v.Visible = false;
                await Task.Delay(100); // Adjust delay time as needed
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
                    tcs.SetResult(null);
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
            if(loaderImage.IsHandleCreated)
            {
                if (loaderImage.InvokeRequired)
                {
                    loaderImage.Invoke((MethodInvoker)delegate { HideLoader(); });
                    return;
                }
                loaderImage.Visible = false;
            }

        }

        private async Task InitializeAsync()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                   
                    string userAgent = "OLL 1.0"; 
                    httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(userAgent);
                    HttpResponseMessage httpResponse = await httpClient.GetAsync(APIURL + "/api/v2/client/servers?key=" + Settings.Default.clientSecret).ConfigureAwait(false);
                   
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var response = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<ClientServer>>(content);

                        foreach (ClientServer srv in response)
                        {
                            clientServers.Add(srv);
                           
                        }

                        
                        await HideLoader();
                        InitializeServersAsync();
                    }
                    else
                    {
                        MessageBox.Show("Error accessing API: " + httpResponse.StatusCode);
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
        }

        private void voteSortButton_Click(object sender, EventArgs e)
        {
            sort(true);
        }

        private void sort(Boolean votes)
        {
            ShowFavorites(false);
            List<Server> serverControls = new List<Server>();

            foreach (Control c in flowLayoutPanel1.Controls)
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

            flowLayoutPanel1.Controls.Clear();

            foreach (Server serverControl in serverControls)
            {
                flowLayoutPanel1.Controls.Add(serverControl);
            }
        }

        private void playerSortButton_Click(object sender, EventArgs e)
        {
            sort(false);
        }

        private void ShowFavorites(bool favorites)
        {
            if (favorites)
            {
                foreach (Control c in flowLayoutPanel1.Controls)
                {
                    if (c is Server serv)
                    {
                        if (Settings.Default.favorites.Contains(serv.server.ID.ToString()))
                        {
                            c.Visible = true;
                        }
                        else
                        {
                            c.Visible = false;
                        }

                    }
                }
            }
            else
            {
                foreach (Control c in flowLayoutPanel1.Controls)
                {
                    if (c is Server serv)
                    {
                        c.Visible = true;
                    }
                }
            }



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

            Process.Start(new ProcessStartInfo
            {
                FileName = Settings.Default.osupath,
                Arguments = arguments,
                UseShellExecute = false
            });
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
                string selectedValue = showOnStartBox.SelectedItem.ToString();
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

            object shortcut = null;
            try
            {
                Type type = Type.GetTypeFromProgID("WScript.Shell");
                shortcut = Activator.CreateInstance(type);
                object shortcutProperties = type.InvokeMember("CreateShortcut", BindingFlags.InvokeMethod, null, shortcut, new object[] { shortcutLocation });

                type.InvokeMember("TargetPath", BindingFlags.SetProperty, null, shortcutProperties, new object[] { targetPath });
                type.InvokeMember("Save", BindingFlags.InvokeMethod, null, shortcutProperties, null);

                MessageBox.Show("Shortcut created");
            }
            catch (Exception) { }

            finally
            {
                // Release the shortcut object
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
    }
}
