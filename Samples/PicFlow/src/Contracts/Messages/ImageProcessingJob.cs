namespace FP.DevSpace2016.PicFlow.Contracts.Messages
{
    public class ImageProcessingJob : ImageJob
    {
        public string Overlay { get; set; }

        public int Resolution { get; set; }
    }
}
