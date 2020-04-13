namespace Server
{
    partial class Server_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_Send = new System.Windows.Forms.TextBox();
            this.txt_recieved = new System.Windows.Forms.RichTextBox();
            this.List_Client = new System.Windows.Forms.CheckedListBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.btn_Broadcast = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_Send
            // 
            this.txt_Send.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Send.Location = new System.Drawing.Point(22, 343);
            this.txt_Send.Name = "txt_Send";
            this.txt_Send.Size = new System.Drawing.Size(310, 32);
            this.txt_Send.TabIndex = 1;
            // 
            // txt_recieved
            // 
            this.txt_recieved.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_recieved.Location = new System.Drawing.Point(12, 12);
            this.txt_recieved.Name = "txt_recieved";
            this.txt_recieved.Size = new System.Drawing.Size(335, 305);
            this.txt_recieved.TabIndex = 3;
            this.txt_recieved.Text = "";
            // 
            // List_Client
            // 
            this.List_Client.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.List_Client.FormattingEnabled = true;
            this.List_Client.Location = new System.Drawing.Point(367, 15);
            this.List_Client.Name = "List_Client";
            this.List_Client.Size = new System.Drawing.Size(129, 395);
            this.List_Client.TabIndex = 4;
            this.List_Client.SelectedIndexChanged += new System.EventHandler(this.List_Client_SelectedIndexChanged);
            // 
            // btn_Send
            // 
            this.btn_Send.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Send.Location = new System.Drawing.Point(22, 381);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(105, 43);
            this.btn_Send.TabIndex = 5;
            this.btn_Send.Text = "Send";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // btn_Broadcast
            // 
            this.btn_Broadcast.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Broadcast.Location = new System.Drawing.Point(227, 381);
            this.btn_Broadcast.Name = "btn_Broadcast";
            this.btn_Broadcast.Size = new System.Drawing.Size(105, 43);
            this.btn_Broadcast.TabIndex = 6;
            this.btn_Broadcast.Text = "Broadcast";
            this.btn_Broadcast.UseVisualStyleBackColor = true;
            this.btn_Broadcast.Click += new System.EventHandler(this.btn_Broadcast_Click);
            // 
            // Server_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 436);
            this.Controls.Add(this.btn_Broadcast);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.List_Client);
            this.Controls.Add(this.txt_recieved);
            this.Controls.Add(this.txt_Send);
            this.Name = "Server_Form";
            this.Text = "Server Harami";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_Send;
        private System.Windows.Forms.RichTextBox txt_recieved;
        private System.Windows.Forms.CheckedListBox List_Client;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.Button btn_Broadcast;
    }
}

