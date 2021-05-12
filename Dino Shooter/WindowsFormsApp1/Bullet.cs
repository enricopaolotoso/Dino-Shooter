using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;
namespace WindowsFormsApp1
{
    class Bullet
    {
        public string direction;
        public int bulletLeft;
        public int bulletTop;

        private int speed = 20;
        private PictureBox bullet = new PictureBox();
        private Timer bulletTimer = new Timer();

        public void makeBullet(Form form)
        {
            bullet.BackColor = Color.White;
            bullet.Size = new Size(5, 5);
            bullet.Tag = "bullet";
            bullet.Left = bulletLeft;
            bullet.Top = bulletTop;
            bullet.BringToFront();

            form.Controls.Add(bullet);

            bulletTimer.Interval = speed;
            bulletTimer.Tick += new EventHandler(BulletTimerEvent);
            bulletTimer.Start();

        }


        private void BulletTimerEvent(object sender, EventArgs e)
        {
            if(direction == "left")
            {
                bulletLeft -= speed;
            }

            if(direction == "right")
            {
                bulletLeft += speed;
            }

            if(direction == "up")
            {
                bulletTop -= speed;
            }

            if(direction == "down")
            {
                bulletTop += speed;
            }
        }

    }
}
