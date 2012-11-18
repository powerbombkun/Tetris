using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris.Models
{
    public class PieceT : AbstractPiece
    {
        public PieceT(int x, int y, AngleType angle)
            : base(x, y, angle)
        {
        }

        public override void UpdateAngle(AngleType angle)
        {
            switch (angle)
            {
                case AngleType.Angle0:
                    Map = new int[,] 
                    { 
                        { 0, 0, 0, 0 }, 
                        { 0, 1, 0, 0 }, 
                        { 1, 1, 1, 0 }, 
                        { 0, 0, 0, 0 }
                    };
                    break;
                case AngleType.Angle90:
                    Map = new int[,] 
                    { 
                        { 0, 0, 0, 0 }, 
                        { 0, 1, 0, 0 }, 
                        { 0, 1, 1, 0 }, 
                        { 0, 1, 0, 0 }
                    };
                    break;
                case AngleType.Angle180:
                    Map = new int[,] 
                    { 
                        { 0, 0, 0, 0 }, 
                        { 0, 0, 0, 0 }, 
                        { 1, 1, 1, 0 }, 
                        { 0, 1, 0, 0 }
                    };
                    break;
                case AngleType.Angle270:
                    Map = new int[,] 
                    { 
                        { 0, 0, 0, 0 }, 
                        { 0, 1, 0, 0 }, 
                        { 1, 1, 0, 0 }, 
                        { 0, 1, 0, 0 }
                    };
                    break;
            }
            SwapXY();
            Angle = angle;
        }
    }
}
