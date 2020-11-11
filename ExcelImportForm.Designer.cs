namespace SupportTicketDemo.Forms
{
    partial class ExcelImportForm
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.marquee = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.progress = new DevExpress.XtraEditors.ProgressBarControl();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.btnChooseFile = new DevExpress.XtraEditors.ButtonEdit();
            this.btnImporter = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlMapping = new DevExpress.XtraGrid.GridControl();
            this.gridViewMapping = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lkpField = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.cboPersistent = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gridControlExcelSource = new DevExpress.XtraGrid.GridControl();
            this.gridViewExcelSource = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcgMappingData = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgExcelData = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciChooseFile = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.behaviorManager = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.pageHome = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.groupMain = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.marquee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnChooseFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMapping)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMapping)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPersistent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlExcelSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewExcelSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMappingData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgExcelData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciChooseFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.marquee);
            this.layoutControl1.Controls.Add(this.progress);
            this.layoutControl1.Controls.Add(this.memoEdit1);
            this.layoutControl1.Controls.Add(this.btnChooseFile);
            this.layoutControl1.Controls.Add(this.btnImporter);
            this.layoutControl1.Controls.Add(this.gridControlMapping);
            this.layoutControl1.Controls.Add(this.cboPersistent);
            this.layoutControl1.Controls.Add(this.gridControlExcelSource);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 158);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1598, 741);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // marquee
            // 
            this.marquee.EditValue = 0;
            this.marquee.Location = new System.Drawing.Point(22, 41);
            this.marquee.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.marquee.MenuManager = this.ribbon;
            this.marquee.Name = "marquee";
            this.marquee.Properties.MarqueeAnimationSpeed = 5;
            this.marquee.Properties.MarqueeWidth = 300;
            this.marquee.Properties.Stopped = true;
            this.marquee.Size = new System.Drawing.Size(1554, 0);
            this.marquee.StyleController = this.layoutControl1;
            this.marquee.TabIndex = 14;
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(22, 337);
            this.progress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progress.MenuManager = this.ribbon;
            this.progress.Name = "progress";
            this.progress.Properties.PercentView = false;
            this.progress.Properties.Step = 1;
            this.progress.ShowProgressInTaskBar = true;
            this.progress.Size = new System.Drawing.Size(1554, 1);
            this.progress.StyleController = this.layoutControl1;
            this.progress.TabIndex = 13;
            // 
            // memoEdit1
            // 
            this.memoEdit1.Location = new System.Drawing.Point(22, 342);
            this.memoEdit1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.memoEdit1.MenuManager = this.ribbon;
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Properties.ReadOnly = true;
            this.memoEdit1.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.memoEdit1.Size = new System.Drawing.Size(516, 164);
            this.memoEdit1.StyleController = this.layoutControl1;
            this.memoEdit1.TabIndex = 12;
            // 
            // btnChooseFile
            // 
            this.behaviorManager.SetBehaviors(this.btnChooseFile, new DevExpress.Utils.Behaviors.Behavior[] {
            ((DevExpress.Utils.Behaviors.Behavior)(DevExpress.Utils.Behaviors.Common.OpenFileBehavior.Create(typeof(DevExpress.XtraEditors.Behaviors.OpenFileBehaviorSourceForButtonEdit), true, DevExpress.Utils.Behaviors.Common.FileIconSize.Small, null, null, DevExpress.Utils.Behaviors.Common.CompletionMode.FilesAndDirectories, null, null, DevExpress.Utils.CommonDialogs.FileBrowserStyle.Default)))});
            this.btnChooseFile.Location = new System.Drawing.Point(22, 45);
            this.btnChooseFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnChooseFile.MenuManager = this.ribbon;
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnChooseFile.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.btnChooseFile.Size = new System.Drawing.Size(774, 20);
            this.btnChooseFile.StyleController = this.layoutControl1;
            this.btnChooseFile.TabIndex = 11;
            this.btnChooseFile.EditValueChanged += new System.EventHandler(this.OnChooseFileEditValueChanged);
            // 
            // btnImporter
            // 
            this.btnImporter.Appearance.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImporter.Appearance.Options.UseFont = true;
            this.btnImporter.ImageOptions.SvgImageSize = new System.Drawing.Size(18, 18);
            this.btnImporter.Location = new System.Drawing.Point(22, 550);
            this.btnImporter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnImporter.Name = "btnImporter";
            this.btnImporter.Size = new System.Drawing.Size(516, 24);
            this.btnImporter.StyleController = this.layoutControl1;
            this.btnImporter.TabIndex = 10;
            this.btnImporter.Text = "Import Data";
            this.btnImporter.Click += new System.EventHandler(this.OnImportClick);
            // 
            // gridControlMapping
            // 
            this.gridControlMapping.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControlMapping.Location = new System.Drawing.Point(542, 342);
            this.gridControlMapping.MainView = this.gridViewMapping;
            this.gridControlMapping.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControlMapping.MenuManager = this.ribbon;
            this.gridControlMapping.Name = "gridControlMapping";
            this.gridControlMapping.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lkpField});
            this.gridControlMapping.Size = new System.Drawing.Size(1034, 379);
            this.gridControlMapping.TabIndex = 9;
            this.gridControlMapping.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMapping});
            // 
            // gridViewMapping
            // 
            this.gridViewMapping.DetailHeight = 284;
            this.gridViewMapping.GridControl = this.gridControlMapping;
            this.gridViewMapping.Name = "gridViewMapping";
            this.gridViewMapping.OptionsDetail.EnableMasterViewMode = false;
            this.gridViewMapping.OptionsView.ShowGroupPanel = false;
            this.gridViewMapping.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.OnMappingRowCellClick);
            this.gridViewMapping.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.OnGridviewBeforeLeaveRow);
            this.gridViewMapping.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.OnCustomColumnDisplayText);
            // 
            // lkpField
            // 
            this.lkpField.AutoHeight = false;
            this.lkpField.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpField.Name = "lkpField";
            // 
            // cboPersistent
            // 
            this.cboPersistent.Location = new System.Drawing.Point(22, 526);
            this.cboPersistent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboPersistent.MenuManager = this.ribbon;
            this.cboPersistent.Name = "cboPersistent";
            this.cboPersistent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPersistent.Size = new System.Drawing.Size(516, 20);
            this.cboPersistent.StyleController = this.layoutControl1;
            this.cboPersistent.TabIndex = 7;
            this.cboPersistent.SelectedIndexChanged += new System.EventHandler(this.OnCboPersistentSelectedIndexChanged);
            // 
            // gridControlExcelSource
            // 
            this.gridControlExcelSource.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControlExcelSource.Location = new System.Drawing.Point(22, 69);
            this.gridControlExcelSource.MainView = this.gridViewExcelSource;
            this.gridControlExcelSource.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControlExcelSource.MenuManager = this.ribbon;
            this.gridControlExcelSource.Name = "gridControlExcelSource";
            this.gridControlExcelSource.Size = new System.Drawing.Size(1554, 223);
            this.gridControlExcelSource.TabIndex = 4;
            this.gridControlExcelSource.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewExcelSource});
            // 
            // gridViewExcelSource
            // 
            this.gridViewExcelSource.DetailHeight = 284;
            this.gridViewExcelSource.GridControl = this.gridControlExcelSource;
            this.gridViewExcelSource.Name = "gridViewExcelSource";
            this.gridViewExcelSource.OptionsDetail.EnableMasterViewMode = false;
            this.gridViewExcelSource.OptionsView.ShowGroupPanel = false;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgMappingData,
            this.lcgExcelData});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1598, 741);
            this.Root.TextVisible = false;
            // 
            // lcgMappingData
            // 
            this.lcgMappingData.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem5,
            this.layoutControlItem4,
            this.layoutControlItem3,
            this.emptySpaceItem3,
            this.layoutControlItem2,
            this.layoutControlItem6});
            this.lcgMappingData.Location = new System.Drawing.Point(0, 296);
            this.lcgMappingData.Name = "lcgMappingData";
            this.lcgMappingData.Size = new System.Drawing.Size(1580, 429);
            this.lcgMappingData.Text = "Map Database Fields to Excel Headers";
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.BestFitWeight = 200;
            this.layoutControlItem5.Control = this.gridControlMapping;
            this.layoutControlItem5.Location = new System.Drawing.Point(520, 5);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(1038, 383);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.cboPersistent;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 173);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(520, 40);
            this.layoutControlItem4.Text = "Choose Database Table";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(114, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.BestFitWeight = 1;
            this.layoutControlItem3.Control = this.progress;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(0, 5);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(1, 5);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1558, 5);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 241);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(520, 147);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.memoEdit1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 5);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(12, 89);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(520, 168);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnImporter;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 213);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(520, 28);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // lcgExcelData
            // 
            this.lcgExcelData.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.lciChooseFile,
            this.layoutControlItem7});
            this.lcgExcelData.Location = new System.Drawing.Point(0, 0);
            this.lcgExcelData.Name = "lcgExcelData";
            this.lcgExcelData.Size = new System.Drawing.Size(1580, 296);
            this.lcgExcelData.Text = "Select Excel File";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.BestFitWeight = 200;
            this.layoutControlItem1.Control = this.gridControlExcelSource;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1558, 227);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(778, 4);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(780, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciChooseFile
            // 
            this.lciChooseFile.Control = this.btnChooseFile;
            this.lciChooseFile.Location = new System.Drawing.Point(0, 4);
            this.lciChooseFile.Name = "lciChooseFile";
            this.lciChooseFile.Size = new System.Drawing.Size(778, 24);
            this.lciChooseFile.TextSize = new System.Drawing.Size(0, 0);
            this.lciChooseFile.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.BestFitWeight = 1;
            this.layoutControlItem7.Control = this.marquee;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(0, 4);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(46, 4);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(1558, 4);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // pageHome
            // 
            this.pageHome.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.groupMain});
            this.pageHome.Name = "pageHome";
            this.pageHome.Text = "Home";
            // 
            // groupMain
            // 
            this.groupMain.Name = "groupMain";
            this.groupMain.Text = "Main";
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ribbon.MaxItemId = 1;
            this.ribbon.Name = "ribbon";
            this.ribbon.OptionsMenuMinWidth = 283;
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.pageHome});
            this.ribbon.Size = new System.Drawing.Size(1598, 158);
            // 
            // ExcelImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1598, 899);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbon);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ExcelImportForm";
            this.Ribbon = this.ribbon;
            this.Text = "Excel Import Form";
            this.Load += new System.EventHandler(this.OnFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.marquee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnChooseFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMapping)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMapping)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPersistent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlExcelSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewExcelSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMappingData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgExcelData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciChooseFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl gridControlExcelSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewExcelSource;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.ComboBoxEdit cboPersistent;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.GridControl gridControlMapping;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMapping;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.SimpleButton btnImporter;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox lkpField;
        private DevExpress.XtraLayout.LayoutControlGroup lcgMappingData;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlGroup lcgExcelData;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.ButtonEdit btnChooseFile;
        private DevExpress.XtraLayout.LayoutControlItem lciChooseFile;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.ProgressBarControl progress;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.MarqueeProgressBarControl marquee;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage pageHome;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup groupMain;
    }
}