using Autofac;
using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

namespace RedGunMVVM
{
    public static class ViewModelLocator
    {
        private static IContainer _container;

        public static readonly BindableProperty AutoWireViewModelProperty = BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(AutoWireViewModelProperty, value);
        }

        public static void RegisterDependencies(ContainerBuilder builder)
        {
            if (_container != null)
            {
                _container.Dispose();
            }
            _container = builder.Build();
        }

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var ViewPage = bindable as Element;
            if (ViewPage == null)
            {
                return;
            }
            var ViewType = ViewPage.GetType();
            var ViewPageName = ViewType.FullName.Replace(".Views.", ".ViewModels.");
            var ViewModelName = string.Format(CultureInfo.InvariantCulture, "{0}ViewModel", ViewPageName);
            var AppProjectRootNameSpace = ViewModelName.Split(".")[0];
            Assembly ExternalAssembly = Assembly.Load(AppProjectRootNameSpace);
            var ViewModelType = ExternalAssembly.GetType(ViewModelName);
            if (ViewModelType == null)
            {
                return;
            }
            ViewPage.BindingContext = _container.Resolve(ViewModelType);
        }
    }
}