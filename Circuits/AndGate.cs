using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Circuits
{
    /// <summary>
    /// This class implements an AND gate with two inputs
    /// and one output.
    /// </summary>
    public class AndGate : Gate
    {
        /// <summary>
        /// Initialises the Gate.
        /// </summary>
        /// <param name="x">The x position of the gate</param>
        /// <param name="y">The y position of the gate</param>
        public AndGate(int x, int y) : base(x, y)
        {
            //Add the two input pins to the gate
            pins.Add(new Pin(this, true, 20));
            pins.Add(new Pin(this, true, 20));
            //Add the output pin to the gate
            pins.Add(new Pin(this, false, 20));
            //move the gate and the pins to the position passed in
            MoveTo(x, y);
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
        /// Draws the gate in the normal colour or in the selected colour.
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

            // AND is simple, so we can use a circle plus a rectange.
            // An alternative would be to use a bitmap.
            //paper.FillEllipse(brush, left, top, WIDTH, HEIGHT);
            //paper.FillRectangle(brush, left, top, WIDTH / 2, HEIGHT);

            //Note: You can also use the images that have been imported into the project if you wish,
            //      using the code below.  You will need to space the pins out a bit more in the constructor.
            //      There are provided images for the other gates and selected versions of the gates as well.
            paper.DrawImage(Properties.Resources.AndGate, Left, Top);


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
            pins[0].X = x - GAP;    //Input pin 1
            pins[0].Y = y + GAP;
            pins[1].X = x - GAP;    //Input pin 2
            pins[1].Y = y + HEIGHT;  
            pins[2].X = x + WIDTH + (GAP*2);    //Output pin
            pins[2].Y = y + HEIGHT - GAP - 5;
        }

        /// <summary>
        /// Evaluate if both input pins are true, otherwise return false.
        /// </summary>
        /// <returns>Input pin evaluation.</returns>
        public override bool Evaluate()
        {
            //If input pin is not connected to wire, return false.
            if (pins[0].InputWire == null || pins[1].InputWire == null)
            {
                //Display error message.
                MessageBox.Show("Error: The AND gate input pin is not connected to a wire.");
                return false;
            }

            //If both input pins evaluate to true
            Gate gateA = pins[0].InputWire.FromPin.Owner;
            Gate gateB = pins[1].InputWire.FromPin.Owner;
            return gateA.Evaluate() && gateB.Evaluate();
        }

        /// <summary>
        /// Clones the AND gate.
        /// </summary>
        /// <returns>Fresh copy of the AND gate.</returns>
        public override Gate Clone()
        {
            //Create a copy of and gate and return.
            AndGate copyAndGate = new AndGate(left, top);
            return copyAndGate;
        }
    }
}
