using Core.Exceptions.Types;

namespace Core.Exceptions.Handlers;

public abstract class ExceptionHandler
{
    public Task HandleExceptionAsync(Exception exception) =>
        exception switch
        {
            BusinessException businessException => HandleException(businessException),
            _ => HandleException(exception)
        };
    

    protected abstract Task HandleException(BusinessException businessException);
    protected abstract Task HandleException(Exception exception);


}
