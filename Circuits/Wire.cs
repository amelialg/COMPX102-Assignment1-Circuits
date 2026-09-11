using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuits
{
    /// <summary>
    /// A wire connects between two pins.
    /// That is, it connects the output pin FromPin 
    /// to the input pin ToPin.
    /// </summary>
    public class Wire
    {
        //Has the wire been selected
        protected bool selected = false;
        //The pins the wire is connected to
        protected Pin fromPin, toPin;

        /// <summary>
        /// Initialises the object to the pins it is connected to.
        /// </summary>
        /// <param name="from">The pin the wire starts from</param>
        /// <param name="to">The pin the wire ends at</param>
        public Wire(Pin from, Pin to)
        {
            fromPin = from;
            toPin = to;
        }

        /// <summary>
        /// Indicates whether this gate is the current one selected.
        /// </summary>
        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }

        /// <summary>
        /// The output pin that this wire is connected to.
        /// </summary>
        public Pin FromPin
        {
            get { return fromPin; }
        }

        /// <summary>
        /// The input pin that this wire is connected to.
        /// </summary>
        public Pin ToPin
        {
            get { return toPin; }
        }

        /// <summary>
        /// Draws the wire.
        /// </summary>
        /// <param name="paper"></param>
        public void Draw(Graphics paper)
        {
            //This is a short-hand way of doing an if statement.  It is saying if selected == true then 
            //use Color.Red else use Color.White and then create the wire
            Pen wire = new Pen(selected ? Color.Red : Color.White, 3);
            //Draw the wire
            paper.DrawLine(wire, fromPin.X, fromPin.Y, toPin.X, toPin.Y);
        }
    }
}
