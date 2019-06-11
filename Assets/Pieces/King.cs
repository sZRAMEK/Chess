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
    public class King : Piece, IKing
    {
        public King(IPosition position, Color color) : base(position, color)
        {
            Type = PiecesTypesEnum.King;
        }

        public List<IMove> Castling(IMove move , IBoard board)
        {
                if (move.Distance() == DistanceEnum.TwoSquares &&
                    move.Direction() == MoveDirection.Horizontally &&
                   !Moved)
                {
                    Position rookPosition;
                    int castlingDirection = move.SenseHorizontal();
                    if (castlingDirection == 1)
                        rookPosition = new Position(7, currentPosition.y);
                    else
                        rookPosition = new Position(0, currentPosition.y);


                    IPiece rock = board.GetFigureAt(rookPosition);
                    if (rock != null)
                    {
                        if (rock.Type == PiecesTypesEnum.Rock &&
                            !rock.Moved &&
                            !board.AreAnyPiecesBetwen(currentPosition, rock.currentPosition) &&
                            !board.IsCheck(color) &&
                            !board.IsFieldAttacked(new Position(currentPosition.x + castlingDirection, currentPosition.y), color) &&
                            !board.IsFieldAttacked(new Position(currentPosition.x + 2 * castlingDirection, currentPosition.y), color) &&
                            !board.IsFieldAttacked(move.Destination, color))
                        {
                        List<IMove> result = new List<IMove>();
                        result.Add(move);
                        result.Add(new Move(rookPosition, new Position(currentPosition.x + castlingDirection, currentPosition.y)));
                        return result;
                        }
                    }
                }
                return null;
        }

        public override bool IsAllowedMove(IMove move)
        {
            if (move.Distance() == DistanceEnum.OneSquare)
                return true;
            return false;
        }
    }
}
