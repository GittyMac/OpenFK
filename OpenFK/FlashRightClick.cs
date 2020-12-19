using AxShockwaveFlashObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenFK
{
    class FlashRightClick : AxShockwaveFlash
    {
        protected override void WndProc(ref Message m)
        {
            if(m.Msg == 0x204) //If it's a right click.
            {
                if(!ModifierKeys.HasFlag(Keys.Control)) //If control is not held down | If it is, the context menu will show
                {
                    this.SetVariable("msg", @"<rightclick x=""" + Cursor.Position.X + @""" y=""" + Cursor.Position.Y + @""" />"); //Sends right click command to flash.
                    m.Result = IntPtr.Zero; //Blocks context menu from showing
                    return;
                }
            }
            base.WndProc(ref m);
        }
    }
}
