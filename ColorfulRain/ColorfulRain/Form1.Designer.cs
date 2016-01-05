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
            this.lightning = new System.Windows.Forms.Button();
            this.windy = new System.Windows.Forms.Button();
            this.brash = new System.Windows.Forms.Button();
            this.SpeedBar = new System.Windows.Forms.TrackBar();
            this.DenseBar = new System.Windows.Forms.TrackBar();
            this.DegreeBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DenseBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DegreeBar)).BeginInit();
            this.SuspendLayout();
            // 
            // lightning
            // 
            this.lightning.Location = new System.Drawing.Point(897, 14);
            this.lightning.Name = "lightning";
            this.lightning.Size = new System.Drawing.Size(75, 23);
            this.lightning.TabIndex = 0;
            this.lightning.Text = "电闪雷鸣";
            this.lightning.UseVisualStyleBackColor = true;
            // 
            // windy
            // 
            this.windy.Location = new System.Drawing.Point(897, 43);
            this.windy.Name = "windy";
            this.windy.Size = new System.Drawing.Size(75, 23);
            this.windy.TabIndex = 1;
            this.windy.Text = "风雨飘摇";
            this.windy.UseVisualStyleBackColor = true;
            // 
            // brash
            // 
            this.brash.Location = new System.Drawing.Point(897, 72);
            this.brash.Name = "brash";
            this.brash.Size = new System.Drawing.Size(75, 23);
            this.brash.TabIndex = 2;
            this.brash.Text = "时细时骤";
            this.brash.UseVisualStyleBackColor = true;
            // 
            // SpeedBar
            // 
            this.SpeedBar.Location = new System.Drawing.Point(854, 187);
            this.SpeedBar.Name = "SpeedBar";
            this.SpeedBar.Size = new System.Drawing.Size(130, 45);
            this.SpeedBar.TabIndex = 3;
            this.SpeedBar.Scroll += new System.EventHandler(this.SpeedBar_Scroll);
            // 
            // DenseBar
            // 
            this.DenseBar.Location = new System.Drawing.Point(854, 144);
            this.DenseBar.Name = "DenseBar";
            this.DenseBar.Size = new System.Drawing.Size(130, 45);
            this.DenseBar.TabIndex = 4;
            this.DenseBar.Scroll += new System.EventHandler(this.DenseBar_Scroll);
            // 
            // DegreeBar
            // 
            this.DegreeBar.Location = new System.Drawing.Point(854, 101);
            this.DegreeBar.Name = "DegreeBar";
            this.DegreeBar.Size = new System.Drawing.Size(130, 45);
            this.DegreeBar.TabIndex = 5;
            // 
            // RainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 612);
            this.Controls.Add(this.DegreeBar);
            this.Controls.Add(this.DenseBar);
            this.Controls.Add(this.SpeedBar);
            this.Controls.Add(this.brash);
            this.Controls.Add(this.windy);
            this.Controls.Add(this.lightning);
            this.Name = "RainWindow";
            this.Text = "池塘夜降彩色雨";
            this.Load += new System.EventHandler(this.RainWindow_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.RainWindow_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.SpeedBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DenseBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DegreeBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button lightning;
        private System.Windows.Forms.Button windy;
        private System.Windows.Forms.Button brash;
        private System.Windows.Forms.TrackBar SpeedBar;
        private System.Windows.Forms.TrackBar DenseBar;
        private System.Windows.Forms.TrackBar DegreeBar;
    }
}

