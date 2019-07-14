namespace GradientPicker
{
    partial class GradientPickerForm
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
            this.SourcePictureBox = new System.Windows.Forms.PictureBox();
            this.GradientGroupBox = new System.Windows.Forms.GroupBox();
            this.GradientLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.GradientPictureBox = new System.Windows.Forms.PictureBox();
            this.SourceGroupBox = new System.Windows.Forms.GroupBox();
            this.SourceFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ToolsGroupBox = new System.Windows.Forms.GroupBox();
            this.GradientWidthLabel = new System.Windows.Forms.Label();
            this.GradientWidthComboBox = new System.Windows.Forms.ComboBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.NewSessionButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SourcePictureBox)).BeginInit();
            this.GradientGroupBox.SuspendLayout();
            this.GradientLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GradientPictureBox)).BeginInit();
            this.SourceGroupBox.SuspendLayout();
            this.SourceFlowLayoutPanel.SuspendLayout();
            this.TableLayoutPanel.SuspendLayout();
            this.ToolsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SourcePictureBox
            // 
            this.SourcePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SourcePictureBox.Location = new System.Drawing.Point(3, 3);
            this.SourcePictureBox.Name = "SourcePictureBox";
            this.SourcePictureBox.Size = new System.Drawing.Size(200, 200);
            this.SourcePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.SourcePictureBox.TabIndex = 2;
            this.SourcePictureBox.TabStop = false;
            this.SourcePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.sourcePictureBox_Paint);
            this.SourcePictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SourcePictureBox_MouseDown_1);
            this.SourcePictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SourcePictureBox_MouseMove_1);
            this.SourcePictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SourcePictureBox_MouseUp);
            // 
            // GradientGroupBox
            // 
            this.GradientGroupBox.Controls.Add(this.GradientLayoutPanel);
            this.GradientGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GradientGroupBox.Location = new System.Drawing.Point(3, 61);
            this.GradientGroupBox.Name = "GradientGroupBox";
            this.GradientGroupBox.Size = new System.Drawing.Size(1258, 73);
            this.GradientGroupBox.TabIndex = 5;
            this.GradientGroupBox.TabStop = false;
            this.GradientGroupBox.Text = "Gradient";
            // 
            // GradientLayoutPanel
            // 
            this.GradientLayoutPanel.AutoScroll = true;
            this.GradientLayoutPanel.AutoSize = true;
            this.GradientLayoutPanel.Controls.Add(this.GradientPictureBox);
            this.GradientLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GradientLayoutPanel.Location = new System.Drawing.Point(3, 16);
            this.GradientLayoutPanel.Name = "GradientLayoutPanel";
            this.GradientLayoutPanel.Size = new System.Drawing.Size(1252, 54);
            this.GradientLayoutPanel.TabIndex = 4;
            // 
            // GradientPictureBox
            // 
            this.GradientPictureBox.Location = new System.Drawing.Point(3, 3);
            this.GradientPictureBox.Name = "GradientPictureBox";
            this.GradientPictureBox.Size = new System.Drawing.Size(128, 25);
            this.GradientPictureBox.TabIndex = 3;
            this.GradientPictureBox.TabStop = false;
            // 
            // SourceGroupBox
            // 
            this.SourceGroupBox.Controls.Add(this.SourceFlowLayoutPanel);
            this.SourceGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SourceGroupBox.Location = new System.Drawing.Point(3, 140);
            this.SourceGroupBox.Name = "SourceGroupBox";
            this.SourceGroupBox.Size = new System.Drawing.Size(1258, 538);
            this.SourceGroupBox.TabIndex = 6;
            this.SourceGroupBox.TabStop = false;
            this.SourceGroupBox.Text = "Source Image";
            // 
            // SourceFlowLayoutPanel
            // 
            this.SourceFlowLayoutPanel.AutoScroll = true;
            this.SourceFlowLayoutPanel.Controls.Add(this.SourcePictureBox);
            this.SourceFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SourceFlowLayoutPanel.Location = new System.Drawing.Point(3, 16);
            this.SourceFlowLayoutPanel.Name = "SourceFlowLayoutPanel";
            this.SourceFlowLayoutPanel.Size = new System.Drawing.Size(1252, 519);
            this.SourceFlowLayoutPanel.TabIndex = 3;
            // 
            // TableLayoutPanel
            // 
            this.TableLayoutPanel.ColumnCount = 1;
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutPanel.Controls.Add(this.GradientGroupBox, 0, 1);
            this.TableLayoutPanel.Controls.Add(this.SourceGroupBox, 0, 2);
            this.TableLayoutPanel.Controls.Add(this.ToolsGroupBox, 0, 0);
            this.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel.Name = "TableLayoutPanel";
            this.TableLayoutPanel.RowCount = 3;
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel.Size = new System.Drawing.Size(1264, 681);
            this.TableLayoutPanel.TabIndex = 7;
            // 
            // ToolsGroupBox
            // 
            this.ToolsGroupBox.Controls.Add(this.GradientWidthLabel);
            this.ToolsGroupBox.Controls.Add(this.GradientWidthComboBox);
            this.ToolsGroupBox.Controls.Add(this.SaveButton);
            this.ToolsGroupBox.Controls.Add(this.NewSessionButton);
            this.ToolsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolsGroupBox.Location = new System.Drawing.Point(3, 3);
            this.ToolsGroupBox.Name = "ToolsGroupBox";
            this.ToolsGroupBox.Size = new System.Drawing.Size(1258, 52);
            this.ToolsGroupBox.TabIndex = 7;
            this.ToolsGroupBox.TabStop = false;
            this.ToolsGroupBox.Text = "Tools";
            // 
            // GradientWidthLabel
            // 
            this.GradientWidthLabel.AutoSize = true;
            this.GradientWidthLabel.Location = new System.Drawing.Point(188, 24);
            this.GradientWidthLabel.Name = "GradientWidthLabel";
            this.GradientWidthLabel.Size = new System.Drawing.Size(78, 13);
            this.GradientWidthLabel.TabIndex = 7;
            this.GradientWidthLabel.Text = "Gradient Width";
            // 
            // GradientWidthComboBox
            // 
            this.GradientWidthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GradientWidthComboBox.FormattingEnabled = true;
            this.GradientWidthComboBox.Location = new System.Drawing.Point(272, 21);
            this.GradientWidthComboBox.Name = "GradientWidthComboBox";
            this.GradientWidthComboBox.Size = new System.Drawing.Size(121, 21);
            this.GradientWidthComboBox.TabIndex = 6;
            this.GradientWidthComboBox.SelectionChangeCommitted += new System.EventHandler(this.GradientWidthComboBox_SelectionChangeCommitted);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(447, 19);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(126, 23);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // NewSessionButton
            // 
            this.NewSessionButton.Location = new System.Drawing.Point(6, 19);
            this.NewSessionButton.Name = "NewSessionButton";
            this.NewSessionButton.Size = new System.Drawing.Size(141, 23);
            this.NewSessionButton.TabIndex = 4;
            this.NewSessionButton.Text = "New Session";
            this.NewSessionButton.UseVisualStyleBackColor = true;
            this.NewSessionButton.Click += new System.EventHandler(this.NewSessionButton_Click);
            // 
            // GradientPickerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.TableLayoutPanel);
            this.Name = "GradientPickerForm";
            this.Text = "Gradient Picker";
            ((System.ComponentModel.ISupportInitialize)(this.SourcePictureBox)).EndInit();
            this.GradientGroupBox.ResumeLayout(false);
            this.GradientGroupBox.PerformLayout();
            this.GradientLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GradientPictureBox)).EndInit();
            this.SourceGroupBox.ResumeLayout(false);
            this.SourceFlowLayoutPanel.ResumeLayout(false);
            this.SourceFlowLayoutPanel.PerformLayout();
            this.TableLayoutPanel.ResumeLayout(false);
            this.ToolsGroupBox.ResumeLayout(false);
            this.ToolsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox SourcePictureBox;
        private System.Windows.Forms.GroupBox GradientGroupBox;
        private System.Windows.Forms.GroupBox SourceGroupBox;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanel;
        private System.Windows.Forms.GroupBox ToolsGroupBox;
        private System.Windows.Forms.Button NewSessionButton;
        private System.Windows.Forms.PictureBox GradientPictureBox;
        private System.Windows.Forms.FlowLayoutPanel SourceFlowLayoutPanel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.FlowLayoutPanel GradientLayoutPanel;
        private System.Windows.Forms.ComboBox GradientWidthComboBox;
        private System.Windows.Forms.Label GradientWidthLabel;
    }
}

