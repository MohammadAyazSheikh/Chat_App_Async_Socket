using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    public partial class Client_Form : Form
    {
        Socket Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        byte[] byteData;
        int BUFFER_SIZE = 2048;
        public Client_Form()
        {
            InitializeComponent();
            label1.Text = "try 0";
          
            ConnectToServer();
            Server.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(Receive_Callback), Server);
        }

        private void ConnectToServer()
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            byteData = new byte[1024];
            Server.BeginConnect(new IPEndPoint(ipAddress, 800), new AsyncCallback(Connect_Callback), null);
          
        }

        private void Connect_Callback(IAsyncResult ar)
        {
            try
            {
                //BeginInvoke(new MethodInvoker(() => label1.Text = "try 1"));
             
                Server.EndConnect(ar);

                
                //BeginInvoke(new MethodInvoker(() => label1.Text = "try 2"));
                byte[] buffer = Encoding.ASCII.GetBytes("im new client");
                Server.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(Send_Callback), Server);
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "client error");
            }
        }

        void Receive_Callback(IAsyncResult AR)
        {
           int receivedSize = Server.EndReceive(AR);
            byte[] recBuffer;
            string text;
            try
            {
               
                recBuffer = new byte[receivedSize];
                Array.Copy(byteData, recBuffer, receivedSize);
                text = Encoding.ASCII.GetString(recBuffer);
                this.BeginInvoke(new MethodInvoker(() => { label1.Text = text + "\n"; }));
               Server.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, Receive_Callback, Server);
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message,"client error");

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(textBox1.Text);
            Server.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(Send_Callback), Server);
        }

        public void Send_Callback(IAsyncResult ar)
        {
            try
            {
                Server = (Socket)ar.AsyncState;
                Server.EndSend(ar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Client Error: ",ex.Message);
            }
        }
    }
}
