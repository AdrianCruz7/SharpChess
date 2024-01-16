using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChess.Model
{
    /// <summary>
    /// class for generating string
    /// </summary>
    public class StartString
    {
        Random rand = new Random();
        public Dictionary<int, char> spaces = new Dictionary<int, char> { { 0, 'B' }, { 1, 'W' }, { 2, 'B' }, { 3, 'W' }, { 4, 'B' }, { 5, 'W' }, { 6, 'B' }, { 7, 'W' } };
        char[] pieces1 = new char[5] { 'k', 'r', 'r', 'b', 'b' };
        char[] pieces2 = new char[3] { 'n', 'n', 'q' };
        

        /// <summary>
        /// generates starting string for board
        /// </summary>
        /// <returns> string for the starting board </returns>
        public string GenerateStartString()
        {
            //char[] row = new char[8] { 'r', 'n', 'b', 'q', 'k', 'b', 'n', 'r' };
            //rnbqkbnr

            int kingPlacement = -1;
            char firstBishopPlacement = 'L';
            string board = "";
            string startBoard = "";

            foreach (char piece1 in pieces1)
            {
                switch (piece1)
                {
                    case 'k':
                        //int test = rand.Next(1, 7);
                        int test1 = rand.Next(1, 7);
                        spaces[test1] = piece1;
                        kingPlacement = test1;
                        break;

                    case 'r':
                        if (spaces.ContainsValue(piece1))
                        {
                            int secondRook = rand.Next(kingPlacement + 1, 8);
                            spaces[secondRook] = piece1;
                        }
                        else
                        {
                            int firstRook = rand.Next(0, kingPlacement);
                            spaces[firstRook] = piece1;
                        }
                        break;

                    case 'b':
                        bool placed = false;

                        while(!placed)
                        {
                            int test2 = rand.Next(0, 8);

                            if(firstBishopPlacement == 'B' || firstBishopPlacement == 'W')
                            {
                                switch (spaces[test2])
                                {
                                    case 'B':
                                        if(firstBishopPlacement == 'W')
                                        {
                                            spaces[test2] = piece1;
                                            placed = true;
                                        }
                                        break;

                                    case 'W':
                                        if(firstBishopPlacement == 'B')
                                        {
                                            spaces[test2] = piece1;
                                            placed = true;
                                        }
                                        break;

                                    default:
                                        break;
                                }
                                continue;
                            }

                            if (spaces[test2] == 'B' || spaces[test2] == 'W')
                            {
                                firstBishopPlacement = spaces[test2];
                                spaces[test2] = piece1;
                                placed = true;
                            }
                        }
                        break;
                }
            }

            foreach (char piece2 in pieces2)
            {
                bool placed = false;
                while (!placed)
                {
                    int test3 = rand.Next(0, 8);

                    if (spaces[test3] == 'B' || spaces[test3] == 'W')
                    {
                        spaces[test3] = piece2;
                        placed = true;
                    }
                }
            }

            foreach (var value in spaces)
            {
                board += value.Value;
            }

            Debug.Print(board);

            startBoard = CreateString(board);

            return startBoard;
        }

        public string CreateString(string board)
        {
            string finalBoard = "";
            finalBoard += board + "/pppppppp/8/8/8/8/PPPPPPPP/" + board.ToUpper() + " w KQkq - 0 1";
            return finalBoard;
        }
    }
}
