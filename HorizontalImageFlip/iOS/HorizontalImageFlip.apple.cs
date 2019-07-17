using UIKit;

namespace Plugin.HorizontalImageFlip
{
    /// <summary>
    /// Interface for HorizontalImageFlip
    /// </summary>
    public class HorizontalImageFlipImplementation : IHorizontalImageFlip
    {
        public byte[] FlipImage(byte[] imageBytes)
        {
            UIImage originalImage = new UIImage(Foundation.NSData.FromArray(imageBytes));
            return originalImage.GetImageWithHorizontallyFlippedOrientation().AsJPEG().ToArray();
        }
    }
}
