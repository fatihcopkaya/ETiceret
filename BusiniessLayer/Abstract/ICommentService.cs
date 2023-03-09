using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLayer.Utilities.Result;
using EntityLayer.Concrete;

namespace BusiniessLayer.Abstract
{
    public interface ICommentService
    {
       Task<IDataResult<Comment>> GetByCommentIdAsync(int CommentId);
       Task<IDataResult<Comment>> AddAsync(Comment comment);
       Task<IResult> UpdateAsync(Comment comment);
       Task<IResult> DeleteAsync(Comment comment);
       Task<IDataResult<List<Comment>>> GetCommentList(int Id);
    }
}