namespace ColorfulRain
{
    partial class RainWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RainWindow));
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.SpeedBar = new System.Windows.Forms.TrackBar();
            this.brash = new System.Windows.Forms.Button();
            this.DenseBar = new System.Windows.Forms.TrackBar();
            this.windy = new System.Windows.Forms.Button();
            this.DegreeBar = new System.Windows.Forms.TrackBar();
            this.lightning = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.DegreeLab = new System.Windows.Forms.Label();
            this.DenseLab = new System.Windows.Forms.Label();
            this.SpeedLab = new System.Windows.Forms.Label();
            this.classLab = new System.Windows.Forms.Label();
            this.numLab = new System.Windows.Forms.Label();
            this.nameLab = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DenseBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DegreeBar)).BeginInit();
            this.SuspendLayout();
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(12, 562);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(75, 38);
            this.axWindowsMediaPlayer1.TabIndex = 6;
            this.axWindowsMediaPlayer1.Visible = false;
            // 
            // SpeedBar
            // 
            this.SpeedBar.Location = new System.Drawing.Point(1043, 281);
            this.SpeedBar.Name = "SpeedBar";
            this.SpeedBar.Size = new System.Drawing.Size(130, 45);
            this.SpeedBar.TabIndex = 3;
            this.SpeedBar.Scroll += new System.EventHandler(this.SpeedBar_Scroll);
            // 
            // brash
            // 
            this.brash.Location = new System.Drawing.Point(1043, 379);
            this.brash.Name = "brash";
            this.brash.Size = new System.Drawing.Size(130, 23);
            this.brash.TabIndex = 2;
            this.brash.Text = "时细时骤";
            this.brash.UseVisualStyleBackColor = true;
            this.brash.Click += new System.EventHandler(this.brash_Click);
            // 
            // DenseBar
            // 
            this.DenseBar.Location = new System.Drawing.Point(1043, 238);
            this.DenseBar.Name = "DenseBar";
            this.DenseBar.Size = new System.Drawing.Size(130, 45);
            this.DenseBar.TabIndex = 4;
            this.DenseBar.Scroll += new System.EventHandler(this.DenseBar_Scroll);
            // 
            // windy
            // 
            this.windy.Location = new System.Drawing.Point(1043, 356);
            this.windy.Name = "windy";
            this.windy.Size = new System.Drawing.Size(130, 23);
            this.windy.TabIndex = 1;
            this.windy.Text = "风雨飘摇";
            this.windy.UseVisualStyleBackColor = true;
            this.windy.Click += new System.EventHandler(this.windy_Click);
            // 
            // DegreeBar
            // 
            this.DegreeBar.Location = new System.Drawing.Point(1043, 195);
            this.DegreeBar.Name = "DegreeBar";
            this.DegreeBar.Size = new System.Drawing.Size(130, 45);
            this.DegreeBar.TabIndex = 5;
            this.DegreeBar.Scroll += new System.EventHandler(this.DegreeBar_Scroll);
            // 
            // lightning
            // 
            this.lightning.Location = new System.Drawing.Point(1043, 333);
            this.lightning.Name = "lightning";
            this.lightning.Size = new System.Drawing.Size(130, 23);
            this.lightning.TabIndex = 0;
            this.lightning.Text = "电闪雷鸣";
            this.lightning.UseVisualStyleBackColor = true;
            this.lightning.Click += new System.EventHandler(this.lightning_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(1043, 310);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(130, 23);
            this.StopButton.TabIndex = 7;
            this.StopButton.Text = "停雨";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // DegreeLab
            // 
            this.DegreeLab.AutoSize = true;
            this.DegreeLab.Location = new System.Drawing.Point(1011, 198);
            this.DegreeLab.Name = "DegreeLab";
            this.DegreeLab.Size = new System.Drawing.Size(29, 12);
            this.DegreeLab.TabIndex = 8;
            this.DegreeLab.Text = "风向";
            // 
            // DenseLab
            // 
            this.DenseLab.AutoSize = true;
            this.DenseLab.Location = new System.Drawing.Point(1011, 243);
            this.DenseLab.Name = "DenseLab";
            this.DenseLab.Size = new System.Drawing.Size(29, 12);
            this.DenseLab.TabIndex = 9;
            this.DenseLab.Text = "密度";
            // 
            // SpeedLab
            // 
            this.SpeedLab.AutoSize = true;
            this.SpeedLab.Location = new System.Drawing.Point(1011, 285);
            this.SpeedLab.Name = "SpeedLab";
            this.SpeedLab.Size = new System.Drawing.Size(29, 12);
            this.SpeedLab.TabIndex = 10;
            this.SpeedLab.Text = "速度";
            // 
            // classLab
            // 
            this.classLab.AutoSize = true;
            this.classLab.Location = new System.Drawing.Point(1120, 576);
            this.classLab.Name = "classLab";
            this.classLab.Size = new System.Drawing.Size(59, 12);
            this.classLab.TabIndex = 11;
            this.classLab.Text = "14软件1班";
            // 
            // numLab
            // 
            this.numLab.AutoSize = true;
            this.numLab.Location = new System.Drawing.Point(1114, 588);
            this.numLab.Name = "numLab";
            this.numLab.Size = new System.Drawing.Size(65, 12);
            this.numLab.TabIndex = 12;
            this.numLab.Text = "3114006174";
            // 
            // nameLab
            // 
            this.nameLab.AutoSize = true;
            this.nameLab.Location = new System.Drawing.Point(1138, 600);
            this.nameLab.Name = "nameLab";
            this.nameLab.Size = new System.Drawing.Size(41, 12);
            this.nameLab.TabIndex = 13;
            this.nameLab.Text = "邓苏城";
            // 
            // RainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 648);
            this.Controls.Add(this.nameLab);
            this.Controls.Add(this.numLab);
            this.Controls.Add(this.classLab);
            this.Controls.Add(this.SpeedLab);
            this.Controls.Add(this.DenseLab);
            this.Controls.Add(this.DegreeLab);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.DegreeBar);
            this.Controls.Add(this.DenseBar);
            this.Controls.Add(this.SpeedBar);
            this.Controls.Add(this.brash);
            this.Controls.Add(this.windy);
            this.Controls.Add(this.lightning);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "RainWindow";
            this.Text = "池塘夜降彩色雨";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RainWindow_FormClosing);
            this.Load += new System.EventHandler(this.RainWindow_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.RainWindow_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DenseBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DegreeBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.TrackBar SpeedBar;
        private System.Windows.Forms.Button brash;
        private System.Windows.Forms.TrackBar DenseBar;
        private System.Windows.Forms.Button windy;
        private System.Windows.Forms.TrackBar DegreeBar;
        private System.Windows.Forms.Button lightning;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Label DegreeLab;
        private System.Windows.Forms.Label DenseLab;
        private System.Windows.Forms.Label SpeedLab;
        private System.Windows.Forms.Label classLab;
        private System.Windows.Forms.Label numLab;
        private System.Windows.Forms.Label nameLab;


    }
}

