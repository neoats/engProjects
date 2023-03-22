using Business.Abstract;
using Business.Constants;
using Business.Validators.FluentValidators;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using Entity.Concrete;
using System.Transactions;

namespace Business.Concrete;

public class ProductManager : IProductService
{
    private readonly IProductDal _productDal;
    private readonly ICategoryService _categoryService;
    private readonly ICacheManager _cacheManager;

    public ProductManager(IProductDal productDal, ICategoryService categoryService)
    {
        _productDal = productDal;
        _categoryService = categoryService;
    }
/*    [SecuredOperation("product.add,admin")]*/
    /*[ValidationAspect(typeof(ProductValidator))]
    [CacheRemoveAspect("IProductService.Get")]*/
    public IResult Add(Product product)
    {

        /* _logger.Log();*/
        #region goes CCC\validation
        /*var context = new ValidationContext<Product>(product);
        ProductValidator productValidator = new ProductValidator();
        var result = productValidator.Validate(context);
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }*/
        #endregion
        #region goes aspects\validation
        /*  ValidationTool.Validate(new ProductValidator(),product);*/
        #endregion
        #region no set method

        /*Result result = new Result();
        result.Message = "asd";
        return result;*/

        #endregion
        #region old business

        /*    if (product.ProductName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            return new SuccessResult(Messages.ProductAdded);

        */

        #endregion
        #region tryCatch
        /*   try
           {
               //business code
               _productDal.Add(product);
               return new SuccessResult(Messages.ProductAdded);

           }
           catch (Exception)
           {
               Console.WriteLine(typeof(Exception));
               throw;
           }

           return new ErrorResult();

   */

        #endregion
        #region oneCategoryMax10Sample

        /* var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Count;
         if (result>=10)
         {

             return new ErrorResult(Messages.ProductCountOfCategoryError);
         }*/

        #endregion
        #region checkcategorycount>15!+



        #endregion
        #region oldBusinessRule
        /*if (CheckIfProductCountOfCategoryCorrect(product.CategoryId).Success)
                       {
                           _productDal.Add(product);
                           return new SuccessResult(Messages.ProductAdded);
                       }*/
    /*    if (CheckIfThereIsSameProduct(product.ProductName).Success)
        {
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }
*/

        #endregion

        //business code

        var result = BusinessRules.Run(/*CheckIfProductCountOfCategoryCorrect(product.CategoryId),*/
            CheckIfThereIsSameProduct(product.ProductName),CheckCategoryCount());
        if (result != null)
        {
            return result;
        }

        _productDal.Add(product);
        return new SuccessResult(Messages.ProductAdded);


    }
    #region OldGetAll

    /* public List<Product> GetAll()
    {
        return _productDal.GetAll();
    }*/

    #endregion
    /*[CacheAspect]*/
    [ValidationAspect(typeof(ProductValidator))]
    public IDataResult<List<Product>> GetAll()
    {
        Thread.Sleep(1000);
        #region olds

        /*return  new DataResult<List<Product>>(_productDal.GetAll(),true,Messages.ProductsListed);*/

        #endregion
        #region withoutAspectCachemanager
        /*  if (_cacheManager.IsAdd(""))
        {
            return _cacheManager.Get<IDataResult<List<Product>>>();
        }
        else
        {
            _cacheManager.Add(_productDal.GetAll());
        }*/


        #endregion


        /*if (DateTime.Now.Hour == 16) return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);*/
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
    }
    
    [ValidationAspect(typeof(ProductValidator))]
    [CacheRemoveAspect("IProductService.Get")]
    public IResult Update(Product product)
    {
        var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Count;
        if (result >= 10)
        {

            return new ErrorResult(Messages.ProductCountOfCategoryError);
        }
        return new SuccessResult(Messages.ProductUpdated);
    }

    public IResult AddTransactionalTest(Product product)
    {
        using (TransactionScope scope = new TransactionScope())
        {
            try
            {
                Add(product);
                if (product.UnitPrice<10)
                {
                    throw new Exception("");
                }
            }
            catch (Exception e)
            {
                scope.Dispose();
            }
        }

        return null;
    }


    [CacheAspect]
    public IDataResult<Product> GetById(int productId)
    {
        return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
    }


    public IDataResult<List<Product>> GetAllByCategoryId(int id)
    {
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
    }

    public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
    {
        #region old

        /*  return _productDal.GetAll(p=>p.UnitPrice>=min&&p.UnitPrice<=max);*/

        #endregion

        return new SuccessDataResult<List<Product>>(
            _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
    }

    public IDataResult<List<ProductDetailDto>> GetProductDetails()
    {
        return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
    }
    /*Business----------------------------------------------------------------------*/

    /*private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
    {
        var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count();
        if (result >= 10)
        {

            return new ErrorResult(Messages.ProductCountOfCategoryError);
        }

        return new SuccessResult();

    }*/

    private IResult CheckIfThereIsSameProduct(string productName)
    {
        
        var result = _productDal.GetAll(p=>p.ProductName == productName).Any();
        if (result) 
        {

            return new ErrorResult(Messages.ProductNameExists);
        }
        return new SuccessResult();

    }

    private IResult CheckCategoryCount()
    {
        
        var result = _categoryService.GetAll().Data.Count;
        if (result>15)
        {
            return new ErrorResult(Messages.CategoryCountMaxed);
        }
        return new SuccessResult();
    }
}