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

namespace Tetris.Views
{
    /// <summary>
    /// テトリスのフィールド
    /// </summary>
    public partial class TetrisFieldControl : UserControl
    {
        /// <summary>
        /// 論理行の上端のバッファサイズ
        /// </summary>
        private const int COLUMN_BUFFER_SIZE = 4;

        /// <summary>
        /// ブロックの物理サイズ（ピクセル）
        /// </summary>
        private const int BLOCK_SIZE = 24;

        /// <summary>
        /// ゲームオーバー文字描画用フォント
        /// </summary>
        private const float GAME_OVER_FONT_SIZE = 24.0f;

        /// <summary>
        /// レベルアップによる減る時間数
        /// </summary>
        private const int DECREASE_TIME = 20;

        /// <summary>
        /// 最後に更新した際のレベル
        /// </summary>
        private int _lastLevel;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TetrisFieldControl()
        {
            InitializeComponent();

            _lastLevel = MainModel.Level;
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
            // レベルが変わった
            if (_lastLevel != MainModel.Level)
            {
                _timer.Interval = _timer.Interval - DECREASE_TIME;
                _lastLevel = MainModel.Level;
            }

            // ゲームオーバーならタイマー停止
            if (MainModel.IsGameOver)
            {
                _timer.Stop();
            }
            
            // 再描画
            Invalidate();
        }

        /// <summary>
        /// 再描画イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TetrisField_Paint(object sender, PaintEventArgs e)
        {
            if (this.DesignMode) return;

            // マップ情報の描画
            for (int i = 0; i < MainModel.Field.GetLength(0); i++)
            {
                for (int j = COLUMN_BUFFER_SIZE; j < MainModel.Field.GetLength(1); j++)
                {
                    int x = i * BLOCK_SIZE;
                    int y = (j - COLUMN_BUFFER_SIZE) * BLOCK_SIZE;
                    e.Graphics.DrawImage(ResourceUtility.GetPieceBitmap(MainModel.Field[i, j]), x, y);
                }
            }

            // 現在のピース描画
            for (int i = 0; i < MainModel.CurrentPieceParameter.Piece.Map.GetLength(0); i++)
            {
                for (int j = 0; j < MainModel.CurrentPieceParameter.Piece.Map.GetLength(1); j++)
                {
                    if (MainModel.CurrentPieceParameter.Piece.Map[i, j] == 1)
                    {
                        int x = (MainModel.CurrentPieceParameter.Piece.Position.X + i) * BLOCK_SIZE;
                        int y = (MainModel.CurrentPieceParameter.Piece.Position.Y + j - COLUMN_BUFFER_SIZE) * BLOCK_SIZE;
                        e.Graphics.DrawImage(ResourceUtility.GetPieceBitmap(MainModel.CurrentPieceParameter.PieceType), x, y);
                    }
                }
            }

            // ゲームオーバーなら文字描画
            if (MainModel.IsGameOver)
            {
                _lblGameOver.Visible = true;
                _lblReStart.Visible = true;
            }
        }

        /// <summary>
        /// タイマー処理イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _timer_Tick(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            // ↓ボタンと同一の処理を行う
            ModelController.MoveDownPiece();
        }

        /// <summary>
        /// キーを押した際のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TetrisField_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // ゲームオーバーの場合は無視
            if (MainModel.IsGameOver)
            {
                return;
            }

            switch (e.KeyData)
            {
                case Keys.Up:
                case Keys.I:
                    // 回転
                    ModelController.RotatePiece();
                    e.IsInputKey = true;
                    break;
                case Keys.Down:
                case Keys.K:
                    // ↓
                    ModelController.MoveDownPiece();
                    e.IsInputKey = true;
                    break;
                case Keys.Left:
                case Keys.J:
                    // ←
                    ModelController.MoveLeftPiece();
                    e.IsInputKey = true;
                    break;
                case Keys.Right:
                case Keys.L:
                    // →
                    ModelController.MoveRightPiece();
                    e.IsInputKey = true;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// リスタートボタンをクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _lblReStart_Click(object sender, EventArgs e)
        {
            ModelController.Clear();
            _timer.Start();

            // ラベルの非表示化
            _lblGameOver.Visible = false;
            _lblReStart.Visible = false;
        }




    }
}
