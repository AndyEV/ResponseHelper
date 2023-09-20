using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResponseWrapperUtil.Core
{
    public class PaginatedRespose<T> : Response
    {
        public PaginatedRespose(List<T> data)
        {
            Data = data;
        }

        public List<T> Data { get; set; }

        internal PaginatedRespose(bool succeeded, List<T> data, string message = "", int count = 0, int page = 1, int pageSize = 10)
        {
            Data = data;
            CurrentPage = page;
            base.succeeded = succeeded;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
            statuscode = succeeded ? 200 : 400;
        }

        public static PaginatedRespose<T> Failure(string message)
        {
            return new PaginatedRespose<T>(false, default, message);
        }

        public static PaginatedRespose<T> Success(List<T> data, int count, int page, int pageSize)
        {
            return new PaginatedRespose<T>(true, data: data, count: count, page: page, pageSize: pageSize);
        }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int TotalCount { get; set; }
        public int PageSize { get; set; }

        public bool HasPreviousPage => CurrentPage > 1;

        public bool HasNextPage => CurrentPage < TotalPages;
    }

    public static partial class QueryableExtensions
    {
        public static async Task<PaginatedRespose<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize) where T : class
        {
            if (source == null) throw new Exception();
            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            pageSize = pageSize == 0 ? 10 : pageSize;
            int count = await source.CountAsync();
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            List<T> items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return PaginatedRespose<T>.Success(items, count, pageNumber, pageSize);
        }

        public static PaginatedRespose<T> ToPaginatedList<T>(this IQueryable<T> source, int pageNumber, int pageSize) where T : class
        {
            if (source == null) throw new Exception();
            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            pageSize = pageSize == 0 ? 10 : pageSize;
            int count = source.Count();
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            List<T> items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return PaginatedRespose<T>.Success(items, count, pageNumber, pageSize);
        }

        public static PaginatedRespose<T> ToPaginatedList<T>(this IEnumerable<T> source, int pageNumber, int pageSize) where T : class
        {
            if (source == null) throw new Exception();
            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            pageSize = pageSize == 0 ? 10 : pageSize;
            int count = source.Count();
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            List<T> items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return PaginatedRespose<T>.Success(items, count, pageNumber, pageSize);
        }

    }
}
