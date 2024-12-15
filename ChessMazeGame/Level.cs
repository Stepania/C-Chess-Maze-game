using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using FilerNS;
//using Newtonsoft.Json;

namespace Maze
{
    public class Level : ILevel
    {
        public Part[,] Board;
        
        private int BoardWidth;
        private int BoardHeight;
        private bool IsValid = false;
        public string LevelName = "";
        private string LevelBackground="";
        private string LevelMusic="";
        #nullable enable
        public Fileable? Data;




        // 1. set level name

        public void SetLevelName(string value)
        {
            LevelName = value;
        }

        // 2. set level width or board width
        public void SetLevelWidth(int width)
        {
            BoardWidth = width;
        }
        // 3. set Level height or board height
        public void SetLevelHeight(int height)
        {
            BoardHeight = height;
        }
        // 4. get level width
        public int GetLevelWidth()
        {
            return BoardWidth;

        }
        // 5. get level height
        public int GetLevelHeight()
        {
            return BoardHeight;
        }
        // 6. get level Name
        public string GetLevelName()
        {
            return LevelName;
        }
        // 7. add empty part to a particular position

        public void AddEmpty(int gridX, int gridY)
        {
            Board[gridX, gridY] = Part.Empty;
        }

        // 8. add Bishop to a particular position

        public void AddBishop(int gridX, int gridY)
        {
            Board[gridX, gridY] = Part.Bishop;
        }
        // 9. add King to a particular position

        public void AddKing(int gridX, int gridY)
        {
            Board[gridX, gridY] = Part.King;
        }
        // 10. add Knight to a particular position

        public void AddKnight(int gridX, int gridY)
        {
            Board[gridX, gridY] = Part.Knight;
        }
        // 11. add Rook to a particular position

        public void AddRook(int gridX, int gridY)
        {
            Board[gridX, gridY] = Part.Rook;
        }
        // 12. add player to a Bishop position

        public void AddPlayerOnBishop(int gridX, int gridY)
        {
            Board[gridX, gridY] = Part.PlayerOnBishop;
        }
        // 13. add player on empty part to particular position

        public void AddPlayerOnEmpty(int gridX, int gridY)
        {
            Board[gridX, gridY] = Part.PlayerOnEmpty;
        }

        // 14. add player on King part to particular position

        public void AddPlayerOnKing(int gridX, int gridY)
        {
            Board[gridX, gridY] = Part.PlayerOnKing;
        }
        // 15. add player on Knight part to particular position

        public void AddPlayerOnKnight(int gridX, int gridY)
        {
            Board[gridX, gridY] = Part.PlayerOnKnight;
        }
        // 16. add player on Rook part to particular position

        public void AddPlayerOnRook(int gridX, int gridY)
        {
            Board[gridX, gridY] = Part.PlayerOnRook;
        }
        // 17. check if level is valid
        public bool CheckValid()
        {
            if (BoardHeight==BoardWidth)// checking if a board is square
            {
                if(BoardHeight >2 & BoardWidth>2) // validation of a board,makes sure it is playable,because minimum size is 2x2.
                {
                    IsValid = true;
                }
                
            }else
            {
                Console.WriteLine("Incorrect input");
            }
            return IsValid;

        }
        // 18. creating a level from given width and height(board height and board width)
        public void CreateLevel(int width, int height)
        {
            Board = new Part[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Board[x, y] = new Part();
                    AddEmpty(x, y);
                }
            }
        }
        // 19. return part  position
        public Part GetPartAtIndex(int gridX, int gridY)
        {
            return Board[gridX, gridY];
        }

        // 21. save level to all levels
        public void SaveMe()
        {
            if (CheckValid())
            {
                Data = new(LevelName, Board,LevelBackground,LevelMusic);
                Filer filer = new();
                filer.Save(LevelName, Data);

            }
        }


        // 22. load a level
        public void LoadMe(string fileName)
        {
            Filer filer = new();
            filer.Load(fileName);
        }


        // 15. add player on Trophy part to particular position

        public void AddPlayerOnTrophy(int gridX, int gridY)
        {
            Board[gridX, gridY] = Part.PlayerOnTrophy;
        }
        // 16. add player on Rook part to particular position
        public void AddTrophy(int gridX, int gridY)
        {
            Board[gridX, gridY] = Part.Trophy;
        }

    }
}
