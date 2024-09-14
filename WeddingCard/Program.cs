// See https://aka.ms/new-console-template for more information
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Drawing;

static Mat DrawTextOnImage(string inputImagePath, string text, Font font, Brush brush, RectangleF region)
{
    using Bitmap image = new(inputImagePath);


    using (Graphics g = Graphics.FromImage(image))
    {
        SizeF textSize = g.MeasureString(text, font);

        // Calculate the position to center the text
        float x = region.X + (region.Width - textSize.Width) / 2;
        float y = region.Y + (region.Height - textSize.Height) / 2;

        g.DrawString(text, font, brush, new PointF(x, y));
    }

    return image.ToMat();
}
using var img = DrawTextOnImage("miu.jpg", "Anh Huy", new Font(FontFamily.Families[3], 20), new SolidBrush(Color.Red), new RectangleF(550, 375, 360, 30));
using (new Window("dst image", img))
{
    Cv2.WaitKey();
}

