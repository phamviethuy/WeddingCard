// See https://aka.ms/new-console-template for more information
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Drawing;
using System.Drawing.Text;

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
PrivateFontCollection pfc = new PrivateFontCollection();
//pfc.AddFontFile("Fonts/Playwrite_CU/PlaywriteCU-Regular.ttf");
pfc.AddFontFile("GreatVibes-Regular.ttf");
FontFamily fontFamily = pfc.Families[0];


var guest = File.ReadAllLines("guest.txt");
Directory.CreateDirectory("output");
foreach (var name in guest)
{
    using var img = DrawTextOnImage("miu.jpg", name, new Font(fontFamily, 25), new SolidBrush(Color.BlueViolet), new RectangleF(550, 375, 360, 30));
    img.ToBitmap().Save($"output/{name}.jpg");
}


var guest_huy = File.ReadAllLines("guest_huy.txt");
Directory.CreateDirectory("huy");
foreach (var name in guest_huy)
{
    using var img = DrawTextOnImage("huy.jpg", name, new Font(fontFamily, 25), new SolidBrush(Color.BlueViolet), new RectangleF(550, 375, 360, 30));
    img.ToBitmap().Save($"huy/{name}.jpg");
}