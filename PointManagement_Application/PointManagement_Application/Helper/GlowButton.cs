using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MetroFramework.Drawing.MetroPaint;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;

namespace PointManagement_Application.Helper
{
    public class GlowButton : Button
    {
        public Color GlowColor { get; set; } = Color.OrangeRed; // Màu phát sáng
        public int GlowRadius { get; set; } = 15; // Độ rộng phát sáng

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            // Vẽ hiệu ứng sáng lan tỏa phía ngoài
            DrawGlowEffect(pevent.Graphics);
        }

        private void DrawGlowEffect(Graphics g)
        {
            // Đặt chế độ vẽ chất lượng cao
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Kích thước và vị trí của hiệu ứng sáng
            var glowBounds = new Rectangle(
                this.ClientRectangle.X - GlowRadius,
                this.ClientRectangle.Y - GlowRadius,
                this.ClientRectangle.Width + GlowRadius * 2,
                this.ClientRectangle.Height + GlowRadius * 2
            );

            // Tạo hiệu ứng gradient phát sáng
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(glowBounds);

                using (PathGradientBrush brush = new PathGradientBrush(path))
                {
                    brush.CenterColor = Color.FromArgb(120, GlowColor); // Màu trung tâm (phát sáng)
                    brush.SurroundColors = new[] { Color.Transparent }; // Màu ngoài cùng (mờ dần)

                    g.FillEllipse(brush, glowBounds);
                }
            }
        }
    }
}
