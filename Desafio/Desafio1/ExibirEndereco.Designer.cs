namespace Desafio1
{
    partial class ExibirEndereco
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
            this.lblCep = new System.Windows.Forms.Label();
            this.lblBairro = new System.Windows.Forms.Label();
            this.lblLocalidade = new System.Windows.Forms.Label();
            this.lblLogradouro = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCep
            // 
            this.lblCep.AutoSize = true;
            this.lblCep.Location = new System.Drawing.Point(12, 94);
            this.lblCep.Name = "lblCep";
            this.lblCep.Size = new System.Drawing.Size(35, 13);
            this.lblCep.TabIndex = 1;
            this.lblCep.Text = "label1";
            this.lblCep.Click += new System.EventHandler(this.lblCep_Click);
            // 
            // lblBairro
            // 
            this.lblBairro.AutoSize = true;
            this.lblBairro.Location = new System.Drawing.Point(12, 67);
            this.lblBairro.Name = "lblBairro";
            this.lblBairro.Size = new System.Drawing.Size(35, 13);
            this.lblBairro.TabIndex = 2;
            this.lblBairro.Text = "label1";
            this.lblBairro.Click += new System.EventHandler(this.lblBairro_Click);
            // 
            // lblLocalidade
            // 
            this.lblLocalidade.AutoSize = true;
            this.lblLocalidade.Location = new System.Drawing.Point(12, 38);
            this.lblLocalidade.Name = "lblLocalidade";
            this.lblLocalidade.Size = new System.Drawing.Size(35, 13);
            this.lblLocalidade.TabIndex = 3;
            this.lblLocalidade.Text = "label1";
            this.lblLocalidade.Click += new System.EventHandler(this.lblLocalidade_Click);
            // 
            // lblLogradouro
            // 
            this.lblLogradouro.AutoSize = true;
            this.lblLogradouro.Location = new System.Drawing.Point(12, 9);
            this.lblLogradouro.Name = "lblLogradouro";
            this.lblLogradouro.Size = new System.Drawing.Size(35, 13);
            this.lblLogradouro.TabIndex = 4;
            this.lblLogradouro.Text = "label1";
            this.lblLogradouro.Click += new System.EventHandler(this.lblLogradouro_Click);
            // 
            // ExibirEndereco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(167, 119);
            this.Controls.Add(this.lblCep);
            this.Controls.Add(this.lblBairro);
            this.Controls.Add(this.lblLocalidade);
            this.Controls.Add(this.lblLogradouro);
            this.Name = "ExibirEndereco";
            this.Text = "ExibirEndereco";
            this.Load += new System.EventHandler(this.ExibirEndereco_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCep;
        private System.Windows.Forms.Label lblBairro;
        private System.Windows.Forms.Label lblLocalidade;
        private System.Windows.Forms.Label lblLogradouro;
    }
}