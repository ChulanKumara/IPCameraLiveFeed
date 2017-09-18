using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MjpegProcessor;

namespace CameraIP
{
    public partial class Form1 : Form
    {
        private MjpegDecoder mjp;
        public Form1()
        {
            InitializeComponent();
            mjp = new MjpegDecoder();
            mjp.FrameReady += mjp_FrameReady;
            mjp.Error += Mjp_Error;
        }

        private void Mjp_Error(object sender, MjpegProcessor.ErrorEventArgs e)
        {
            MessageBox.Show(e.Message);
        }

        private void mjp_FrameReady(object sender, FrameReadyEventArgs e)
        {
            pictureBox1.Image = e.Bitmap;
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            //mjp.ParseStream(new Uri("http://10.128.1.31/Streaming/Channels/1/picture"), "admin", "admin1234");
            mjp.ParseStream(new Uri("http://88.53.197.250/axis-cgi/mjpg/video.cgi?resolution=320×240"));
        }
    }
}
