using Castle.DynamicProxy;
using System.Reflection;


namespace Core.Utilities.Interceptors;

public abstract class MethodInterception : MethodInterceptionBaseAttribute
{
    //invocation : business method
    protected virtual void OnBefore (IInvocation invocation){}
    protected virtual void OnAfter(IInvocation invocation){}

    protected  virtual void OnException(IInvocation invocation, Exception exception){}
    protected virtual void OnSuccess(IInvocation invocation){}
    public override void Intercept(IInvocation invocation)
    {
        var isSucces = true;
        OnBefore(invocation);
        try
        {
            invocation.Proceed();
        }
        catch (Exception e)
        {
            isSucces = false;
            OnException(invocation, e);
            throw;
        }
        finally
        {
            if (isSucces)
            {
                OnSuccess(invocation);
            }
        }
        OnAfter(invocation);
    }

    
}