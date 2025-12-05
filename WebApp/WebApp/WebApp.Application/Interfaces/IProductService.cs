using WebApp.WebApp.Application.DTOs;

namespace WebApp.WebApp.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO?> GetProductByIdAsync(int id);
        Task<ProductDTO> CreateProductAsync(CreateProductDTO createProductDto);
        Task<ProductDTO> UpdateProductAsync(int id, UpdateProductDTO updateProductDto);
        Task<bool> DeleteProductAsync(int id);
    }
}
