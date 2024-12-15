using Maze;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChessMazeGame;
using MazeProgramm;

namespace  ChessMazeGame

{

    public class Controller
    {
        private readonly Form1 _view;
        private readonly Level _level;
        
        public Controller(Form1 view, Level level)
        {
            _view = view;
            _level = level;
        }

        public void createBoard(int size)
        {
            _level.SetLevelHeight(size);
            _level.SetLevelWidth(size);
            _level.CreateLevel(size, size);
        }


        public void clickedCell(string item, int x, int y)
        {
            
            int newX = x / 100 - 1;
            int newY = y / 100 - 1;

            switch (item)
            {
                case "Bishop":

                    {
                        _view.createButtonCell(x, y,"Bishop");
                    }
                    break;


                case "Empty":

                    {
                        _view.createButtonCell(x, y, "Empty");
                    }
                    break;

                case "King":

                    {
                        _view.createButtonCell(x, y, "King");
                    }
                    break;
                case "Knight":

                    {
                        _view.createButtonCell(x, y, "Knight");
                    }
                    break;

                case "Rook":

                    {
                        _view.createButtonCell(x, y, "Rook");
                    }
                    break;
                case "Trophy":

                    {
                        _view.createButtonCell(x, y, "Trophy");
                    }
                    break;
            }         

        }

        public void saveMe(string name,string music,string background)
        {

            try
            {
                _level.SetLevelName(name);
                _level.SaveMe();
            }

            catch (Exception e)
            {
                _view.errorHandler(e.Message);
            }

        }

        public void loadMe(string name)
        {

            try
            {
                _level.LoadMe(name);
            }

            catch (Exception e)
            {
                _view.errorHandler(e.Message);
            }

        }
        public void ClickedSong(string song)

        {
            MessageBox.Show(song.ToString());


            switch (song)
            {
                case "track":

                    {
                        System.IO.Stream str = Properties.Resources.track;
                        System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                        snd.Play();
                    }
                    break;
                case "dj":

                    {
                        System.IO.Stream str = Properties.Resources.dj;
                        System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                        snd.Play();
                    }
                    break;
            }

        }

    }

}

