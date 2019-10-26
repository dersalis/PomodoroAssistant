using System;
using System.Collections.Generic;
using System.Text;

using PomodoroAssistantPlus.ViewModel;
using PomodoroAssistantPlus.Model;
using PomodoroAssistantPlus.Pomodoro;
using System.ComponentModel;
using System.Linq;
using Windows.UI.Xaml.Media;
using Windows.UI.Popups;
using Windows.ApplicationModel.Resources;

namespace PomodoroAssistantPlus.ViewModel
{
    public class AddCategoryViewModel : INotifyPropertyChanged
    {
        // Kolory
        public List<CategoryColor> CategoryColors { get; set; }
        // Nazwa kategorii
        private string _categoryName;
        public string CategoryName
        {
            get { return _categoryName; }
            set
            {
                if (_categoryName != value)
                {
                    _categoryName = value;
                    RaisePropertyChanged("CategoryName");
                }
            }
        }
        // Kolor kategorii
        private SolidColorBrush _categoryColor;
        public SolidColorBrush CategoryColor
        {
            get { return _categoryColor; }
            set
            {
                if (_categoryColor != value)
                {
                    _categoryColor = value;
                    RaisePropertyChanged("CategoryColor");
                }
            }
        }

        //
        // Konstruktor
        //
        public AddCategoryViewModel()
        {
            // Ustaw listę kolorów
            CategoryColors = SetCategoryColors();
            // Ustaw kolor
            CategoryColor = new SolidColorBrush(Windows.UI.Colors.White);
        }


        //
        // Ustawia kolory kategorii
        //
        private List<CategoryColor> SetCategoryColors()
        {
            List<CategoryColor> categoryColors = new List<CategoryColor>();

            categoryColors.Add(new CategoryColor() { Color = new SolidColorBrush(ColorRevert.ToColor("#FF1BA1E2")) });
            categoryColors.Add(new CategoryColor() { Color = new SolidColorBrush(ColorRevert.ToColor("#FFA05000")) });
            categoryColors.Add(new CategoryColor() { Color = new SolidColorBrush(ColorRevert.ToColor("#FF339933")) });
            categoryColors.Add(new CategoryColor() { Color = new SolidColorBrush(ColorRevert.ToColor("#FFE671B8")) });
            categoryColors.Add(new CategoryColor() { Color = new SolidColorBrush(ColorRevert.ToColor("#FFA200FF")) });
            categoryColors.Add(new CategoryColor() { Color = new SolidColorBrush(ColorRevert.ToColor("#FFE51400")) });
            categoryColors.Add(new CategoryColor() { Color = new SolidColorBrush(ColorRevert.ToColor("#FF00ABA9")) });
            categoryColors.Add(new CategoryColor() { Color = new SolidColorBrush(ColorRevert.ToColor("#FF8CBF26")) });
            categoryColors.Add(new CategoryColor() { Color = new SolidColorBrush(Windows.UI.Colors.Gray)});
            categoryColors.Add(new CategoryColor() { Color = new SolidColorBrush(ColorRevert.ToColor("#FFFF0097")) });
            categoryColors.Add(new CategoryColor() { Color = new SolidColorBrush(ColorRevert.ToColor("#FFD80073")) });
            categoryColors.Add(new CategoryColor() { Color = new SolidColorBrush(ColorRevert.ToColor("#FFF09609")) });
            categoryColors.Add(new CategoryColor() { Color = new SolidColorBrush(Windows.UI.Colors.Yellow) });
            return categoryColors;
        }


        //
        // Dodaje kategorię
        //
        public void AddCategory()
        {
            // Nowa kategoria
            Category category = new Category()
            {
                Id = Guid.NewGuid().ToString(),
                Name = CategoryName,
                Color = CategoryColor.Color.ToString(),
                IsPermissionDelete = true
            };
            // Dodaj i zapisz kategorie
            LocalStorage.CategoryStorage.AddItem(category);
            
        }


        //
        // Edycja kategorii
        //
        public void EditCategory(Category category)
        {
            category.Name = CategoryName;
            category.Color = CategoryColor.Color.ToString();
            // Edytuj
            LocalStorage.CategoryStorage.EditCategory(category);
        }


        #region INotifyPropertyChanged
        // Deklaracja ReisePropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        #endregion

        #region Singleton
        //
        // Singleton
        //
        private static AddCategoryViewModel _instance;
        public static AddCategoryViewModel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AddCategoryViewModel();
                return _instance;
            }
        }
        #endregion
    }
}
