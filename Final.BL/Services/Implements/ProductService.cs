using AutoMapper;
using Final.BL.DTOs.Product;
using Final.BL.Exceptions;
using Final.BL.ExternalServices.Abstracts;
using Final.BL.Services.Abstract;
using Final.Core.Entities;
using Final.Core.Repositories;

namespace Final.BL.Services.Implements
{
    public class ProductService(
        IProductRepository _repo,
        IFileService _file,
        IMapper _mapper,
        IProductImageRepository _imgrepo,
        ICategoryRepository _catrepo) : IProductService
    {

        public async Task<Product> CreateAsync(ProductCreateDTO dto)
        {
            bool isCategoryExist = await _catrepo.IsExistAsync(dto.CategoryId);

            if (!isCategoryExist)
                throw new NotFoundException<Category>();

            string ImageURL = await _file.SaveImageAsync(dto.Image, "Products");

            Product product = new Product
            {
                Image = ImageURL,
                CategoryId = dto.CategoryId,
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                DiscountPrice = dto.DiscountPrice,
                Stock = dto.Stock,
                IsFeatured = dto.IsFeatured
            };


            await _repo.AddAsync(product);
            await _repo.SaveAsync();


            if (dto.OtherImages != null && dto.OtherImages.Any())
            {
                foreach (var image in dto.OtherImages)
                {
                    string imageUrl = await _file.SaveImageAsync(image, "ProductImages");


                    ProductImage productImage = new ProductImage
                    {
                        ProductId = product.Id,
                        Image = imageUrl
                    };


                    await _imgrepo.AddAsync(productImage);
                }

                await _imgrepo.SaveAsync();
            }


            return product;
        }



        public async Task DeleteAsync(int id)
        {
            var product = await _repo.GetByIdAsync(id);


            if (product == null)
                throw new NotFoundException("Product tapılmadı.");


            // əsas şəkil
            if (!string.IsNullOrEmpty(product.Image))
            {
                await _file.DeleteImageAsync(product.Image);
            }



            // əlavə şəkillər
            if (product.Images != null)
            {
                foreach (var image in product.Images)
                {
                    if (!string.IsNullOrEmpty(image.Image))
                    {
                        await _file.DeleteImageAsync(image.Image);
                    }


                    _imgrepo.Remove(image);
                }
            }



            _repo.Remove(product);


            await _repo.SaveAsync();
        }




        public async Task<IEnumerable<ProductGetDTO>> GetAllAsync()
        {
            var products = _repo.GetAll();


            return _mapper.Map<IEnumerable<ProductGetDTO>>(products);
        }





        public async Task<ProductGetDTO> GetAsync(int id)
        {
            var product = await _repo.GetByIdAsync(id);


            if (product == null)
                throw new NotFoundException("Product tapılmadı.");



            return _mapper.Map<ProductGetDTO>(product);
        }





        public async Task<Product> UpdateAsync(int id, ProductUpdateDTO dto)
        {
            var product = await _repo.GetByIdAsync(id);


            if (product == null)
                throw new NotFoundException("Product tapılmadı.");



            string oldImage = product.Image;


            try
            {

                // əsas şəkilin dəyişməsi
                if (dto.Image != null)
                {

                    if (!string.IsNullOrEmpty(product.Image))
                    {
                        await _file.DeleteImageAsync(product.Image);
                    }


                    product.Image = await _file.SaveImageAsync(dto.Image, "Products");
                }



                product.Name = dto.Name;
                product.Description = dto.Description;
                product.Price = dto.Price;
                product.DiscountPrice = dto.DiscountPrice;
                product.Stock = dto.Stock;
                product.IsFeatured = dto.IsFeatured;
                product.CategoryId = dto.CategoryId;



                await _repo.SaveAsync();


                return product;

            }
            catch
            {

                if (!string.IsNullOrEmpty(product.Image) && product.Image != oldImage)
                {
                    await _file.DeleteImageAsync(product.Image);
                }


                throw;
            }
        }
    }
}