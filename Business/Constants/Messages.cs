using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Entity.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Product Added";
        public static string ProductNameInvalid = "ProductName Invalid";
        public static string ProductsListed = "All Products Listed";
        public static string MaintenanceTime = "System in Maintenance";
        public static string ProductCountOfCategoryError ="Max Count 10 in one category";
        public static string ProductUpdated ="Product Updated";
        public static string ProductNameExists = "Product Name Exists";
        public static string CategoryCountMaxed ="Category Count Maxed";
        public static string AuthorizationDenied= "You Are Not Authorized";
        public static string UserRegistered="User Registered";
        public static string UserNotFound ="User Not Found 604";
        public static string PasswordError = "Password Not Match";
        public static string SuccessfulLogin="Login Success";
        public static string UserAlreadyExists="User Already Exists";
        public static string AccessTokenCreated="Access Token Created";
        public static string CategoriesListed="All Categories Listed";
    }
}
