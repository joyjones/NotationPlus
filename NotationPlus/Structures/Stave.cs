using Melanchall.DryWetMidi.Smf;
using Melanchall.DryWetMidi.Smf.Interaction;
using NotationPlus.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotationPlus
{
    public class Stave
    {
        public Stave(Notation notation, TrackChunk ch)
        {
            ParentNotation = notation;
            
            using (var notesManager = new NotesManager(ch.Events))
            {
                foreach (var n in notesManager.Notes)
                {
                    notes.Add(new StaveNoteEvent(this, n));
                }
                //var timesMgr = new Melanchall.DryWetMidi.Smf.Interaction.TimedEventsManager(ch.Events);
                //var chordsMgr = new Melanchall.DryWetMidi.Smf.Interaction.ChordsManager(ch.Events);
            }
        }

        public Notation ParentNotation
        {
            get; private set;
        }
        
        public float YPosOfNoteC
        {
            get { return ParentNotation.StaveViewRect.Top + ParentNotation.Settings.StaveTopLineOffset + ParentNotation.Settings.StaveGapHeight * 5; }
        }
        public float DeltaTimePerSection
        {
            get { return ParentNotation.TimeDivision.TicksPerQuarterNote * ParentNotation.TimeSign.Numerator; }
        }
        public void Draw(Graphics g)
        {
            var rc = ParentNotation.StaveViewRect;
            float sectionWidth = rc.Width / 4;
            for (int ln = 0; ln < 5; ++ln)
            {
                var pos1 = new PointF(rc.Left, rc.Top + ln * ParentNotation.Settings.StaveGapHeight);
                var pos2 = new PointF(rc.Right, pos1.Y);
                g.DrawLine(Pens.Black, pos1, pos2);
            }
            float sectionX = rc.Left;
            while (sectionX <= rc.Right)
            {
                g.DrawLine(Pens.Black, sectionX, rc.Top, sectionX, rc.Top + 5 * ParentNotation.Settings.StaveGapHeight);
                sectionX += sectionWidth;
            }
            float posX = rc.Left;
            foreach (var n in notes)
            {
                int updown = 0;
                var step = GetNoteOffsetStepFromC(n.MidiNote.NoteNumber, ref updown) * -1;
                var offsetY = step * ParentNotation.Settings.StaveGapHeight * 0.5f - StaveNoteEvent.DefaultSize.Height * 0.5f;

                n.Draw(g, ref posX, offsetY);
            }
        }
        public int GetNoteOffsetStepFromC(int number, ref int updown)
        {
            // 1  2  3  4  5  6  7  1  2  3  4  5  6  7  1
            // 60,62,64,65,67,69,71,72,74,76,77,79,81,83,84
            int[] steps = new int[] { 2, 2, 1, 2, 2, 2, 1 };
            int n = 60;
            int cnt = 0;
            updown = 0;
            int dir = n < number ? 1 : -1;
            while (n != number)
            {
                cnt += 1 * dir;
                if (cnt > 0)
                    n += steps[(cnt - 1) % 7];
                else
                    n -= steps[(7 + (cnt % 7)) % 7];
                if (n == number)
                    return cnt;
                if (n == number + 1 * dir)
                {
                    updown = 1 * dir;
                    return cnt;
                }
            }
            return cnt;
        }
        private List<StaveEvent> events = new List<StaveEvent>();
        private List<StaveNoteEvent> notes = new List<StaveNoteEvent>();
    }

    public abstract class StaveEvent
    {
    }

    public class StaveNoteEvent : StaveEvent
    {
        public StaveNoteEvent(Stave stave, Note n)
        {
            MidiNote = n;
        }
        public Stave ParentStave
        {
            get; private set;
        }
        public Note MidiNote
        {
            get; private set;
        }
        public static readonly Size DefaultSize = new Size(30, 60);
        public enum Kind
        {
            Note1,
            Note2,
            Note4,
            Note8,
            Note16,
            Note32,
            Note64
        }
        public static Dictionary<Kind, (RectangleF region, PointF center)> NotesImageRegions = new Dictionary<Kind, (RectangleF region, PointF center)>()
        {
            { Kind.Note1, (new RectangleF(50, 500, 50, 50), new PointF(75, 537.5f)) },
            { Kind.Note2, (new RectangleF(100, 450, 50, 100), new PointF(125, 537.5f)) },
            { Kind.Note4, (new RectangleF(150, 450, 50, 100), new PointF(175, 537.5f)) },
            { Kind.Note8, (new RectangleF(200, 450, 70, 100), new PointF(225, 537.5f)) },
        };

        public void Draw(Graphics g, ref float x, float y)
        {
            var rc = new RectangleF(new PointF(x, y), DefaultSize);
            //g.DrawImage(Resources.elements, rc, new RectangleF(new PointF(150, 450), new SizeF(50, 100)), GraphicsUnit.Pixel);
            //e.Graphics.FillEllipse(Brushes.Black, rc);
        }

    }
}
