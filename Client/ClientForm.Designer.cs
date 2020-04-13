namespace Client
{
    partial class Client_Form
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
            this.txtSend = new System.Windows.Forms.TextBox();
            this.txtRecieved = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSend
            // 
            this.txtSend.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSend.Location = new System.Drawing.Point(12, 339);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(348, 32);
            this.txtSend.TabIndex = 0;
            // 
            // txtRecieved
            // 
            this.txtRecieved.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecieved.Location = new System.Drawing.Point(12, 12);
            this.txtRecieved.Name = "txtRecieved";
            this.txtRecieved.Size = new System.Drawing.Size(348, 311);
            this.txtRecieved.TabIndex = 3;
            this.txtRecieved.Text = "";
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(12, 377);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(84, 38);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // Client_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 427);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtRecieved);
            this.Controls.Add(this.txtSend);
            this.Name = "Client_Form";
            this.Text = "Client Harami";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.RichTextBox txtRecieved;
        private System.Windows.Forms.Button btnSend;
    }
}

