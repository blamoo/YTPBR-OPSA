using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Sony.Vegas;

namespace SelectEven
{
    public class EntryPoint
    {
        public void FromVegas(Vegas vegas)
        {
            foreach (Track Track in vegas.Project.Tracks)
            {
                if (!Track.Selected)
                    continue;

                foreach (TrackEvent Event in Track.Events)
                {
                    Event.Selected = (Event.Index % 2 == 1) ? true : false;
                }
            }
        }
    }
}
