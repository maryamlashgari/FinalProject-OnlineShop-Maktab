using App.Domain.Core.DataAccess;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices.Admins.Queries
{
    public class GetAllComments : IGetAllComments
    {
        private readonly ICommentRepository _commentRepo;

        public GetAllComments(ICommentRepository commentRepo)
        {
            _commentRepo = commentRepo;
        }
        /// <summary>
        /// ToDo : If I want to do this functin asyncronous what am i do??
        /// </summary>
        /// <returns></returns>
        public List<UserComment> Execute()
        {
            return _commentRepo.GetAllUserComments();
        }
    }
}
