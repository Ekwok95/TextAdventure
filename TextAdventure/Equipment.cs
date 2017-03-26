using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    public class Equipment
    {
        private int rightHand;
        private int leftHand;
        private int torso;
        private int legs;
        private int arms;
        private int helmet;

        public Equipment(int primary, int secondary, int chest, int legplate, int gloves, int head)
        {
            rightHand = primary;
            leftHand = secondary;
            torso = chest;
            legs = legplate;
            arms = gloves;
            helmet = head;
        }

        public int RightHand
        {
            get { return rightHand; }
            set { rightHand = value; }
        }

        public int LeftHand
        {
            get { return leftHand; }
            set { leftHand = value; }
        }

        public int Torso
        {
            get { return torso; }
            set { torso = value; }
        }

        public int Legs
        {
            get { return legs; }
            set { legs = value; }
        }

        public int Arms
        {
            get { return arms; }
            set { arms = value; }
        }

        public int Helmet
        {
            get { return helmet; }
            set { helmet = value; }
        }
    }
}
