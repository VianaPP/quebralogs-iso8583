namespace Mensagem_ISO8583
{
    partial class FormISO
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
            this.txt_Log = new System.Windows.Forms.TextBox();
            this.btn_reinicia = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btn_quebra = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_Log
            // 
            this.txt_Log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(90)))));
            this.txt_Log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Log.Font = new System.Drawing.Font("Arial", 9F);
            this.txt_Log.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(242)))));
            this.txt_Log.Location = new System.Drawing.Point(12, 16);
            this.txt_Log.Multiline = true;
            this.txt_Log.Name = "txt_Log";
            this.txt_Log.Size = new System.Drawing.Size(318, 310);
            this.txt_Log.TabIndex = 0;
            // 
            // btn_reinicia
            // 
            this.btn_reinicia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(147)))), ((int)(((byte)(249)))));
            this.btn_reinicia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_reinicia.Enabled = false;
            this.btn_reinicia.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btn_reinicia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(54)))));
            this.btn_reinicia.Location = new System.Drawing.Point(352, 332);
            this.btn_reinicia.Name = "btn_reinicia";
            this.btn_reinicia.Size = new System.Drawing.Size(318, 32);
            this.btn_reinicia.TabIndex = 74;
            this.btn_reinicia.Text = "Reiniciar";
            this.btn_reinicia.UseVisualStyleBackColor = false;
            this.btn_reinicia.Visible = false;
            this.btn_reinicia.Click += new System.EventHandler(this.btn_reinicia_Click);
            // 
            // txtResult
            // 
            this.txtResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(90)))));
            this.txtResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtResult.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.txtResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(242)))));
            this.txtResult.Location = new System.Drawing.Point(352, 16);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(318, 310);
            this.txtResult.TabIndex = 75;
            // 
            // btn_quebra
            // 
            this.btn_quebra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(147)))), ((int)(((byte)(249)))));
            this.btn_quebra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_quebra.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btn_quebra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(54)))));
            this.btn_quebra.Location = new System.Drawing.Point(12, 330);
            this.btn_quebra.Name = "btn_quebra";
            this.btn_quebra.Size = new System.Drawing.Size(318, 32);
            this.btn_quebra.TabIndex = 76;
            this.btn_quebra.Text = "Quebrar";
            this.btn_quebra.UseVisualStyleBackColor = false;
            this.btn_quebra.Click += new System.EventHandler(this.btn_quebra_click);
            // 
            // FormISO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(689, 374);
            this.Controls.Add(this.btn_quebra);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btn_reinicia);
            this.Controls.Add(this.txt_Log);
            this.Name = "FormISO";
            this.Text = "ISO8583";
            this.Load += new System.EventHandler(this.FormISO_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Log;
        private System.Windows.Forms.Button btn_reinicia;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btn_quebra;

    }
}

