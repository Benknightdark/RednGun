﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Example.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoDetailPage : ContentPage
    {
        public ToDoDetailPage()
        {
            InitializeComponent();
        }
    }
}