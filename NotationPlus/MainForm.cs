using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Smf;
using Melanchall.DryWetMidi.Smf.Interaction;
using NotationPlus.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotationPlus
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private Notation notation = null;
        private Font noteFont = new Font(new FontFamily("微软雅黑"), 20);
        private void tsmiFile_OpenMidi_Click(object sender, EventArgs e)
        {
            if (dlgOpenMidi.ShowDialog() == DialogResult.OK)
            {
                notation = new Notation(dlgOpenMidi.FileName, mainView);
                pnlContainer.Refresh();
            }
        }

        private void pnlView_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.Clear(Color.White);
            //PointF posLT = new PointF(20, 50);
            //PointF posRB = new PointF(pnlView.Width - posLT.X, pnlView.Height - posLT.X);
            //float gapHeight = 10;
            //PointF pos = new PointF(20, 20);
            //for (int ln = 0; ln < 11; ++ln)
            //{
            //    if (ln == 5)
            //        continue;
            //    var pos1 = new PointF(posLT.X, posLT.Y + ln * gapHeight);
            //    var pos2 = new PointF(posRB.X, pos1.Y);
            //    e.Graphics.DrawLine(Pens.Black, pos1, pos2);
            //}
            //if (currMidiFile == null)
            //    return;
            //SizeF noteSize = new SizeF(10, 8);
            //float yPosC = posLT.Y + gapHeight * 5;
            //pos.Y = yPosC;
            //pos.X = posLT.X;
            //foreach (var ch in currMidiFile.GetTrackChunks())
            //{
            //    using (var notesManager = new NotesManager(ch.Events))
            //    {
            //        foreach (var n in notesManager.Notes)
            //        {
            //            int updown = 0;
            //            var step = GetNoteOffsetStepFromC(n.NoteNumber, ref updown) * -1;
            //            var offsetY = step * gapHeight * 0.5f - noteSize.Height * 0.5f;
            //            var rc = new RectangleF(new PointF(pos.X, yPosC + offsetY), new SizeF(30, 60));
            //            e.Graphics.DrawImage(Resources.elements, rc, new RectangleF(new PointF(150, 450), new SizeF(50, 100)), GraphicsUnit.Pixel);
            //            //e.Graphics.FillEllipse(Brushes.Black, rc);
            //            pos.X += 20;
            //        }
            //    }
            //    pos.Y += 50;
            //    pos.X = 20;
            //}
            //e.Graphics.DrawImage(Resources.elements, pos);
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            mainView.MouseWheel += MainView_MouseWheel;

            var file = @"\\Mac\Home\Music\Piano\Studying\Game - ToZanarkand.mid";
            //var midifile = MidiFile.Read(@"\\Mac\Home\Music\Piano\Studying\ForrestGump.mid");
            var midifile = MidiFile.Read(file);
            var ev = midifile.GetTempoMap().TimeSignature.Values.First().Value;


            notation = new Notation(file, mainView);
        }
        
        private void MainView_MouseWheel(object sender, MouseEventArgs e)
        {
            var add = e.Delta > 0 ? 0.1f : -0.1f;
            notation.ZoomRate += add;
        }

        private void mainView_Paint(object sender, PaintEventArgs e)
        {
            notation.Draw(e.Graphics);
        }
    }
}
