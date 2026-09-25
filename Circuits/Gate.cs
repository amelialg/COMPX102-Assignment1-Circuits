using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuits
{
    public abstract class Gate
    {

        /// <summary>
        /// Constructor, initalises the objects for the values to be passed in.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Gate (int x, int y)
        {
        }

        // left is the left-hand edge of the main part of the gate.
        // So the input pins are further left than left.
        protected int left;

        // top is the top of the whole gate
        protected int top;

        //Width of the main part of the gate
        protected const int WIDTH = 40;
        //Height of the main part of the gate.
        protected const int HEIGHT = 40;
        //Length of the connector legs sticking out left and right
        protected const int GAP = 10;
        //Selected colour of the brush (red).
        protected Brush selectedBrush = Brushes.Red;
        //Deselected normal colour of the brush (light gray).
        protected Brush normalBrush = Brushes.LightGray;
        //Has the gate been selected
        protected bool selected = false;

        /// <summary>
        /// This is the list of all the pins of this gate.
        /// An AND gate always has two input pins (0 and 1)
        /// and one output pin (number 2).
        /// </summary>
        protected List<Pin> pins = new List<Pin>();

        /// <summary>
        /// Gets and sets whether the gate is selected or not.
        /// </summary>
        public virtual bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }

        /// <summary>
        /// Gets and sets the left hand edge of the gate.
        /// </summary>
        public virtual int Left
        {
            get { return left; }
            set { left = value; }
        }

        /// <summary>
        /// Gets and sets the top edge of the gate.
        /// </summary>
        public virtual int Top
        {
            get { return top; }
            set { top = value; }
        }

        /// <summary>
        /// Gets the list of pins for the gate.
        /// </summary>
        public List<Pin> Pins
        {
            get { return pins; }
        }

        /// <summary>
        /// Checks if the gate has been clicked on.
        /// </summary>
        /// <param name="x">The x position of the mouse click</param>
        /// <param name="y">The y position of the mouse click</param>
        /// <returns>True if the mouse click position is inside the gate</returns>
        public abstract bool IsMouseOn(int x, int y);

        /// <summary>
        /// Draws the gate in the normal colour or in the selected colour.
        /// </summary>
        /// <param name="paper"></param>
        public abstract void Draw(Graphics paper);

        /// <summary>
        /// Moves the gate to the position specified.
        /// </summary>
        /// <param name="x">The x position to move the gate to</param>
        /// <param name="y">The y position to move the gate to</param>
        public abstract void MoveTo(int x, int y);

        /// <summary>
        /// Compute the correct logical result for that kind of gate.
        /// </summary>
        /// <returns>Boolean variable as result</returns>
        public abstract bool Evaluate();

        /// <summary>
        /// Makes a copy of that kind of gate (including each of its pins).
        /// </summary>
        /// <returns>Fresh copy of the gate</returns>
        public abstract Gate Clone();

    }
}
