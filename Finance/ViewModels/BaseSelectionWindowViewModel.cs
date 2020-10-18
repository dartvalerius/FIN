using System;
using System.IO;
using Finance.ServiceClasses;
using MahApps.Metro.Controls;
using Microsoft.Win32;

namespace Finance.ViewModels
{
    /// <summary>
    /// Окно создания/выбора базы
    /// </summary>
    public class BaseSelectionWindowViewModel : PropertyNotificator
    {
        /// <summary>
        /// Экземпляр текущего окна
        /// </summary>
        private MetroWindow Window { get; }

        /// <summary>
        /// Путь к файлу
        /// </summary>
        public string FilePath { get; private set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="window">экземпляр текущего окна</param>
        public BaseSelectionWindowViewModel(MetroWindow window) => Window = window;

        /// <summary>
        /// Создание новой базы
        /// </summary>
        public RelayCommand CreateCmd => _createCmd ??= new RelayCommand(() =>
        {
            var dateTimeNow = DateTime.Now;

            FilePath =
                $@"Base/{dateTimeNow.Day}{dateTimeNow.Month}{dateTimeNow.Year}{dateTimeNow.Hour}{dateTimeNow.Minute}{dateTimeNow.Second}.fin";
            File.Copy("template.fin", FilePath);

            Window.DialogResult = true;
        });
        private RelayCommand _createCmd;

        /// <summary>
        /// Открыть существующую базу
        /// </summary>
        public RelayCommand OpenCmd => _openCmd ??= new RelayCommand(() =>
        {
            var openFileDialog = new OpenFileDialog {Filter = "Файл приложения|*.fin" };

            if (openFileDialog.ShowDialog() != true) return;

            FilePath = openFileDialog.FileName;

            Window.DialogResult = true;
        });
        private RelayCommand _openCmd;
    }
}