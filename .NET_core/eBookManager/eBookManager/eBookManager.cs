using eBookManager.Engine;
using eBookManager.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Diagnostics;

namespace eBookManager
{
    public partial class eBookManager : Form
    {
        private string _jsonPath;
        private List<StorageSpace> spaces;

        public eBookManager()
        {
            InitializeComponent();

            _jsonPath = Path.Combine(Application.StartupPath, "bookData.txt");

            spaces = spaces.ReadFromDataStore(_jsonPath);
        }
        private void eBookManager_Load(object sender, EventArgs e)
        {
            PopulateStorageSpaceList();
        }

        //Add the list from Vitual Storage Spaces.
        private void PopulateStorageSpaceList()
        {
            //Virtual Storage Spaces Clear
            lstStorageSpaces.Clear();
            if(!(spaces == null))
            {
                //Add BookList on Storage Space LIstView
                foreach (StorageSpace space in spaces)
                {
                    ListViewItem lvItem = new ListViewItem(space.Name, 0);
                    lvItem.Tag = space.BookList;
                    lvItem.Name = space.ID.ToString();
                    lstStorageSpaces.Items.Add(lvItem);
                }
            }
        }

        //Add the list from Vitual Storage Spaces.
        private void PopulateContainedEbooks(List<Document> eBookList)
        {
            lstBooks.Clear();
            ClearSelectedBook();

            if (eBookList != null)
            {
                foreach (Document eBook in eBookList)
                {
                    ListViewItem book = new ListViewItem(eBook.Title, 1);
                    book.Tag = eBook;
                    lstBooks.Items.Add(book);
                }
            }
            else
            {
                ListViewItem book = new ListViewItem("This storage space contains no eBooks", 2);
                book.Tag = "";
                lstBooks.Items.Add(book);
            }
        }

        //eBook Info & Book details Group Clear
        private void ClearSelectedBook()
        {
            foreach (Control ctrl in gbBookDetails.Controls)
            {
                if (ctrl is TextBox)
                    ctrl.Text = "";
            }
            foreach (Control ctrl in gbFileDetails.Controls)
            {
                if(ctrl is TextBox)
                    ctrl.Text = "";
            }

            dtLastAccessed.Value = DateTime.Now;
            dtCreated.Value = DateTime.Now;
            dtDatePublished.Value = DateTime.Now;
        }

        //Import from virtual storage space
        private void mnuImportEbooks_Click(object sender, EventArgs e)
        {
            ImportBooks import = new ImportBooks();
            import.ShowDialog();
            spaces = spaces.ReadFromDataStore(_jsonPath);
            PopulateStorageSpaceList();
        }

        // Shows the item clicked on the Virtual Storage Spaces in Vitual Storage Space Info
        private void lstStorageSpaces_MouseClick(object sender, MouseEventArgs e)
        {
            //Select 0th item
            ListViewItem selectedStorageSpace = lstStorageSpaces.SelectedItems[0];
            int spaceID = selectedStorageSpace.Name.ToInt();

            //Search and display the selected item
            txtStorageSpaceDescription.Text = (from d in spaces
                                               where d.ID == spaceID
                                               select d.Description).First();

            //Gets an object that contains data to associate with the item.
            List<Document> ebookList = (List<Document>)selectedStorageSpace.Tag;
            PopulateContainedEbooks(ebookList);
        }

        //Show selected item in lstBooks in eBook Info Group
        private void lstBooks_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewItem selectedBook = lstBooks.SelectedItems[0];
            if (!String.IsNullOrEmpty(selectedBook.Tag.ToString()))
            {
                Document ebook = (Document)selectedBook.Tag;
                txtFileName.Text = ebook.FileName;
                txtExtension.Text = ebook.Extension;
                dtLastAccessed.Value = ebook.LastAccessed;
                dtCreated.Value = ebook.Created;
                txtFilePath.Text = ebook.FilePath;
                txtFileSize.Text = ebook.FileSize;
                txtTitle.Text = ebook.Title;
                txtAuthor.Text = ebook.Author;
                txtPublisher.Text = ebook.Publisher;
                txtPrice.Text = ebook.Price;
                txtISBN.Text = ebook.ISBN;
                dtDatePublished.Value = ebook.PublishDate;
                txtCategory.Text = ebook.Category;
            }
        }

        //Open file location folder
        private void btnReadEbook_Click(object sender, EventArgs e)
        {
            string filePath = txtFilePath.Text;
            FileInfo fi = new FileInfo(filePath);
            if (fi.Exists)
            {
                Process.Start(Path.GetDirectoryName(filePath));
            }
        }

        //Delete eBook file
        private void btnDeleteEbook_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection itemColl = lstBooks.SelectedItems;

            DialogResult dialog = MessageBox.Show("Are you sure you want to delete this eBook?", "eBook Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                if (!(spaces == null))
                {
                    foreach (ListViewItem item in itemColl)
                    {
                        foreach (StorageSpace space in spaces)
                        {
                            for (int i = 0; i < space.BookList.Count; i++)
                            {
                                Document book = space.BookList[i];
                                if (item.Text == book.Title)
                                {
                                    try
                                    {
                                        space.BookList.Remove(book);
                                        spaces.WriteToDataStore(_jsonPath);
                                        lstBooks.Items.Remove(item);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        //Delete Virtual Storage Space
        private void btnDeleteStorageSpace_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection itemColl = lstStorageSpaces.SelectedItems;

            DialogResult dialog = MessageBox.Show("Are you sure you want to delete this Vitural Storage Space?", "Vitural Storage Space Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                if (!(spaces == null))
            {
                foreach (ListViewItem item in itemColl)
                {
                    for (int i = 0; i < spaces.Count; i++)
                    {
                        StorageSpace space = spaces[i];
                        if(item.Text == space.Name)
                        {
                            try
                            {
                                if (space.BookList.Count > 0)
                                {
                                    space.BookList.Clear();
                                }
                                spaces.Remove(space);
                                spaces.WriteToDataStore(_jsonPath);
                                lstStorageSpaces.Items.Remove(item);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                }
            }
            }
        }
    }
}
