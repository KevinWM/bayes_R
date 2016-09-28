namespace prograIA2
{
    partial class Form1
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.CantiCorreosLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.correoText = new System.Windows.Forms.TextBox();
            this.contrasenaText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.CantTweetsLabel = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.usuarioTwitterText = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.nombreClasiText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.clasificarDocuComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nombreDocumenTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(789, 426);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Analizar Correos";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.CantiCorreosLabel);
            this.splitContainer2.Panel1.Controls.Add(this.button2);
            this.splitContainer2.Panel1.Controls.Add(this.button1);
            this.splitContainer2.Panel1.Controls.Add(this.correoText);
            this.splitContainer2.Panel1.Controls.Add(this.contrasenaText);
            this.splitContainer2.Panel1.Controls.Add(this.label6);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(783, 417);
            this.splitContainer2.SplitterDistance = 339;
            this.splitContainer2.TabIndex = 11;
            // 
            // CantiCorreosLabel
            // 
            this.CantiCorreosLabel.AutoSize = true;
            this.CantiCorreosLabel.Location = new System.Drawing.Point(96, 282);
            this.CantiCorreosLabel.Name = "CantiCorreosLabel";
            this.CantiCorreosLabel.Size = new System.Drawing.Size(0, 13);
            this.CantiCorreosLabel.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(206, 220);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 30);
            this.button2.TabIndex = 3;
            this.button2.Text = "Analizar Correos";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.analizarCorreos);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(67, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "Descargar Correos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.descargarCorreos);
            // 
            // correoText
            // 
            this.correoText.Location = new System.Drawing.Point(99, 142);
            this.correoText.Name = "correoText";
            this.correoText.Size = new System.Drawing.Size(150, 20);
            this.correoText.TabIndex = 4;
            // 
            // contrasenaText
            // 
            this.contrasenaText.Location = new System.Drawing.Point(99, 168);
            this.contrasenaText.Name = "contrasenaText";
            this.contrasenaText.PasswordChar = '*';
            this.contrasenaText.Size = new System.Drawing.Size(150, 20);
            this.contrasenaText.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Contraseña:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Correo:";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.CantTweetsLabel);
            this.splitContainer3.Panel1.Controls.Add(this.button7);
            this.splitContainer3.Panel1.Controls.Add(this.button5);
            this.splitContainer3.Panel1.Controls.Add(this.label7);
            this.splitContainer3.Panel1.Controls.Add(this.usuarioTwitterText);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.button6);
            this.splitContainer3.Panel2.Controls.Add(this.label8);
            this.splitContainer3.Panel2.Controls.Add(this.textBox2);
            this.splitContainer3.Size = new System.Drawing.Size(440, 417);
            this.splitContainer3.SplitterDistance = 190;
            this.splitContainer3.TabIndex = 0;
            // 
            // CantTweetsLabel
            // 
            this.CantTweetsLabel.AutoSize = true;
            this.CantTweetsLabel.Location = new System.Drawing.Point(126, 130);
            this.CantTweetsLabel.Name = "CantTweetsLabel";
            this.CantTweetsLabel.Size = new System.Drawing.Size(0, 13);
            this.CantTweetsLabel.TabIndex = 14;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(276, 44);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(115, 30);
            this.button7.TabIndex = 11;
            this.button7.Text = "Descargar Tweets";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.ejecutarScriptR);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(276, 91);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(115, 30);
            this.button5.TabIndex = 10;
            this.button5.Text = "Analizar Tweets";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.analizarTweets);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Usuario Twitter:";
            // 
            // usuarioTwitterText
            // 
            this.usuarioTwitterText.Location = new System.Drawing.Point(129, 54);
            this.usuarioTwitterText.Multiline = true;
            this.usuarioTwitterText.Name = "usuarioTwitterText";
            this.usuarioTwitterText.Size = new System.Drawing.Size(119, 20);
            this.usuarioTwitterText.TabIndex = 9;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(276, 135);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(94, 30);
            this.button6.TabIndex = 13;
            this.button6.Text = "Analizar";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(42, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Link HTML:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(129, 81);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(241, 20);
            this.textBox2.TabIndex = 12;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-1, -2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(797, 452);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(789, 426);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Entrenar IA";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.button3);
            this.splitContainer1.Panel1.Controls.Add(this.nombreClasiText);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.button4);
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox1);
            this.splitContainer1.Panel2.Controls.Add(this.clasificarDocuComboBox);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.nombreDocumenTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(783, 420);
            this.splitContainer1.SplitterDistance = 108;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Nombre Categoria";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(367, 40);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(74, 28);
            this.button3.TabIndex = 11;
            this.button3.Text = "Agregar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.agregarClasificacion);
            // 
            // nombreClasiText
            // 
            this.nombreClasiText.Location = new System.Drawing.Point(222, 45);
            this.nombreClasiText.Name = "nombreClasiText";
            this.nombreClasiText.Size = new System.Drawing.Size(120, 20);
            this.nombreClasiText.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Categoria";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(659, 228);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(74, 29);
            this.button4.TabIndex = 14;
            this.button4.Text = "Agregar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.agregarTextoDocumento);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(196, 35);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(409, 222);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            // 
            // clasificarDocuComboBox
            // 
            this.clasificarDocuComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clasificarDocuComboBox.FormattingEnabled = true;
            this.clasificarDocuComboBox.Location = new System.Drawing.Point(30, 106);
            this.clasificarDocuComboBox.Name = "clasificarDocuComboBox";
            this.clasificarDocuComboBox.Size = new System.Drawing.Size(120, 21);
            this.clasificarDocuComboBox.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(202, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Texto";
            // 
            // nombreDocumenTextBox
            // 
            this.nombreDocumenTextBox.Location = new System.Drawing.Point(30, 170);
            this.nombreDocumenTextBox.Name = "nombreDocumenTextBox";
            this.nombreDocumenTextBox.Size = new System.Drawing.Size(120, 20);
            this.nombreDocumenTextBox.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Nombre Documento";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 443);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabPage1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox nombreClasiText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox clasificarDocuComboBox;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox nombreDocumenTextBox;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox contrasenaText;
        private System.Windows.Forms.TextBox correoText;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox usuarioTwitterText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label CantiCorreosLabel;
        private System.Windows.Forms.Label CantTweetsLabel;


    }
}

