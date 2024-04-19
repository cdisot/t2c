using Microsoft.Practices.Unity;

namespace CC.Core.InversionOfControl
{
    public interface IIocConfigurator
    {
        void Configure(IUnityContainer container);
    }
}