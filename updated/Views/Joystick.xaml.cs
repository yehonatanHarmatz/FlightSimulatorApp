using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlightSimulatorApp.Views
{
    /// <summary>
    /// Interaction logic for Joystick.xaml
    /// </summary>
    public partial class Joystick : UserControl
    {
        // dragging == true if the knob is currently being dragged.
        public bool dragging;
        public static readonly DependencyProperty ElevatorProperty =
            DependencyProperty.Register("ELEVATOR", typeof(double), typeof(Joystick), null);
        public static readonly DependencyProperty RudderProperty =
            DependencyProperty.Register("RUDDER", typeof(double), typeof(Joystick), null);
        public double ELEVATOR
        {
            get { return Convert.ToDouble(GetValue(ElevatorProperty)); }
            set { SetValue(ElevatorProperty, value); }
        }
        public double RUDDER
        {
            get { return Convert.ToDouble(GetValue(RudderProperty)); }
            set { SetValue(RudderProperty, value); }
        }
        // Constructor
        public Joystick()
        {
            InitializeComponent();
            this.dragging = false;
            this.RUDDER = 0;
            this.ELEVATOR = 0;
        }

        /* * * * * * * * * * * * * * * * * * * * * *
         * This function in activated when the mouse
         * is over the joystick and on of the following
         * happens:
         *  1. The left button is clicked/released
         *  2. The left mouse is moving.
         *  
         * The function is moving the knob if needed,
         * or activating the center animation of the knob.
         * * * * * * * * * * * * * * * * * * * * * */
        public void onMouseMove(object sender, MouseEventArgs e)
        {
            // if the left button is clicked
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                dragging = true;
                // the position of the mouse:
                updatePosition(e.GetPosition(Base).X - BorderMouse.Width/2, e.GetPosition(Base).Y - BorderMouse.Height/2);
            }
            else if (dragging)
            {
                // activates the animation
                Storyboard exitAni = Knob.FindResource("CenterKnob") as Storyboard;
                exitAni.Begin(this, true);
                dragging = false;
            }
        }
        /* * * * * * * * * * * * * * * * * * * * * *
         * This function updates the location of the knob
         * according to the mouse location.
         * It also updates the X and Y cordinated that will
         * be sent to the flightsimulator.
         * * * * * * * * * * * * * * * * * * * * * */
        private void updatePosition(double x, double y)
        {
            // the position of the mouse
            Console.WriteLine(x + " " + y);
            double posX = x;
            double posY = y;
            // the radius of the black circle minus the radius of the knob.
            double border = (BorderStick.Width / 2) - (KnobBase.Width / 2);
            // the length of the knob from the center
            double len = Math.Sqrt(Math.Pow(posX, 2) + Math.Pow(posY, 2));
            // the x position of the knob if the knob is outside the black circle.
            // (I calculated his position so it won't exit the black circle)
            double x1 = (Math.Sqrt(Math.Pow(border, 2)/(Math.Pow((posY / posX), 2) + 1)));
            // just to know if the knob is on the right or on the left
            if (posX < 0) { x1 = -x1; }
            // the y position of the knob if it is outside the black circle.
            double y1 = x1 * (posY / posX);
            // if the knob still stays inside the black circle.
            if (len <= border)
            {
                knobPosition.X = posX;
                knobPosition.Y = posY;
            }
            // if the movement will take the knob outside the black circle.
            else
            {
                knobPosition.X = x1;
                knobPosition.Y = y1;
            }
            // updates cordinates
            this.RUDDER = knobPosition.X / border;
            this.ELEVATOR = -(knobPosition.Y / border);
            // changes in vm
        }
        /* * * * * * * * * * * * * * * * * * * * * *
         * This function stops the center knob animation.
         * * * * * * * * * * * * * * * * * * * * * */
        public void centerKnob_Completed(object sender, EventArgs e) {
            Storyboard exitAni = Knob.FindResource("CenterKnob") as Storyboard;
            exitAni.Stop(this);
            // resets the knob's position
            knobPosition.X = 0;
            knobPosition.Y = 0;
            // resets cordinates
            this.RUDDER = 0;
            this.ELEVATOR = 0;
        }
    }
}

