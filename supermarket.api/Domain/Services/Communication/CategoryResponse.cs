﻿using supermarket.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace supermarket.api.Domain.Services.Communication
{
    public class CategoryResponse : BaseResponse
    {
        public Category Category { get; private set; }
        private CategoryResponse(bool success, string message, Category category) : base(success, message)
        {
            {
                Category = category;
            }
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="category">Save category.</param>
        /// <returns>Response.</returns>
        public CategoryResponse(Category category) : this(true, string.Empty, category)
        {

        }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public CategoryResponse(string message) : this(false, message, null)
        {

        }

    }
}