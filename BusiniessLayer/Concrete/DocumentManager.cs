using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using BusiniessLayer.Abstract;
using BusiniessLayer.Contacts;
using CoreLayer.Utilities.Result;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;


namespace BusiniessLayer.Concrete
{
    public class DocumentManager : IDocumentService
    {
        private readonly IDocumentDal _documentDal;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DocumentManager(IDocumentDal documentDal, IHostingEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _documentDal = documentDal;
            _hostingEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IDataResult<string>> AddUploadAsync(IFormFile file, string FolderName, string Image_Url = null, string Video_Url = null)
        {
            if (file != null)
            {
                if (!IsImageValid(file))
                {
                    return new ErrorDataResult<string>(Messages.ImageSizeMessage);
                }
                else
                {
                    string Unique = GetId();
                    string path = string.Concat(_hostingEnvironment.ContentRootPath, "/wwwroot", FolderName);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string filename = string.Concat(Guid.NewGuid().ToString().Replace("-", "").Substring(0, 15), GetMimeTypes(file.ContentType));
                    using var fileStream = new FileStream(Path.Combine(path, filename), FileMode.Create);
                    await file.CopyToAsync(fileStream);
                    await _documentDal.AddAsync(new Document()
                    {
                        DocumentUnique = Unique,
                        DocumentName = filename,
                        DocumentFolderName = FolderName,
                        DocumentType = GetMimeTypes(file.ContentType),
                        DocumentSize = file.Length.ToString(),
                         Image_Url = Image_Url,
                         Video_Url = Video_Url,
                        CreateDate = DateTime.Now,
                        
                        


                    });
                    return new SuccessDataResult<string>(Unique, Messages.AddMessage);
                }
            }
            return new ErrorDataResult<string>(Messages.ErrorMessage);
        }

        public async Task<IDataResult<EntityLayer.Concrete.Document>> GetDocumentByIdAsync(string DocumentUnique)
        {
            var documentRow = await _documentDal.GetFirstOrDefaultAsync(x => x.DocumentUnique == DocumentUnique);
            if (documentRow != null)
            {
                return new SuccessDataResult<Document>(documentRow);
            }
            return new ErrorDataResult<Document>(Messages.RecordMessage);
        }

        public async Task<IDataResult<List<EntityLayer.Concrete.Document>>> GetDocumentListAsync()
        {
            return new SuccessDataResult<List<Document>>((await _documentDal.GetListAsync()).ToList());
        }

        public async Task<IDataResult<string>> UpdateUploadAsync(IFormFile file, string DocumentUnique, string FolderName, string Image_Url = null, string Video_Url = null)
        {
            if (file != null)
            {
                if (!IsImageValid(file))
                {
                    return new ErrorDataResult<string>(Messages.ImageSizeMessage);
                }
                else
                {
                    var documnetRow = await _documentDal.GetFirstOrDefaultAsync(x => x.DocumentUnique == DocumentUnique);
                    if (documnetRow != null)
                    {
                        string deleteFile = string.Concat(_hostingEnvironment.ContentRootPath, "/wwwroot", string.Concat(documnetRow.DocumentFolderName, documnetRow.DocumentName));
                        if (File.Exists(deleteFile) == true)
                        {
                            File.Delete(deleteFile);
                        }
                        string path = string.Concat(_hostingEnvironment.ContentRootPath, "/wwwroot", FolderName);
                        string filename = string.Concat(Guid.NewGuid().ToString().Replace("-", "").Substring(0, 15), GetMimeTypes(file.ContentType));
                        using var fileStream = new FileStream(Path.Combine(path, filename), FileMode.Create);
                        await file.CopyToAsync(fileStream);
                        documnetRow.DocumentName = filename;
                        documnetRow.DocumentFolderName = FolderName;
                        documnetRow.DocumentType = GetMimeTypes(file.ContentType);
                        documnetRow.DocumentSize = file.Length.ToString();
                        documnetRow.Image_Url = Image_Url;
                        documnetRow.Video_Url = Video_Url;
                        documnetRow.CreateDate = DateTime.Now;
                        await _documentDal.UpdateAsync(documnetRow);
                        return new SuccessDataResult<string>(documnetRow.DocumentUnique, Messages.AddMessage);
                    }
                    else
                    {
                        return new ErrorDataResult<string>(Messages.ErrorMessage);
                    }
                }
            }
            return new ErrorDataResult<string>(Messages.ErrorMessage);
        }
        private static string GetId()
        {
            return Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
        }
        private static string GetMimeTypes(string url)
        {
            string str = "";
            switch (url)
            {
                case "application/pdf":
                    str = ".pdf";
                    break;
                case "application/vnd.ms-excel":
                    str = ".xls";
                    break;
                case "application/vnd.ms-word":
                    str = ".doc";
                    break;
                case "application/vnd.openxmlformats-officedocument.presentationml.presentation":
                    str = ".pptx";
                    break;
                case "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet":
                    str = ".xlsx";
                    break;
                case "application/vnd.openxmlformats-officedocument.wordprocessingml.document":
                    str = ".docx";
                    break;
                case "image/gif":
                    str = ".gif";
                    break;
                case "image/jpeg":
                    str = ".jpeg";
                    break;
                case "image/jpg":
                    str = ".jpg";
                    break;
                case "image/png":
                    str = ".png";
                    break;
                case "image/svg+xml":
                    str = ".svg";
                    break;
                case "image/webp":
                    str = ".webp";
                    break;
                case "text/plain":
                    str = ".txt";
                    break;
                case "video/mp4":
                    str = ".mp4";
                    break;
            }
            return str;
        }
        public static bool IsImageValid(IFormFile file)
        {
            return file.Length <= 3 * 1024 * 1024;
        }
    }
}