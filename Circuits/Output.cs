using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuits
{
    public class Output : Gate
    {
        //ON brush
        protected Brush OFFBrush = Brushes.DarkSlateGray;

        //Boolean variable for current on/off status
        protected bool OnOffStatus = false;


        //Constructor
        public Output(int x, int y) : base (x, y)
        {
            //Add the input pin to the gate
            pins.Add(new Pin(this, true, 20));
            //move the gate and the pins to the position passed in
            MoveTo(x, y);
        }

        /// <summary>
        /// Override the draw method to draw the output gate.
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

            

            //Each time InputSource is selected, boolean value should toggle.
            //selecting it once changes the boolean value from false to true
            if (selected == true)
            {
                //high voltage (true) 
                OnOffStatus = !OnOffStatus;
            }
            // selecting it again changes it from true back to false.
            else
            {
                selected = false; //zero voltage (false)
            }

            //Check whether output pin is high voltage (true) or zero voltage (false)
            if (OnOffStatus == true) //glow like a small coloured lamp
            {                
                //Draw the gate with image from resources
                paper.DrawImage(Properties.Resources.OutputIcon, Left, Top);
            }
            else
            {
                //Dark when it is false
                brush = OFFBrush;
                paper.FillEllipse(brush, Left, Top, 15, 15);
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
            pins[0].Y = y + 8;
        }
    }
}