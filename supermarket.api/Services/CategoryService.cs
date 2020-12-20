﻿using supermarket.api.Domain.Repositories;
using supermarket.api.Domain.Services;
using supermarket.api.Domain.Services.Communication;
using supermarket.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace supermarket.api.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRespository _categoryRespository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRespository categoryRespository, IUnitOfWork unitOfWork)
        {
            _categoryRespository = categoryRespository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _categoryRespository.ListAsync();
        }

        public async Task<CategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await _categoryRespository.AddAsync(category);
                await _unitOfWork.CompleteAsync();
                return new CategoryResponse(category);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CategoryResponse($"An errror occured when saving the category: {ex.Message}");
            }
        }

        public async Task<CategoryResponse> UpdateAsync(int id, Category category)
        {
            var existingCategory = await _categoryRespository.FindByIdAsync(id);

            if (existingCategory == null)
            {
                return new CategoryResponse("Category not found");
            }

            existingCategory.Name = category.Name;

            try
            {
                _categoryRespository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(existingCategory);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CategoryResponse($"An error occured when updating the category: {ex.Message}");
            }
        }

        public async Task<CategoryResponse> DeleteAsync(int id)
        {
            var existingCategory = await _categoryRespository.FindByIdAsync(id);

            if (existingCategory == null)
            {
                return new CategoryResponse("Category not found");
            }

            try
            {
                _categoryRespository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(existingCategory);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CategoryResponse($"An error occurred when deleting the category: {ex.Message}");
            }


        }

    }
}
