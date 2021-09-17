using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public ObservableCollection<ComboBoxItem> GenreComboBoxItems { get; set; }
        public ObservableCollection<ComboBoxItem> PeopleComboBoxItems { get; set; }
        public ObservableCollection<ComboBoxItem> TitleComboBoxItems { get; set; }

        public ComboBoxItem T1SelectedComboBoxItem { get; set; }
        public ComboBoxItem T3GenreSelectedComboBoxItem { get; set; }
        public ComboBoxItem T3PeopleSelectedComboBoxItem { get; set; }
        public ComboBoxItem T4TitleSelectedComboBoxItem { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            InitializeGenreComboBox();
            //InitializePeopleComboBox();
            InitializeTitleComboBox();


            // Specify the directory you want to manipulate.
            string folderPathPC = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\MoviePickerFiles";
            FileFolder.Create(folderPathPC);



            DataContext = this;

            Movie movie = new Movie("test");
            movie.Genres.Add(EnumGenre.Genre.Action);

            Person pActor = new Person("Bruce Wayne", EnumTitle.Title.Actor);
            T1SearchPersonTextBox.Text = pActor.Title.ToString();
        }

        #region Initialize
        private void InitializeGenreComboBox()
        {
            GenreComboBoxItems = new ObservableCollection<ComboBoxItem>();

            foreach (EnumGenre.Genre genre in (EnumGenre.Genre[])Enum.GetValues(typeof(EnumGenre.Genre)))
            {
                GenreComboBoxItems.Add(new ComboBoxItem { Content = genre.ToString() });
            }
        }
        /*
        private void InitializePeopleComboBox()
        {
            GenreComboBoxItems = new ObservableCollection<ComboBoxItem>();

            foreach (EnumGenre.Genre genre in (EnumGenre.Genre[])Enum.GetValues(typeof(EnumGenre.Genre)))
            {
                GenreComboBoxItems.Add(new ComboBoxItem { Content = genre.ToString() });
            }
        }
        */

        private void InitializeTitleComboBox()
        {
            TitleComboBoxItems = new ObservableCollection<ComboBoxItem>();

            foreach (EnumTitle.Title title in (EnumTitle.Title[])Enum.GetValues(typeof(EnumTitle.Title)))
            {
                TitleComboBoxItems.Add(new ComboBoxItem { Content = title.ToString() });
            }
        }


        #endregion


        #region Tab1 Movie Picker
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

        #region Tab3 Add Movie

        #region Genre Selection
        private void T3SelectedGenreComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (T3SelectedGenreComboBox.Text == "")
            { }
            else
            {
                T3SelectedGenresListBox.Items.Add(T3SelectedGenreComboBox.Text);
            }
        }
        private void T3SelectedGenresListBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                T3SelectedGenresListBox.Items.Remove(T3SelectedGenresListBox.SelectedItem);
                e.Handled = true;
            }
        }
        #endregion

        #region People Selection
        private void T3SelectedPeopleComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (T3SelectedPeopleComboBox.Text == "")
            { }
            else
            {
                T3SelectedPeopleComboBox.Items.Add(T3SelectedPeopleComboBox.Text);
            }
        }
        private void T3SelectedPeopleListBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                T3SelectedPeopleListBox.Items.Remove(T3SelectedPeopleListBox.SelectedItem);
                e.Handled = true;
            }
        }
        #endregion

        private void T3MovieYearTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[^0-9]+$");
            regex.Replace(" ", "");
            e.Handled = regex.IsMatch(e.Text);
        }


        #endregion

        #region Tab4 Add Person
        private void T4SelectedTitleComboBox_DropDownClosed(object sender, EventArgs e)
        {
            T4SSelectedTitleTextBox.Clear();

            if (T4TitleSelectedComboBox.Text == "")
            { }
            else
            {
                T4SSelectedTitleTextBox.Text = T4TitleSelectedComboBox.Text;
            }
        }


        #endregion

    }
}
