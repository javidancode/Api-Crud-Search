using AutoMapper;
using DomainLayer.Entities;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTOs.Product;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repo, IMapper mapper)
        {
                _repo= repo;
                _mapper= mapper;    
        }

        public async Task CreateAsync(ProductCreateDto product)
        {
            //var mappedData = _mapper.Map<Product>(product);
            await _repo.Create(_mapper.Map<Product>(product));
        }

        public async Task DeleteAsync(int id)
        {
            Product product = await _repo.Get(id);
            await _repo.Delete(product);
        }

        public async Task<List<ProductListDto>> GetAllAsync()
        {
            //var products = await _repo.GetAll();
            return _mapper.Map<List<ProductListDto>>(await _repo.GetAll());
        }

        public async Task<List<ProductListDto>> SearchAsync(string? searchText)
        {
            List<Product> searchDatas = new();

            if (searchText != null)
            {
                searchDatas = await _repo.FindAllByExpressionAsync(m => m.Name.Contains(searchText));
            }
            else
            {
                searchDatas = await _repo.GetAll();
            }

            return _mapper.Map<List<ProductListDto>>(searchDatas);
        }

        public async Task SoftDeleteAsync(int id)
        {
            Product product = await _repo.Get(id);
            await _repo.SoftDelete(product);
        }

        public async Task UpdateAsync(int id, ProductUpdateDto product)
        {
            var dbProduct = await _repo.Get(id);

            _mapper.Map(product, dbProduct);

            await _repo.Update(dbProduct);
        }
    }
}
