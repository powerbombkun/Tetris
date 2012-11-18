using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Tetris.Models
{
    /// <summary>
    /// 回転角度
    /// </summary>
    public enum AngleType
    {
        Angle0,
        Angle90,
        Angle180,
        Angle270,
    }

    /// <summary>
    /// テトリスのピースの抽象クラス
    /// </summary>
    public abstract class AbstractPiece
    {
        private Position _position = new Position(0, 0);
        /// <summary>
        /// 現在位置
        /// </summary>
        public Position Position
        {
            get { return _position; }
            set { _position = value; }
        }

        private int[,] _map;
        /// <summary>
        /// マップ
        /// </summary>
        public int[,] Map
        {
            get { return _map; }
            protected set { _map = value; }
        }

        private AngleType _angle;
        /// <summary>
        /// 角度
        /// </summary>
        public AngleType Angle
        {
            get { return _angle; }
            protected set { _angle = value; }
        }

        /// <summary>
        /// 角度更新
        /// </summary>
        /// <param name="angle"></param>
        public abstract void UpdateAngle(AngleType angle);

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AbstractPiece()
        {            
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AbstractPiece(int x, int y, AngleType angle)
            : base()
        {
            _position.X = x;
            _position.Y = y;
            UpdateAngle(angle);
        }

        /// <summary>
        /// MapのXYの入れ替えを行う
        /// </summary>
        protected void SwapXY()
        {
            int countX = _map.GetLength(0);
            int countY = _map.GetLength(1);
            int[,] map = new int[countX, countY];
            for (int i = 0; i < countX; i++)
            {
                for (int j = 0; j < countY; j++)
                {
                    map[i, j] = _map[j, i];
                }
            }
            _map = map;
        }
    }
}
