namespace CardFileExporter {
	partial class Form1 {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.label1 = new System.Windows.Forms.Label();
			this.tb_Filename = new System.Windows.Forms.TextBox();
			this.b_go = new System.Windows.Forms.Button();
			this.rtb_Msg = new System.Windows.Forms.RichTextBox();
			this.cbDoLogging = new System.Windows.Forms.CheckBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.b_Browse = new System.Windows.Forms.Button();
			this.SuspendLayout();
			//
			// label1
			//
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(40, 55);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Filename";
			//
			// tb_Filename
			//
			this.tb_Filename.Location = new System.Drawing.Point(95, 55);
			this.tb_Filename.Name = "tb_Filename";
			this.tb_Filename.Size = new System.Drawing.Size(263, 20);
			this.tb_Filename.TabIndex = 2;
			this.tb_Filename.TextChanged += new System.EventHandler(this.tbFilename_TextChanged);
			//
			// b_go
			//
			this.b_go.Location = new System.Drawing.Point(182, 95);
			this.b_go.Name = "b_go";
			this.b_go.Size = new System.Drawing.Size(83, 23);
			this.b_go.TabIndex = 4;
			this.b_go.Text = "Export to XML";
			this.b_go.UseVisualStyleBackColor = true;
			this.b_go.Click += new System.EventHandler(this.b_go_Click);
			//
			// rtb_Msg
			//
			this.rtb_Msg.BackColor = System.Drawing.SystemColors.ControlLight;
			this.rtb_Msg.Enabled = false;
			this.rtb_Msg.ForeColor = System.Drawing.Color.Maroon;
			this.rtb_Msg.Location = new System.Drawing.Point(13, 283);
			this.rtb_Msg.Name = "rtb_Msg";
			this.rtb_Msg.Size = new System.Drawing.Size(605, 26);
			this.rtb_Msg.TabIndex = 5;
			this.rtb_Msg.Text = "";
			//
			// cbDoLogging
			//
			this.cbDoLogging.AutoSize = true;
			this.cbDoLogging.Enabled = false;
			this.cbDoLogging.Location = new System.Drawing.Point(387, 57);
			this.cbDoLogging.Name = "cbDoLogging";
			this.cbDoLogging.Size = new System.Drawing.Size(70, 17);
			this.cbDoLogging.TabIndex = 3;
			this.cbDoLogging.Text = "Logging?";
			this.cbDoLogging.UseVisualStyleBackColor = true;
			this.cbDoLogging.Visible = false;
			//
			// openFileDialog1
			//
			this.openFileDialog1.DefaultExt = "\"crd\"";
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.ReadOnlyChecked = true;
			//
			// b_Browse
			//
			this.b_Browse.Location = new System.Drawing.Point(95, 24);
			this.b_Browse.Name = "b_Browse";
			this.b_Browse.Size = new System.Drawing.Size(75, 23);
			this.b_Browse.TabIndex = 0;
			this.b_Browse.Text = "Browse";
			this.b_Browse.UseVisualStyleBackColor = true;
			this.b_Browse.Click += new System.EventHandler(this.b_Browse_Click);
			//
			// Form1
			//
			this.AcceptButton = this.b_go;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(630, 334);
			this.Controls.Add(this.b_Browse);
			this.Controls.Add(this.cbDoLogging);
			this.Controls.Add(this.rtb_Msg);
			this.Controls.Add(this.b_go);
			this.Controls.Add(this.tb_Filename);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "CardFileExporter";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tb_Filename;
		private System.Windows.Forms.Button b_go;
		private System.Windows.Forms.RichTextBox rtb_Msg;
		private System.Windows.Forms.CheckBox cbDoLogging;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button b_Browse;
	}
}

