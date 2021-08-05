using FA.JustBlog.Models.Common;
using FA.JustBlog.Services.BaseServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FA.JustBlog.Services
{
    public interface ICommentServices : IBaseService<Comment>
    {
        /// <summary>
        /// add comment for post
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="commentName"></param>
        /// <param name="commentEmail"></param>
        /// <param name="commentTitle"></param>
        /// <param name="commentBody"></param>
        Task<int> AddCommentAsync(int postId, string commentName, string commentEmail, string commentTitle, string commentBody);

        /// <summary>
        /// Get comment for post by post id
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        Task<IEnumerable<Comment>> GetCommentsForPostAsync(Guid postId);

        /// <summary>
        /// Get comment for post by post
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        Task<IEnumerable<Comment>> GetCommentsForPostAsync(Post post);
    }
}
