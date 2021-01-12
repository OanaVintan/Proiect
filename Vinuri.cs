using System;
using System.Collections.Generic;
using System.Text;

namespace Proiect
{
    class Vinuri
    {
        private VinuriType mFlavor;
        public VinuriType Flavor
        {
            get
            {
                return mFlavor;
            }
            set
            {
                mFlavor = value;
            }
        }
        private float mPrice;
        public float Price
        {
            get
            {
                return mPrice;
            }
            set
            {
                mPrice = value;
            }
        }
        public Vinuri(VinuriType aFlavor) 
        {
            mFlavor = aFlavor;
        }

    }
    public enum VinuriType
    {
        RosuSec,
        RosuDemisec,
        RosuDemidulce,
        AlbSec,
        AlbDemisec,
        AlbDemidulce,
        RoseDemidulce

    }
}
