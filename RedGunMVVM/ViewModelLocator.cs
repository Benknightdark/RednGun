﻿using Autofac;
using System;
using System.Globalization;
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
            return (bool)bindable.GetValue(ViewModelLocator.AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(ViewModelLocator.AutoWireViewModelProperty, value);
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
            var view = bindable as Element;

            if (view == null)
            {
                return;
            }

            var viewType = view.GetType();
            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}ViewModel", viewName);
            var viewModelType = Type.GetType(viewModelName); //"EUPApp.ViewModels.DetailsPageViewModel"

            if (viewModelType == null)
            {
                return;
            }

            var viewModel = _container.Resolve(viewModelType);
            view.BindingContext = viewModel;
        }
    }
}