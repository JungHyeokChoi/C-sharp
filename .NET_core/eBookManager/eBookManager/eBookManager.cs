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
        private List<StorageSpace> spaces;

        public eBookManager()
        {
            InitializeComponent();
        }

        private void eBookManager_Load(object sender, EventArgs e)
        {
            PopulateStorageSpaceList();
            UpdatedlClassification();
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
            dlClassification.SelectedIndex = 0;
        }

        //Import from virtual storage space
        private void mnuImportEbooks_Click(object sender, EventArgs e)
        {
            ImportBooks import = new ImportBooks();
            import.ShowDialog();
            spaces = spaces.ReadFromDataStore(ExtensionMethods.storagePath);
            PopulateStorageSpaceList();

            UpdatedlClassification();
        }

        //Create File
        private void mnuNewFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                dlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                dlg.Title = "New FIle";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    ExtensionMethods.storagePath = dlg.FileName;
                    spaces = spaces.ReadFromDataStore(ExtensionMethods.storagePath);
                    DeweyDecimal.Classification = DeweyDecimal.ReadToClassfication();

                    gbVirtualSotrageSpaces.Visible = true;
                    gbEbooks.Visible = true;
                    gbBookInfo.Visible = true;
                    gbBookDetails.Visible = true;
                    gbVirtualStorageSpaceInfo.Visible = true;
                    mnuImportEbooks.Enabled = true;

                    PopulateStorageSpaceList();
                }
            }
        }

        //Open File
        private void mnuOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                dlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    ExtensionMethods.storagePath = dlg.FileName;
                    spaces = spaces.ReadFromDataStore(ExtensionMethods.storagePath);
                    DeweyDecimal.Classification = DeweyDecimal.ReadToClassfication();

                    gbVirtualSotrageSpaces.Visible = true;
                    gbEbooks.Visible = true;
                    gbBookInfo.Visible = true;
                    gbBookDetails.Visible = true;
                    gbVirtualStorageSpaceInfo.Visible = true;
                    mnuImportEbooks.Enabled = true;

                    PopulateStorageSpaceList();
                }
            }
        }

        // Shows the item clicked on the Virtual Storage Spaces in Vitual Storage Space Info
        private void lstStorageSpaces_MouseClick(object sender, MouseEventArgs e)
        {
            if(lstStorageSpaces.SelectedItems.Count > 0)
            {
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
        }

        //Show selected item in lstBooks in eBook Info Group
        private void lstBooks_MouseClick(object sender, MouseEventArgs e)
        {

            if (lstBooks.SelectedItems.Count > 0)
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
                    dlClassification.Text = ebook.Classification;
                }
            }
        }

        //Open file location folder
        private void btnReadEbook_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = txtFilePath.Text;
                FileInfo fi = new FileInfo(filePath);
                if (fi.Exists)
                {
                    Process.Start(Path.GetDirectoryName(filePath));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        //Update eBook file
        private void btnUpdateEbook_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstStorageSpaces.SelectedItems.Count > 0)
                {
                    DialogResult dialog = MessageBox.Show("Are you sure you want to update this eBook?", "Update eBook", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        foreach (StorageSpace space in spaces)
                        {
                            Document updateBook = (from b in space.BookList
                                                   where $"{b.Title}".Equals($"{lstBooks.SelectedItems[0].Text}")
                                                   select b).First();

                            updateBook.FileName = txtFileName.Text;
                            updateBook.Extension = txtExtension.Text;
                            updateBook.LastAccessed = dtLastAccessed.Value;
                            updateBook.Created = dtCreated.Value;
                            updateBook.FilePath = txtFilePath.Text;
                            updateBook.FileSize = txtFileSize.Text;
                            updateBook.Title = txtTitle.Text;
                            updateBook.Author = txtAuthor.Text;
                            updateBook.Publisher = txtPublisher.Text;
                            updateBook.Price = txtPrice.Text;
                            updateBook.ISBN = txtISBN.Text;
                            updateBook.PublishDate = dtDatePublished.Value;
                            updateBook.Category = txtCategory.Text;
                            updateBook.Classification = dlClassification.Text;

                            spaces.WriteToDataStore(ExtensionMethods.storagePath);
                            PopulateContainedEbooks(space.BookList);
                        }
                        ClearSelectedBook();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Delete eBook file
        private void btnDeleteEbook_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstStorageSpaces.SelectedItems.Count > 0)
                {
                    int selectedStorageSpaceID = lstStorageSpaces.SelectedItems[0].Name.ToInt();

                    StorageSpace storageSpace = (from s in spaces
                                                 where s.ID == selectedStorageSpaceID
                                                 select s).First();

                    List<Document> ebooks = storageSpace.BookList;

                    ListView.SelectedListViewItemCollection itemColl = lstBooks.SelectedItems;

                    DialogResult dialog = MessageBox.Show($"Are you sure you want to delete {lstBooks.SelectedItems.Count} {(lstBooks.SelectedItems.Count == 1 ? "eBook file" : "eBook files")}?", 
                        "Delete eBook ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        foreach (ListViewItem item in itemColl)
                        {
                            Document deleteBook = (from b in ebooks
                                                   where $"{b.Title}".Equals($"{item.Text}")
                                                   select b).First();

                            if (deleteBook != null)
                            {
                                storageSpace.BookList.Remove(deleteBook);
                            }
                            lstBooks.Items.Remove(item);
                        }
                        spaces.WriteToDataStore(ExtensionMethods.storagePath);
                        ClearSelectedBook();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Delete Virtual Storage Space
        private void btnDeleteStorageSpace_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstStorageSpaces.SelectedItems.Count > 0)
                {
                    DialogResult dialog = MessageBox.Show($"Are you sure you want to delete {lstStorageSpaces.SelectedItems.Count} {(lstStorageSpaces.SelectedItems.Count == 1 ? "Vitural Storage space" : "Vitural Storage spaces")}?",
                        "Delete Vitural Storage Space", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        ListView.SelectedListViewItemCollection itemColl = lstStorageSpaces.SelectedItems;

                        foreach (ListViewItem item in itemColl)
                        {
                            StorageSpace deleteStorage = (from s in spaces
                                                          where $"{s.ID}".Equals($"{item.Name}")
                                                          select s).First();

                            if (deleteStorage.BookList.Count > 0)
                            {
                                deleteStorage.BookList.Clear();
                                lstBooks.Items.Clear();
                            }
                            spaces.Remove(deleteStorage);
                            spaces.WriteToDataStore(ExtensionMethods.storagePath);
                            lstStorageSpaces.Items.Remove(item);
                        }
                        ClearSelectedBook();
                        txtStorageSpaceDescription.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Setting toolTip
        private void btnReadEbook_MouseHover(object sender, EventArgs e)
        {
            this.toolTip.ToolTipTitle = "Read eBook";
            this.toolTip.SetToolTip(this.btnReadEbook, "Click here to open the eBook file location");
        }

        //Setting toolTip
        private void btnDeleteEbook_MouseHover(object sender, EventArgs e)
        {
            this.toolTip.ToolTipTitle = "Delete eBook";
            this.toolTip.SetToolTip(this.btnReadEbook, "Click here to delete the eBook file");
        }

        //Setting toolTip
        private void btnDeleteStorageSpace_MouseHover(object sender, EventArgs e)
        {
            this.toolTip.ToolTipTitle = "Delete Virtual Storage Space";
            this.toolTip.SetToolTip(this.btnReadEbook, "Click here to delete the Virtual Storage Space");
        }
        
        //Setting toolTip
        private void btnUpdateEbook_MoustHover(object sender, EventArgs e)
        {
            this.toolTip.ToolTipTitle = "Update eBook";
            this.toolTip.SetToolTip(this.btnUpdateEbook, "Click here to update the eBook file");
        }

        //Select Classification
        private void dlClassification_SelectionChangeCommitted(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, string> pair in DeweyDecimal.Classification)
            {
                if (dlClassification.SelectedItem.ToString() == pair.Key)
                {
                    this.BeginInvoke(new MethodInvoker(delegate ()
                    {
                        dlClassification.Text = pair.Value;
                    }));
                }
            }
        }

        //Update Classification ComboBox
        private void UpdatedlClassification()
        {
            dlClassification.Items.Clear();
            dlClassification.Items.Add("<Select Classification>");
            foreach (KeyValuePair<string, string> pair in DeweyDecimal.Classification)
                dlClassification.Items.Add(pair.Key.ToString());
            dlClassification.SelectedIndex = 0;
        }
    }
}
