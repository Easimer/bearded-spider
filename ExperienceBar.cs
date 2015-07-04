using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IrrlichtLime.Core;
using IrrlichtLime.Video;
using IrrlichtLime.GUI;
using IrrlichtLime.Scene;

namespace EasimerDemoScene
{
    class ExperienceBar : GUIElement
    {
        GUIEnvironment gui;
        int xWidth;
        Recti bar, border, toFill, empty;
        Color fillcolor, emptycolor, bordercolor;
        VideoDriver videoDriver;
 
        public ExperienceBar(GUIEnvironment guienv, Recti rectangle, int id = -1, GUIElement parent = null)
            : base(GUIElementType.Unknown, guienv, parent, rectangle)
        {
            xWidth = rectangle.LowerRightCorner.X - rectangle.UpperLeftCorner.X;
            gui = guienv;
            if (Parent != null)
            { bar = new Recti(Parent.RelativePosition.UpperLeftCorner + rectangle.UpperLeftCorner, Parent.RelativePosition.UpperLeftCorner + rectangle.LowerRightCorner); }
            else { bar = rectangle; }
 
            if (parent != null)
                gui.RootElement.AddChild(this);
            videoDriver = gui.VideoDriver;
            fillcolor = Color.OpaqueGreen;
            emptycolor = Color.OpaqueRed;
            bordercolor = Color.OpaqueBlack;
            border = bar;
            toFill = new Recti();
            empty = new Recti();
            SetProgress(0);
 
        }
        public void SetColors(Color progress, Color filling)
        {
            fillcolor = progress;
            emptycolor = filling;
        }
        public void AddBorder(int size, Color color)
        {
            bordercolor = color;
            border = new Recti(border.UpperLeftCorner.X - size, border.UpperLeftCorner.Y - size, border.LowerRightCorner.X + size, border.LowerRightCorner.Y + size);
        }
        public void SetProgress(uint progress)
        {
            if (progress > 100)
                progress = 0;
 
            int xpercentage;
            xpercentage = (int)(progress * xWidth) / 100; //Reducing to the bar size
            toFill.UpperLeftCorner.Set(bar.UpperLeftCorner.X, bar.UpperLeftCorner.Y);
            toFill = new Recti(bar.UpperLeftCorner.X, bar.UpperLeftCorner.Y, bar.UpperLeftCorner.X + xpercentage, bar.LowerRightCorner.Y);
            empty = new Recti(new Vector2Di(toFill.LowerRightCorner.X, toFill.UpperLeftCorner.Y), new Vector2Di(bar.LowerRightCorner.X, bar.LowerRightCorner.Y));
        }
        public new void Draw()
        {
            if (this.Visible == false)
                return;
 
            videoDriver.Draw2DRectangle(border, bordercolor);
            videoDriver.Draw2DRectangle(toFill, fillcolor);
            videoDriver.Draw2DRectangle(empty, emptycolor);
        }
    }
}
