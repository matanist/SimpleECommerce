using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleECommerce.Models
{
    public class Data
    {
        public List<Product> Items { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class RootData
    {
        public bool Success { get; set; }
        public object Message { get; set; }
        public Data Data { get; set; }
        public object Errors { get; set; }
    }
}
