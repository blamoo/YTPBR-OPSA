using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Sony.Vegas;

namespace Enfileirar
{
    public class EntryPoint
    {
        public void FromVegas(Vegas vegas)
        {
            foreach (Track Track in vegas.Project.Tracks)
            {
                if (!Track.Selected)
                    continue;
                Timecode CPos = Timecode.FromNanos(0);

                foreach (TrackEvent Event in Track.Events)
                {
                    Event.Start = CPos;
                    CPos += Event.Length;
                }
            }
        }
    }
}
