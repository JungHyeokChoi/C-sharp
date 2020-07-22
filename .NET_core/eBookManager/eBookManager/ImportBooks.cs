using eBookManager.Engine;
using eBookManager.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static eBookManager.Helper.ExtensionMethods;
using static System.Math;

namespace eBookManager
{
    public partial class ImportBooks : Form
    {
        private string _jsonPath;
        private List<StorageSpace> spaces;
        private enum StorageSpaceSelection { New = -9999, NoSelection = -1 }

        private HashSet<string> AllowedExtensions => new HashSet<string>(StringComparer.InvariantCultureIgnoreCase) { ".doc", ".docx", ".pdf", ".epub" };

        //Define Document Type
        private enum Extention { doc = 0, docx = 1, pdf = 2, epub = 3 }

        public ImportBooks()
        {
            InitializeComponent();
            _jsonPath = Path.Combine(Application.StartupPath, "bookData.txt");
            spaces = spaces.ReadFromDataStore(_jsonPath);
        }

        //Select Source Folder
        private void btnSelectSourceFolder_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = "Select the location of your eBooks and documents";

                DialogResult dlgResult = fbd.ShowDialog();
                if(dlgResult == DialogResult.OK)
                {
                    tvFoundBooks.Nodes.Clear();
                    tvFoundBooks.ImageList = tvImages;

                    string path = fbd.SelectedPath;
                    DirectoryInfo di = new DirectoryInfo(path);
                    TreeNode root = new TreeNode(di.Name);
                    root.ImageIndex = 4;
                    root.SelectedImageIndex = 5;
                    tvFoundBooks.Nodes.Add(root);
                    PopulateBookList(di.FullName, root);
                    tvFoundBooks.Sort();

                    root.Expand();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Show subdirectories of the root directory
        public void PopulateBookList(string paramDir, TreeNode paramNode)
        {
            DirectoryInfo dir = new DirectoryInfo(paramDir);
            foreach(DirectoryInfo dirInfo in dir.GetDirectories())
            {
                TreeNode node = new TreeNode(dirInfo.Name);
                node.ImageIndex = 4;
                node.SelectedImageIndex = 5;

                if (paramNode != null)
                    paramNode.Nodes.Add(node);
                else
                    tvFoundBooks.Nodes.Add(node);

                PopulateBookList(dirInfo.FullName, node);
            }
            foreach (FileInfo fleInfo in dir.GetFiles().Where(x => AllowedExtensions.Contains(x.Extension)).ToList())
            {
                TreeNode node = new TreeNode(fleInfo.Name);
                node.Tag = fleInfo.FullName;
                int iconIndex = Enum.Parse(typeof(Extention), fleInfo.Extension.TrimStart('.'), true).GetHashCode();

                node.ImageIndex = iconIndex;
                node.SelectedImageIndex = iconIndex;
                if (paramNode != null)
                    paramNode.Nodes.Add(node);
                else
                    tvFoundBooks.Nodes.Add(node);
            }
        }

        //Shows the item clicked on tvFoundBooks in File details Group
        private void tvFoundBooks_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DocumentEngine engine = new DocumentEngine();
            string path = e.Node.Tag?.ToString() ?? "";

            if (File.Exists(path))
            {
                var (dateCreated, dateLastAccessed, fileName, fileExtention, fileLength, hasError) = engine.GetFileProperties(e.Node.Tag.ToString());
            
                if (!hasError)
                {
                    txtFileName.Text = fileName;
                    txtExtension.Text = fileExtention;
                    dtCreated.Value = dateCreated;
                    dtLastAccessed.Value = dateLastAccessed;
                    txtFilePath.Text = e.Node.Tag.ToString();
                    txtFileSize.Text = $"{Round(fileLength.ToMegabytes(), 2).ToString()} MB";
                }
            }
        }

        private void ImportBooks_Load(object sender, EventArgs e)
        {
            PopulateStorageSpacesList();

            if(dlVirtualStorageSpaces.Items.Count == 0)
            {
                dlVirtualStorageSpaces.Items.Add("<Create new storage space>");
            }

            lblEbookCount.Text = "";
            
            foreach(KeyValuePair<string, string> pair in DeweyDecimal.Classification)
                dlClassification.Items.Add(pair.Key.ToString());
        }

        //Show Virtual Storage Spaces
        private void PopulateStorageSpacesList()
        {
            List<KeyValuePair<int, string>> lstSpaces = new List<KeyValuePair<int, string>>();
            BindStorageSpaceList((int)StorageSpaceSelection.NoSelection, "Select Storage Space");

            void BindStorageSpaceList(int key, string value)
            {
                lstSpaces.Add(new KeyValuePair<int, string>(key, value));
            }

            if(spaces is null || spaces.Count() == 0)
            {
                BindStorageSpaceList((int)StorageSpaceSelection.New, "<create new>");
            }
            else
            {
                foreach(var space in spaces)
                {
                    BindStorageSpaceList(space.ID, space.Name);
                }
            }

            dlVirtualStorageSpaces.DataSource = new BindingSource(lstSpaces, null);
            dlVirtualStorageSpaces.DisplayMember = "Value";
            dlVirtualStorageSpaces.ValueMember = "Key";
        }

        //Show the status of Virtual storage spaces selected
        private void dlVirtualStorageSpaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedValue = dlVirtualStorageSpaces.SelectedValue.ToString().ToInt();

            if (selectedValue == (int)StorageSpaceSelection.New)
            {
                txtNewStorageSpaceName.Visible = true;
                lblStorageSpaceDescription.Visible = true;
                txtStorageSpaceDescription.Visible = true;
                btnSaveNewStorageSpace.Visible = true;
                btnCancelNewStorageSpaceSave.Visible = true;
                dlVirtualStorageSpaces.Enabled = true;
                btnAddNewStorageSpace.Enabled = true;
                lblEbookCount.Text = "";
            }
            else if (selectedValue != (int)StorageSpaceSelection.NoSelection)
            {
                int contentCount = (from c in spaces
                                    where c.ID == selectedValue
                                    select c).Count();

                if (contentCount > 0)
                {
                    StorageSpace selectedSpace = (from c in spaces
                                                 where c.ID == selectedValue
                                                 select c).First();

                    txtStorageSpaceDescription.Text = selectedSpace.Description;

                    List<Document> eBooks = (selectedSpace.BookList == null) ? new List<Document> { } : selectedSpace.BookList;
                    lblEbookCount.Text = $"Storage Space contains {eBooks.Count()} {(eBooks.Count() == 1 ? "eBook" : "eBooks")}";
                }
            }
        }

        //Create New Storage Space
        private void btnSaveNewStorageSpace_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNewStorageSpaceName.Text.Length != 0)
                {
                    string newName = txtNewStorageSpaceName.Text;

                    bool spaceExists = (!spaces.StorageSpaceExists(newName, out int nextID)) ? false : throw new Exception("The storage space you are trying to add already exists");

                    if (!spaceExists)
                    {
                        StorageSpace newSpace = new StorageSpace();
                        newSpace.Name = newName;
                        newSpace.ID = nextID;
                        newSpace.Description = txtStorageSpaceDescription.Text;
                        spaces.Add(newSpace);

                        PopulateStorageSpacesList();

                        txtNewStorageSpaceName.Clear();
                        txtNewStorageSpaceName.Visible = false;
                        lblStorageSpaceDescription.Visible = false;
                        txtStorageSpaceDescription.Clear();
                        txtStorageSpaceDescription.Visible = false;
                        btnSaveNewStorageSpace.Visible = false;
                        btnCancelNewStorageSpaceSave.Visible = false;
                        dlVirtualStorageSpaces.Enabled = true;
                        btnAddNewStorageSpace.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                txtNewStorageSpaceName.SelectAll();
                MessageBox.Show(ex.Message);
            }
        }

        //Cancel New Storage Space
        private void btnCancelNewStorageSpaceSave_Click(object sender, EventArgs e)
        {
            txtNewStorageSpaceName.Clear();
            txtNewStorageSpaceName.Visible = false;
            lblStorageSpaceDescription.Visible = false;
            txtStorageSpaceDescription.Clear();
            txtStorageSpaceDescription.Visible = false;
            btnSaveNewStorageSpace.Visible = false;
            btnCancelNewStorageSpaceSave.Visible = false;
            dlVirtualStorageSpaces.Enabled = true;
            btnAddNewStorageSpace.Enabled = true;
        }

        //Add New Storage Space
        private void btnAddNewStorageSpace_Click(object sender, EventArgs e)
        {
            txtNewStorageSpaceName.Visible = true;
            lblStorageSpaceDescription.Visible = true;
            txtStorageSpaceDescription.Visible = true;
            btnSaveNewStorageSpace.Visible = true;
            btnCancelNewStorageSpaceSave.Visible = true;
            dlVirtualStorageSpaces.Enabled = false;
            btnAddNewStorageSpace.Enabled = false;
        }

        //Add ebook to Virtual storage spaces
        private void btnAddeBookToStorageSpace_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedStorageSpaceID = dlVirtualStorageSpaces.SelectedValue.ToString().ToInt();
                if ((selectedStorageSpaceID != (int)StorageSpaceSelection.NoSelection) && (selectedStorageSpaceID != (int)StorageSpaceSelection.New))
                {
                    UpdateStorageSpaceBooks(selectedStorageSpaceID);
                }
                else throw new Exception("Please select a Storage Space to add your ebook to");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Add ebook to Virtual storage spaces
        private void UpdateStorageSpaceBooks(int storageSpaceId)
        {
            try
            {
                int iCount = (from s in spaces
                              where s.ID == storageSpaceId
                              select s).Count();
                if (iCount > 0)
                {
                    StorageSpace existingSpace = (from s in spaces
                                                  where s.ID == storageSpaceId
                                                  select s).First();

                    List<Document> ebooks = existingSpace.BookList;

                    int iBooksExist = (ebooks != null) ? (from b in ebooks
                                                          where $"{b.FileName}".Equals($"{txtFileName.Text.Trim()}")
                                                          select b).Count() : 0;

                    if (iBooksExist > 0)
                    {
                        DialogResult dlgResult = MessageBox.Show($"A book with the same name has been found in Storage Space {existingSpace.Name}. Do you want to replace the existing book entry with this one?", "Duplicate Title", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                        if (dlgResult == DialogResult.Yes)
                        {
                            Document existingBook = (from b in ebooks
                                                     where $"{b.FileName}".Equals($"{txtFileName.Text.Trim()}")
                                                     select b).First();

                            existingBook.FileName = txtFileName.Text;
                            existingBook.Extension = txtExtension.Text;
                            existingBook.LastAccessed = dtLastAccessed.Value;
                            existingBook.Created = dtCreated.Value;
                            existingBook.FilePath = txtFilePath.Text;
                            existingBook.FileSize = txtFileSize.Text;
                            existingBook.Title = txtTitle.Text;
                            existingBook.Author = txtAuthor.Text;
                            existingBook.Publisher = txtPublisher.Text;
                            existingBook.Price = txtPrice.Text;
                            existingBook.ISBN = txtISBN.Text;
                            existingBook.PublishDate = dtDatePublished.Value;
                            existingBook.Category = txtCategory.Text;
                            existingBook.Classification = dlClassification.Text;
                        }
                    }
                    else
                    {
                        Document newBook = new Document();
                        newBook.FileName = txtFileName.Text;
                        newBook.Extension = txtExtension.Text;
                        newBook.LastAccessed = dtLastAccessed.Value;
                        newBook.Created = dtCreated.Value;
                        newBook.FilePath = txtFilePath.Text;
                        newBook.FileSize = txtFileSize.Text;
                        newBook.Title = txtTitle.Text;
                        newBook.Author = txtAuthor.Text;
                        newBook.Publisher = txtPublisher.Text;
                        newBook.Price = txtPrice.Text;
                        newBook.ISBN = txtISBN.Text;
                        newBook.PublishDate = dtDatePublished.Value;
                        newBook.Category = txtCategory.Text;
                        newBook.Classification = dlClassification.Text;

                        if (ebooks == null)
                            ebooks = new List<Document>();
                        ebooks.Add(newBook);
                        existingSpace.BookList = ebooks;
                    }
                }

                spaces.WriteToDataStore(_jsonPath);
                PopulateStorageSpacesList();
                MessageBox.Show("Book added");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        //Select Classification
        private void dlClassification_SelectionChangeCommitted(object sender, EventArgs e)
        {
            foreach(KeyValuePair<string, string> pair in DeweyDecimal.Classification)
            {
                if (dlClassification.SelectedItem.ToString() == pair.Key)
                {
                    this.BeginInvoke(new MethodInvoker(delegate()
                    { 
                        dlClassification.Text = pair.Value; 
                    }));
                }
            }
        }
    }
}
