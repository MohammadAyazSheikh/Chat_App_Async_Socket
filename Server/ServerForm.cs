using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    struct Client_Info
    {
        public Socket clientSocket;
        public int CLientID;
    }
    public partial class Server_Form : Form
    {
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<Client_Info> clientSockets_List = new List<Client_Info>();
        int BUFFER_SIZE = 2048;
        int Client_ID = 0;
        int tempID;

        byte[] buffer; 
        public Server_Form()
        {
            InitializeComponent();
            btn_Send.Enabled = false;
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

                Client_ID++;
                Client_Info cl = new Client_Info();
                cl.clientSocket = ClientSocket;
                cl.CLientID = Client_ID;
                clientSockets_List.Add(cl);
                BeginInvoke(new MethodInvoker(() => List_Client.Items.Add("Client " + Client_ID, CheckState.Unchecked)));
               

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
                foreach (var item in clientSockets_List)
                {
                    if (item.clientSocket == currentClient)
                    {
                        this.BeginInvoke(new MethodInvoker(() => {txt_recieved.Text += "Client "+ item.CLientID +": "+ text + "\n"; }));
                    }
                }
              
                currentClient.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, Receive_Callback, currentClient);
            }
            catch (SocketException ex)
            {
               
                currentClient.Close();
                foreach (Client_Info Item in clientSockets_List)
                {
                    if (currentClient == Item.clientSocket)
                    {
                        clientSockets_List.Remove(Item);
                    }
                }
                
                MessageBox.Show("Server",ex.Message);
                
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

     

        private void btn_Send_Click(object sender, EventArgs e)
        {
          
            foreach (Client_Info Item in clientSockets_List)
            {
                if (tempID == Item.CLientID)
                {
                    byte[] bytes = Encoding.ASCII.GetBytes(txt_Send.Text);
                    Item.clientSocket.BeginSend(bytes, 0, bytes.Length, SocketFlags.None, new AsyncCallback(Send_Callback), Item.clientSocket);
                }
            }

            for (int i = 0; i < List_Client.Items.Count; i++)
            {
                List_Client.SetItemChecked(i, false);
            }
            btn_Send.Enabled = false;
        }

        private void btn_Broadcast_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] bytes = Encoding.ASCII.GetBytes(txt_Send.Text);

                foreach (Client_Info Item in clientSockets_List)
                {
                    Item.clientSocket.BeginSend(bytes, 0, bytes.Length, SocketFlags.None, new AsyncCallback(Send_Callback), Item.clientSocket);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Server", ex.Message);
            }
        }

        private void List_Client_SelectedIndexChanged(object sender, EventArgs e)
        {
            tempID = int.Parse(List_Client.Text.Split(' ')[1]);
            btn_Send.Enabled = true;
        }
    }
}
