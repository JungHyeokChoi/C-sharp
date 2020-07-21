﻿namespace eBookManager
{
    partial class eBookManager
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(eBookManager));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImportEbooks = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstStorageSpaces = new System.Windows.Forms.ListView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstBooks = new System.Windows.Forms.ListView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gbBookDetails = new System.Windows.Forms.GroupBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dtDatePublished = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.dlClassification = new System.Windows.Forms.ComboBox();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPublisher = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.gbFileDetails = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtLastAccessed = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtCreated = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExtension = new System.Windows.Forms.TextBox();
            this.txtFileSize = new System.Windows.Forms.TextBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtStorageSpaceDescription = new System.Windows.Forms.TextBox();
            this.btnDeleteStorageSpace = new System.Windows.Forms.Button();
            this.btnDeleteEbook = new System.Windows.Forms.Button();
            this.btnReadEbook = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbBookDetails.SuspendLayout();
            this.gbFileDetails.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1484, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuImportEbooks});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 26);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mnuImportEbooks
            // 
            this.mnuImportEbooks.Name = "mnuImportEbooks";
            this.mnuImportEbooks.Size = new System.Drawing.Size(191, 26);
            this.mnuImportEbooks.Text = "Import eBooks";
            this.mnuImportEbooks.Click += new System.EventHandler(this.mnuImportEbooks_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Read eBook";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.lstStorageSpaces);
            this.groupBox1.Location = new System.Drawing.Point(16, 31);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(344, 697);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Virtual Storage Spaces";
            // 
            // lstStorageSpaces
            // 
            this.lstStorageSpaces.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstStorageSpaces.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstStorageSpaces.HideSelection = false;
            this.lstStorageSpaces.HotTracking = true;
            this.lstStorageSpaces.HoverSelection = true;
            this.lstStorageSpaces.Location = new System.Drawing.Point(8, 22);
            this.lstStorageSpaces.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lstStorageSpaces.Name = "lstStorageSpaces";
            this.lstStorageSpaces.Size = new System.Drawing.Size(327, 667);
            this.lstStorageSpaces.TabIndex = 0;
            this.lstStorageSpaces.TileSize = new System.Drawing.Size(260, 36);
            this.lstStorageSpaces.UseCompatibleStateImageBehavior = false;
            this.lstStorageSpaces.View = System.Windows.Forms.View.Tile;
            this.lstStorageSpaces.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstStorageSpaces_MouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.lstBooks);
            this.groupBox2.Location = new System.Drawing.Point(368, 31);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(613, 697);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "eBooks in Virtual Storage Space";
            // 
            // lstBooks
            // 
            this.lstBooks.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstBooks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstBooks.HideSelection = false;
            this.lstBooks.HotTracking = true;
            this.lstBooks.HoverSelection = true;
            this.lstBooks.Location = new System.Drawing.Point(8, 22);
            this.lstBooks.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lstBooks.Name = "lstBooks";
            this.lstBooks.Size = new System.Drawing.Size(596, 667);
            this.lstBooks.SmallImageList = this.imageList1;
            this.lstBooks.StateImageList = this.imageList1;
            this.lstBooks.TabIndex = 4;
            this.lstBooks.UseCompatibleStateImageBehavior = false;
            this.lstBooks.View = System.Windows.Forms.View.List;
            this.lstBooks.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstBooks_MouseClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.gbBookDetails);
            this.groupBox3.Controls.Add(this.gbFileDetails);
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Location = new System.Drawing.Point(989, 31);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Size = new System.Drawing.Size(487, 697);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "eBook Info";
            // 
            // gbBookDetails
            // 
            this.gbBookDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBookDetails.Controls.Add(this.btnDeleteStorageSpace);
            this.gbBookDetails.Controls.Add(this.btnDeleteEbook);
            this.gbBookDetails.Controls.Add(this.btnReadEbook);
            this.gbBookDetails.Controls.Add(this.txtPrice);
            this.gbBookDetails.Controls.Add(this.label6);
            this.gbBookDetails.Controls.Add(this.label4);
            this.gbBookDetails.Controls.Add(this.label13);
            this.gbBookDetails.Controls.Add(this.label12);
            this.gbBookDetails.Controls.Add(this.dtDatePublished);
            this.gbBookDetails.Controls.Add(this.label11);
            this.gbBookDetails.Controls.Add(this.label14);
            this.gbBookDetails.Controls.Add(this.txtCategory);
            this.gbBookDetails.Controls.Add(this.dlClassification);
            this.gbBookDetails.Controls.Add(this.txtISBN);
            this.gbBookDetails.Controls.Add(this.txtTitle);
            this.gbBookDetails.Controls.Add(this.label10);
            this.gbBookDetails.Controls.Add(this.txtPublisher);
            this.gbBookDetails.Controls.Add(this.label9);
            this.gbBookDetails.Controls.Add(this.txtAuthor);
            this.gbBookDetails.Location = new System.Drawing.Point(8, 239);
            this.gbBookDetails.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbBookDetails.Name = "gbBookDetails";
            this.gbBookDetails.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbBookDetails.Size = new System.Drawing.Size(469, 315);
            this.gbBookDetails.TabIndex = 42;
            this.gbBookDetails.TabStop = false;
            this.gbBookDetails.Text = "Book details";
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.Location = new System.Drawing.Point(137, 111);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(317, 25);
            this.txtPrice.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 24);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Title:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 54);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.TabIndex = 26;
            this.label4.Text = "Author:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(24, 144);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 15);
            this.label13.TabIndex = 18;
            this.label13.Text = "ISBN:";
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
            // dtDatePublished
            // 
            this.dtDatePublished.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDatePublished.Enabled = false;
            this.dtDatePublished.Location = new System.Drawing.Point(137, 171);
            this.dtDatePublished.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtDatePublished.Name = "dtDatePublished";
            this.dtDatePublished.Size = new System.Drawing.Size(317, 25);
            this.dtDatePublished.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 204);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 15);
            this.label11.TabIndex = 20;
            this.label11.Text = "Category";
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
            // txtCategory
            // 
            this.txtCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCategory.Location = new System.Drawing.Point(137, 201);
            this.txtCategory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.ReadOnly = true;
            this.txtCategory.Size = new System.Drawing.Size(317, 25);
            this.txtCategory.TabIndex = 6;
            // 
            // dlClassification
            // 
            this.dlClassification.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dlClassification.Enabled = false;
            this.dlClassification.FormattingEnabled = true;
            this.dlClassification.Location = new System.Drawing.Point(137, 231);
            this.dlClassification.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dlClassification.Name = "dlClassification";
            this.dlClassification.Size = new System.Drawing.Size(317, 23);
            this.dlClassification.TabIndex = 7;
            // 
            // txtISBN
            // 
            this.txtISBN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtISBN.Location = new System.Drawing.Point(137, 141);
            this.txtISBN.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.ReadOnly = true;
            this.txtISBN.Size = new System.Drawing.Size(317, 25);
            this.txtISBN.TabIndex = 4;
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(137, 21);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(317, 25);
            this.txtTitle.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 84);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 15);
            this.label10.TabIndex = 24;
            this.label10.Text = "Publisher:";
            // 
            // txtPublisher
            // 
            this.txtPublisher.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPublisher.Location = new System.Drawing.Point(137, 81);
            this.txtPublisher.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPublisher.Name = "txtPublisher";
            this.txtPublisher.ReadOnly = true;
            this.txtPublisher.Size = new System.Drawing.Size(317, 25);
            this.txtPublisher.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 114);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 15);
            this.label9.TabIndex = 25;
            this.label9.Text = "Price:";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAuthor.Location = new System.Drawing.Point(137, 51);
            this.txtAuthor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.ReadOnly = true;
            this.txtAuthor.Size = new System.Drawing.Size(317, 25);
            this.txtAuthor.TabIndex = 1;
            // 
            // gbFileDetails
            // 
            this.gbFileDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFileDetails.Controls.Add(this.label1);
            this.gbFileDetails.Controls.Add(this.dtLastAccessed);
            this.gbFileDetails.Controls.Add(this.label2);
            this.gbFileDetails.Controls.Add(this.dtCreated);
            this.gbFileDetails.Controls.Add(this.label3);
            this.gbFileDetails.Controls.Add(this.txtExtension);
            this.gbFileDetails.Controls.Add(this.txtFileSize);
            this.gbFileDetails.Controls.Add(this.txtFileName);
            this.gbFileDetails.Controls.Add(this.txtFilePath);
            this.gbFileDetails.Controls.Add(this.label8);
            this.gbFileDetails.Controls.Add(this.label5);
            this.gbFileDetails.Controls.Add(this.label7);
            this.gbFileDetails.Location = new System.Drawing.Point(8, 22);
            this.gbFileDetails.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbFileDetails.Name = "gbFileDetails";
            this.gbFileDetails.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbFileDetails.Size = new System.Drawing.Size(469, 210);
            this.gbFileDetails.TabIndex = 41;
            this.gbFileDetails.TabStop = false;
            this.gbFileDetails.Text = "File details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 114);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Created:";
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
            this.dtLastAccessed.TabIndex = 99;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 144);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "File path:";
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
            this.dtCreated.TabIndex = 99;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 174);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Size:";
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
            this.txtExtension.TabIndex = 99;
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
            this.txtFileSize.TabIndex = 99;
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
            this.txtFileName.TabIndex = 99;
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
            this.txtFilePath.TabIndex = 99;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 54);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 15);
            this.label8.TabIndex = 10;
            this.label8.Text = "File extension:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 24);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "File name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 84);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "Last accessed:";
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.txtStorageSpaceDescription);
            this.groupBox6.Location = new System.Drawing.Point(8, 561);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox6.Size = new System.Drawing.Size(469, 129);
            this.groupBox6.TabIndex = 40;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Virtual Storage Space Info";
            // 
            // txtStorageSpaceDescription
            // 
            this.txtStorageSpaceDescription.Location = new System.Drawing.Point(8, 22);
            this.txtStorageSpaceDescription.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtStorageSpaceDescription.Multiline = true;
            this.txtStorageSpaceDescription.Name = "txtStorageSpaceDescription";
            this.txtStorageSpaceDescription.ReadOnly = true;
            this.txtStorageSpaceDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStorageSpaceDescription.Size = new System.Drawing.Size(447, 71);
            this.txtStorageSpaceDescription.TabIndex = 7;
            // 
            // btnDeleteStorageSpace
            // 
            this.btnDeleteStorageSpace.Image = global::eBookManager.Properties.Resources.delete_storage_space;
            this.btnDeleteStorageSpace.Location = new System.Drawing.Point(249, 262);
            this.btnDeleteStorageSpace.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDeleteStorageSpace.Name = "btnDeleteStorageSpace";
            this.btnDeleteStorageSpace.Size = new System.Drawing.Size(48, 46);
            this.btnDeleteStorageSpace.TabIndex = 34;
            this.toolTip1.SetToolTip(this.btnDeleteStorageSpace, "Click here to delete the eBook file");
            this.btnDeleteStorageSpace.UseVisualStyleBackColor = true;
            this.btnDeleteStorageSpace.Click += new System.EventHandler(this.btnDeleteStorageSpace_Click);
            // 
            // btnDeleteEbook
            // 
            this.btnDeleteEbook.Image = global::eBookManager.Properties.Resources.delete_ebook_file1;
            this.btnDeleteEbook.Location = new System.Drawing.Point(193, 263);
            this.btnDeleteEbook.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDeleteEbook.Name = "btnDeleteEbook";
            this.btnDeleteEbook.Size = new System.Drawing.Size(48, 46);
            this.btnDeleteEbook.TabIndex = 33;
            this.toolTip1.SetToolTip(this.btnDeleteEbook, "Click here to delete the eBook file");
            this.btnDeleteEbook.UseVisualStyleBackColor = true;
            this.btnDeleteEbook.Click += new System.EventHandler(this.btnDeleteEbook_Click);
            // 
            // btnReadEbook
            // 
            this.btnReadEbook.Image = global::eBookManager.Properties.Resources.ReadEbook;
            this.btnReadEbook.Location = new System.Drawing.Point(137, 262);
            this.btnReadEbook.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnReadEbook.Name = "btnReadEbook";
            this.btnReadEbook.Size = new System.Drawing.Size(48, 46);
            this.btnReadEbook.TabIndex = 32;
            this.toolTip1.SetToolTip(this.btnReadEbook, "Click here to open the eBook file location");
            this.btnReadEbook.UseVisualStyleBackColor = true;
            this.btnReadEbook.Click += new System.EventHandler(this.btnReadEbook_Click);
            // 
            // eBookManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 742);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "eBookManager";
            this.Text = "eBook Manager";
            this.Load += new System.EventHandler(this.eBookManager_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.gbBookDetails.ResumeLayout(false);
            this.gbBookDetails.PerformLayout();
            this.gbFileDetails.ResumeLayout(false);
            this.gbFileDetails.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuImportEbooks;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ListView lstStorageSpaces;
        private System.Windows.Forms.ListView lstBooks;
        private System.Windows.Forms.GroupBox gbFileDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtLastAccessed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtCreated;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExtension;
        private System.Windows.Forms.TextBox txtFileSize;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gbBookDetails;
        private System.Windows.Forms.Button btnReadEbook;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtDatePublished;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.ComboBox dlClassification;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPublisher;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtStorageSpaceDescription;
        private System.Windows.Forms.Button btnDeleteEbook;
        private System.Windows.Forms.Button btnDeleteStorageSpace;
    }
}

