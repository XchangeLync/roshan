using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GM.Business.Layer.UnitOfWork;
using GM.Business.Entity;
using AutoMapper;
using DBModel = GM.Data.Model;
using System.Globalization;

namespace GM.Business.Layer
{
    public class ProductLayer
    {
        private UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork();

        public IEnumerable<ProductModel> GetProducts()
        {
            var productList = new List<ProductModel>();
            Mapper.CreateMap<DBModel.Product, ProductModel>();
            foreach (var emp in uow.ProductRepository.Get())
                productList.Add(Mapper.Map<DBModel.Product, ProductModel>(emp));

            return productList;
        }

        public ProductModel GetProduct(string code)
        {
            var productDtl = new ProductModel();
            var result = uow.ProductRepository.GetById(code);
            Mapper.CreateMap<DBModel.Product, ProductModel>();
            if (result != null)
                productDtl = Mapper.Map<DBModel.Product, ProductModel>(result);

            return productDtl;
        }

        public string AddProduct(ProductModel emp)
        {
            bool success = false;
            var productDtl = new DBModel.Product();
            emp.LastUpdatedBy = "Roshan";
            emp.LastUpdatedDate = DateTime.Now;
            try
            {
                Mapper.CreateMap<ProductModel, DBModel.Product>();
                productDtl = Mapper.Map<ProductModel, DBModel.Product>(emp);
                uow.ProductRepository.Insert(productDtl);
                uow.Save();
                success = true;
            }
            catch (Exception ex)
            {
            }

            if (success)
                return productDtl.Code;

            return "-1";
        }

        public bool EditProduct(ProductModel emp)
        {
            bool success = false;
            emp.LastUpdatedBy = "Roshan";
            emp.LastUpdatedDate = DateTime.Now;
            try
            {
                var empDtl = new DBModel.Product();
                Mapper.CreateMap<ProductModel, DBModel.Product>();
                empDtl = Mapper.Map<ProductModel, DBModel.Product>(emp);
                uow.ProductRepository.Update(empDtl);
                uow.Save();
                success = true;
            }
            catch (Exception ex)
            {
            }

            return success;
        }

        public bool DeleteProduct(string code)
        {
            bool success = false;
            try
            {
                var emp = uow.ProductRepository.GetById(code);
                emp.IsActive = false;
                uow.ProductRepository.Update(emp);
                //uow.EmployeeRepository.Delete(id);
                uow.Save();
                success = true;
            }
            catch (Exception ex)
            {
            }

            return success;
        }
    }
}
