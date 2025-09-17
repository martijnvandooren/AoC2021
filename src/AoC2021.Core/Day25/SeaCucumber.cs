using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021.Core.Day25
{
    public class SeaCucumber
    {
        public readonly int Height;
        public readonly int Width;
        private HashSet<Point> _right;   // '>'
        private HashSet<Point> _down;  // 'v'

        public readonly record struct Point(int Row, int Col);

        public SeaCucumber(string[] lines)
        {
            Height = lines.Length;
            Width = lines[0].Length;
            _right = new HashSet<Point>();
            _down = new HashSet<Point>();

            SetupGrid(lines);
        }

        private void SetupGrid(string[] lines) 
        {
            for (int r = 0; r < Height; r++)
            {
                for (int c = 0; c < Width; c++)
                {
                    char ch = lines[r][c];
                    if (ch == '>') _right.Add(new Point(r, c));
                    else if (ch == 'v') _down.Add(new Point(r, c));
                }
            }
        }

        public bool Step() => MoveRight() | MoveDown();

        //returned integer aantal iteraties
        //
        public int RunUntilStable()
        {
            int steps = 0;
            bool moved = true;
            while (moved)
            {
                steps++;
                moved = Step(); //voer stap uit
                if (!moved) return steps;
            }
            return steps;
        }

        private bool MoveRight()
        {
            bool movedRight = false;
            var next = new HashSet<Point>(_right.Count);
            foreach (var p in _right)
            {
                var q = new Point(p.Row, NeedToSwitchToStartColumn(p.Col + 1));
                // als positie vrij is (geen > of v) ga dan naar punt
                if (!_right.Contains(q) && !_down.Contains(q))
                {
                    next.Add(q);
                    movedRight = true;
                }
                else next.Add(p);
            }
            _right = next;
            return movedRight;
        }

        private bool MoveDown()
        {
            bool movedDown = false;
            var next = new HashSet<Point>(_down.Count);
            foreach (var p in _down)
            {
                var q = new Point(NeedToSwitchToStartRow(p.Row + 1), p.Col);
                //Nadat rechts is geweest, checken op rechts(updated) en beneden(huidig)
                if (!_right.Contains(q) && !_down.Contains(q))
                {
                    next.Add(q);
                    movedDown = true;
                }
                else next.Add(p);
            }
            _down = next;
            return movedDown;
        }

        private int NeedToSwitchToStartRow(int r) => r >= Height ? 0 : r;
        private int NeedToSwitchToStartColumn(int c) => c >= Width ? 0 : c;
    }
}
