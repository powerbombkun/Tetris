using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Tetris.Enums;

namespace Tetris.Models
{
    /// <summary>
    /// アプリケーションのメインモデルデータ
    /// </summary>
    public static class MainModel
    {
        /// <summary>
        /// モデルの更新イベント通知
        /// </summary>
        public static event EventHandler<EventArgs> Updated;

        private static bool _isGameOver;
        /// <summary>
        /// ゲームオーバーフラグ
        /// </summary>
        public static bool IsGameOver
        {
            get { return _isGameOver; }
            set { _isGameOver = value; }
        }

        private static int _lineCounter;
        /// <summary>
        /// 消去行数カウンター
        /// </summary>
        public static int LineCounter
        {
            get { return _lineCounter; }
            set { _lineCounter = value; }
        }

        private static int _level;
        /// <summary>
        /// ゲームレベル
        /// </summary>
        public static int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        private static int _score;
        /// <summary>
        /// スコア
        /// </summary>
        public static int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        private static PieceParameter _currentPieceParameter;
        /// <summary>
        /// 現在のピースの設定データ
        /// </summary>
        public static PieceParameter CurrentPieceParameter
        {
            get { return _currentPieceParameter; }
            set { _currentPieceParameter = value; }
        }

        private static PieceParameter _nextPieceParameter;
        /// <summary>
        /// 次のピースの設定データ
        /// </summary>
        public static PieceParameter NextPieceParameter
        {
            get { return _nextPieceParameter; }
            set { _nextPieceParameter = value; }
        }

        private static PieceType[,] _field;
        /// <summary>
        /// 論理座標に応じたピースの種類のマップ
        /// </summary>
        public static PieceType[,] Field
        {
            get { return _field; }
            set { _field = value; }
        }

        /// <summary>
        /// モデル更新イベント
        /// ※コントローラ層でデータ更新後このメソッドで更新通知を行う
        /// </summary>
        public static void OnUpdated()
        {
            if (Updated != null)
            {
                Updated(null, EventArgs.Empty);
            }
        }

    }
}
