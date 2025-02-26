﻿using EGreetings.Data;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EGreetings.Services
{
    public class CategoryDataActionFilter : IActionFilter
    {
        private readonly EGreetingsDbContext _context;

        public CategoryDataActionFilter(EGreetingsDbContext context)
        {
            _context = context;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Lấy tất cả các category từ cơ sở dữ liệu
            var categories = _context.Categories.Where(c => c.Status == true).ToList();

            // Truyền vào ViewData để sử dụng trong layout
            context.HttpContext.Items["Categories"] = categories;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
