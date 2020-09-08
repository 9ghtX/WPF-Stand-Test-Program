using System;
using System.Collections.Generic;
using System.Text;
using WpfApp2.ViewModels.Base;

namespace WpfApp2.ViewModels
{
    class MainWindowViewModel : ViewModel
    {

        #region Загловок окна

        /// <summery>Загловок окна</summery>

        private string _Title = "Main Menu";

        public string Title
        {

            get => _Title;

            set => Set(ref _Title, value);

        }
        #endregion

    }
}
