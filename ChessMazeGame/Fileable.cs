using System;
using System.Collections.Generic;
using Maze;

namespace FilerNS
{
    public class Fileable : IFileable
    {
        public Part[,] LevelBoard = { };

        public string LevelName = "";

        public string LevelMusic = "";
        public string LevelBackground = "";
        
        //public 

        public Fileable(string name, Part[,] board,string background,string music)
        {
            LevelName = name;
      
            LevelBoard = board;

            LevelBackground = background;
            LevelMusic = music;
            
        }
        public int GetColumnCount()
        {
            return LevelBoard.GetLength(0);
        }

        public int GetRowCount()
        {
            return LevelBoard.GetLength(1);
        }

        public Part WhatsAt(int row, int column)
        {
            return LevelBoard[row, column];
        }
    }
}
