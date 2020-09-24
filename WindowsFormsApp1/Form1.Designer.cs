namespace ErmesConn
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtChaff = new System.Windows.Forms.TextBox();
            this.txtLights = new System.Windows.Forms.TextBox();
            this.lblChaff = new System.Windows.Forms.Label();
            this.lblLights = new System.Windows.Forms.Label();
            this.cbCOM = new System.Windows.Forms.ComboBox();
            this.cbCOMff = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnStartFF = new System.Windows.Forms.Button();
            this.txtData = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStrip2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsBMS = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Typewriter", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(112, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(406, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aplicación de pruebas ErmesConnector";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(129, 39);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(74, 21);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(388, 92);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(130, 20);
            this.txtStatus.TabIndex = 2;
            // 
            // txtChaff
            // 
            this.txtChaff.Location = new System.Drawing.Point(387, 147);
            this.txtChaff.Name = "txtChaff";
            this.txtChaff.Size = new System.Drawing.Size(130, 20);
            this.txtChaff.TabIndex = 3;
            // 
            // txtLights
            // 
            this.txtLights.Location = new System.Drawing.Point(388, 201);
            this.txtLights.Name = "txtLights";
            this.txtLights.Size = new System.Drawing.Size(130, 20);
            this.txtLights.TabIndex = 4;
            // 
            // lblChaff
            // 
            this.lblChaff.AutoSize = true;
            this.lblChaff.Location = new System.Drawing.Point(393, 132);
            this.lblChaff.Name = "lblChaff";
            this.lblChaff.Size = new System.Drawing.Size(32, 13);
            this.lblChaff.TabIndex = 5;
            this.lblChaff.Text = "Chaff";
            // 
            // lblLights
            // 
            this.lblLights.AutoSize = true;
            this.lblLights.Location = new System.Drawing.Point(392, 185);
            this.lblLights.Name = "lblLights";
            this.lblLights.Size = new System.Drawing.Size(35, 13);
            this.lblLights.TabIndex = 6;
            this.lblLights.Text = "Lights";
            // 
            // cbCOM
            // 
            this.cbCOM.FormattingEnabled = true;
            this.cbCOM.Location = new System.Drawing.Point(25, 40);
            this.cbCOM.Name = "cbCOM";
            this.cbCOM.Size = new System.Drawing.Size(98, 21);
            this.cbCOM.TabIndex = 8;
            // 
            // cbCOMff
            // 
            this.cbCOMff.FormattingEnabled = true;
            this.cbCOMff.Location = new System.Drawing.Point(25, 102);
            this.cbCOMff.Name = "cbCOMff";
            this.cbCOMff.Size = new System.Drawing.Size(98, 21);
            this.cbCOMff.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Fuel Flow 14";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "ICP/Misc 13";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnStartFF);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbCOMff);
            this.groupBox1.Controls.Add(this.cbCOM);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Location = new System.Drawing.Point(115, 185);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 187);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "COM";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 159);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 22);
            this.button1.TabIndex = 17;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnStartFF
            // 
            this.btnStartFF.Location = new System.Drawing.Point(129, 102);
            this.btnStartFF.Name = "btnStartFF";
            this.btnStartFF.Size = new System.Drawing.Size(74, 21);
            this.btnStartFF.TabIndex = 15;
            this.btnStartFF.Text = "Start";
            this.btnStartFF.UseVisualStyleBackColor = true;
            this.btnStartFF.Click += new System.EventHandler(this.btnStartFF_Click);
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(392, 277);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(125, 20);
            this.txtData.TabIndex = 7;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStrip,
            this.tsStrip2,
            this.tsBMS});
            this.statusStrip1.Location = new System.Drawing.Point(0, 416);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(745, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsStrip
            // 
            this.tsStrip.AutoSize = false;
            this.tsStrip.Name = "tsStrip";
            this.tsStrip.Size = new System.Drawing.Size(150, 17);
            this.tsStrip.Text = "tsStrip";
            this.tsStrip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsStrip2
            // 
            this.tsStrip2.AutoSize = false;
            this.tsStrip2.Name = "tsStrip2";
            this.tsStrip2.Size = new System.Drawing.Size(150, 17);
            this.tsStrip2.Text = "tsStrip2";
            this.tsStrip2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsBMS
            // 
            this.tsBMS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBMS.Name = "tsBMS";
            this.tsBMS.Size = new System.Drawing.Size(430, 17);
            this.tsBMS.Spring = true;
            this.tsBMS.Text = "tsBMS";
            this.tsBMS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 438);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.lblLights);
            this.Controls.Add(this.lblChaff);
            this.Controls.Add(this.txtLights);
            this.Controls.Add(this.txtChaff);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtChaff;
        private System.Windows.Forms.TextBox txtLights;
        private System.Windows.Forms.Label lblChaff;
        private System.Windows.Forms.Label lblLights;
        private System.Windows.Forms.ComboBox cbCOM;
        private System.Windows.Forms.ComboBox cbCOMff;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Button btnStartFF;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsStrip;
        private System.Windows.Forms.ToolStripStatusLabel tsStrip2;
        private System.Windows.Forms.ToolStripStatusLabel tsBMS;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
    }
}

