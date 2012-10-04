using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Sony.Vegas;

namespace Aumentar
{
    public class EntryPoint
    {
        public void FromVegas(Vegas vegas)
        {
            foreach (Track Track in vegas.Project.Tracks)
            {
                if (!Track.Selected)
                    continue;

                for (int i = 0; i < Track.Events.Count - 1; i++)
                {
                    Track.Events[i].Length = Track.Events[i + 1].Start - Track.Events[i].Start;
                }
            }
        }
    }
}
