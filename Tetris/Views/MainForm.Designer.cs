namespace Tetris.Views
{
    partial class MainForm
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._lblLines = new System.Windows.Forms.Label();
            this._lblLevel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._lblScore = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this._pnlField = new System.Windows.Forms.Panel();
            this._tetrisField = new Tetris.Views.TetrisFieldControl();
            this._pnlNextBlock = new System.Windows.Forms.Panel();
            this._nextBlock = new Tetris.Views.NextBlockControl();
            this._pnlLines = new System.Windows.Forms.Panel();
            this._pnlLevels = new System.Windows.Forms.Panel();
            this._pnlScore = new System.Windows.Forms.Panel();
            this._pnlField.SuspendLayout();
            this._pnlNextBlock.SuspendLayout();
            this._pnlLines.SuspendLayout();
            this._pnlLevels.SuspendLayout();
            this._pnlScore.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("メイリオ", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(272, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "NEXT";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("メイリオ", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(275, 318);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "LINES";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _lblLines
            // 
            this._lblLines.BackColor = System.Drawing.Color.Black;
            this._lblLines.Font = new System.Drawing.Font("メイリオ", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._lblLines.ForeColor = System.Drawing.Color.White;
            this._lblLines.Location = new System.Drawing.Point(3, 3);
            this._lblLines.Name = "_lblLines";
            this._lblLines.Size = new System.Drawing.Size(96, 24);
            this._lblLines.TabIndex = 4;
            this._lblLines.Text = "0";
            this._lblLines.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _lblLevel
            // 
            this._lblLevel.BackColor = System.Drawing.Color.Black;
            this._lblLevel.Font = new System.Drawing.Font("メイリオ", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._lblLevel.ForeColor = System.Drawing.Color.White;
            this._lblLevel.Location = new System.Drawing.Point(3, 3);
            this._lblLevel.Name = "_lblLevel";
            this._lblLevel.Size = new System.Drawing.Size(96, 24);
            this._lblLevel.TabIndex = 6;
            this._lblLevel.Text = "0";
            this._lblLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Font = new System.Drawing.Font("メイリオ", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(272, 378);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 24);
            this.label5.TabIndex = 5;
            this.label5.Text = "LEVEL";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _lblScore
            // 
            this._lblScore.BackColor = System.Drawing.Color.Black;
            this._lblScore.Font = new System.Drawing.Font("メイリオ", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._lblScore.ForeColor = System.Drawing.Color.White;
            this._lblScore.Location = new System.Drawing.Point(3, 3);
            this._lblScore.Name = "_lblScore";
            this._lblScore.Size = new System.Drawing.Size(96, 24);
            this._lblScore.TabIndex = 8;
            this._lblScore.Text = "0";
            this._lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.Font = new System.Drawing.Font("メイリオ", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(272, 438);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 24);
            this.label7.TabIndex = 7;
            this.label7.Text = "SCORE";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _pnlField
            // 
            this._pnlField.Controls.Add(this._tetrisField);
            this._pnlField.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._pnlField.Location = new System.Drawing.Point(12, 10);
            this._pnlField.Name = "_pnlField";
            this._pnlField.Size = new System.Drawing.Size(246, 486);
            this._pnlField.TabIndex = 9;
            this._pnlField.Paint += new System.Windows.Forms.PaintEventHandler(this.EdgePaint);
            // 
            // _tetrisField
            // 
            this._tetrisField.BackColor = System.Drawing.Color.Black;
            this._tetrisField.Font = new System.Drawing.Font("メイリオ", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._tetrisField.Location = new System.Drawing.Point(3, 3);
            this._tetrisField.Name = "_tetrisField";
            this._tetrisField.Size = new System.Drawing.Size(240, 480);
            this._tetrisField.TabIndex = 0;
            // 
            // _pnlNextBlock
            // 
            this._pnlNextBlock.Controls.Add(this._nextBlock);
            this._pnlNextBlock.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._pnlNextBlock.Location = new System.Drawing.Point(269, 42);
            this._pnlNextBlock.Name = "_pnlNextBlock";
            this._pnlNextBlock.Size = new System.Drawing.Size(102, 102);
            this._pnlNextBlock.TabIndex = 10;
            this._pnlNextBlock.Paint += new System.Windows.Forms.PaintEventHandler(this.EdgePaint);
            // 
            // _nextBlock
            // 
            this._nextBlock.BackColor = System.Drawing.Color.Black;
            this._nextBlock.Font = new System.Drawing.Font("メイリオ", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._nextBlock.Location = new System.Drawing.Point(3, 3);
            this._nextBlock.Name = "_nextBlock";
            this._nextBlock.Size = new System.Drawing.Size(96, 96);
            this._nextBlock.TabIndex = 1;
            this._nextBlock.TabStop = false;
            // 
            // _pnlLines
            // 
            this._pnlLines.Controls.Add(this._lblLines);
            this._pnlLines.Location = new System.Drawing.Point(269, 345);
            this._pnlLines.Name = "_pnlLines";
            this._pnlLines.Size = new System.Drawing.Size(102, 30);
            this._pnlLines.TabIndex = 11;
            this._pnlLines.Paint += new System.Windows.Forms.PaintEventHandler(this.EdgePaint);
            // 
            // _pnlLevels
            // 
            this._pnlLevels.Controls.Add(this._lblLevel);
            this._pnlLevels.Location = new System.Drawing.Point(269, 405);
            this._pnlLevels.Name = "_pnlLevels";
            this._pnlLevels.Size = new System.Drawing.Size(102, 30);
            this._pnlLevels.TabIndex = 12;
            this._pnlLevels.Paint += new System.Windows.Forms.PaintEventHandler(this.EdgePaint);
            // 
            // _pnlScore
            // 
            this._pnlScore.Controls.Add(this._lblScore);
            this._pnlScore.Location = new System.Drawing.Point(269, 465);
            this._pnlScore.Name = "_pnlScore";
            this._pnlScore.Size = new System.Drawing.Size(102, 30);
            this._pnlScore.TabIndex = 13;
            this._pnlScore.Paint += new System.Windows.Forms.PaintEventHandler(this.EdgePaint);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(386, 508);
            this.Controls.Add(this._pnlScore);
            this.Controls.Add(this._pnlLevels);
            this.Controls.Add(this._pnlLines);
            this.Controls.Add(this._pnlNextBlock);
            this.Controls.Add(this._pnlField);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Tetris";
            this._pnlField.ResumeLayout(false);
            this._pnlNextBlock.ResumeLayout(false);
            this._pnlLines.ResumeLayout(false);
            this._pnlLevels.ResumeLayout(false);
            this._pnlScore.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TetrisFieldControl _tetrisField;
        private NextBlockControl _nextBlock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label _lblLines;
        private System.Windows.Forms.Label _lblLevel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label _lblScore;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel _pnlField;
        private System.Windows.Forms.Panel _pnlNextBlock;
        private System.Windows.Forms.Panel _pnlLines;
        private System.Windows.Forms.Panel _pnlLevels;
        private System.Windows.Forms.Panel _pnlScore;

    }
}

