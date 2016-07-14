using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze
{
    public partial class Form1 : Form
    {
        #region http://stackoverflow.com/questions/6638720/custom-cursor-in-c-sharp-winforms
        //(in a class)
        public static Cursor ActuallyLoadCursor(String path)
        {
            return new Cursor(LoadCursorFromFile(path));
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr LoadCursorFromFile(string fileName);
        #endregion

        System.Media.SoundPlayer startSoundPlayer = new System.Media.SoundPlayer(@"C:\Windows\Media\chord.wav");
        System.Media.SoundPlayer finishSoundPlayer = new System.Media.SoundPlayer(@"C:\Windows\Media\tada.wav");
        public Form1()
        {
            InitializeComponent();

            //var cursorFileName = @"C:\Users\littl\Downloads\sword.cur";
            var cursorFileName = @"sword.cur";
            var myCursor = new Cursor(cursorFileName);
            this.Cursor = myCursor;

            MoveToStart();
        }

        private void MoveToStart()
        {
            startSoundPlayer.Play();
            Point startingPoint = panel1.Location;
            startingPoint.Offset(10, 10);
            Cursor.Position = PointToScreen(startingPoint);
        }

        private void finishLabel_MouseEnter(object sender, EventArgs e)
        {
            finishSoundPlayer.Play();
            MessageBox.Show("Congratulations! You finished the maze!");
            Close();
        }

        private void wall_MouseEnter(object sender, EventArgs e)
        {
            //When the mouse pointer hits a wall or enters the panel,
            //call the MoveToStart() method
            MoveToStart();
        }
    }
}
