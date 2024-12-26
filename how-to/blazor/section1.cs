using BarCode;
namespace IronBarcode.Examples.HowTo.Blazor
{
    public static class Section1
    {
        public static void Run()
        {
            // current video stream
            let videoStream;
            async function initializeCamera() 
            {
                const canvas = document.querySelector("#canvas");
                const video = document.querySelector("#video");
                if (
                    !"mediaDevices" in navigator ||
                    !"getUserMedia" in navigator.mediaDevices
                    )
                    {
                        alert("Camera API is not available in your browser");
                        return;
                    }
            
                // video constraints
                const constraints = {
                    video: {
                        width: {
                            min: 180
                        },
                        height: {
                            min: 120
                        },
                    },
                };
            
                constraints.video.facingMode = useFrontCamera ? "user" : "environment";
            
                try
                {
                    videoStream = await navigator.mediaDevices.getUserMedia (constraints);    
                    video.srcObject = videoStream;
                } 
                catch (err) 
                {
                    alert("Could not access the camera" + err);
                }
            }
        }
    }
}