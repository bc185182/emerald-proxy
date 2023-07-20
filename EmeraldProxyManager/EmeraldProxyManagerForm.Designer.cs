namespace EmeraldProxyManager
{
    partial class EmeraldProxyManagerForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbResponse = new System.Windows.Forms.RichTextBox();
            this.rtbRequest = new System.Windows.Forms.RichTextBox();
            this.lvRequests = new System.Windows.Forms.ListView();
            this.lvResponses = new System.Windows.Forms.ListView();
            this.fileSystemWatcher = new System.IO.FileSystemWatcher();
            this.btnRequestDebug = new System.Windows.Forms.Button();
            this.btnResponseDebug = new System.Windows.Forms.Button();
            this.btnRequestStopDebug = new System.Windows.Forms.Button();
            this.btnResponseStopDebug = new System.Windows.Forms.Button();
            this.btnSendEditedRequest = new System.Windows.Forms.Button();
            this.btnSendEditedResponse = new System.Windows.Forms.Button();
            this.lvDebugRequests = new System.Windows.Forms.ListView();
            this.lvDebugResponses = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lvEditRequests = new System.Windows.Forms.ListView();
            this.label8 = new System.Windows.Forms.Label();
            this.lvEditResponses = new System.Windows.Forms.ListView();
            this.btnRequestStopEdit = new System.Windows.Forms.Button();
            this.btnRequestEdit = new System.Windows.Forms.Button();
            this.btnResponseStopEdit = new System.Windows.Forms.Button();
            this.btnResponseEdit = new System.Windows.Forms.Button();
            this.btnEditRequest = new System.Windows.Forms.Button();
            this.btnEditResponse = new System.Windows.Forms.Button();
            this.txbRequestServiceName = new System.Windows.Forms.TextBox();
            this.lblRequestServiceName = new System.Windows.Forms.Label();
            this.txbResponseServiceName = new System.Windows.Forms.TextBox();
            this.lblResponseServiceName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 456);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Response";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Request";
            // 
            // rtbResponse
            // 
            this.rtbResponse.Location = new System.Drawing.Point(12, 479);
            this.rtbResponse.Name = "rtbResponse";
            this.rtbResponse.Size = new System.Drawing.Size(783, 395);
            this.rtbResponse.TabIndex = 7;
            this.rtbResponse.Text = "";
            // 
            // rtbRequest
            // 
            this.rtbRequest.Location = new System.Drawing.Point(12, 30);
            this.rtbRequest.Name = "rtbRequest";
            this.rtbRequest.Size = new System.Drawing.Size(783, 395);
            this.rtbRequest.TabIndex = 6;
            this.rtbRequest.Text = "";
            // 
            // lvRequests
            // 
            this.lvRequests.FullRowSelect = true;
            this.lvRequests.HideSelection = false;
            this.lvRequests.Location = new System.Drawing.Point(824, 30);
            this.lvRequests.MultiSelect = false;
            this.lvRequests.Name = "lvRequests";
            this.lvRequests.Size = new System.Drawing.Size(201, 395);
            this.lvRequests.TabIndex = 10;
            this.lvRequests.UseCompatibleStateImageBehavior = false;
            this.lvRequests.View = System.Windows.Forms.View.List;
            this.lvRequests.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvRequests_MouseClick);
            // 
            // lvResponses
            // 
            this.lvResponses.FullRowSelect = true;
            this.lvResponses.HideSelection = false;
            this.lvResponses.Location = new System.Drawing.Point(824, 479);
            this.lvResponses.MultiSelect = false;
            this.lvResponses.Name = "lvResponses";
            this.lvResponses.Size = new System.Drawing.Size(201, 395);
            this.lvResponses.TabIndex = 11;
            this.lvResponses.UseCompatibleStateImageBehavior = false;
            this.lvResponses.View = System.Windows.Forms.View.List;
            this.lvResponses.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvResponses_MouseClick);
            // 
            // fileSystemWatcher
            // 
            this.fileSystemWatcher.EnableRaisingEvents = true;
            this.fileSystemWatcher.SynchronizingObject = this;
            // 
            // btnRequestDebug
            // 
            this.btnRequestDebug.Location = new System.Drawing.Point(1048, 31);
            this.btnRequestDebug.Name = "btnRequestDebug";
            this.btnRequestDebug.Size = new System.Drawing.Size(61, 23);
            this.btnRequestDebug.TabIndex = 12;
            this.btnRequestDebug.Text = ">>";
            this.btnRequestDebug.UseVisualStyleBackColor = true;
            this.btnRequestDebug.Click += new System.EventHandler(this.btnRequestDebug_Click);
            // 
            // btnResponseDebug
            // 
            this.btnResponseDebug.Location = new System.Drawing.Point(1047, 479);
            this.btnResponseDebug.Name = "btnResponseDebug";
            this.btnResponseDebug.Size = new System.Drawing.Size(61, 23);
            this.btnResponseDebug.TabIndex = 13;
            this.btnResponseDebug.Text = ">>";
            this.btnResponseDebug.UseVisualStyleBackColor = true;
            this.btnResponseDebug.Click += new System.EventHandler(this.btnResponseDebug_Click);
            // 
            // btnRequestStopDebug
            // 
            this.btnRequestStopDebug.Location = new System.Drawing.Point(1048, 71);
            this.btnRequestStopDebug.Name = "btnRequestStopDebug";
            this.btnRequestStopDebug.Size = new System.Drawing.Size(61, 23);
            this.btnRequestStopDebug.TabIndex = 14;
            this.btnRequestStopDebug.Text = "<<";
            this.btnRequestStopDebug.UseVisualStyleBackColor = true;
            this.btnRequestStopDebug.Click += new System.EventHandler(this.btnRequestStopDebug_Click);
            // 
            // btnResponseStopDebug
            // 
            this.btnResponseStopDebug.Location = new System.Drawing.Point(1047, 518);
            this.btnResponseStopDebug.Name = "btnResponseStopDebug";
            this.btnResponseStopDebug.Size = new System.Drawing.Size(61, 23);
            this.btnResponseStopDebug.TabIndex = 15;
            this.btnResponseStopDebug.Text = "<<";
            this.btnResponseStopDebug.UseVisualStyleBackColor = true;
            this.btnResponseStopDebug.Click += new System.EventHandler(this.btnResponseStopDebug_Click);
            // 
            // btnSendEditedRequest
            // 
            this.btnSendEditedRequest.Location = new System.Drawing.Point(1048, 115);
            this.btnSendEditedRequest.Name = "btnSendEditedRequest";
            this.btnSendEditedRequest.Size = new System.Drawing.Size(61, 23);
            this.btnSendEditedRequest.TabIndex = 16;
            this.btnSendEditedRequest.Text = "Send";
            this.btnSendEditedRequest.UseVisualStyleBackColor = true;
            this.btnSendEditedRequest.Click += new System.EventHandler(this.btnSendEditedRequest_Click);
            // 
            // btnSendEditedResponse
            // 
            this.btnSendEditedResponse.Location = new System.Drawing.Point(1047, 558);
            this.btnSendEditedResponse.Name = "btnSendEditedResponse";
            this.btnSendEditedResponse.Size = new System.Drawing.Size(61, 23);
            this.btnSendEditedResponse.TabIndex = 17;
            this.btnSendEditedResponse.Text = "Send";
            this.btnSendEditedResponse.UseVisualStyleBackColor = true;
            this.btnSendEditedResponse.Click += new System.EventHandler(this.btnSendEditedResponse_Click);
            // 
            // lvDebugRequests
            // 
            this.lvDebugRequests.FullRowSelect = true;
            this.lvDebugRequests.HideSelection = false;
            this.lvDebugRequests.Location = new System.Drawing.Point(1125, 30);
            this.lvDebugRequests.MultiSelect = false;
            this.lvDebugRequests.Name = "lvDebugRequests";
            this.lvDebugRequests.Size = new System.Drawing.Size(111, 64);
            this.lvDebugRequests.TabIndex = 18;
            this.lvDebugRequests.UseCompatibleStateImageBehavior = false;
            this.lvDebugRequests.View = System.Windows.Forms.View.List;
            // 
            // lvDebugResponses
            // 
            this.lvDebugResponses.FullRowSelect = true;
            this.lvDebugResponses.HideSelection = false;
            this.lvDebugResponses.Location = new System.Drawing.Point(1124, 479);
            this.lvDebugResponses.MultiSelect = false;
            this.lvDebugResponses.Name = "lvDebugResponses";
            this.lvDebugResponses.Size = new System.Drawing.Size(111, 62);
            this.lvDebugResponses.TabIndex = 19;
            this.lvDebugResponses.UseCompatibleStateImageBehavior = false;
            this.lvDebugResponses.View = System.Windows.Forms.View.List;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(821, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 18);
            this.label3.TabIndex = 20;
            this.label3.Text = "Requests";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(821, 458);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 18);
            this.label4.TabIndex = 21;
            this.label4.Text = "Responses";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1123, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 15);
            this.label5.TabIndex = 20;
            this.label5.Text = "Debug Requests";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1121, 460);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 15);
            this.label6.TabIndex = 20;
            this.label6.Text = "Debug Responses";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1122, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 15);
            this.label7.TabIndex = 23;
            this.label7.Text = "Edit Requests";
            this.label7.Visible = false;
            // 
            // lvEditRequests
            // 
            this.lvEditRequests.FullRowSelect = true;
            this.lvEditRequests.HideSelection = false;
            this.lvEditRequests.Location = new System.Drawing.Point(1124, 191);
            this.lvEditRequests.MultiSelect = false;
            this.lvEditRequests.Name = "lvEditRequests";
            this.lvEditRequests.Size = new System.Drawing.Size(111, 64);
            this.lvEditRequests.TabIndex = 22;
            this.lvEditRequests.UseCompatibleStateImageBehavior = false;
            this.lvEditRequests.View = System.Windows.Forms.View.List;
            this.lvEditRequests.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1120, 636);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 15);
            this.label8.TabIndex = 25;
            this.label8.Text = "Edit Responses";
            this.label8.Visible = false;
            // 
            // lvEditResponses
            // 
            this.lvEditResponses.FullRowSelect = true;
            this.lvEditResponses.HideSelection = false;
            this.lvEditResponses.Location = new System.Drawing.Point(1123, 655);
            this.lvEditResponses.MultiSelect = false;
            this.lvEditResponses.Name = "lvEditResponses";
            this.lvEditResponses.Size = new System.Drawing.Size(111, 62);
            this.lvEditResponses.TabIndex = 24;
            this.lvEditResponses.UseCompatibleStateImageBehavior = false;
            this.lvEditResponses.View = System.Windows.Forms.View.List;
            this.lvEditResponses.Visible = false;
            // 
            // btnRequestStopEdit
            // 
            this.btnRequestStopEdit.Location = new System.Drawing.Point(1048, 231);
            this.btnRequestStopEdit.Name = "btnRequestStopEdit";
            this.btnRequestStopEdit.Size = new System.Drawing.Size(61, 23);
            this.btnRequestStopEdit.TabIndex = 27;
            this.btnRequestStopEdit.Text = "<<";
            this.btnRequestStopEdit.UseVisualStyleBackColor = true;
            this.btnRequestStopEdit.Visible = false;
            this.btnRequestStopEdit.Click += new System.EventHandler(this.btnRequestStopEdit_Click);
            // 
            // btnRequestEdit
            // 
            this.btnRequestEdit.Location = new System.Drawing.Point(1048, 191);
            this.btnRequestEdit.Name = "btnRequestEdit";
            this.btnRequestEdit.Size = new System.Drawing.Size(61, 23);
            this.btnRequestEdit.TabIndex = 26;
            this.btnRequestEdit.Text = ">>";
            this.btnRequestEdit.UseVisualStyleBackColor = true;
            this.btnRequestEdit.Visible = false;
            this.btnRequestEdit.Click += new System.EventHandler(this.btnRequestEdit_Click);
            // 
            // btnResponseStopEdit
            // 
            this.btnResponseStopEdit.Location = new System.Drawing.Point(1047, 694);
            this.btnResponseStopEdit.Name = "btnResponseStopEdit";
            this.btnResponseStopEdit.Size = new System.Drawing.Size(61, 23);
            this.btnResponseStopEdit.TabIndex = 29;
            this.btnResponseStopEdit.Text = "<<";
            this.btnResponseStopEdit.UseVisualStyleBackColor = true;
            this.btnResponseStopEdit.Visible = false;
            this.btnResponseStopEdit.Click += new System.EventHandler(this.btnResponseStopEdit_Click);
            // 
            // btnResponseEdit
            // 
            this.btnResponseEdit.Location = new System.Drawing.Point(1047, 655);
            this.btnResponseEdit.Name = "btnResponseEdit";
            this.btnResponseEdit.Size = new System.Drawing.Size(61, 23);
            this.btnResponseEdit.TabIndex = 28;
            this.btnResponseEdit.Text = ">>";
            this.btnResponseEdit.UseVisualStyleBackColor = true;
            this.btnResponseEdit.Visible = false;
            this.btnResponseEdit.Click += new System.EventHandler(this.btnResponseEdit_Click);
            // 
            // btnEditRequest
            // 
            this.btnEditRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditRequest.Location = new System.Drawing.Point(716, 426);
            this.btnEditRequest.Name = "btnEditRequest";
            this.btnEditRequest.Size = new System.Drawing.Size(79, 19);
            this.btnEditRequest.TabIndex = 30;
            this.btnEditRequest.Text = "Edit";
            this.btnEditRequest.UseVisualStyleBackColor = true;
            this.btnEditRequest.Click += new System.EventHandler(this.btnEditRequest_Click);
            // 
            // btnEditResponse
            // 
            this.btnEditResponse.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditResponse.Location = new System.Drawing.Point(716, 877);
            this.btnEditResponse.Name = "btnEditResponse";
            this.btnEditResponse.Size = new System.Drawing.Size(79, 19);
            this.btnEditResponse.TabIndex = 31;
            this.btnEditResponse.Text = "Edit";
            this.btnEditResponse.UseVisualStyleBackColor = true;
            this.btnEditResponse.Click += new System.EventHandler(this.btnEditResponse_Click);
            // 
            // txbRequestServiceName
            // 
            this.txbRequestServiceName.Enabled = false;
            this.txbRequestServiceName.Location = new System.Drawing.Point(374, 10);
            this.txbRequestServiceName.Name = "txbRequestServiceName";
            this.txbRequestServiceName.Size = new System.Drawing.Size(136, 20);
            this.txbRequestServiceName.TabIndex = 33;
            // 
            // lblRequestServiceName
            // 
            this.lblRequestServiceName.AutoSize = true;
            this.lblRequestServiceName.Location = new System.Drawing.Point(291, 13);
            this.lblRequestServiceName.Name = "lblRequestServiceName";
            this.lblRequestServiceName.Size = new System.Drawing.Size(77, 13);
            this.lblRequestServiceName.TabIndex = 32;
            this.lblRequestServiceName.Text = "Service Name:";
            // 
            // txbResponseServiceName
            // 
            this.txbResponseServiceName.Enabled = false;
            this.txbResponseServiceName.Location = new System.Drawing.Point(374, 457);
            this.txbResponseServiceName.Name = "txbResponseServiceName";
            this.txbResponseServiceName.Size = new System.Drawing.Size(136, 20);
            this.txbResponseServiceName.TabIndex = 35;
            // 
            // lblResponseServiceName
            // 
            this.lblResponseServiceName.AutoSize = true;
            this.lblResponseServiceName.Location = new System.Drawing.Point(291, 460);
            this.lblResponseServiceName.Name = "lblResponseServiceName";
            this.lblResponseServiceName.Size = new System.Drawing.Size(77, 13);
            this.lblResponseServiceName.TabIndex = 34;
            this.lblResponseServiceName.Text = "Service Name:";
            // 
            // EmeraldProxyManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1402, 947);
            this.Controls.Add(this.txbResponseServiceName);
            this.Controls.Add(this.lblResponseServiceName);
            this.Controls.Add(this.txbRequestServiceName);
            this.Controls.Add(this.lblRequestServiceName);
            this.Controls.Add(this.btnEditResponse);
            this.Controls.Add(this.btnEditRequest);
            this.Controls.Add(this.btnResponseStopEdit);
            this.Controls.Add(this.btnResponseEdit);
            this.Controls.Add(this.btnRequestStopEdit);
            this.Controls.Add(this.btnRequestEdit);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lvEditResponses);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lvEditRequests);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lvDebugResponses);
            this.Controls.Add(this.lvDebugRequests);
            this.Controls.Add(this.btnSendEditedResponse);
            this.Controls.Add(this.btnSendEditedRequest);
            this.Controls.Add(this.btnResponseStopDebug);
            this.Controls.Add(this.btnRequestStopDebug);
            this.Controls.Add(this.btnResponseDebug);
            this.Controls.Add(this.btnRequestDebug);
            this.Controls.Add(this.lvResponses);
            this.Controls.Add(this.lvRequests);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbResponse);
            this.Controls.Add(this.rtbRequest);
            this.Name = "EmeraldProxyManagerForm";
            this.Text = "Emerald Proxy Manager";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbResponse;
        private System.Windows.Forms.RichTextBox rtbRequest;
        private System.Windows.Forms.ListView lvRequests;
        private System.Windows.Forms.ListView lvResponses;
        private System.IO.FileSystemWatcher fileSystemWatcher;
        private System.Windows.Forms.Button btnResponseStopDebug;
        private System.Windows.Forms.Button btnRequestStopDebug;
        private System.Windows.Forms.Button btnResponseDebug;
        private System.Windows.Forms.Button btnRequestDebug;
        private System.Windows.Forms.Button btnSendEditedResponse;
        private System.Windows.Forms.Button btnSendEditedRequest;
        private System.Windows.Forms.ListView lvDebugResponses;
        private System.Windows.Forms.ListView lvDebugRequests;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRequestStopEdit;
        private System.Windows.Forms.Button btnRequestEdit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView lvEditResponses;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView lvEditRequests;
        private System.Windows.Forms.Button btnResponseStopEdit;
        private System.Windows.Forms.Button btnResponseEdit;
        private System.Windows.Forms.Button btnEditResponse;
        private System.Windows.Forms.Button btnEditRequest;
        private System.Windows.Forms.TextBox txbResponseServiceName;
        private System.Windows.Forms.Label lblResponseServiceName;
        private System.Windows.Forms.TextBox txbRequestServiceName;
        private System.Windows.Forms.Label lblRequestServiceName;
    }
}

