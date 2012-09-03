using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ViewModelFirst
{
    public interface INavigationProvider
    {
        void GoForward(ViewModelBase viewModel);
        void GoBackward();
    }
}
