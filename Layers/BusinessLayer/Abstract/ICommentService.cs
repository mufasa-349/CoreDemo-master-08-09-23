using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
        //void BlogAdd(Comment comment);
        //void BlogDelete(Comment comment);
        //void BlogUpdate(Comment comment);

        List<Comment> GetList();
        Comment GetById(int id);

        List<Comment> GetCommentList(int id);
    }
}
