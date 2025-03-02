﻿namespace TsmartTechnicalInterviewAssignment.Entities.Dtos
{
    public class PagedList<T> : List<T>
    {
        public MetaData MetaData { get; set; }
        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            MetaData = new MetaData()
            {
                TotalCount = count,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalPage = (int)Math.Ceiling(count / (double)pageSize)
            };
            AddRange(items);


        }
        public static PagedList<T> ToPagedList(IEnumerable<T> sourse, int pageNumber, int pageSize)
        {

            var count = sourse.Count();
            var items = sourse
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
