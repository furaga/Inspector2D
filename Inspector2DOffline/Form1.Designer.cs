namespace Inspector2DOffline
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.inspector2DControl1 = new Company.Inspector2D.Inspector2DControl();
            this.SuspendLayout();
            // 
            // inspector2DControl1
            // 
            this.inspector2DControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inspector2DControl1.Location = new System.Drawing.Point(0, 0);
            this.inspector2DControl1.Name = "inspector2DControl1";
            this.inspector2DControl1.Size = new System.Drawing.Size(655, 261);
            this.inspector2DControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 261);
            this.Controls.Add(this.inspector2DControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Company.Inspector2D.Inspector2DControl inspector2DControl1;
    }
}

