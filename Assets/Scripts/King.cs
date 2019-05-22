using Assets.Enums;
using Assets.Interfaces;
using Scripts;
using Scripts.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class King : Figure,IKing
    {
        public bool moved;

        public King(IPosition position,Color color) : base(position,color)
        {
            Type = FigureType.King;
            moved = false;
        }

        public override bool isLegalMove(IPosition to, IBoard board, out MoveTypes moveType)
        {
            moveType = MoveTypes.NormalMove;
            if (Math.Abs(to.x - position.x) <= 1 && Math.Abs(to.y - position.y) <= 1)
            {
                return true;
            }
            else
            {
                int direction = to.x - position.x;
                if ((direction == 2 || direction == -2) && to.y==position.y)
                {
                    if (!moved)
                    {
                        Position rookPosition;
                        if (direction == 2)
                        {
                            direction = 1;
                            rookPosition = new Position(7, position.y);
                        }
                        else
                        {
                            direction = -1;
                            rookPosition= new Position(0, position.y);
                        }

                        if (board.isFigureAt(rookPosition))
                        {
                            IFigure figure = board.GetFigureAt(rookPosition);
                            if (figure.Type == FigureType.Rock)
                            {
                                Rock rock = figure as Rock;
                                if (!rock.moved)
                                {
                                    if (!board.isSomethingBetwen(position, rock.position))
                                    {
                                        if (!board.IsCheck(color))
                                        {
                                             if (!board.isUnderPreasure(new Position(position.x + direction, position.y), color))
                                            {
                                                 if (!board.isUnderPreasure(to, color))
                                                {
                                                    moveType = MoveTypes.Roszada;
                                                    return true;
                                                }
                                            }
                                        }

                                    }
                                }
                            }
                        }
                            
                            
                    }
                }
            }
                return false;
        }

        
    }
}
