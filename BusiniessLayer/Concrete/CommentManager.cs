using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusiniessLayer.Abstract;
using BusiniessLayer.Contacts;
using CoreLayer.Utilities.Result;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusiniessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public async Task<IDataResult<Comment>> AddAsync(Comment comment)
        {
            await _commentDal.AddAsync(comment);
            return new SuccessDataResult<Comment>(comment, Messages.AddMessage);
        }

        public async Task<IResult> DeleteAsync(Comment comment)
        {
            await _commentDal.UpdateAsync(comment);
            return new SuccessDataResult<Comment>(comment, Messages.DeleteMessage);
        }

        public async Task<IDataResult<Comment>> GetByCommentIdAsync(int CommentId)
        {
           var row = await _commentDal.GetFirstOrDefaultAsync(x=>x.Id == CommentId);
           if(row != null)
           {
            return new SuccessDataResult<Comment>(row);
           }
           return new ErrorDataResult<Comment>(new Comment(), Messages.RecordMessage);

        }

        public async Task<IDataResult<List<Comment>>> GetCommentList(int Id)
        {
            return new SuccessDataResult<List<Comment>>((await _commentDal.GetListAsync(x => x.IsActived == true &&
             x.Product.Id == Id)).ToList());
        }

        public async Task<IResult> UpdateAsync(Comment comment)
        {
            await _commentDal.UpdateAsync(comment);
            return new SuccessDataResult<Comment>(comment, Messages.UpdateMessage);
        }

       

    }
}