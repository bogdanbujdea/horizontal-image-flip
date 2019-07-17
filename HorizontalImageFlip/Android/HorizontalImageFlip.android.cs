using System;
using System.Collections.Generic;
using System.IO;
using Android.Graphics;

namespace Plugin.HorizontalImageFlip
{
    /// <summary>
    /// Interface for HorizontalImageFlip
    /// </summary>
    public class HorizontalImageFlipImplementation : IHorizontalImageFlip
    {
        public byte[] FlipImage(byte[] imageBytes)
        {
            var bitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
            var bitmapDrawable = Flip(bitmap);
            using (MemoryStream ms = new MemoryStream())
            {
                bitmapDrawable.Compress(Bitmap.CompressFormat.Jpeg, 100, ms);

                bitmapDrawable.Recycle();

                return ms.ToArray();
            }
        }

        Bitmap Flip(Bitmap d)
        {
            Matrix m = new Matrix();
            m.PreScale(-1, 1);
            Bitmap dst = Bitmap.CreateBitmap(d, 0, 0, d.Width, d.Height, m, false);
            return dst;
        }
    }
}
