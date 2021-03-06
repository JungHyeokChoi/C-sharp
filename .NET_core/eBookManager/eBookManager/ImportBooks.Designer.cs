﻿namespace eBookManager
{
    partial class ImportBooks
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportBooks));
            this.btnSelectSourceFolder = new System.Windows.Forms.Button();
            this.tvFoundBooks = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtStorageSpaceDescription = new System.Windows.Forms.TextBox();
            this.dlVirtualStorageSpaces = new System.Windows.Forms.ComboBox();
            this.lblStorageSpaceDescription = new System.Windows.Forms.Label();
            this.lblEbookCount = new System.Windows.Forms.Label();
            this.btnSaveNewStorageSpace = new System.Windows.Forms.Button();
            this.btnCancelNewStorageSpaceSave = new System.Windows.Forms.Button();
            this.txtNewStorageSpaceName = new System.Windows.Forms.TextBox();
            this.btnAddNewStorageSpace = new System.Windows.Forms.Button();
            this.gbFileDetails = new System.Windows.Forms.GroupBox();
            this.dtCreated = new System.Windows.Forms.DateTimePicker();
            this.dtLastAccessed = new System.Windows.Forms.DateTimePicker();
            this.txtFileSize = new System.Windows.Forms.TextBox();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.txtExtension = new System.Windows.Forms.TextBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbBookDetails = new System.Windows.Forms.GroupBox();
            this.btnDeleteClassification = new System.Windows.Forms.Button();
            this.btnAddClassification = new System.Windows.Forms.Button();
            this.btnAddeBookToStorageSpace = new System.Windows.Forms.Button();
            this.dlClassification = new System.Windows.Forms.ComboBox();
            this.dtDatePublished = new System.Windows.Forms.DateTimePicker();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.txtPublisher = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tvImages = new System.Windows.Forms.ImageList(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.gbFileDetails.SuspendLayout();
            this.gbBookDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelectSourceFolder
            // 
            this.btnSelectSourceFolder.Location = new System.Drawing.Point(13, 13);
            this.btnSelectSourceFolder.Name = "btnSelectSourceFolder";
            this.btnSelectSourceFolder.Size = new System.Drawing.Size(151, 27);
            this.btnSelectSourceFolder.TabIndex = 0;
            this.btnSelectSourceFolder.Text = "Select source folder";
            this.btnSelectSourceFolder.UseVisualStyleBackColor = true;
            this.btnSelectSourceFolder.Click += new System.EventHandler(this.btnSelectSourceFolder_Click);
            // 
            // tvFoundBooks
            // 
            this.tvFoundBooks.Location = new System.Drawing.Point(16, 47);
            this.tvFoundBooks.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tvFoundBooks.Name = "tvFoundBooks";
            this.tvFoundBooks.Size = new System.Drawing.Size(683, 283);
            this.tvFoundBooks.TabIndex = 1;
            this.tvFoundBooks.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvFoundBooks_AfterSelect);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtStorageSpaceDescription);
            this.groupBox1.Controls.Add(this.dlVirtualStorageSpaces);
            this.groupBox1.Controls.Add(this.lblStorageSpaceDescription);
            this.groupBox1.Controls.Add(this.lblEbookCount);
            this.groupBox1.Controls.Add(this.btnSaveNewStorageSpace);
            this.groupBox1.Controls.Add(this.btnCancelNewStorageSpaceSave);
            this.groupBox1.Controls.Add(this.txtNewStorageSpaceName);
            this.groupBox1.Controls.Add(this.btnAddNewStorageSpace);
            this.groupBox1.Location = new System.Drawing.Point(16, 345);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(683, 233);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Virtual storage spaces";
            // 
            // txtStorageSpaceDescription
            // 
            this.txtStorageSpaceDescription.Location = new System.Drawing.Point(331, 78);
            this.txtStorageSpaceDescription.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtStorageSpaceDescription.Multiline = true;
            this.txtStorageSpaceDescription.Name = "txtStorageSpaceDescription";
            this.txtStorageSpaceDescription.Size = new System.Drawing.Size(344, 136);
            this.txtStorageSpaceDescription.TabIndex = 6;
            this.txtStorageSpaceDescription.Visible = false;
            // 
            // dlVirtualStorageSpaces
            // 
            this.dlVirtualStorageSpaces.DropDownWidth = 275;
            this.dlVirtualStorageSpaces.FormattingEnabled = true;
            this.dlVirtualStorageSpaces.Location = new System.Drawing.Point(8, 22);
            this.dlVirtualStorageSpaces.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dlVirtualStorageSpaces.Name = "dlVirtualStorageSpaces";
            this.dlVirtualStorageSpaces.Size = new System.Drawing.Size(276, 23);
            this.dlVirtualStorageSpaces.TabIndex = 3;
            this.dlVirtualStorageSpaces.SelectedIndexChanged += new System.EventHandler(this.dlVirtualStorageSpaces_SelectedIndexChanged);
            // 
            // lblStorageSpaceDescription
            // 
            this.lblStorageSpaceDescription.AutoSize = true;
            this.lblStorageSpaceDescription.Location = new System.Drawing.Point(329, 60);
            this.lblStorageSpaceDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStorageSpaceDescription.Name = "lblStorageSpaceDescription";
            this.lblStorageSpaceDescription.Size = new System.Drawing.Size(188, 15);
            this.lblStorageSpaceDescription.TabIndex = 6;
            this.lblStorageSpaceDescription.Text = "Storage Space Description:";
            this.lblStorageSpaceDescription.Visible = false;
            // 
            // lblEbookCount
            // 
            this.lblEbookCount.AutoSize = true;
            this.lblEbookCount.Location = new System.Drawing.Point(8, 60);
            this.lblEbookCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEbookCount.Name = "lblEbookCount";
            this.lblEbookCount.Size = new System.Drawing.Size(103, 15);
            this.lblEbookCount.TabIndex = 5;
            this.lblEbookCount.Text = "lbleBookCount";
            // 
            // btnSaveNewStorageSpace
            // 
            this.btnSaveNewStorageSpace.Location = new System.Drawing.Point(535, 20);
            this.btnSaveNewStorageSpace.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSaveNewStorageSpace.Name = "btnSaveNewStorageSpace";
            this.btnSaveNewStorageSpace.Size = new System.Drawing.Size(67, 27);
            this.btnSaveNewStorageSpace.TabIndex = 7;
            this.btnSaveNewStorageSpace.Text = "save";
            this.btnSaveNewStorageSpace.UseVisualStyleBackColor = true;
            this.btnSaveNewStorageSpace.Visible = false;
            this.btnSaveNewStorageSpace.Click += new System.EventHandler(this.btnSaveNewStorageSpace_Click);
            // 
            // btnCancelNewStorageSpaceSave
            // 
            this.btnCancelNewStorageSpaceSave.Location = new System.Drawing.Point(609, 20);
            this.btnCancelNewStorageSpaceSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancelNewStorageSpaceSave.Name = "btnCancelNewStorageSpaceSave";
            this.btnCancelNewStorageSpaceSave.Size = new System.Drawing.Size(67, 27);
            this.btnCancelNewStorageSpaceSave.TabIndex = 8;
            this.btnCancelNewStorageSpaceSave.Text = "cancel";
            this.btnCancelNewStorageSpaceSave.UseVisualStyleBackColor = true;
            this.btnCancelNewStorageSpaceSave.Visible = false;
            this.btnCancelNewStorageSpaceSave.Click += new System.EventHandler(this.btnCancelNewStorageSpaceSave_Click);
            // 
            // txtNewStorageSpaceName
            // 
            this.txtNewStorageSpaceName.Location = new System.Drawing.Point(331, 22);
            this.txtNewStorageSpaceName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNewStorageSpaceName.Name = "txtNewStorageSpaceName";
            this.txtNewStorageSpaceName.Size = new System.Drawing.Size(195, 25);
            this.txtNewStorageSpaceName.TabIndex = 5;
            this.txtNewStorageSpaceName.Visible = false;
            // 
            // btnAddNewStorageSpace
            // 
            this.btnAddNewStorageSpace.Image = global::eBookManager.Properties.Resources.add_new_storage_space;
            this.btnAddNewStorageSpace.Location = new System.Drawing.Point(292, 20);
            this.btnAddNewStorageSpace.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAddNewStorageSpace.Name = "btnAddNewStorageSpace";
            this.btnAddNewStorageSpace.Size = new System.Drawing.Size(31, 27);
            this.btnAddNewStorageSpace.TabIndex = 4;
            this.toolTip.SetToolTip(this.btnAddNewStorageSpace, "Add new Storage Space");
            this.btnAddNewStorageSpace.UseVisualStyleBackColor = true;
            this.btnAddNewStorageSpace.Click += new System.EventHandler(this.btnAddNewStorageSpace_Click);
            // 
            // gbFileDetails
            // 
            this.gbFileDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFileDetails.Controls.Add(this.dtCreated);
            this.gbFileDetails.Controls.Add(this.dtLastAccessed);
            this.gbFileDetails.Controls.Add(this.txtFileSize);
            this.gbFileDetails.Controls.Add(this.txtFilePath);
            this.gbFileDetails.Controls.Add(this.txtExtension);
            this.gbFileDetails.Controls.Add(this.txtFileName);
            this.gbFileDetails.Controls.Add(this.label6);
            this.gbFileDetails.Controls.Add(this.label5);
            this.gbFileDetails.Controls.Add(this.label4);
            this.gbFileDetails.Controls.Add(this.label3);
            this.gbFileDetails.Controls.Add(this.label2);
            this.gbFileDetails.Controls.Add(this.label1);
            this.gbFileDetails.Location = new System.Drawing.Point(707, 47);
            this.gbFileDetails.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbFileDetails.Name = "gbFileDetails";
            this.gbFileDetails.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbFileDetails.Size = new System.Drawing.Size(469, 210);
            this.gbFileDetails.TabIndex = 9;
            this.gbFileDetails.TabStop = false;
            this.gbFileDetails.Text = "File details";
            // 
            // dtCreated
            // 
            this.dtCreated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtCreated.Enabled = false;
            this.dtCreated.Location = new System.Drawing.Point(137, 114);
            this.dtCreated.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtCreated.Name = "dtCreated";
            this.dtCreated.Size = new System.Drawing.Size(317, 25);
            this.dtCreated.TabIndex = 13;
            // 
            // dtLastAccessed
            // 
            this.dtLastAccessed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtLastAccessed.Enabled = false;
            this.dtLastAccessed.Location = new System.Drawing.Point(137, 84);
            this.dtLastAccessed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtLastAccessed.Name = "dtLastAccessed";
            this.dtLastAccessed.Size = new System.Drawing.Size(317, 25);
            this.dtLastAccessed.TabIndex = 12;
            // 
            // txtFileSize
            // 
            this.txtFileSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileSize.Location = new System.Drawing.Point(137, 171);
            this.txtFileSize.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtFileSize.Name = "txtFileSize";
            this.txtFileSize.ReadOnly = true;
            this.txtFileSize.Size = new System.Drawing.Size(317, 25);
            this.txtFileSize.TabIndex = 15;
            // 
            // txtFilePath
            // 
            this.txtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePath.Location = new System.Drawing.Point(137, 141);
            this.txtFilePath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(317, 25);
            this.txtFilePath.TabIndex = 14;
            // 
            // txtExtension
            // 
            this.txtExtension.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExtension.Location = new System.Drawing.Point(137, 51);
            this.txtExtension.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtExtension.Name = "txtExtension";
            this.txtExtension.ReadOnly = true;
            this.txtExtension.Size = new System.Drawing.Size(317, 25);
            this.txtExtension.TabIndex = 11;
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.Location = new System.Drawing.Point(137, 21);
            this.txtFileName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(317, 25);
            this.txtFileName.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 174);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "Size:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 144);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "File path:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 114);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Created:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 84);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Last accessed:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "File extension:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "File name:";
            // 
            // gbBookDetails
            // 
            this.gbBookDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBookDetails.Controls.Add(this.txtPrice);
            this.gbBookDetails.Controls.Add(this.btnDeleteClassification);
            this.gbBookDetails.Controls.Add(this.btnAddClassification);
            this.gbBookDetails.Controls.Add(this.btnAddeBookToStorageSpace);
            this.gbBookDetails.Controls.Add(this.dlClassification);
            this.gbBookDetails.Controls.Add(this.dtDatePublished);
            this.gbBookDetails.Controls.Add(this.txtCategory);
            this.gbBookDetails.Controls.Add(this.txtISBN);
            this.gbBookDetails.Controls.Add(this.txtPublisher);
            this.gbBookDetails.Controls.Add(this.txtAuthor);
            this.gbBookDetails.Controls.Add(this.txtTitle);
            this.gbBookDetails.Controls.Add(this.label14);
            this.gbBookDetails.Controls.Add(this.label13);
            this.gbBookDetails.Controls.Add(this.label12);
            this.gbBookDetails.Controls.Add(this.label11);
            this.gbBookDetails.Controls.Add(this.label10);
            this.gbBookDetails.Controls.Add(this.label9);
            this.gbBookDetails.Controls.Add(this.label8);
            this.gbBookDetails.Controls.Add(this.label7);
            this.gbBookDetails.Location = new System.Drawing.Point(706, 263);
            this.gbBookDetails.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbBookDetails.Name = "gbBookDetails";
            this.gbBookDetails.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbBookDetails.Size = new System.Drawing.Size(469, 315);
            this.gbBookDetails.TabIndex = 16;
            this.gbBookDetails.TabStop = false;
            this.gbBookDetails.Text = "Book details";
            // 
            // btnDeleteClassification
            // 
            this.btnDeleteClassification.Image = global::eBookManager.Properties.Resources.delete_classification;
            this.btnDeleteClassification.Location = new System.Drawing.Point(215, 262);
            this.btnDeleteClassification.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDeleteClassification.Name = "btnDeleteClassification";
            this.btnDeleteClassification.Size = new System.Drawing.Size(31, 27);
            this.btnDeleteClassification.TabIndex = 33;
            this.btnDeleteClassification.UseVisualStyleBackColor = true;
            this.btnDeleteClassification.Click += new System.EventHandler(this.btnDeleteClassification_Click);
            this.btnDeleteClassification.MouseHover += new System.EventHandler(this.btnDeleteClassification_MouseHover);
            // 
            // btnAddClassification
            // 
            this.btnAddClassification.Image = global::eBookManager.Properties.Resources.add_classification;
            this.btnAddClassification.Location = new System.Drawing.Point(176, 262);
            this.btnAddClassification.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAddClassification.Name = "btnAddClassification";
            this.btnAddClassification.Size = new System.Drawing.Size(31, 27);
            this.btnAddClassification.TabIndex = 32;
            this.btnAddClassification.UseVisualStyleBackColor = true;
            this.btnAddClassification.Click += new System.EventHandler(this.btnAddClassification_Click);
            this.btnAddClassification.MouseHover += new System.EventHandler(this.btnAddClassification_MouseHover);
            // 
            // btnAddeBookToStorageSpace
            // 
            this.btnAddeBookToStorageSpace.Image = global::eBookManager.Properties.Resources.add_ebook_to_storage_space;
            this.btnAddeBookToStorageSpace.Location = new System.Drawing.Point(137, 262);
            this.btnAddeBookToStorageSpace.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAddeBookToStorageSpace.Name = "btnAddeBookToStorageSpace";
            this.btnAddeBookToStorageSpace.Size = new System.Drawing.Size(31, 27);
            this.btnAddeBookToStorageSpace.TabIndex = 25;
            this.btnAddeBookToStorageSpace.UseVisualStyleBackColor = true;
            this.btnAddeBookToStorageSpace.Click += new System.EventHandler(this.btnAddeBookToStorageSpace_Click);
            this.btnAddeBookToStorageSpace.MouseHover += new System.EventHandler(this.btnAddeBookToStorageSpace_MouseHover);
            // 
            // dlClassification
            // 
            this.dlClassification.FormattingEnabled = true;
            this.dlClassification.Location = new System.Drawing.Point(137, 231);
            this.dlClassification.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dlClassification.Name = "dlClassification";
            this.dlClassification.Size = new System.Drawing.Size(317, 23);
            this.dlClassification.TabIndex = 24;
            this.dlClassification.SelectionChangeCommitted += new System.EventHandler(this.dlClassification_SelectionChangeCommitted);
            // 
            // dtDatePublished
            // 
            this.dtDatePublished.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDatePublished.Location = new System.Drawing.Point(137, 171);
            this.dtDatePublished.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtDatePublished.Name = "dtDatePublished";
            this.dtDatePublished.Size = new System.Drawing.Size(317, 25);
            this.dtDatePublished.TabIndex = 22;
            // 
            // txtCategory
            // 
            this.txtCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCategory.Location = new System.Drawing.Point(137, 201);
            this.txtCategory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(317, 25);
            this.txtCategory.TabIndex = 23;
            // 
            // txtISBN
            // 
            this.txtISBN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtISBN.Location = new System.Drawing.Point(137, 141);
            this.txtISBN.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(317, 25);
            this.txtISBN.TabIndex = 21;
            // 
            // txtPublisher
            // 
            this.txtPublisher.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPublisher.Location = new System.Drawing.Point(137, 81);
            this.txtPublisher.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPublisher.Name = "txtPublisher";
            this.txtPublisher.Size = new System.Drawing.Size(317, 25);
            this.txtPublisher.TabIndex = 19;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(137, 51);
            this.txtAuthor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(317, 25);
            this.txtAuthor.TabIndex = 18;
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(137, 21);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(317, 25);
            this.txtTitle.TabIndex = 17;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(24, 234);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(99, 15);
            this.label14.TabIndex = 31;
            this.label14.Text = "Classification:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(24, 204);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 15);
            this.label13.TabIndex = 20;
            this.label13.Text = "Category:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(24, 174);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(109, 15);
            this.label12.TabIndex = 19;
            this.label12.Text = "Date published:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 144);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 15);
            this.label11.TabIndex = 18;
            this.label11.Text = "ISBN:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 114);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 15);
            this.label10.TabIndex = 25;
            this.label10.Text = "Price:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 84);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 15);
            this.label9.TabIndex = 24;
            this.label9.Text = "Publisher:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 54);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 15);
            this.label8.TabIndex = 26;
            this.label8.Text = "Author:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 24);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Title:";
            // 
            // tvImages
            // 
            this.tvImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.tvImages.ImageSize = new System.Drawing.Size(16, 16);
            this.tvImages.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // txtPrice
            // 
            this.txtPrice.AcceptsReturn = true;
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.Location = new System.Drawing.Point(137, 110);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(317, 25);
            this.txtPrice.TabIndex = 34;
            // 
            // ImportBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 642);
            this.Controls.Add(this.gbBookDetails);
            this.Controls.Add(this.gbFileDetails);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tvFoundBooks);
            this.Controls.Add(this.btnSelectSourceFolder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImportBooks";
            this.Text = "ImportBooks";
            this.Load += new System.EventHandler(this.ImportBooks_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbFileDetails.ResumeLayout(false);
            this.gbFileDetails.PerformLayout();
            this.gbBookDetails.ResumeLayout(false);
            this.gbBookDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSelectSourceFolder;
        private System.Windows.Forms.TreeView tvFoundBooks;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox dlVirtualStorageSpaces;
        private System.Windows.Forms.Label lblStorageSpaceDescription;
        private System.Windows.Forms.Label lblEbookCount;
        private System.Windows.Forms.Button btnSaveNewStorageSpace;
        private System.Windows.Forms.Button btnCancelNewStorageSpaceSave;
        private System.Windows.Forms.TextBox txtNewStorageSpaceName;
        private System.Windows.Forms.Button btnAddNewStorageSpace;
        private System.Windows.Forms.GroupBox gbFileDetails;
        private System.Windows.Forms.GroupBox gbBookDetails;
        private System.Windows.Forms.TextBox txtStorageSpaceDescription;
        private System.Windows.Forms.TextBox txtFileSize;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.TextBox txtExtension;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtCreated;
        private System.Windows.Forms.DateTimePicker dtLastAccessed;
        private System.Windows.Forms.DateTimePicker dtDatePublished;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.TextBox txtPublisher;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAddeBookToStorageSpace;
        private System.Windows.Forms.ComboBox dlClassification;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ImageList tvImages;
        private System.Windows.Forms.Button btnAddClassification;
        private System.Windows.Forms.Button btnDeleteClassification;
        private System.Windows.Forms.TextBox txtPrice;
    }
}