using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuits
{
    public class InputSource : Gate
    {
        ////boolean variable for output voltage
        protected bool outputVoltage;
        
        //High voltage brush
        protected Brush highVoltageBrush = Brushes.GreenYellow;

        //Constructor
        public InputSource (int x, int y) : base (x, y) 
        {
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
            {
                p.Draw(paper);
            }

            //Draw the gate with image from resources
            paper.DrawImage(Properties.Resources.InputIcon, Left, Top);

            //Check whether output pin is high voltage (true) or zero voltage (false)
            if (selected == true)
            {
                //Each time InputSource is selected, boolean value should toggle.
                //selecting it once should change the boolean value from false to true, selecting it again should change it from true back to false.
                //high voltage (true) 
                 outputVoltage = true;
            }
            else
            {
                //zero voltage (false)
                outputVoltage = false;
            }

            //Make gate a different colour when its boolean value is high (true)
            if (selected == true)
            {
                brush = highVoltageBrush;
                paper.FillRectangle(brush, Left, Top, 15, 15);

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
            pins[0].X = x + 20;    //Output pin
            pins[0].Y = y + 9;
        }
    }
}