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

namespace Tetris.Views
{
    /// <summary>
    /// 次のブロックを表示するコントロール
    /// </summary>
    public partial class NextBlockControl : UserControl
    {
        /// <summary>
        /// ブロックの物理サイズ（ピクセル）
        /// </summary>
        private const int BLOCK_SIZE = 24;

        /// <summary>
        /// 最後に描画したピースパラメータ
        /// </summary>
        private PieceParameter _lastPieceParameter;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NextBlockControl()
        {
            InitializeComponent();

            _lastPieceParameter = MainModel.NextPieceParameter;
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
            // 次のピースが新しくなった場合
            if (_lastPieceParameter != MainModel.NextPieceParameter)
            {
                _lastPieceParameter = MainModel.NextPieceParameter;
                Invalidate();
            }
        }

        /// <summary>
        /// 再描画イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextBlockControl_Paint(object sender, PaintEventArgs e)
        {
            if (this.DesignMode) return;

            // 現在のピース描画
            for (int i = 0; i < _lastPieceParameter.Piece.Map.GetLength(0); i++)
            {
                for (int j = 0; j < _lastPieceParameter.Piece.Map.GetLength(1); j++)
                {
                    if (_lastPieceParameter.Piece.Map[i, j] == 1)
                    {
                        int x = i * BLOCK_SIZE;
                        int y = j * BLOCK_SIZE;
                        e.Graphics.DrawImage(ResourceUtility.GetPieceBitmap(_lastPieceParameter.PieceType), x, y);
                    }
                }
            }
        }
    }
}
