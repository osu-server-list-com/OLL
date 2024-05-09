using System;
using System.Diagnostics;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using OLL.Properties;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Png;
using Svg;

namespace OLL
{
    public partial class Server : UserControl
    {
        public ClientServer server;
        private CurrentServer currentServerPanel;

        public Server(ClientServer server, CurrentServer currentServerPanel)
        {
            this.currentServerPanel = currentServerPanel;
            this.server = server;
            InitializeComponent();

            LoadServerInformations();
            LoadImageAsync(server.Image);

        }
        private void LoadServerInformations()
        {
            try
            {
                label1.Text = server.Name;
                label2.Text = server.Timestamp;
                label3.Text = server.Players + " online players";
                label4.Text = server.Votes + " total votes";

                serverUrlLinkLabel.Text = server.URL;

                if (Settings.Default.favorites.Contains(server.ID.ToString()))
                {
                    favoriteButton.Text = "Unfavorite";
                }
            }
            catch(Exception)
            {
               
            }
            
        }

        private async void LoadImageAsync(string imageUrl)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(imageUrl))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var contentType = response.Content.Headers.ContentType;

                            if (contentType.MediaType == "image/svg+xml")
                            {
                                using (var stream = await response.Content.ReadAsStreamAsync())
                                {
                                    // Load and render SVG image
                                    var svgDocument = SvgDocument.Open<SvgDocument>(stream);
                                    var bitmap = svgDocument.Draw();
                                    SetPictureBoxImage(bitmap);
                                }
                            }
                            else if (contentType.MediaType == "image/webp")
                            {
                                using (var stream = await response.Content.ReadAsStreamAsync())
                                {
                                    // Decode WebP image
                                    using (SixLabors.ImageSharp.Image image = SixLabors.ImageSharp.Image.Load(stream))
                                    {
                                        using (MemoryStream ms = new MemoryStream())
                                        {
                                            image.SaveAsBmp(ms);
                                            SetPictureBoxImage(new Bitmap(ms));
                                        }
                                    }
                                }
                            }
                            else
                            {
                                using (var stream = await response.Content.ReadAsStreamAsync())
                                {
                                    try
                                    {
                                        var image = System.Drawing.Image.FromStream(stream);
                                        SetPictureBoxImage(image);
                                    }
                                    catch (ArgumentException ex)
                                    {
                                        using (SixLabors.ImageSharp.Image image = SixLabors.ImageSharp.Image.Load(stream))
                                        {
                                            using (MemoryStream ms = new MemoryStream())
                                            {
                                                image.Save(ms, new PngEncoder());
                                                SetPictureBoxImage(new Bitmap(ms));
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Failed to download image. Status code: " + response.StatusCode);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ServerControl An error occurred: " + ex.Message);
            }
        }

        private void SetPictureBoxImage(System.Drawing.Image image)
        {
            if (pictureBox1.InvokeRequired)
            {
                pictureBox1.Invoke((Action)(() => SetPictureBoxImage(image)));
            }
            else
            {
                pictureBox1.Image = image;
            }
        }

        private void serverUrlLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel linkLabel = sender as LinkLabel;
            if (linkLabel != null && !string.IsNullOrEmpty(linkLabel.Text))
            {
                string url = MainForm.BASEURL + "/server/" + server.Safe_Name + "/play";
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
        }



        private void favoriteButton_Click(object sender, EventArgs e)
        {
            if (Settings.Default.favorites == null) Settings.Default.favorites = new System.Collections.Specialized.StringCollection();

            if (Settings.Default.favorites.Contains(server.ID.ToString()))
            {
                Settings.Default.favorites.Remove(server.ID.ToString());
                favoriteButton.Text = "Favorite";
            }
            else
            {
                Settings.Default.favorites.Add(server.ID.ToString());
                favoriteButton.Text = "Unfavorite";
            }


            Settings.Default.Save();


        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            string url = MainForm.BASEURL + "/server/" + server.Safe_Name;
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void voteButton_Click(object sender, EventArgs e)
        {
            string url = MainForm.BASEURL + "/server/" + server.Safe_Name + "/vote";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void serverSelectButton_Click(object sender, EventArgs e)
        {
            currentServerPanel.setServer(pictureBox1.Image, server);
        }
    }
}
