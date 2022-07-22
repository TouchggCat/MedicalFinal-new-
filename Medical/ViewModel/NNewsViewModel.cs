using Medical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.ViewModel
{
    public class NNewsViewModel
    {
        //private News _News;
        public NNewsViewModel()
        {
            _news = new News();
        }
        public News _news
        {
            get { return _news; }
            set { _news = value; }
        }
        public int No
        {
            get { return _news.No; }
            set { _news.No = value; }
        }
        public int? AdminId
        {
            get { return _news.AdminId; }
            set { _news.AdminId = value; }
        }
        public int? NewsCategoryId
        {
            get { return _news.NewsCategoryId; }
            set { _news.NewsCategoryId = value; }
        }
        public string NewsTitle
        {
            get { return _news.NewsTitle; }
            set { _news.NewsTitle = value; }
        }
        public string NewsContent
        {
            get { return _news.NewsContent; }
            set { _news.NewsContent = value; }
        }
        //public DateTime? PublishDate
        //{
        //    get { return _news.PublishDate; }
        //    set { _news.PublishDate = value; }
        //}
        public DateTime? CreateDate
        {
            get { return _news.CreateDate; }
            set { _news.CreateDate = value; }
        }
    }
}
