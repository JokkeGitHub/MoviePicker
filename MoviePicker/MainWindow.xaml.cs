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

        #region Tab2 Search Movies

        #region Check Boxes
        // Make an event and a list for these v
        private void T2SearchGenreCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            T2SearchGenreCheckBox.IsChecked = true;

            T2SearchTitleCheckBox.IsChecked = false;
            T2SearchYearCheckBox.IsChecked = false;
            T2SearchDescriptionCheckBox.IsChecked = false;
            T2SearchActorCheckBox.IsChecked = false;
            T2SearchWriterCheckBox.IsChecked = false;
            T2SearcDirectorCheckBox.IsChecked = false;
        }

        private void T2SearchTitleCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            T2SearchTitleCheckBox.IsChecked = true;

            T2SearchGenreCheckBox.IsChecked = false;
            T2SearchYearCheckBox.IsChecked = false;
            T2SearchDescriptionCheckBox.IsChecked = false;
            T2SearchActorCheckBox.IsChecked = false;
            T2SearchWriterCheckBox.IsChecked = false;
            T2SearcDirectorCheckBox.IsChecked = false;
        }

        private void T2SearchYearCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            T2SearchYearCheckBox.IsChecked = true;

            T2SearchTitleCheckBox.IsChecked = false;
            T2SearchGenreCheckBox.IsChecked = false;
            T2SearchDescriptionCheckBox.IsChecked = false;
            T2SearchActorCheckBox.IsChecked = false;
            T2SearchWriterCheckBox.IsChecked = false;
            T2SearcDirectorCheckBox.IsChecked = false;
        }

        private void T2SearchDescriptionCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            T2SearchDescriptionCheckBox.IsChecked = true;

            T2SearchTitleCheckBox.IsChecked = false;
            T2SearchYearCheckBox.IsChecked = false;
            T2SearchGenreCheckBox.IsChecked = false;
            T2SearchActorCheckBox.IsChecked = false;
            T2SearchWriterCheckBox.IsChecked = false;
            T2SearcDirectorCheckBox.IsChecked = false;
        }

        private void T2SearchActorCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            T2SearchActorCheckBox.IsChecked = true;

            T2SearchTitleCheckBox.IsChecked = false;
            T2SearchYearCheckBox.IsChecked = false;
            T2SearchDescriptionCheckBox.IsChecked = false;
            T2SearchGenreCheckBox.IsChecked = false;
            T2SearchWriterCheckBox.IsChecked = false;
            T2SearcDirectorCheckBox.IsChecked = false;
        }

        private void T2SearchWriterCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            T2SearchWriterCheckBox.IsChecked = true;

            T2SearchTitleCheckBox.IsChecked = false;
            T2SearchYearCheckBox.IsChecked = false;
            T2SearchDescriptionCheckBox.IsChecked = false;
            T2SearchActorCheckBox.IsChecked = false;
            T2SearchGenreCheckBox.IsChecked = false;
            T2SearcDirectorCheckBox.IsChecked = false;
        }

        private void T2SearcDirectorCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            T2SearcDirectorCheckBox.IsChecked = true;

            T2SearchTitleCheckBox.IsChecked = false;
            T2SearchYearCheckBox.IsChecked = false;
            T2SearchDescriptionCheckBox.IsChecked = false;
            T2SearchActorCheckBox.IsChecked = false;
            T2SearchWriterCheckBox.IsChecked = false;
            T2SearchGenreCheckBox.IsChecked = false;
        }
        #endregion


        #endregion

    }
}
