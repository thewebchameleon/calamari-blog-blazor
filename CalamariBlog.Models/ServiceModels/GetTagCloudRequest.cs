namespace CalamariBlog.Models.ServiceModels
{
    public class GetTagCloudRequest
    {
        public TagCloudTypeEnum Type { get; set; }
    }

    public enum TagCloudTypeEnum
    {
        Undefined = 0,
        BlogPosts = 1
    }
}
