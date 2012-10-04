using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Sony.Vegas;

namespace OneFrame
{
    public class EntryPoint
    {
        public void FromVegas(Vegas vegas)
        {
            foreach (Track Track in vegas.Project.Tracks)
            {
                foreach (TrackEvent Event in Track.Events)
                {
                    if (!Event.Selected)
                        continue;

                    Event.Length = Timecode.FromFrames(1);
                }
            }
        }
    }
}
