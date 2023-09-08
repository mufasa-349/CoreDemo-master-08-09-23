﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class BlogManager : IBlogService
	{
		IBlogDal _blogDal;

		public BlogManager(IBlogDal blogDal)
		{
			_blogDal = blogDal;
		}

		public List<Blog> GetBlogList()
		{
			return _blogDal.GetlistWithCategory();
		}

        public List<Blog> Test(int id)
        {
			return _blogDal.GetlistWithCategoryByWriter(id);


		}


        public List<Blog> GetBlogByID(int id)
		{
			return _blogDal.GetListAll(x=>x.BlogID == id);
		}

		public Blog TGetById(int id)
		{
			return _blogDal.GetById(id);
		}

		public List<Blog> GetList()
		{
			return _blogDal.GetListAll();
		}

		public List<Blog> GetBlogListByWriter(int id)
		{
			return _blogDal.GetListAll(x => x.WriterID == id);
		}

        //public List<Blog> GetCategoryListByWriter(int id)
        //{
        //    return _blogDal.GetlistWithCategoryByWriter(id);
        //}

        public void TAdd(Blog t)
        {
			_blogDal.Insert(t);
        }

        public void TDelete(Blog t)
        {
			_blogDal.Delete(t);
        }

        public void TUpdate(Blog t)
        {
			_blogDal.Update(t);
        }
    }
}
