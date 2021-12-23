using System;
using System.Collections.Generic;
using System.Text;

namespace Kursova_Chess
{
	public enum PieceType
	{
		Empty,
		King,       // Цар
		Queen,      // Царица
		Rook,       // Топ
		Bishop,     // Офицер
		Knight,     // Кон
		Pawn        // Пешка
	}

	public enum PieceColour
	{
		Empty,
		White,
		Black
	}

	public struct loc
	{
		public int x;
		public int y;
	}

	public class CPiece
	{
		private PieceType type;
		private PieceColour colour;
		private int value;
		private List<loc> moveset;

		public CPiece()
		{
			this.type = PieceType.Empty;
			this.colour = PieceColour.Empty;
			this.value = 0;
			this.moveset = null;
		}

		public CPiece(PieceType t, PieceColour c)
		{
			this.type = t;
			this.colour = c;
			switch (t)
			{
				case PieceType.King:
					this.value = 100;
					break;
				case PieceType.Queen:
					this.value = 9;
					break;
				case PieceType.Rook:
					this.value = 5;
					break;
				case PieceType.Bishop:
					this.value = 3;
					break;
				case PieceType.Knight:
					this.value = 3;
					break;
				case PieceType.Pawn:
					this.value = 1;
					break;
				default:
					this.value = 0;
					break;
			}
			this.moveset = setMoveset(t, c);
		}
		/*
		public override string ToString()
		{
			string s = "";

			s += type.ToString() + "-";
			s += colour.ToString() + "-";
			s += value.ToString();

			return s;
		}
		*/
		public PieceType getType()
		{ return type; }
		
		public PieceColour getColour()
		{ return colour; }
		public int getValue()
		{ return value; }
		public List<loc> getMoveset()
		{ return moveset; }

		public System.Drawing.Bitmap getImage(CPiece p)
		{
			System.Drawing.Bitmap bitmap = null;
			switch (p.colour)
			{
				case PieceColour.Black:
					switch (p.type)
					{
						case PieceType.Pawn: bitmap = Properties.Resources.BPawn; break;
						case PieceType.Rook: bitmap = Properties.Resources.BRook; break;
						case PieceType.Knight: bitmap = Properties.Resources.BKnight; break;
						case PieceType.Bishop: bitmap = Properties.Resources.BBishop; break;
						case PieceType.Queen: bitmap = Properties.Resources.BQueen; break;
						case PieceType.King: bitmap = Properties.Resources.BKing; break;
					}
					break;

				case PieceColour.White:
					switch (p.type)
					{
						case PieceType.Pawn: bitmap = Properties.Resources.WPawn; break;
						case PieceType.Rook: bitmap = Properties.Resources.WRook; break;
						case PieceType.Knight: bitmap = Properties.Resources.WKnight; break;
						case PieceType.Bishop: bitmap = Properties.Resources.WBishop; break;
						case PieceType.Queen: bitmap = Properties.Resources.WQueen; break;
						case PieceType.King: bitmap = Properties.Resources.WKing; break;
					}
					break;
			}
			return bitmap;
		}

		public void setMoveset(List<loc> m)
		{ this.moveset = m; }
		private List<loc> setMoveset(PieceType t, PieceColour c)
		{
			List<loc> m = new List<loc>();
			switch (t)
			{
				case PieceType.Pawn:
					switch (c)
					{
						case PieceColour.Black:
							m.Add(new loc { x = +0, y = +1 });
							m.Add(new loc { x = +0, y = +2 });
							m.Add(new loc { x = -1, y = +1 });
							m.Add(new loc { x = +1, y = +1 });
							break;
						case PieceColour.White:
							m.Add(new loc { x = +0, y = -1 });
							m.Add(new loc { x = +0, y = -2 });
							m.Add(new loc { x = -1, y = -1 });
							m.Add(new loc { x = +1, y = -1 });
							break;
					}
					break;
				case PieceType.Rook:
					for (int i = 0; i < 8; i++)
					{
						m.Add(new loc { x = +0, y = -i });
						m.Add(new loc { x = +i, y = +0 });
						m.Add(new loc { x = +0, y = +i });
						m.Add(new loc { x = -i, y = +0 });
					}
					break;
				case PieceType.Bishop:
					for (int i = 0; i < 8; i++)
					{
						m.Add(new loc { x = -i, y = -i });
						m.Add(new loc { x = +i, y = -i });
						m.Add(new loc { x = -i, y = +i });
						m.Add(new loc { x = +i, y = +i });
					}
					break;
				case PieceType.Queen:
					for (int i = 0; i < 8; i++)
					{
						m.Add(new loc { x = +i, y = -i });
						m.Add(new loc { x = +i, y = +0 });
						m.Add(new loc { x = +i, y = +i });
						m.Add(new loc { x = +0, y = -i });
						m.Add(new loc { x = +0, y = +i });
						m.Add(new loc { x = -i, y = -i });
						m.Add(new loc { x = -i, y = +0 });
						m.Add(new loc { x = -i, y = +i });
					}
					break;
				case PieceType.Knight:
					m.Add(new loc { x = +2, y = -1 });
					m.Add(new loc { x = +2, y = +1 });
					m.Add(new loc { x = -1, y = +2 });
					m.Add(new loc { x = +1, y = +2 });
					m.Add(new loc { x = -2, y = -1 });
					m.Add(new loc { x = -2, y = +1 });
					m.Add(new loc { x = -1, y = -2 });
					m.Add(new loc { x = +1, y = -2 });
					break;
				case PieceType.King:
					m.Add(new loc { x = +1, y = -1 });
					m.Add(new loc { x = +1, y = +0 });
					m.Add(new loc { x = +1, y = +1 });
					m.Add(new loc { x = +0, y = -1 });
					m.Add(new loc { x = +0, y = +1 });
					m.Add(new loc { x = -1, y = -1 });
					m.Add(new loc { x = -1, y = +0 });
					m.Add(new loc { x = -1, y = +1 });
					break;
			}
			return m;
		}

	} // class
} // namespace

