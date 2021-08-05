using FA.JustBlog.Data.Infrastructure;
using FA.JustBlog.Models.Common;
using FA.JustBlog.Services.BaseServices;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FA.JustBlog.Services
{
    public class CommentServices : BaseServices<Comment>, ICommentServices
    {
        public CommentServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<int> AddCommentAsync(int postId, string commentName, string commentEmail, string commentTitle, string commentBody)
        {
            var comment = new Comment
            {
                PostId = Guid.NewGuid(),
                Name = commentName,
                Email = commentEmail,
                CommentHeader = commentTitle,
                CommentText = commentBody,
                CommentTime = DateTime.Now
            };
            _unitOfWork.CommentRepository.Add(comment);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Comment>> GetCommentsForPostAsync(Post post)
        {
            return await _unitOfWork.CommentRepository.GetQuery().Where(x => x.PostId == post.Id).ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetCommentsForPostAsync(Guid postId)
        {
            return await _unitOfWork.CommentRepository.GetQuery().Where(x=>x.PostId == postId).ToListAsync();
        }
    }
}
