using ChessMazeGame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using Button = System.Windows.Forms.Button;
using ComboBox = System.Windows.Forms.ComboBox;
using GroupBox = System.Windows.Forms.GroupBox;
using Label = System.Windows.Forms.Label;
using TextBox = System.Windows.Forms.TextBox;

namespace MazeProgramm
{
    public partial class Form1 : Form
    {
        public TextBox levelName;
        private Button musicBtn;        
        private ComboBox pickBackground;        
        private Button backgndBtn;     
        private Controller _controller;
        public string item;
        public string song;
        public string background;
        private OpenFileDialog loadFile;  
        private NumericUpDown boardSizeText;        
        private Button clearBtn;        
        private GroupBox gridBox;        
        private Button btnCreateBoard;
        private ComboBox combobox;
        private Button saveBtn;
        private Button btnCell;
        private Label label;
        private Label labelBackground;
        private ComboBox comboboxMusic;

        public Form1()
        {
            InitializeComponent();

        }

        public void SetController(Controller controller)
        {
            _controller = controller;
            
        }
        //creates grid 
        private void createBoardSize(object sender, EventArgs e)
        {
                        
            int x;
            int y;
            int boardSize = (int)boardSizeText.Value;
            
            if (boardSize >=2)
            {
                _controller.createBoard(boardSize);

                
                foreach (Control item in Controls.AsParallel().OfType<GroupBox>())
                {
                    if (item.Name == "gridBox")
                    {
                        Controls.Remove(item);
                    }
                }
                CreateGridBox(boardSize, boardSize);
                for (x = 0; x < boardSize; x++)
                {

                    for (y = 0; y < boardSize; y++)
                    {
                        createButtonCell((x + 1) * 100, (y + 1) * 100, "");
                    }
                }

            } else
            {
                MessageBox.Show($"Size of the board must be bigger than {boardSize}");
            }                  

        }

        //creating a comboboxchoosenFigure
        private void createComboBoxFigure()
        {
            combobox = new ComboBox();            
            combobox.Items.AddRange(new object[] {
            "Rook",
            "King",
            "Knight",
            "Bishop",
            "Empty",
            "Trophy"});
            combobox.Location = new System.Drawing.Point(5, 150);
            combobox.Name = "comboBox1";
            combobox.Size = new System.Drawing.Size(110, 23);
            combobox.TabIndex = 8;
            combobox.Tag = "";
            combobox.SelectedIndexChanged += new System.EventHandler(selectedFigure);
            Controls.Add(combobox);

        }
        //creating a label for combobox choose figure

        private void createLabelFigure()
        {
            label = new Label();
            label.AutoSize = true;
            label.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label.Location = new System.Drawing.Point(5, 120);
            label.Name = "label1";
            label.Size = new System.Drawing.Size(115, 19);
            label.TabIndex = 11;
            label.Text = "Select your figure";
            Controls.Add(label);
        }
        
        // pickMusic
        private void createComboboxMusic()
        {

            comboboxMusic = new ComboBox();
            comboboxMusic.FormattingEnabled = true;
            comboboxMusic.Items.AddRange(new object[] {
            "track",
            "dj"});
            comboboxMusic.Location = new System.Drawing.Point(40, 453);
            comboboxMusic.Name = "pickMusic";
            comboboxMusic.Size = new System.Drawing.Size(80, 40);
            comboboxMusic.TabIndex = 14;
            comboboxMusic.SelectedIndexChanged += new System.EventHandler(pickMusic_SelectedIndexChanged);
            Controls.Add(comboboxMusic);
        }

        //creating a save button
        private void createSaveBtn()
        {
            saveBtn = new Button();
            saveBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))),
                ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            saveBtn.Location = new System.Drawing.Point(5, 518);
            saveBtn.Name = "save";
            saveBtn.Size = new System.Drawing.Size(48, 27);
            saveBtn.TabIndex = 9;
            saveBtn.Text = "save";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += new System.EventHandler(save_Click);
            Controls.Add(saveBtn);
        }
        // creating level textbox for saving
        private void createLevelName()
        {            
            levelName = new();
            levelName.Location = new System.Drawing.Point(5, 490);
            levelName.Name = "levelName";
            levelName.PlaceholderText = "level name";
            levelName.Size = new System.Drawing.Size(100, 23);
            levelName.TabIndex = 10;
            Controls.Add(levelName);
        }

        //creating load level button 
        private void loadLevelBtn()
        {
            loadButton = new Button();
            loadButton.Location = new System.Drawing.Point(5, 550);
            loadButton.Name = "load";
            loadButton.Size = new System.Drawing.Size(75, 23);
            loadButton.TabIndex = 12;
            loadButton.Text = "load level";
            loadButton.UseVisualStyleBackColor = true;
            loadButton.Click += new System.EventHandler(LoadLevel);
            Controls.Add(loadButton);
        }
        // 
        // musicBtn
        // 
        private void createMusicBtn()
        {
            musicBtn = new Button();
            musicBtn.Image = (Bitmap)ChessMazeGame.Properties.Resources.phones;
            musicBtn.Location = new System.Drawing.Point(5, 450);
            musicBtn.Name = "musicBtn";
            musicBtn.Size = new System.Drawing.Size(30, 30);
            musicBtn.TabIndex = 13;
            musicBtn.UseVisualStyleBackColor = true;
            musicBtn.Click += new System.EventHandler(chooseSong);
            Controls.Add(musicBtn);
        }
        // create clear button 
        private void createClearBtn()
        {

            clearBtn = new Button();
            clearBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            clearBtn.FlatAppearance.BorderSize = 3;
            clearBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Fuchsia;
            clearBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point);
            clearBtn.Location = new System.Drawing.Point(5, 390);
            clearBtn.Name = "clearBtn";
            clearBtn.Size = new System.Drawing.Size(100, 51);
            clearBtn.TabIndex = 18;
            clearBtn.Text = "Clear Board";
            clearBtn.UseVisualStyleBackColor = true;
            clearBtn.Click += new System.EventHandler(ClearBoard);
            Controls.Add(clearBtn);

        }
        private void createComboboxBackground()
        {
            pickBackground = new ComboBox();
            pickBackground.FormattingEnabled = true;
            pickBackground.Items.AddRange(new object[] {
            "grass",
            "flowers",
            "chessBoard",
            "sky"});
            pickBackground.Location = new System.Drawing.Point(5, 261);
            pickBackground.Name = "pickBackground";
            pickBackground.Size = new System.Drawing.Size(97, 23);
            pickBackground.TabIndex = 15;
            pickBackground.SelectedIndexChanged += new System.EventHandler(pickBackground_SelectedIndexChanged);
            Controls.Add(pickBackground);
        }
        private void createlabelBackground()
        {
            labelBackground = new Label();
            labelBackground.AutoSize = true;
            labelBackground.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelBackground.Location = new System.Drawing.Point(5, 232);
            labelBackground.Name = "label2";
            labelBackground.Size = new System.Drawing.Size(114, 13);
            labelBackground.TabIndex = 16;
            labelBackground.Text = "Pick our background";

            Controls.Add(labelBackground);
        }
        public void createBackGroundBtn()
        {
            backgndBtn = new Button();
            backgndBtn.Location = new System.Drawing.Point(12, 302);
            backgndBtn.Name = "backgndBtn";
            backgndBtn.Size = new System.Drawing.Size(75, 23);
            backgndBtn.TabIndex = 17;
            backgndBtn.Text = "choose";
            backgndBtn.UseVisualStyleBackColor = true;
            backgndBtn.Click += new System.EventHandler(chooseBackground);
            Controls.Add(backgndBtn);
        }

        // creates a group box  to hold all the buttons
        public void CreateGridBox(int width, int height)
        {
            
            gridBox = new GroupBox();
            width = width * 100 + 200;
            height = height * 100 + 200;
            gridBox.Location = new Point(180,5);
            gridBox.Name = "gridBox";
            gridBox.Size = new Size(width, height);
            gridBox.TabIndex = 17;
            gridBox.TabStop = false;
            Controls.Add(gridBox);
        }
        // creating a button for a board 
        public void createButtonCell(int x, int y, string img)
        {
            btnCell = new Button ();
            btnCell.Image = (Bitmap)ChessMazeGame.Properties.Resources.ResourceManager.GetObject(img);
            btnCell.Location = new Point(x, y);
            btnCell.Name = "cellButton";
            btnCell.Size = new Size(100, 100);
            btnCell.TabIndex = 4;
            btnCell.Tag = "gridButton";
            btnCell.UseVisualStyleBackColor = true;
            btnCell.Click += new EventHandler(chooseCell);
            gridBox.Controls.Add(btnCell);
        }

        // grid size input textBox
        public void createInputBoardSize()
        {            
            boardSizeText = new();
            boardSizeText.Location = new Point(5, 15);
            boardSizeText.Margin = new Padding(3, 2, 3, 2);
            boardSizeText.Name = "boardSizeInput";
            boardSizeText.Size = new Size(110, 23);
            boardSizeText.TabIndex = 1;
            boardSizeText.Maximum = 8;// maximum is 8 as it's classic size of a chessboard
            Controls.Add(boardSizeText);
        }
        //button create grid
        private void createBtnBoard()
        {
            
            btnCreateBoard = new();
            btnCreateBoard.Location = new Point(5, 40);
            btnCreateBoard.Margin = new Padding(3, 2, 3, 2);
            btnCreateBoard.Name = "btnCreateGrid";
            btnCreateBoard.Size = new Size(90, 30);
            btnCreateBoard.TabIndex = 2;
            btnCreateBoard.Text = "Create Board";
            btnCreateBoard.UseVisualStyleBackColor = true;
            btnCreateBoard.Click += new EventHandler(createBoardSize);
            Controls.Add(btnCreateBoard);
        }

        private void chooseCell(object sender, EventArgs e)

        {

            if (item == null)
            {

                MessageBox.Show("Choose a figure!");

            }

            else
            {
                MessageBox.Show($" You picked a {item}");
                System.Windows.Forms.Button btn = (sender as System.Windows.Forms.Button);                
                var x = btn.Location.X;
                var y = btn.Location.Y;
                _controller.clickedCell(item, x, y);
                btn.Image = (Bitmap)ChessMazeGame.Properties.Resources.ResourceManager.GetObject(item);
            }

        }
        public void errorHandler(string Message)
        {
            MessageBox.Show(Message);
        }
        
        private void save_Click(object sender, EventArgs e)
        {
           
            
            if (levelName.Text != "")
            {
                _controller.saveMe(levelName.Text, pickBackground.Text, comboboxMusic.Text);
                MessageBox.Show(($" Level - '{levelName.Text}' is saved.Audio-'{comboboxMusic.Text}'," +
                $"background =-'{pickBackground.Text}'."));

            }
            else
            {
                errorHandler("Type a level name!");
            }

        }

        //load level
        private void LoadLevel(object sender, EventArgs e)
        {            

            loadFile = new OpenFileDialog();
            loadFile.ShowDialog();
            string fileName = loadFile.FileName;
            _controller.loadMe(fileName);
        }

        private void selectedFigure(object sender, EventArgs e)

        {
            System.Windows.Forms.ComboBox cb = (sender as System.Windows.Forms.ComboBox);
            item = cb.Text;
            MessageBox.Show(item);
        }

        private void pickMusic_SelectedIndexChanged(object sender, EventArgs e)
        {

            System.Windows.Forms.ComboBox cb = (sender as System.Windows.Forms.ComboBox);
            song = cb.Text;
            MessageBox.Show(song);
        }
        private void chooseSong(object sender, EventArgs e)

        {

            if (song == null)
            {

                MessageBox.Show("Choose a song!");
            }

            else
            {

                MessageBox.Show($" You picked a {song}");
                Button btnMusic = (sender as Button);

                MessageBox.Show("Music is on");
                _controller.ClickedSong(song);

            }

        }
        private void pickBackground_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            System.Windows.Forms.ComboBox cb = (sender as System.Windows.Forms.ComboBox);
            background = cb.Text;
            MessageBox.Show(background);

        }

        private void chooseBackground(object sender, EventArgs e)
        {
            MessageBox.Show($" You picked a {background}");

            Button btnBack = (sender as Button);


            gridBox.BackgroundImage = (Bitmap)ChessMazeGame.Properties.Resources.ResourceManager.GetObject(background);
        }


        private void ClearBoard(object sender, EventArgs e)
        {
            
            if (item != null) {

                foreach (Button item in gridBox.Controls.AsParallel().OfType<Button>())
                {
                   
                    item.Image = null;
                    item.Text = null;
                }

            }
            else
            {
                MessageBox.Show("There is nothing to clear yet!");
            }
        }
        // button "start it load everything))
        private void loadEverything(object sender, EventArgs e)
        {
            createLabelFigure();
            createComboBoxFigure();
            createSaveBtn();
            createLevelName();
            loadLevelBtn();
            createMusicBtn();
            createComboboxMusic();
            createClearBtn();
            createComboboxBackground();
            createlabelBackground();
            createBackGroundBtn();
            createInputBoardSize();
            createBtnBoard();
            


            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 749);

            this.Name = "Form1";
            this.Text = "Form1";
            
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
