using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcPaging;

namespace CageFlix.Areas.Admin.ViewModels
{
    public class PagedListViewModel<T> where T : class
    {
        private IQueryable<T> _objects;

        public int PageSize { get { return 25; } }

        public int? CurrentPage { get; set; }

        public IPagedList<T> Objects
        {
            get
            {
                return _objects.ToPagedList(this.CurrentPage.HasValue ? this.CurrentPage.Value - 1 : 0, this.PageSize);
            }
        }

        public PagedListViewModel(IQueryable<T> objects, int? currentPage = 1)
        {
            this._objects = objects;
            this.CurrentPage = currentPage;
        }
    }
}