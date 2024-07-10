namespace LinBeach.Repositories
{
    public interface IImageRep
    {
        Task<string> UploadAsync(IFormFile file);
    }
}
