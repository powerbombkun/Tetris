using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Tetris.Controllers;
using Tetris.Models;
using Tetris.Enums;
using Tetris.Properties;
using System.Drawing.Drawing2D;

namespace Tetris.Views
{
    /// <summary>
    /// メインフォーム
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// グラデーション開始色
        /// </summary>
        private static readonly Color GRADIENT_START_COLOR = Color.SkyBlue;

        /// <summary>
        /// グラデーション終了色
        /// </summary>
        private static readonly Color GRADIENT_END_COLOR = Color.Blue;

        /// <summary>
        /// グラデーションの枠のサイズ
        /// </summary>
        private const int EDGE_SIZE = 3;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            SetEvent();
        }

        /// <summary>
        /// イベント登録
        /// </summary>
        private void SetEvent()
        {
            MainModel.Updated += new EventHandler<EventArgs>(MainModel_Updated);
        }

        /// <summary>
        /// イベント解除
        /// </summary>
        private void ResetEvent()
        {
            MainModel.Updated -= new EventHandler<EventArgs>(MainModel_Updated);
        }

        /// <summary>
        /// モデル層からのデータ更新通知
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainModel_Updated(object sender, EventArgs e)
        {
            // LINES
            _lblLines.Text = MainModel.LineCounter.ToString();

            // LEVEL
            _lblLevel.Text = MainModel.Level.ToString();

            // SCORE
            _lblScore.Text = MainModel.Score.ToString(); 
        }

        /// <summary>
        /// コントロールのエッジ描画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EdgePaint(object sender, PaintEventArgs e)
        {
            //枠描画のグラーデーションペンを作成
            using (LinearGradientBrush gb = new LinearGradientBrush(e.ClipRectangle, GRADIENT_START_COLOR, GRADIENT_END_COLOR, LinearGradientMode.ForwardDiagonal))
            using (Pen drawPen = new Pen(gb, EDGE_SIZE))
            {
                Rectangle drawRectangle = new Rectangle(e.ClipRectangle.Location.X, e.ClipRectangle.Location.Y,
                                                        e.ClipRectangle.Width - EDGE_SIZE, e.ClipRectangle.Height - EDGE_SIZE);
                e.Graphics.DrawRectangle(drawPen, drawRectangle);
            }
        }
    }
}
