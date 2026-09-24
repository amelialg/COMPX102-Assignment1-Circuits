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
        public List<Gate> gateObjectsList = new List<Gate>();

        /// <summary>
        /// Gets the left hand edge of the gate.
        /// </summary>
        public override int Left
        {
            get { return left; }
            set { left = value; }
        }

        /// <summary>
        /// Gets the top edge of the gate.
        /// </summary>
        public override int Top
        {
            get { return top; }
            set { top = value; }
        }

        public override bool Selected
        {
            get { return selected; }
            set 
            { 
                if (selected != value)
                {
                    //Set selected to value
                    selected = value;
                    //Foreach gate in compound gate list.
                    foreach(Gate g in gateObjectsList)
                    {
                        g.Selected = value;
                    }
                }
            }

        }

        /// <summary>
        /// Constructor to initalise values passed in.
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        public Compound(int x, int y) : base(x, y)
        {
            MoveTo(x, y);
        }

        /// <summary>
        /// Adds a gate to the list.
        /// </summary>
        public void AddGate(Gate g)
        {
            //Add gate to gates object list.
            gateObjectsList.Add(g);

            //If g.Left < Left THEN...
            if (g.Left < Left)
            {
                //Make left of the compound gate = g.Left
                Left = g.Left;
            }
            //If g.Top < top THEN...
            if (g.Top < Top)
            {
                //Make top of the compound gate = g.Top
                Top = g.Top;
            }
        }

        /// <summary>
        /// Checks if the gate has been clicked on.
        /// </summary>
        /// <param name="x">The x position of the mouse click</param>
        /// <param name="y">The y position of the mouse click</param>
        /// <returns>True if the mouse click position is inside the gate</returns>
        public override bool IsMouseOn(int x, int y)
        {
            //Check if mouse is on the child gates 
            foreach (Gate g in gateObjectsList)
            {
                Console.WriteLine(g.Selected);
                if (g.IsMouseOn(x, y))
                {
                    Selected = !Selected;
                    return true;
                }
            }

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

            foreach (Gate g in gateObjectsList)
            {
                g.Draw(paper);
 
            }

            Pen pen = new Pen(Color.Red);
            paper.DrawRectangle(pen, Left, Top, 20, 20);
        }

        /// <summary>
        /// Moves the gate to the position specified.
        /// </summary>
        /// <param name="x">The x position to move the gate to</param>
        /// <param name="y">The y position to move the gate to</param>
        public override void MoveTo(int x, int y)
        {
            //Debugging message
            //Console.WriteLine("pins = " + pins.Count);

            //Calculate distance of x - left of compound gate.
            int xDistance = x - Left;
            //Calculate distance of y-left of compound gate.
            int yDistance = y - Top;

            //Set the position of the compound gate to the values passed in
            //Make left and top of the compound gate to the x and y
            Left = x; //set left of compound gate to x passed in (mouse click x)
            Top = y;  


            //Move the gates (w/pins too)
            //Foreach gate in the gate list.
            foreach (Gate g in gateObjectsList)
            {
                //Move the left of the current gate to the left of gate + the x distance,
                //Move the top of the current gate + the y distance.
                g.MoveTo(g.Left + xDistance, g.Top + yDistance);
                
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
        /// Clones the compound gate.
        /// </summary>
        /// <returns>Fresh copy of the AND gate.</returns>
        public override Gate Clone()
        {
            //Create a copy of and gate and return.
            Compound copyCompoundGate = new Compound(Left, Top);
            foreach (Gate g in gateObjectsList)
            {
                Gate cloned = (Gate) g.Clone();
                //Add gate to new compound.
                copyCompoundGate.AddGate(cloned);
            }
            return copyCompoundGate;
        }
    }
}
