namespace Tetris.Views
{
    partial class TetrisFieldControl
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
            if (disposing)
            {
                ResetEvent();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._timer = new System.Windows.Forms.Timer(this.components);
            this._lblGameOver = new System.Windows.Forms.Label();
            this._lblReStart = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _timer
            // 
            this._timer.Enabled = true;
            this._timer.Interval = 500;
            this._timer.Tick += new System.EventHandler(this._timer_Tick);
            // 
            // _lblGameOver
            // 
            this._lblGameOver.BackColor = System.Drawing.Color.Transparent;
            this._lblGameOver.Font = new System.Drawing.Font("メイリオ", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._lblGameOver.ForeColor = System.Drawing.Color.White;
            this._lblGameOver.Location = new System.Drawing.Point(21, 180);
            this._lblGameOver.Name = "_lblGameOver";
            this._lblGameOver.Size = new System.Drawing.Size(200, 38);
            this._lblGameOver.TabIndex = 11;
            this._lblGameOver.Text = "GAME OVER";
            this._lblGameOver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._lblGameOver.Visible = false;
            // 
            // _lblReStart
            // 
            this._lblReStart.BackColor = System.Drawing.Color.Transparent;
            this._lblReStart.Font = new System.Drawing.Font("メイリオ", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._lblReStart.ForeColor = System.Drawing.Color.White;
            this._lblReStart.Location = new System.Drawing.Point(21, 228);
            this._lblReStart.Name = "_lblReStart";
            this._lblReStart.Size = new System.Drawing.Size(200, 38);
            this._lblReStart.TabIndex = 12;
            this._lblReStart.Text = "RESTART";
            this._lblReStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._lblReStart.Visible = false;
            this._lblReStart.Click += new System.EventHandler(this._lblReStart_Click);
            // 
            // TetrisFieldControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this._lblGameOver);
            this.Controls.Add(this._lblReStart);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Name = "TetrisFieldControl";
            this.Size = new System.Drawing.Size(240, 480);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TetrisField_Paint);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TetrisField_PreviewKeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer _timer;
        private System.Windows.Forms.Label _lblGameOver;
        private System.Windows.Forms.Label _lblReStart;
    }
}
