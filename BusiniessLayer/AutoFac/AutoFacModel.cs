using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using Autofac;
using BusiniessLayer.Abstract;
using BusiniessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;

namespace BusiniessLayer.AutoFac
{
    public class AutoFacModel : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region Category
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryRepository>().As<ICategoryDal>();
            #endregion

            #region Product
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductRepository>().As<IProductDal>();
            #endregion

            #region Document
            builder.RegisterType<DocumentManager>().As<IDocumentService>();
            builder.RegisterType<EfDocumentRepository>().As<IDocumentDal>();
            #endregion

             #region User
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserRepository>().As<IUserDal>();
            #endregion
            
            #region Comment
            builder.RegisterType<CommentManager>().As<ICommentService>();
            builder.RegisterType<EfCommentRepository>().As<ICommentDal>();
            #endregion

             #region Cart
            builder.RegisterType<CartManager>().As<ICartService>();
            builder.RegisterType<EfCartRepository>().As<ICartDal>();
            #endregion

             #region Adress
            builder.RegisterType<AdressManager>().As<IAdressService>();
            builder.RegisterType<EfAdressRepository>().As<IAdressDal>();
            #endregion

             #region Offer
            builder.RegisterType<OfferManager>().As<IOfferService>();
            builder.RegisterType<EfOfferRepository>().As<IOfferDal>();
            #endregion

             #region Order
            builder.RegisterType<OrderManager>().As<IOrderService>();
            builder.RegisterType<EfOrderRepository>().As<IOrderDal>();
            #endregion

        }
    }
}