using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Tetris.Enums;
using Tetris.Properties;

namespace Tetris.Views
{
    /// <summary>
    /// リソースデータ用ユーティリティ
    /// </summary>
    public static class ResourceUtility
    {
        /// <summary>
        /// ピースの種類に応じたビットマップを返す
        /// </summary>
        /// <param name="pieceType"></param>
        /// <returns></returns>
        public static Bitmap GetPieceBitmap(PieceType pieceType)
        {
            switch (pieceType)
            {
                case PieceType.None: return Resources.Black;
                case PieceType.I: return Resources.Red;
                case PieceType.O: return Resources.Blue;
                case PieceType.S: return Resources.Orange;
                case PieceType.Z: return Resources.Yellow;
                case PieceType.J: return Resources.Purple;
                case PieceType.L: return Resources.Green;
                case PieceType.T: return Resources.Cyan;
                default: System.Diagnostics.Debug.Assert(false); return Resources.Black;
            }
        }
    }
}
