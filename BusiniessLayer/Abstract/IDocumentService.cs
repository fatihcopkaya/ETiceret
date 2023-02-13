
using CoreLayer.Utilities.Result;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;


namespace BusiniessLayer.Abstract
{
    public interface IDocumentService
    {

        Task<IDataResult<Document>> GetDocumentByIdAsync(string DocumentUnique);
        Task<IDataResult<List<Document>>> GetDocumentListAsync();
        Task<IDataResult<string>> AddUploadAsync(IFormFile file, string FolderName, string Image_Url = null, string Video_Url = null);
        Task<IDataResult<string>> UpdateUploadAsync(IFormFile file, string DocumentUnique, string FolderName, string Image_Url = null, string Video_Url = null);
    }

}
