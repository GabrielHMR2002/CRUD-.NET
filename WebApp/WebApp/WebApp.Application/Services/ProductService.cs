using WebApp.WebApp.Application.DTOs;
using WebApp.WebApp.Application.Interfaces;
using WebApp.WebApp.Domain.Entities;
using WebApp.WebApp.Domain.Interfaces;

namespace WebApp.WebApp.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(MapToDTO);
        }

        public async Task<ProductDTO?> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return product == null ? null : MapToDTO(product);
        }

        public async Task<ProductDTO> CreateProductAsync(CreateProductDTO createProductDto)
        {
            var product = new Product
            {
                Nome = createProductDto.Nome,
                Descricao = createProductDto.Descricao,
                Preco = createProductDto.Preco,
                QuantidadeEstoque = createProductDto.QuantidadeEstoque,
                DataCriacao = DateTime.UtcNow,
                Ativo = true
            };

            var createdProduct = await _productRepository.AddAsync(product);
            return MapToDTO(createdProduct);
        }

        public async Task<ProductDTO> UpdateProductAsync(int id, UpdateProductDTO updateProductDto)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                throw new KeyNotFoundException($"Produto com ID {id} não encontrado");

            product.Atualizar(
                updateProductDto.Nome,
                updateProductDto.Descricao,
                updateProductDto.Preco,
                updateProductDto.QuantidadeEstoque
            );

            await _productRepository.UpdateAsync(product);
            return MapToDTO(product);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var exists = await _productRepository.ExistsAsync(id);

            if (!exists)
                return false;

            await _productRepository.DeleteAsync(id);
            return true;
        }

        private static ProductDTO MapToDTO(Product product)
        {
            return new ProductDTO
            {
                Id = product.Id,
                Nome = product.Nome,
                Descricao = product.Descricao,
                Preco = product.Preco,
                QuantidadeEstoque = product.QuantidadeEstoque,
                DataCriacao = product.DataCriacao,
                DataAtualizacao = product.DataAtualizacao,
                Ativo = product.Ativo
            };
        }
    }
}
