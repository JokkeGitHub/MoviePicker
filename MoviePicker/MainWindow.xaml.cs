using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MoviePicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<ComboBoxItem> T1GenreComboBoxItems { get; set; }
        public ComboBoxItem T1SelectedComboBoxItem { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            InitializeT1GenreComboBox();

            DataContext = this;

            Movie movie = new Movie("test");
            movie.Genres.Add(EnumGenre.Genre.Action);

            Person pActor = new Person("Bruce Wayne", EnumTitle.Title.Actor);
            T1SearchPersonTextBox.Text = pActor.Title.ToString();
        }

        #region Tab1 Movie Picker
        private void InitializeT1GenreComboBox()
        {
            T1GenreComboBoxItems = new ObservableCollection<ComboBoxItem>();

            foreach (EnumGenre.Genre genre in (EnumGenre.Genre[])Enum.GetValues(typeof(EnumGenre.Genre)))
            {
                T1GenreComboBoxItems.Add(new ComboBoxItem { Content = genre.ToString() });
            }
        }

        private void T1SelectedGenreComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (T1SelectedGenreComboBox.Text == "")
            { }
            else
            {
                T1SelectedGenresListBox.Items.Add(T1SelectedGenreComboBox.Text);
            }
        }

        private void T1SelectedGenresListBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                T1SelectedGenresListBox.Items.Remove(T1SelectedGenresListBox.SelectedItem);
                e.Handled = true;
            }
        }
        #endregion


    }
}
