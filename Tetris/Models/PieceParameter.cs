using System;
using System.Collections.Generic;
using System.Text;
using Tetris.Enums;

namespace Tetris.Models
{
    /// <summary>
    /// ピースの設定データ
    /// </summary>
    public class PieceParameter
    {
        private PieceType _pieceType;
        /// <summary>
        /// ピースの種類
        /// </summary>
        public PieceType PieceType
        {
            get { return _pieceType; }
            set { _pieceType = value; }
        }

        private AbstractPiece _piece;
        /// <summary>
        /// ピース
        /// </summary>
        public AbstractPiece Piece
        {
            get { return _piece; }
            set { _piece = value; }
        }
    }
}
