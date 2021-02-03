using HovelHouse.GameKit;
using UnityEngine;
using UnityEngine.UI;

public class Sample_Photo : AbstractSample
{
    public Image unityImage;

    protected override void Run()
    {
        GKLocalPlayer.LocalPlayer.LoadPhotoForSize(GKPhotoSize.Normal, (image, error) =>
        {
            if (error != null)
            {
                Debug.LogError(error.LocalizedDescription);
                return;
            }

            var imageBytes = UIImage.PNGRepresentation(image);
            
            // There's also
            // var imageBytes = UIImage.JPEGRepresentation(image, compressionQuality); 
            // If you wanna import as a jpg
            
            // Size won't matter, it'll get resized when we load the data
            var texture = new Texture2D(2,2);
            var didCompress = texture.LoadImage(imageBytes);
            if(didCompress == false)
                Debug.LogError("failed to load image data");

            var newSprite = Sprite.Create(
                texture, 
                new Rect(0, 0, texture.width, texture.height), 
                new Vector2(0.5f, 0.5f));

            unityImage.sprite = newSprite;
        });
    }
}
