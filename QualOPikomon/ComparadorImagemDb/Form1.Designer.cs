namespace ComparadorImagemDb
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
            this.btEncontrar = new System.Windows.Forms.Button();
            this.lblCadastrar = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btSelecionarImg = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btEncontrar
            // 
            this.btEncontrar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btEncontrar.Location = new System.Drawing.Point(46, 203);
            this.btEncontrar.Margin = new System.Windows.Forms.Padding(2);
            this.btEncontrar.Name = "btEncontrar";
            this.btEncontrar.Size = new System.Drawing.Size(144, 46);
            this.btEncontrar.TabIndex = 0;
            this.btEncontrar.Text = "Pesquisar";
            this.btEncontrar.UseVisualStyleBackColor = false;
            this.btEncontrar.Click += new System.EventHandler(this.btEncontrar_Click);
            // 
            // lblCadastrar
            // 
            this.lblCadastrar.AutoSize = true;
            this.lblCadastrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCadastrar.Location = new System.Drawing.Point(47, 266);
            this.lblCadastrar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCadastrar.Name = "lblCadastrar";
            this.lblCadastrar.Size = new System.Drawing.Size(143, 15);
            this.lblCadastrar.TabIndex = 1;
            this.lblCadastrar.TabStop = true;
            this.lblCadastrar.Text = "Cadastrar Novo Pikomon";
            this.lblCadastrar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCadastrar_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.btSelecionarImg);
            this.groupBox1.Controls.Add(this.lblCadastrar);
            this.groupBox1.Controls.Add(this.btEncontrar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(39, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(237, 300);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selecione um pikomon";
            // 
            // btSelecionarImg
            // 
            this.btSelecionarImg.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btSelecionarImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btSelecionarImg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSelecionarImg.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btSelecionarImg.Location = new System.Drawing.Point(46, 30);
            this.btSelecionarImg.Margin = new System.Windows.Forms.Padding(2);
            this.btSelecionarImg.Name = "btSelecionarImg";
            this.btSelecionarImg.Size = new System.Drawing.Size(144, 145);
            this.btSelecionarImg.TabIndex = 0;
            this.btSelecionarImg.UseVisualStyleBackColor = false;
            this.btSelecionarImg.Click += new System.EventHandler(this.btSelecionarImg_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 343);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Pesquisa";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btEncontrar;
        private System.Windows.Forms.Button btSelecionarImg;
        private System.Windows.Forms.LinkLabel lblCadastrar;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

