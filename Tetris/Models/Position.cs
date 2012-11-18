using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    /// <summary>
    /// 位置情報クラス
    /// </summary>
    public class Position
    {
        private int _x;
        /// <summary>
        /// X座標
        /// </summary>
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        private int _y;
        /// <summary>
        /// Y座標
        /// </summary>
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Position(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }
}
