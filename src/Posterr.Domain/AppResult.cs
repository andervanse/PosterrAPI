
namespace Posterr.Domain
{
    public class AppResult<T>
    {
        private IList<string>? _businessErrors;

        private IList<string>? _internalErrors;

        public T? Data { get; set; }

        public bool Success 
        { 
            get 
            {  
                return (_businessErrors == null && _internalErrors == null) || 
                    ((_businessErrors != null && !_businessErrors.Any()) &&
                     (_internalErrors != null && !_internalErrors.Any())); 
            } 
        }

        public IEnumerable<string>? BusinessErrors { get => _businessErrors; }

        public IEnumerable<string>? InternalErrors { get => _internalErrors; }

        public void AddError(Exception ex, string businessErrorMsg)
        {
            if (_businessErrors == null)
                _businessErrors = new List<string>();

            _businessErrors.Add(businessErrorMsg);

            if (ex != null)
            {
                if (_internalErrors == null)
                    _internalErrors = new List<string>();

                _internalErrors.Add(ex.Message);
                var innerExep = ex.InnerException;

                while (innerExep != null)
                {
                    _internalErrors.Add(innerExep.Message);
                }
            }  
        }

        public void AddError(string businessErrorMsg)
        {
            if (_businessErrors == null)
                _businessErrors = new List<string>();

            _businessErrors.Add(businessErrorMsg);
        }
    }
}
