using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OLL
{
    public partial class CurrentServer : UserControl
    {
        public ClientServer server;

        public CurrentServer()
        {
            InitializeComponent();
        }

        public void setServer(Image img, ClientServer clientServer)
        {
            server = clientServer;
            serverImage.Image = img;
            serverName.Text = clientServer.Name;
            serverPlayercount.Text = clientServer.Players.ToString() + " online players";

            serverImage.Visible = true;
            serverPlayercount.Visible = true;
            serverOnlineIcon.Visible = true;
            serverName.Visible = true;
            noserver.Visible = false;
        }
    }
}
