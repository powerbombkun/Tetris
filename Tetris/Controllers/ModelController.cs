using System;
using System.Collections.Generic;
using System.Text;
using Tetris.Models;
using Tetris.Enums;
using System.Drawing;
namespace Tetris.Controllers
{
    /// <summary>
    /// モデルの制御コントローラ
    /// </summary>
    public static class ModelController
    {
        /// <summary>
        /// 論理列のサイズ
        /// </summary>
        private const int FIELD_ROW_SIZE = 10;
        /// <summary>
        /// 論理行のサイズ
        /// </summary>
        private const int FIELD_COLUMN_SIZE = 24;
        /// <summary>
        /// 新規のピースの開始論理位置(X)
        /// </summary>
        private const int NEW_PIECE_START_X = 3;
        /// <summary>
        /// 新規のピースの開始論理位置(Y)
        /// </summary>
        private const int NEW_PIECE_START_Y = 0;
        /// <summary>
        /// ライン１行分のスコア
        /// </summary>
        private const double ONE_LINE_SCORE = 100.0;
        /// <summary>
        /// レベルアップのしきい値
        /// </summary>
        private const int LEVEL_UP_THRESHOLD = 500;

        /// <summary>
        /// 初期化
        /// </summary>
        public static void Init()
        {
            MainModel.IsGameOver = false;
            MainModel.LineCounter = 0;
            MainModel.Level = 0;
            MainModel.Score = 0;
            MainModel.CurrentPieceParameter = CreatePieceParameter();
            MainModel.NextPieceParameter = CreatePieceParameter();
            MainModel.Field = new PieceType[FIELD_ROW_SIZE, FIELD_COLUMN_SIZE];
        }

        /// <summary>
        /// データのクリア
        /// </summary>
        public static void Clear()
        {
            Init();
            MainModel.OnUpdated();
        }

        /// <summary>
        /// ピースを新しく更新する
        /// </summary>
        /// <returns></returns>
        public static PieceParameter CreatePieceParameter()
        {
            // ランダム関数でパラメータを決定
            Random random = new Random();
            int pieceLength = Enum.GetValues(typeof(PieceType)).Length;
            int pieceIndex = random.Next(pieceLength - 1);
            int angleLength = Enum.GetValues(typeof(AngleType)).Length;
            int angleIndex = random.Next(angleLength);

            PieceParameter pieceParameter = new PieceParameter();
            // 更新
            switch (pieceIndex)
            {
                case 0:
                    pieceParameter.Piece = new PieceI(NEW_PIECE_START_X, NEW_PIECE_START_Y, (AngleType)angleIndex);
                    pieceParameter.PieceType = PieceType.I;
                    break;
                case 1:
                    pieceParameter.Piece = new PieceO(NEW_PIECE_START_X, NEW_PIECE_START_Y, (AngleType)angleIndex);
                    pieceParameter.PieceType = PieceType.O;
                    break;
                case 2:
                    pieceParameter.Piece = new PieceS(NEW_PIECE_START_X, NEW_PIECE_START_Y, (AngleType)angleIndex);
                    pieceParameter.PieceType = PieceType.S;
                    break;
                case 3:
                    pieceParameter.Piece = new PieceZ(NEW_PIECE_START_X, NEW_PIECE_START_Y, (AngleType)angleIndex);
                    pieceParameter.PieceType = PieceType.Z;
                    break;
                case 4:
                    pieceParameter.Piece = new PieceJ(NEW_PIECE_START_X, NEW_PIECE_START_Y, (AngleType)angleIndex);
                    pieceParameter.PieceType = PieceType.J;
                    break;
                case 5:
                    pieceParameter.Piece = new PieceL(NEW_PIECE_START_X, NEW_PIECE_START_Y, (AngleType)angleIndex);
                    pieceParameter.PieceType = PieceType.L;
                    break;
                case 6:
                    pieceParameter.Piece = new PieceT(NEW_PIECE_START_X, NEW_PIECE_START_Y, (AngleType)angleIndex);
                    pieceParameter.PieceType = PieceType.T;
                    break;
                default:
                    System.Diagnostics.Debug.Assert(false);
                    pieceParameter.Piece = new PieceI(NEW_PIECE_START_X, NEW_PIECE_START_Y, (AngleType)angleIndex);
                    pieceParameter.PieceType = PieceType.I;
                    break;
            }
            return pieceParameter;
        }

        /// <summary>
        /// ピースを回転させる
        /// </summary>
        public static void RotatePiece()
        {
            Array angles = Enum.GetValues(typeof(AngleType));
            int currentIndex = Array.IndexOf(angles, MainModel.CurrentPieceParameter.Piece.Angle);
            int nextIndex = (currentIndex + 1) % angles.Length;

            MainModel.CurrentPieceParameter.Piece.UpdateAngle((AngleType)nextIndex);
            if (IsHit(MainModel.CurrentPieceParameter.Piece))
            {
                MainModel.CurrentPieceParameter.Piece.UpdateAngle((AngleType)currentIndex);
            }
            MainModel.OnUpdated();
        }

        /// <summary>
        /// ピースの位置を１つ下へ動かす
        /// </summary>
        /// <returns></returns>
        public static void MoveDownPiece()
        {
            MainModel.CurrentPieceParameter.Piece.Position.Y++;
            if (IsHit(MainModel.CurrentPieceParameter.Piece))
            {
                MainModel.CurrentPieceParameter.Piece.Position.Y--;

                // フィールドへコピー
                CopyToFileld();

                // 削除行があるか判定し削除
                int deleteCount = 0;
                while (true)
                {
                    int deleteIndex = SearchDeleteIndex();
                    if (deleteIndex < 0)
                    {
                        break;
                    }
                    DeleteLine(deleteIndex);
                    deleteCount++;
                }

                if (0 < deleteCount)
                {
                    // 削除行数加算
                    MainModel.LineCounter = MainModel.LineCounter + deleteCount;
                    // 得点更新
                    MainModel.Score = MainModel.Score + (int)(ONE_LINE_SCORE * System.Math.Pow(2, deleteCount - 1));
                    // レベル更新
                    MainModel.Level = MainModel.Score / LEVEL_UP_THRESHOLD;
                }

                // １回も動けずヒットした為、ゲームオーバー
                if (MainModel.CurrentPieceParameter.Piece.Position.Y == 0)
                {
                    MainModel.IsGameOver = true;
                }

                // 次のを現在のに設定
                MainModel.CurrentPieceParameter = MainModel.NextPieceParameter;
                // 次のピース生成
                MainModel.NextPieceParameter = CreatePieceParameter();
            }
            MainModel.OnUpdated();
        }
        /// <summary>
        /// ピースの位置を１つ左へ動かす
        /// </summary>
        /// <returns></returns>
        public static void MoveLeftPiece()
        {
            MainModel.CurrentPieceParameter.Piece.Position.X--;
            if (IsHit(MainModel.CurrentPieceParameter.Piece))
            {
                MainModel.CurrentPieceParameter.Piece.Position.X++;
            }
            MainModel.OnUpdated();
        }
        /// <summary>
        /// ピースの位置を１つ右へ動かす
        /// </summary>
        /// <returns></returns>
        public static void MoveRightPiece()
        {
            MainModel.CurrentPieceParameter.Piece.Position.X++;
            if (IsHit(MainModel.CurrentPieceParameter.Piece))
            {
                MainModel.CurrentPieceParameter.Piece.Position.X--;
            }
            MainModel.OnUpdated();
        }

        /// <summary>
        /// 対象位置に障害物があるか
        /// </summary>
        private static bool IsHit(AbstractPiece piece)
        {
            int x = piece.Position.X;
            int y = piece.Position.Y;

            for (int i = 0; i < piece.Map.GetLength(0); i++)
            {
                for (int j = 0; j < piece.Map.GetLength(1); j++)
                {
                    if (piece.Map[i, j] == 1)
                    {
                        if (IsHit(x + i, y + j))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 対象位置に障害物があるか
        /// </summary>
        private static bool IsHit(int x, int y)
        {
            if (x < 0)
            {
                return true;
            }
            if (MainModel.Field.GetLength(0) <= x)
            {
                return true;
            }
            if (MainModel.Field.GetLength(1) <= y)
            {
                return true;
            }

            // 上端ではみ出している部分は当たり判定から除き、空のフィールドかどうか判定
            if ((0 <= y) && (MainModel.Field[x, y] != PieceType.None))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 現在のピースをマップへセット
        /// Mapの領域外へのプロットが発生する場合は無視
        /// </summary>
        private static void CopyToFileld()
        {
            for (int i = 0; i < MainModel.CurrentPieceParameter.Piece.Map.GetLength(0); i++)
            {
                for (int j = 0; j < MainModel.CurrentPieceParameter.Piece.Map.GetLength(1); j++)
                {
                    if (MainModel.CurrentPieceParameter.Piece.Map[i, j] == 1)
                    {
                        int x = MainModel.CurrentPieceParameter.Piece.Position.X + i;
                        int y = MainModel.CurrentPieceParameter.Piece.Position.Y + j;

                        // X座標、Y座標が範囲に入っている
                        if ((0 <= x) && (x < MainModel.Field.GetLength(0)) && (0 <= y) && (y < MainModel.Field.GetLength(1)))
                        {
                            MainModel.Field[x, y] = MainModel.CurrentPieceParameter.PieceType;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 現在のピースが上限をオーバーしているか判定するメソッド
        /// </summary>
        private static bool IsCurrentPieceOver()
        {
            for (int i = 0; i < MainModel.CurrentPieceParameter.Piece.Map.GetLength(0); i++)
            {
                for (int j = 0; j < MainModel.CurrentPieceParameter.Piece.Map.GetLength(1); j++)
                {
                    if (MainModel.CurrentPieceParameter.Piece.Map[i, j] == 1)
                    {
                        int y = MainModel.CurrentPieceParameter.Piece.Position.Y + j;
                        if (MainModel.Field.GetLength(1) <= y)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 削除する行があるか検索
        /// </summary>
        /// <returns>Y座標の０番目のインデックスから検索し最初に見つかったインデックス</returns>
        private static int SearchDeleteIndex()
        {
            // 削除するインデックスのリストを作成
            for (int j = 0; j < MainModel.Field.GetLength(1); j++)
            {
                bool isRemove = true;
                for (int i = 0; i < MainModel.Field.GetLength(0); i++)
                {
                    if (MainModel.Field[i, j] == PieceType.None)
                    {
                        isRemove = false;
                        break;
                    }
                }
                if (isRemove)
                {
                    return j;
                }
            }
            return -1;
        }

        /// <summary>
        /// 指定した行を削除
        /// </summary>
        /// <param name="lineIndex"></param>
        private static void DeleteLine(int lineIndex)
        {
            for (int j = lineIndex; 0 <= j; j--)
            {
                for (int i = 0; i < MainModel.Field.GetLength(0); i++)
                {
                    if (j == 0)
                    {
                        MainModel.Field[i, j] = PieceType.None;
                    }
                    else
                    {
                        MainModel.Field[i, j] = MainModel.Field[i, j - 1];
                    }
                }
            }
        }
    }
}
