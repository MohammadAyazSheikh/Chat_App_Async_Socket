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

namespace Server
{
    public partial class Server_Form : Form
    {
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<Socket> clientSockets_List = new List<Socket>();
        int BUFFER_SIZE = 2048;
    
        byte[] buffer; 
        public Server_Form()
        {
            InitializeComponent();
           
            buffer = new byte[BUFFER_SIZE];
            startServer();
        }

        void startServer()
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            serverSocket.Bind(new IPEndPoint(ipAddress, 800));
            serverSocket.Listen(50);
            serverSocket.BeginAccept(Accept_Callback, null);
        }

        void Accept_Callback(IAsyncResult AR)
        {

            Socket ClientSocket;

            try
            {
                ClientSocket = serverSocket.EndAccept(AR);
                BeginInvoke(new MethodInvoker(() => label1.Text = "new client connected"));
                clientSockets_List.Add(ClientSocket);
                ClientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, Receive_Callback, ClientSocket);
                    
                serverSocket.BeginAccept(Accept_Callback, null);
            }
            catch (ObjectDisposedException) 
            {
                MessageBox.Show("Server Error");
            }

          
        }

        void Receive_Callback(IAsyncResult AR)
        {
            Socket currentClient = (Socket)AR.AsyncState;
            int receivedSize;
            byte[] recBuffer;
            string text;
            try
            {
                receivedSize = currentClient.EndReceive(AR);
                recBuffer = new byte[receivedSize];
                Array.Copy(buffer, recBuffer, receivedSize);
                text = Encoding.ASCII.GetString(recBuffer);
                this.BeginInvoke(new MethodInvoker( () => {label1.Text = text + "\n";}));
                currentClient.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, Receive_Callback, currentClient);
            }
            catch (SocketException ex)
            {
               
                currentClient.Close();
                clientSockets_List.Remove(currentClient);
                MessageBox.Show(ex.Message);
                
            }

        }

        public void Send_Callback(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;
                client.EndSend(ar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] bytes = Encoding.ASCII.GetBytes(textBox1.Text);

                foreach (Socket client in clientSockets_List)
                {
                   client.BeginSend(bytes, 0, bytes.Length, SocketFlags.None, new AsyncCallback(Send_Callback), client);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Server","Unable to send message to the clients.");
            }

        }
    }
}
