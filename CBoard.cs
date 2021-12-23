using System;
using System.Collections.Generic;
using System.Text;

namespace Kursova_Chess
{
	public class Score
	{
		public int White;
		public int Black;
		public Score() { White = 0; Black = 0; }
		public void addScore(PieceColour player, int value)
		{
			if (player == PieceColour.White) White += value;
			if (player == PieceColour.Black) Black += value;
		}

	}

	// duska 8x8, s ugli - goren lqv (0,0) dolen desen (7,7)
	class CBoard : CPiece
	{
		

		public static int boardSize = 8;
		private static CPiece[,] board = new CPiece[boardSize, boardSize];
		private static CPiece CurrentPiece = null;
		private static int last_x = 0, last_y = 0;
		private static PieceColour playerTurn = PieceColour.White;
		private static Score score;
		
		private void fillBoard()
		{
			PieceType t;
			PieceColour c;

			for (int i = 0; i < boardSize; i++) // red 
			{
				for (int j = 0; j < boardSize; j++) // kolona
				{
					switch (j)
					{
						case 0:
						case 1:
							c = PieceColour.Black;
							break;
						case 6:
						case 7:
							c = PieceColour.White;
							break;
						default:
							c = PieceColour.Empty;
							break;
					}
					if (2 <= j && j <= 5)
					{ t = PieceType.Empty; }
					else switch (i)
						{
							case 0:
							case 7:
								t = PieceType.Rook;
								break;
							case 1:
							case 6:
								t = PieceType.Knight;
								break;
							case 2:
							case 5:
								t = PieceType.Bishop;
								break;
							case 3: t = PieceType.Queen; break;
							case 4: t = PieceType.King; break;

							default:
								t = PieceType.Empty;
								break;
						}
					if (j == 1 || j == 6) t = PieceType.Pawn;
					board[i, j] = new CPiece(t, c);
				}
			}
		}

		public CBoard()
		{
			fillBoard();
			score = new Score();
			playerTurn = PieceColour.White;
		}
		/*
		public string viewBoard()
		{
			string s = "";
			for (int i = 0; i < boardSize; i++)
			{
				for (int j = 0; j < boardSize; j++)
					s += board[i, j].getType().ToString() + "." + board[i, j].getColour().ToString() + " ";
				s += "\n";
			}
			return s;
		}
		*/
		public string getCell(int x, int y)
		{
			string s = "";
			try
			{
				CPiece p = board[x, y];
				s = p.getColour().ToString()[0].ToString();
				if (s == "B" || s == "W")
				{
					string t = p.getType().ToString();
					if (t == "Knight")
						s += "N";
					else s += t[0];
				}
				else s = "EE";
			}
			catch (IndexOutOfRangeException) { s = "getCell out of range"; }
			return s;
		}

		public CPiece getPiece(int x, int y)
		{
			CPiece p = new CPiece();
			try { p = board[x, y]; }
			catch (IndexOutOfRangeException) { }
			return p;
		}

		public void setPiece(int x, int y, CPiece p)
		{ board[x, y] = p; }

		public System.Drawing.Bitmap getImage(int x, int y)
		{
			CPiece p = board[x, y];
			return getImage(p);
		}

		public Score getScore() { return score; }
		public PieceColour getTurn() { return playerTurn; }

		// start of legal moves checking
private List<loc> setRook(CPiece piece, int px, int py)
		{
			List<loc> m = new List<loc>();
			for (int i = 1; i <= px; i++)
			{
				PieceColour newLoc = getPiece(px - i, py + 0).getColour();
				if (newLoc == PieceColour.Empty) m.Add(new loc { x = -i, y = +0 });
				else if (newLoc != piece.getColour()) { m.Add(new loc { x = -i, y = +0 }); break; }
				else break;
			}
			for (int i = 1; px + i < 8; i++)
			{
				PieceColour newLoc = getPiece(px + i, py + 0).getColour();
				if (newLoc == PieceColour.Empty) m.Add(new loc { x = +i, y = +0 });
				else if (newLoc != piece.getColour()) { m.Add(new loc { x = +i, y = +0 }); break; }
				else break;
			}
			for (int j = 1; j <= py; j++)
			{
				PieceColour newLoc = getPiece(px + 0, py - j).getColour();
				if (newLoc == PieceColour.Empty) m.Add(new loc { x = +0, y = -j });
				else if (newLoc != piece.getColour()) { m.Add(new loc { x = +0, y = -j }); break; }
				else break;
			}
			for (int j = 1; py + j < 8; j++)
			{
				PieceColour newLoc = getPiece(px + 0, py + j).getColour();
				if (newLoc == PieceColour.Empty) m.Add(new loc { x = +0, y = +j });
				else if (newLoc != piece.getColour()) { m.Add(new loc { x = +0, y = +j }); break; }
				else break;
			}
			return m;
		} // setRook

		private List<loc> setBishop(CPiece piece, int px, int py)
		{
			List<loc> m = new List<loc>();
			for (int i = 1; i <= Math.Min(px, py); i++)
			{
				PieceColour newLoc = getPiece(px - i, py - i).getColour();
				if (newLoc == PieceColour.Empty) m.Add(new loc { x = -i, y = -i });
				else if (newLoc != piece.getColour()) { m.Add(new loc { x = -i, y = -i }); break; }
				else break;
			}
			for (int i = 1; px + i < 8 && py - i >= 0; i++)
			{
				PieceColour newLoc = getPiece(px + i, py - i).getColour();
				if (newLoc == PieceColour.Empty) m.Add(new loc { x = +i, y = -i });
				else if (newLoc != piece.getColour()) { m.Add(new loc { x = +i, y = -i }); break; }
				else break;
			}
			for (int i = 1; px - i >= 0 && py + i < 8; i++)
			{
				PieceColour newLoc = getPiece(px - i, py + i).getColour();
				if (newLoc == PieceColour.Empty) m.Add(new loc { x = -i, y = +i });
				else if (newLoc != piece.getColour()) { m.Add(new loc { x = -i, y = +i }); break; }
				else break;
			}
			for (int i = 1; Math.Max(px, py) + i <= 7; i++)
			{
				PieceColour newLoc = getPiece(px + i, py + i).getColour();
				if (newLoc == PieceColour.Empty) m.Add(new loc { x = +i, y = +i });
				else if (newLoc != piece.getColour()) { m.Add(new loc { x = +i, y = +i }); break; }
				else break;
			}
			return m;
		} // setBishop

		private void updateMoveset(CPiece piece, int px, int py)
		{
			List<loc> m = new List<loc>();
			switch (piece.getType())
			{
				case PieceType.Pawn:
					switch (piece.getColour())
					{
						case PieceColour.Black:
							if (getPiece(px + 0, py + 1).getType() == PieceType.Empty) m.Add(new loc { x = +0, y = +1 });
							if (py == 1 && getPiece(px + 0, py + 2).getType() == PieceType.Empty) m.Add(new loc { x = +0, y = +2 });
							if (getPiece(px - 1, py + 1).getColour() == PieceColour.White) m.Add(new loc { x = -1, y = +1 });
							if (getPiece(px + 1, py + 1).getColour() == PieceColour.White) m.Add(new loc { x = +1, y = +1 });
							break;

						case PieceColour.White:
							if (getPiece(px + 0, py - 1).getType() == PieceType.Empty) m.Add(new loc { x = +0, y = -1 });
							if (py == 6 && getPiece(px + 0, py - 2).getType() == PieceType.Empty) m.Add(new loc { x = +0, y = -2 });
							if (getPiece(px - 1, py - 1).getColour() == PieceColour.Black) m.Add(new loc { x = -1, y = -1 });
							if (getPiece(px + 1, py - 1).getColour() == PieceColour.Black) m.Add(new loc { x = +1, y = -1 });
							break;
					}
					break;
				case PieceType.Rook:
					m= setRook(piece, px, py);
					break;
				case PieceType.Bishop:
					m = setBishop(piece, px, py);
					break;
				case PieceType.Queen:
					m = setRook(piece, px, py);
					m.AddRange(setBishop(piece, px, py));
					break;
				case PieceType.Knight:
					if (getPiece(px + 2, py - 1).getColour() != piece.getColour()) m.Add(new loc { x = +2, y = -1 });
					if (getPiece(px + 2, py + 1).getColour() != piece.getColour()) m.Add(new loc { x = +2, y = +1 });
					if (getPiece(px + 1, py - 2).getColour() != piece.getColour()) m.Add(new loc { x = +1, y = -2 });
					if (getPiece(px + 1, py + 2).getColour() != piece.getColour()) m.Add(new loc { x = +1, y = +2 });
					if (getPiece(px - 2, py - 1).getColour() != piece.getColour()) m.Add(new loc { x = -2, y = -1 });
					if (getPiece(px - 2, py + 1).getColour() != piece.getColour()) m.Add(new loc { x = -2, y = +1 });
					if (getPiece(px - 1, py - 2).getColour() != piece.getColour()) m.Add(new loc { x = -1, y = -2 });
					if (getPiece(px - 1, py + 2).getColour() != piece.getColour()) m.Add(new loc { x = -1, y = +2 });
					break;
				case PieceType.King:
					if (getPiece(px - 1, py - 1).getColour() != piece.getColour()) m.Add(new loc { x = -1, y = -1 });
					if (getPiece(px - 1, py + 0).getColour() != piece.getColour()) m.Add(new loc { x = -1, y = +0 });
					if (getPiece(px - 1, py + 1).getColour() != piece.getColour()) m.Add(new loc { x = -1, y = +1 });
					if (getPiece(px + 0, py - 1).getColour() != piece.getColour()) m.Add(new loc { x = +0, y = -1 });
					if (getPiece(px + 0, py + 1).getColour() != piece.getColour()) m.Add(new loc { x = +0, y = +1 });
					if (getPiece(px + 1, py - 1).getColour() != piece.getColour()) m.Add(new loc { x = +1, y = -1 });
					if (getPiece(px + 1, py + 0).getColour() != piece.getColour()) m.Add(new loc { x = +1, y = +0 });
					if (getPiece(px + 1, py + 1).getColour() != piece.getColour()) m.Add(new loc { x = +1, y = +1 });
					break;
			}
			piece.setMoveset(m);

		} // updateMoveset
		// end of legal moves checking

		public string PickOrDropPiece(int x, int y)
		{
			bool pickOrDrop = CurrentPiece == null;
			string s="";

			if (pickOrDrop)
			{
				// Pick a piece
				last_x = x; last_y = y;
				CPiece piece = getPiece(x, y);
				CPiece empty = new CPiece();

				if (piece.getColour() == playerTurn)
				{
					setPiece(x, y, empty);
					if (piece.getColour() != empty.getColour())
					{
						updateMoveset(piece, x, y);
						s = string.Format("You picked a {0}{1} at location {2},{3}", piece.getColour().ToString(), piece.getType().ToString(), x, y);
					}
					else
					{
						s = "Nothing there !";
						piece = null;
					}
					CurrentPiece = piece;
				}
				else s = string.Format("Other player's turn.");
			}
			else
			{
				// Drop picked piece
				if (x == last_x && y == last_y) { setPiece(x, y, CurrentPiece); s = string.Format("Cancelled move"); CurrentPiece = null; }
				else
				{
					bool valid = false; // restrict dropping
					foreach (loc lc in CurrentPiece.getMoveset())
					{ if (x == last_x + lc.x && y == last_y + lc.y) valid = true; }
					if (valid)
					{
						// taking opposite player piece
						score.addScore(playerTurn,getPiece(x, y).getValue());

						// drop
						setPiece(x, y, CurrentPiece);
						s = string.Format("You dropped a {0}{1} at location {2},{3}", CurrentPiece.getColour().ToString(), CurrentPiece.getType().ToString(), x, y);
						CurrentPiece = null;

						// switch players
						if (playerTurn == PieceColour.White) playerTurn = PieceColour.Black;
						else playerTurn = PieceColour.White;
					}
					else s = string.Format("Illegal move");
				}
			}
			return s;
		}


	} // class
} // namespace