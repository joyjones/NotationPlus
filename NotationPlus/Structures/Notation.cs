using Melanchall.DryWetMidi.Smf;
using Melanchall.DryWetMidi.Smf.Interaction;
using NotationPlus.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotationPlus
{
    public class Notation
    {
        public Notation(string file, PictureBox canvas)
        {
            HostMidiFile = MidiFile.Read(file);
            CanvasControl = canvas;
            Settings = new NotationSettings();
            ZoomRate = 1;
            foreach (var ch in HostMidiFile.GetTrackChunks())
            {
                staves.Add(new Stave(this, ch));
            }
        }

        public class NotationSettings
        {
            public static readonly Size StandardA4Size = new Size(842, 595);
            public int TitleHeight = 50;
            public int TitleVerticalGap = 10;
            public Size NoteSize = new Size(10, 8);
            public int StaveGapHeight = 10;
            public int StaveTopLineOffset = 15;
        }

        public MidiFile HostMidiFile
        {
            get; private set;
        }

        public PictureBox CanvasControl
        {
            get; private set;
        }

        public NotationSettings Settings
        {
            get; private set;
        }
        private float zoomRate = 0;
        public float ZoomRate
        {
            get { return zoomRate; }
            set
            {
                if (zoomRate != value)
                {
                    var size = NotationSettings.StandardA4Size;
                    size.Width = (int)(size.Width * value);
                    size.Height = (int)(size.Height * value);
                    CanvasControl.Size = size;

                    zoomRate = value;
                    CanvasControl.Refresh();
                }
            }
        }
        public TimeSignature TimeSign
        {
            get => HostMidiFile.GetTempoMap().TimeSignature.Values.First().Value;
        }
        public TicksPerQuarterNoteTimeDivision TimeDivision
        {
            get => HostMidiFile.GetTempoMap().TimeDivision as TicksPerQuarterNoteTimeDivision;
        }

        public int Speed
        {
            get; private set;
        }

        public string Title
        {
            get; set;
        }

        public RectangleF StaveViewRect
        {
            get
            {
                var size = new SizeF(CanvasControl.Width, CanvasControl.Height);
                var padding = CanvasControl.Padding;
                PointF posLT = new PointF(padding.Left, padding.Top + Settings.TitleHeight + Settings.TitleVerticalGap * 2);
                PointF posRB = new PointF(padding.Right, padding.Bottom);
                size.Width -= posLT.X + posRB.X;
                size.Height -= posLT.Y + posRB.Y;
                return new RectangleF(posLT, size);
            }
        }

        public void Draw(Graphics g)
        {
            foreach (var s in staves)
                s.Draw(g);
        }

        private List<Stave> staves = new List<Stave>();
    }
}
