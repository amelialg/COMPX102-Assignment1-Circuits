using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Circuits
{
    public class NotGate : Gate
    {
        /// <summary>
        /// Constructor to initialise the objects passed in.
        /// </summary>
        public NotGate(int x, int y) : base(x, y)
        {
            //Add the input pin to the gate
            pins.Add(new Pin(this, true, 20));
            //Add the output pin to the gate
            pins.Add(new Pin(this, false, 20));
            //move the gate and the pins to the position passed in
            MoveTo(x, y);
        }
        
        /// <summary>
        /// Override the draw method to draw not gate.
        /// </summary>
        /// <param name="paper"></param>
        public override void Draw(Graphics paper)
        {
            Brush brush;
            //Check if the gate has been selected
            if (selected)
            {
                brush = selectedBrush;
            }
            else
            {
                brush = normalBrush;
            }
            //Draw each of the pins
            foreach (Pin p in pins)
                p.Draw(paper);

            //Draw the gate with image from resources
            paper.DrawImage(Properties.Resources.NotGate, Left, Top);
        }

        /// <summary>
        /// Checks if the gate has been clicked on.
        /// </summary>
        /// <param name="x">The x position of the mouse click</param>
        /// <param name="y">The y position of the mouse click</param>
        /// <returns>True if the mouse click position is inside the gate</returns>
        public override bool IsMouseOn(int x, int y)
        {
            if (left <= x && x < left + WIDTH
                && top <= y && y < top + HEIGHT)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Moves the gate to the position specified.
        /// </summary>
        /// <param name="x">The x position to move the gate to</param>
        /// <param name="y">The y position to move the gate to</param>
        public override void MoveTo(int x, int y)
        {
            //Debugging message
            Console.WriteLine("pins = " + pins.Count);
            //Set the position of the gate to the values passed in
            left = x;
            top = y;
            // must move the pins too
            pins[0].X = x - GAP;    //Input pin
            pins[0].Y = y + HEIGHT/2 + GAP/2;
            pins[1].X = x + WIDTH + GAP*2;    //Output pin
            pins[1].Y = y + HEIGHT/2 + GAP/2;
        }

        /// <summary>
        /// Evaluate if input pin and return the opposite bool var.
        /// </summary>
        /// <returns>The opposite of input pin evaluation.</returns>
        public override bool Evaluate()
        {
            //If input pin is not connected to wire, return false.
            if (pins[0].InputWire == null )
            {
                //Display error message.
                MessageBox.Show("Error: The NOT gate input pin is not connected to a wire.");
                return false;
            }

            //If input evaluates true, return false. Otherwise return true.
            Gate gate = pins[0].InputWire.FromPin.Owner;
            return !gate.Evaluate();
        }

        /// <summary>
        /// Clones the NOT gate.
        /// </summary>
        /// <returns>Fresh copy of the NOT gate.</returns>
        public override Gate Clone()
        {
            //Create a copy of not gate and return.
            NotGate copyNotGate = new NotGate(left, top);
            return copyNotGate;
        }
    }
}
