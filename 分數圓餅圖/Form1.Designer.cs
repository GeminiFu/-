namespace 分數圓餅圖
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.num_Radius = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.num_Section = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rb_Draw_2 = new System.Windows.Forms.RadioButton();
            this.rb_Draw_1 = new System.Windows.Forms.RadioButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbl_Section1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_Section2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.num_Radius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Section)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(228, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "半徑：";
            // 
            // num_Radius
            // 
            this.num_Radius.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.num_Radius.Location = new System.Drawing.Point(307, 60);
            this.num_Radius.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_Radius.Name = "num_Radius";
            this.num_Radius.Size = new System.Drawing.Size(52, 33);
            this.num_Radius.TabIndex = 4;
            this.num_Radius.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.num_Radius.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(228, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "分母：";
            // 
            // num_Section
            // 
            this.num_Section.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.num_Section.Location = new System.Drawing.Point(307, 99);
            this.num_Section.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_Section.Name = "num_Section";
            this.num_Section.Size = new System.Drawing.Size(52, 33);
            this.num_Section.TabIndex = 4;
            this.num_Section.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.num_Section.ValueChanged += new System.EventHandler(this.num_Section_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rb_Draw_2);
            this.panel1.Controls.Add(this.rb_Draw_1);
            this.panel1.Location = new System.Drawing.Point(38, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(161, 56);
            this.panel1.TabIndex = 5;
            // 
            // rb_Draw_2
            // 
            this.rb_Draw_2.AutoSize = true;
            this.rb_Draw_2.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rb_Draw_2.Location = new System.Drawing.Point(3, 28);
            this.rb_Draw_2.Name = "rb_Draw_2";
            this.rb_Draw_2.Size = new System.Drawing.Size(154, 25);
            this.rb_Draw_2.TabIndex = 0;
            this.rb_Draw_2.TabStop = true;
            this.rb_Draw_2.Text = "畫第二個圓餅";
            this.rb_Draw_2.UseVisualStyleBackColor = true;
            this.rb_Draw_2.CheckedChanged += new System.EventHandler(this.rb_Draw_2_CheckedChanged);
            // 
            // rb_Draw_1
            // 
            this.rb_Draw_1.AutoSize = true;
            this.rb_Draw_1.Checked = true;
            this.rb_Draw_1.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rb_Draw_1.Location = new System.Drawing.Point(3, 3);
            this.rb_Draw_1.Name = "rb_Draw_1";
            this.rb_Draw_1.Size = new System.Drawing.Size(154, 25);
            this.rb_Draw_1.TabIndex = 0;
            this.rb_Draw_1.TabStop = true;
            this.rb_Draw_1.Text = "畫第一個圓餅";
            this.rb_Draw_1.UseVisualStyleBackColor = true;
            this.rb_Draw_1.CheckedChanged += new System.EventHandler(this.rb_Draw_1_CheckedChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(38, 138);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbl_Section1);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lbl_Section2);
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox2);
            this.splitContainer1.Size = new System.Drawing.Size(869, 420);
            this.splitContainer1.SplitterDistance = 421;
            this.splitContainer1.TabIndex = 6;
            // 
            // lbl_Section1
            // 
            this.lbl_Section1.AutoSize = true;
            this.lbl_Section1.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbl_Section1.Location = new System.Drawing.Point(3, 9);
            this.lbl_Section1.Name = "lbl_Section1";
            this.lbl_Section1.Size = new System.Drawing.Size(86, 32);
            this.lbl_Section1.TabIndex = 7;
            this.lbl_Section1.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(421, 420);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.ClientSizeChanged += new System.EventHandler(this.pictureBox1_ClientSizeChanged);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // lbl_Section2
            // 
            this.lbl_Section2.AutoSize = true;
            this.lbl_Section2.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbl_Section2.Location = new System.Drawing.Point(3, 9);
            this.lbl_Section2.Name = "lbl_Section2";
            this.lbl_Section2.Size = new System.Drawing.Size(86, 32);
            this.lbl_Section2.TabIndex = 7;
            this.lbl_Section2.Text = "label1";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(444, 420);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
            this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseMove);
            this.pictureBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(32, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 32);
            this.label1.TabIndex = 7;
            this.label1.Text = "分數圓餅圖產生器";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 588);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.num_Section);
            this.Controls.Add(this.num_Radius);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "Form1";
            this.Text = "分數圓餅圖產生器";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.num_Radius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Section)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown num_Radius;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown num_Section;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rb_Draw_1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RadioButton rb_Draw_2;
        private System.Windows.Forms.Label lbl_Section1;
        private System.Windows.Forms.Label lbl_Section2;
        private System.Windows.Forms.Label label1;
    }
}

