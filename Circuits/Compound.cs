using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Circuits
{
    public class Compound : Gate
    {
        //List of all gate objects.
        List<Gate> gateObjectsList = new List<Gate>();

        /// <summary>
        /// Constructor to initalise values passed in.
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        public Compound(int x, int y) : base(x, y)
        {
        }

        /// <summary>
        /// Adds a gate to the list.
        /// </summary>
        public void AddGate(Gate g)
        {
            //Add gate to gates object list.
            gateObjectsList.Add(g);
            //If g.Left < Left THEN..
            if (g.Left < Left)
            {
                //Make left of the compound gate = g.Left
                left = g.Left;
            }
            //If g.Top < top THEN...
            if (g.Top < Top)
            {
                //Make top of the compound gate = g.Top
                top = g.Top;
            }
            //Test its in the list.
            MessageBox.Show(gateObjectsList.ToString());
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
        /// Draws the compound gate in the normal colour or in the selected colour from the gateOject list.
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
            pins[2].X = x + WIDTH + (GAP * 2);    //Output pin
            pins[2].Y = y + HEIGHT - GAP - 5;

            //Calculate distance of x - left of compound gate.
            int xDistance = x - left;
            //Calculate distance of y-left of compound gate.
            int yDistance = y - left;

            //Make left and top of the compound gate to the x and y.


            //Foreach gate in the gate list.
            foreach (Gate g in gateObjectsList)
            {
                //Move the left of the current gate to the left of gate + the x distance.
                //g.left += xDistance; 

                //The op of the current gate + the y distance.

                
            }
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
