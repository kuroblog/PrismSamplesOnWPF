
namespace PEF.Common
{
    using Prism.Mvvm;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class ValidationBindableBase : BindableBase, IDataErrorInfo
    {
        #region IDataErrorInfo

        public string Error { get; private set; }

        public string this[string columnName]
        {
            get
            {
                Error = null;

                var pi = GetType().GetProperty(columnName);
                var piValue = pi.GetValue(this, null);
                var attributes = pi.GetCustomAttributes(false);
                if (attributes != null && attributes.Any())
                {
                    foreach (var attr in attributes)
                    {
                        if (attr is ValidationAttribute)
                        {
                            var vAttr = attr as ValidationAttribute;
                            if (!vAttr.IsValid(piValue))
                            {
                                Error = vAttr.ErrorMessage;
                                break;
                            }
                        }
                    }
                }

                return Error;
            }
        }
        #endregion
    }
}
