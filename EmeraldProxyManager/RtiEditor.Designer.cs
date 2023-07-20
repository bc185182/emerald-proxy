using System.Windows.Forms;

namespace EmeraldProxyManager
{
    partial class RtiEditor
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
            this.rtbContent = new System.Windows.Forms.RichTextBox();
            this.btnGetXPath = new System.Windows.Forms.Button();
            this.txbXPath = new System.Windows.Forms.TextBox();
            this.cmbOperationType = new System.Windows.Forms.ComboBox();
            this.lblOperationType = new System.Windows.Forms.Label();
            this.lblRtiType = new System.Windows.Forms.Label();
            this.txbRtiType = new System.Windows.Forms.TextBox();
            this.txbServiceName = new System.Windows.Forms.TextBox();
            this.lblServiceName = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.txbContent = new System.Windows.Forms.TextBox();
            this.btnAddOperation = new System.Windows.Forms.Button();
            this.lblOperations = new System.Windows.Forms.Label();
            this.lvOperations = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // rtbContent
            // 
            this.rtbContent.Location = new System.Drawing.Point(24, 42);
            this.rtbContent.Name = "rtbContent";
            this.rtbContent.ReadOnly = true;
            this.rtbContent.Size = new System.Drawing.Size(783, 567);
            this.rtbContent.TabIndex = 7;
            this.rtbContent.Text = "";
            // 
            // btnGetXPath
            // 
            this.btnGetXPath.Location = new System.Drawing.Point(24, 628);
            this.btnGetXPath.Name = "btnGetXPath";
            this.btnGetXPath.Size = new System.Drawing.Size(75, 23);
            this.btnGetXPath.TabIndex = 8;
            this.btnGetXPath.Text = "Get Xpath";
            this.btnGetXPath.UseVisualStyleBackColor = true;
            this.btnGetXPath.Click += new System.EventHandler(this.btnGetXPath_Click);
            // 
            // txbXPath
            // 
            this.txbXPath.Location = new System.Drawing.Point(116, 630);
            this.txbXPath.Name = "txbXPath";
            this.txbXPath.Size = new System.Drawing.Size(601, 20);
            this.txbXPath.TabIndex = 9;
            // 
            // cmbOperationType
            // 
            this.cmbOperationType.FormattingEnabled = true;
            this.cmbOperationType.Items.AddRange(new object[] {
            "AddNode",
            "UpdateValue",
            "DeleteNode",
            "RepalceFullRti"});
            this.cmbOperationType.Location = new System.Drawing.Point(116, 659);
            this.cmbOperationType.Name = "cmbOperationType";
            this.cmbOperationType.Size = new System.Drawing.Size(219, 21);
            this.cmbOperationType.TabIndex = 10;
            // 
            // lblOperationType
            // 
            this.lblOperationType.AutoSize = true;
            this.lblOperationType.Location = new System.Drawing.Point(29, 662);
            this.lblOperationType.Name = "lblOperationType";
            this.lblOperationType.Size = new System.Drawing.Size(80, 13);
            this.lblOperationType.TabIndex = 11;
            this.lblOperationType.Text = "Operation Type";
            // 
            // lblRtiType
            // 
            this.lblRtiType.AutoSize = true;
            this.lblRtiType.Location = new System.Drawing.Point(21, 22);
            this.lblRtiType.Name = "lblRtiType";
            this.lblRtiType.Size = new System.Drawing.Size(55, 13);
            this.lblRtiType.TabIndex = 12;
            this.lblRtiType.Text = "RTI Type:";
            // 
            // txbRtiType
            // 
            this.txbRtiType.Enabled = false;
            this.txbRtiType.Location = new System.Drawing.Point(82, 19);
            this.txbRtiType.Name = "txbRtiType";
            this.txbRtiType.Size = new System.Drawing.Size(97, 20);
            this.txbRtiType.TabIndex = 13;
            // 
            // txbServiceName
            // 
            this.txbServiceName.Enabled = false;
            this.txbServiceName.Location = new System.Drawing.Point(288, 19);
            this.txbServiceName.Name = "txbServiceName";
            this.txbServiceName.Size = new System.Drawing.Size(136, 20);
            this.txbServiceName.TabIndex = 15;
            // 
            // lblServiceName
            // 
            this.lblServiceName.AutoSize = true;
            this.lblServiceName.Location = new System.Drawing.Point(205, 22);
            this.lblServiceName.Name = "lblServiceName";
            this.lblServiceName.Size = new System.Drawing.Size(77, 13);
            this.lblServiceName.TabIndex = 14;
            this.lblServiceName.Text = "Service Name:";
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Location = new System.Drawing.Point(29, 691);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(47, 13);
            this.lblContent.TabIndex = 16;
            this.lblContent.Text = "Content:";
            // 
            // txbContent
            // 
            this.txbContent.Location = new System.Drawing.Point(116, 688);
            this.txbContent.Name = "txbContent";
            this.txbContent.Size = new System.Drawing.Size(219, 20);
            this.txbContent.TabIndex = 17;
            // 
            // btnAddOperation
            // 
            this.btnAddOperation.Location = new System.Drawing.Point(723, 628);
            this.btnAddOperation.Name = "btnAddOperation";
            this.btnAddOperation.Size = new System.Drawing.Size(84, 23);
            this.btnAddOperation.TabIndex = 8;
            this.btnAddOperation.Text = "Add Operation";
            this.btnAddOperation.UseVisualStyleBackColor = true;
            this.btnAddOperation.Click += new System.EventHandler(this.btnAddOperation_Click);
            // 
            // lblOperations
            // 
            this.lblOperations.AutoSize = true;
            this.lblOperations.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperations.Location = new System.Drawing.Point(835, 24);
            this.lblOperations.Name = "lblOperations";
            this.lblOperations.Size = new System.Drawing.Size(123, 15);
            this.lblOperations.TabIndex = 25;
            this.lblOperations.Text = "Operations on RTI";
            // 
            // lvOperations
            // 
            this.lvOperations.FullRowSelect = true;
            this.lvOperations.HideSelection = false;
            this.lvOperations.Location = new System.Drawing.Point(838, 42);
            this.lvOperations.MultiSelect = false;
            this.lvOperations.Name = "lvOperations";
            this.lvOperations.Size = new System.Drawing.Size(120, 166);
            this.lvOperations.TabIndex = 24;
            this.lvOperations.UseCompatibleStateImageBehavior = false;
            this.lvOperations.View = System.Windows.Forms.View.List;
            this.lvOperations.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvOperations_MouseClick);
            this.lvOperations.KeyDown += lvOperations_KeyDown;
            // 
            // RtiEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 749);
            this.Controls.Add(this.lblOperations);
            this.Controls.Add(this.lvOperations);
            this.Controls.Add(this.txbContent);
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.txbServiceName);
            this.Controls.Add(this.lblServiceName);
            this.Controls.Add(this.txbRtiType);
            this.Controls.Add(this.lblRtiType);
            this.Controls.Add(this.lblOperationType);
            this.Controls.Add(this.cmbOperationType);
            this.Controls.Add(this.txbXPath);
            this.Controls.Add(this.btnAddOperation);
            this.Controls.Add(this.btnGetXPath);
            this.Controls.Add(this.rtbContent);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RtiEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RtiEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RtiEditor_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbContent;
        private System.Windows.Forms.Button btnGetXPath;
        private System.Windows.Forms.TextBox txbXPath;
        private System.Windows.Forms.ComboBox cmbOperationType;
        private System.Windows.Forms.Label lblOperationType;
        private System.Windows.Forms.Label lblRtiType;
        private System.Windows.Forms.TextBox txbRtiType;
        private System.Windows.Forms.TextBox txbServiceName;
        private System.Windows.Forms.Label lblServiceName;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.TextBox txbContent;
        private System.Windows.Forms.Button btnAddOperation;
        private System.Windows.Forms.Label lblOperations;
        private System.Windows.Forms.ListView lvOperations;
    }
}