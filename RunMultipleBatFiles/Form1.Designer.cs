namespace RunMultipleBatFiles
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtStdOut = new System.Windows.Forms.TextBox();
            this.txtLstCmd = new System.Windows.Forms.TextBox();
            this.tabCntrl = new System.Windows.Forms.TabControl();
            this.pageList = new System.Windows.Forms.TabPage();
            this.pageStdOut = new System.Windows.Forms.TabPage();
            this.pageSettings = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkIgnoreStdErr = new System.Windows.Forms.CheckBox();
            this.bttnSelect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCD = new System.Windows.Forms.TextBox();
            this.txtValue10 = new System.Windows.Forms.TextBox();
            this.txtVar10 = new System.Windows.Forms.TextBox();
            this.txtValue09 = new System.Windows.Forms.TextBox();
            this.txtVar09 = new System.Windows.Forms.TextBox();
            this.txtValue08 = new System.Windows.Forms.TextBox();
            this.txtVar08 = new System.Windows.Forms.TextBox();
            this.txtValue07 = new System.Windows.Forms.TextBox();
            this.txtVar07 = new System.Windows.Forms.TextBox();
            this.txtValue06 = new System.Windows.Forms.TextBox();
            this.txtVar06 = new System.Windows.Forms.TextBox();
            this.txtValue05 = new System.Windows.Forms.TextBox();
            this.txtVar05 = new System.Windows.Forms.TextBox();
            this.txtValue04 = new System.Windows.Forms.TextBox();
            this.txtVar04 = new System.Windows.Forms.TextBox();
            this.txtValue03 = new System.Windows.Forms.TextBox();
            this.txtVar03 = new System.Windows.Forms.TextBox();
            this.txtValue02 = new System.Windows.Forms.TextBox();
            this.txtVar02 = new System.Windows.Forms.TextBox();
            this.txtValue01 = new System.Windows.Forms.TextBox();
            this.txtVar01 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bttnRun = new System.Windows.Forms.Button();
            this.tabCntrl.SuspendLayout();
            this.pageList.SuspendLayout();
            this.pageStdOut.SuspendLayout();
            this.pageSettings.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtStdOut
            // 
            this.txtStdOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStdOut.Location = new System.Drawing.Point(3, 3);
            this.txtStdOut.Multiline = true;
            this.txtStdOut.Name = "txtStdOut";
            this.txtStdOut.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtStdOut.Size = new System.Drawing.Size(570, 347);
            this.txtStdOut.TabIndex = 0;
            this.txtStdOut.Text = "---StdOut---";
            // 
            // txtLstCmd
            // 
            this.txtLstCmd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLstCmd.Location = new System.Drawing.Point(3, 3);
            this.txtLstCmd.Multiline = true;
            this.txtLstCmd.Name = "txtLstCmd";
            this.txtLstCmd.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLstCmd.Size = new System.Drawing.Size(570, 347);
            this.txtLstCmd.TabIndex = 1;
            this.txtLstCmd.Text = "---List---";
            // 
            // tabCntrl
            // 
            this.tabCntrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCntrl.Controls.Add(this.pageList);
            this.tabCntrl.Controls.Add(this.pageStdOut);
            this.tabCntrl.Controls.Add(this.pageSettings);
            this.tabCntrl.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tabCntrl.Location = new System.Drawing.Point(0, 12);
            this.tabCntrl.Name = "tabCntrl";
            this.tabCntrl.SelectedIndex = 0;
            this.tabCntrl.Size = new System.Drawing.Size(584, 380);
            this.tabCntrl.TabIndex = 2;
            // 
            // pageList
            // 
            this.pageList.Controls.Add(this.txtLstCmd);
            this.pageList.Location = new System.Drawing.Point(4, 23);
            this.pageList.Name = "pageList";
            this.pageList.Padding = new System.Windows.Forms.Padding(3);
            this.pageList.Size = new System.Drawing.Size(576, 353);
            this.pageList.TabIndex = 1;
            this.pageList.Text = "List";
            this.pageList.UseVisualStyleBackColor = true;
            // 
            // pageStdOut
            // 
            this.pageStdOut.Controls.Add(this.txtStdOut);
            this.pageStdOut.Location = new System.Drawing.Point(4, 23);
            this.pageStdOut.Name = "pageStdOut";
            this.pageStdOut.Padding = new System.Windows.Forms.Padding(3);
            this.pageStdOut.Size = new System.Drawing.Size(576, 353);
            this.pageStdOut.TabIndex = 3;
            this.pageStdOut.Text = "StdOut";
            this.pageStdOut.UseVisualStyleBackColor = true;
            // 
            // pageSettings
            // 
            this.pageSettings.Controls.Add(this.panel1);
            this.pageSettings.Location = new System.Drawing.Point(4, 23);
            this.pageSettings.Name = "pageSettings";
            this.pageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.pageSettings.Size = new System.Drawing.Size(576, 353);
            this.pageSettings.TabIndex = 4;
            this.pageSettings.Text = "Settings";
            this.pageSettings.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.chkIgnoreStdErr);
            this.panel1.Controls.Add(this.bttnSelect);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtCD);
            this.panel1.Controls.Add(this.txtValue10);
            this.panel1.Controls.Add(this.txtVar10);
            this.panel1.Controls.Add(this.txtValue09);
            this.panel1.Controls.Add(this.txtVar09);
            this.panel1.Controls.Add(this.txtValue08);
            this.panel1.Controls.Add(this.txtVar08);
            this.panel1.Controls.Add(this.txtValue07);
            this.panel1.Controls.Add(this.txtVar07);
            this.panel1.Controls.Add(this.txtValue06);
            this.panel1.Controls.Add(this.txtVar06);
            this.panel1.Controls.Add(this.txtValue05);
            this.panel1.Controls.Add(this.txtVar05);
            this.panel1.Controls.Add(this.txtValue04);
            this.panel1.Controls.Add(this.txtVar04);
            this.panel1.Controls.Add(this.txtValue03);
            this.panel1.Controls.Add(this.txtVar03);
            this.panel1.Controls.Add(this.txtValue02);
            this.panel1.Controls.Add(this.txtVar02);
            this.panel1.Controls.Add(this.txtValue01);
            this.panel1.Controls.Add(this.txtVar01);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(570, 347);
            this.panel1.TabIndex = 0;
            // 
            // chkIgnoreStdErr
            // 
            this.chkIgnoreStdErr.AutoSize = true;
            this.chkIgnoreStdErr.Location = new System.Drawing.Point(6, 319);
            this.chkIgnoreStdErr.Name = "chkIgnoreStdErr";
            this.chkIgnoreStdErr.Size = new System.Drawing.Size(145, 17);
            this.chkIgnoreStdErr.TabIndex = 24;
            this.chkIgnoreStdErr.Text = "Ignore standard error";
            this.chkIgnoreStdErr.UseVisualStyleBackColor = true;
            // 
            // bttnSelect
            // 
            this.bttnSelect.Location = new System.Drawing.Point(456, 290);
            this.bttnSelect.Name = "bttnSelect";
            this.bttnSelect.Size = new System.Drawing.Size(75, 23);
            this.bttnSelect.TabIndex = 23;
            this.bttnSelect.Text = "Select";
            this.bttnSelect.UseVisualStyleBackColor = true;
            this.bttnSelect.Click += new System.EventHandler(this.bttnSelect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 276);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "CurrentDirectory";
            // 
            // txtCD
            // 
            this.txtCD.Location = new System.Drawing.Point(5, 292);
            this.txtCD.Name = "txtCD";
            this.txtCD.Size = new System.Drawing.Size(445, 20);
            this.txtCD.TabIndex = 21;
            // 
            // txtValue10
            // 
            this.txtValue10.Location = new System.Drawing.Point(211, 253);
            this.txtValue10.Name = "txtValue10";
            this.txtValue10.Size = new System.Drawing.Size(320, 20);
            this.txtValue10.TabIndex = 21;
            // 
            // txtVar10
            // 
            this.txtVar10.Location = new System.Drawing.Point(5, 253);
            this.txtVar10.Name = "txtVar10";
            this.txtVar10.Size = new System.Drawing.Size(200, 20);
            this.txtVar10.TabIndex = 20;
            // 
            // txtValue09
            // 
            this.txtValue09.Location = new System.Drawing.Point(211, 227);
            this.txtValue09.Name = "txtValue09";
            this.txtValue09.Size = new System.Drawing.Size(320, 20);
            this.txtValue09.TabIndex = 19;
            // 
            // txtVar09
            // 
            this.txtVar09.Location = new System.Drawing.Point(5, 227);
            this.txtVar09.Name = "txtVar09";
            this.txtVar09.Size = new System.Drawing.Size(200, 20);
            this.txtVar09.TabIndex = 18;
            // 
            // txtValue08
            // 
            this.txtValue08.Location = new System.Drawing.Point(211, 201);
            this.txtValue08.Name = "txtValue08";
            this.txtValue08.Size = new System.Drawing.Size(320, 20);
            this.txtValue08.TabIndex = 17;
            // 
            // txtVar08
            // 
            this.txtVar08.Location = new System.Drawing.Point(5, 201);
            this.txtVar08.Name = "txtVar08";
            this.txtVar08.Size = new System.Drawing.Size(200, 20);
            this.txtVar08.TabIndex = 16;
            // 
            // txtValue07
            // 
            this.txtValue07.Location = new System.Drawing.Point(211, 175);
            this.txtValue07.Name = "txtValue07";
            this.txtValue07.Size = new System.Drawing.Size(320, 20);
            this.txtValue07.TabIndex = 15;
            // 
            // txtVar07
            // 
            this.txtVar07.Location = new System.Drawing.Point(5, 175);
            this.txtVar07.Name = "txtVar07";
            this.txtVar07.Size = new System.Drawing.Size(200, 20);
            this.txtVar07.TabIndex = 14;
            // 
            // txtValue06
            // 
            this.txtValue06.Location = new System.Drawing.Point(211, 149);
            this.txtValue06.Name = "txtValue06";
            this.txtValue06.Size = new System.Drawing.Size(320, 20);
            this.txtValue06.TabIndex = 13;
            // 
            // txtVar06
            // 
            this.txtVar06.Location = new System.Drawing.Point(5, 149);
            this.txtVar06.Name = "txtVar06";
            this.txtVar06.Size = new System.Drawing.Size(200, 20);
            this.txtVar06.TabIndex = 12;
            // 
            // txtValue05
            // 
            this.txtValue05.Location = new System.Drawing.Point(211, 123);
            this.txtValue05.Name = "txtValue05";
            this.txtValue05.Size = new System.Drawing.Size(320, 20);
            this.txtValue05.TabIndex = 11;
            // 
            // txtVar05
            // 
            this.txtVar05.Location = new System.Drawing.Point(5, 123);
            this.txtVar05.Name = "txtVar05";
            this.txtVar05.Size = new System.Drawing.Size(200, 20);
            this.txtVar05.TabIndex = 10;
            // 
            // txtValue04
            // 
            this.txtValue04.Location = new System.Drawing.Point(211, 97);
            this.txtValue04.Name = "txtValue04";
            this.txtValue04.Size = new System.Drawing.Size(320, 20);
            this.txtValue04.TabIndex = 9;
            // 
            // txtVar04
            // 
            this.txtVar04.Location = new System.Drawing.Point(5, 97);
            this.txtVar04.Name = "txtVar04";
            this.txtVar04.Size = new System.Drawing.Size(200, 20);
            this.txtVar04.TabIndex = 8;
            // 
            // txtValue03
            // 
            this.txtValue03.Location = new System.Drawing.Point(211, 71);
            this.txtValue03.Name = "txtValue03";
            this.txtValue03.Size = new System.Drawing.Size(320, 20);
            this.txtValue03.TabIndex = 7;
            // 
            // txtVar03
            // 
            this.txtVar03.Location = new System.Drawing.Point(5, 71);
            this.txtVar03.Name = "txtVar03";
            this.txtVar03.Size = new System.Drawing.Size(200, 20);
            this.txtVar03.TabIndex = 6;
            // 
            // txtValue02
            // 
            this.txtValue02.Location = new System.Drawing.Point(211, 45);
            this.txtValue02.Name = "txtValue02";
            this.txtValue02.Size = new System.Drawing.Size(320, 20);
            this.txtValue02.TabIndex = 5;
            // 
            // txtVar02
            // 
            this.txtVar02.Location = new System.Drawing.Point(5, 45);
            this.txtVar02.Name = "txtVar02";
            this.txtVar02.Size = new System.Drawing.Size(200, 20);
            this.txtVar02.TabIndex = 4;
            // 
            // txtValue01
            // 
            this.txtValue01.Location = new System.Drawing.Point(211, 19);
            this.txtValue01.Name = "txtValue01";
            this.txtValue01.Size = new System.Drawing.Size(320, 20);
            this.txtValue01.TabIndex = 3;
            // 
            // txtVar01
            // 
            this.txtVar01.Location = new System.Drawing.Point(5, 19);
            this.txtVar01.Name = "txtVar01";
            this.txtVar01.Size = new System.Drawing.Size(200, 20);
            this.txtVar01.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "VALUE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "VARIABLE";
            // 
            // bttnRun
            // 
            this.bttnRun.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bttnRun.Location = new System.Drawing.Point(4, 394);
            this.bttnRun.Name = "bttnRun";
            this.bttnRun.Size = new System.Drawing.Size(576, 25);
            this.bttnRun.TabIndex = 3;
            this.bttnRun.Text = "Run";
            this.bttnRun.UseVisualStyleBackColor = true;
            this.bttnRun.Click += new System.EventHandler(this.bttnRun_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 421);
            this.Controls.Add(this.bttnRun);
            this.Controls.Add(this.tabCntrl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.tabCntrl.ResumeLayout(false);
            this.pageList.ResumeLayout(false);
            this.pageList.PerformLayout();
            this.pageStdOut.ResumeLayout(false);
            this.pageStdOut.PerformLayout();
            this.pageSettings.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtStdOut;
        private System.Windows.Forms.TextBox txtLstCmd;
        private System.Windows.Forms.TabControl tabCntrl;
        private System.Windows.Forms.TabPage pageList;
        private System.Windows.Forms.TabPage pageStdOut;
        private System.Windows.Forms.TabPage pageSettings;
        private System.Windows.Forms.Button bttnRun;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtValue10;
        private System.Windows.Forms.TextBox txtVar10;
        private System.Windows.Forms.TextBox txtValue09;
        private System.Windows.Forms.TextBox txtVar09;
        private System.Windows.Forms.TextBox txtValue08;
        private System.Windows.Forms.TextBox txtVar08;
        private System.Windows.Forms.TextBox txtValue07;
        private System.Windows.Forms.TextBox txtVar07;
        private System.Windows.Forms.TextBox txtValue06;
        private System.Windows.Forms.TextBox txtVar06;
        private System.Windows.Forms.TextBox txtValue05;
        private System.Windows.Forms.TextBox txtVar05;
        private System.Windows.Forms.TextBox txtValue04;
        private System.Windows.Forms.TextBox txtVar04;
        private System.Windows.Forms.TextBox txtValue03;
        private System.Windows.Forms.TextBox txtVar03;
        private System.Windows.Forms.TextBox txtValue02;
        private System.Windows.Forms.TextBox txtVar02;
        private System.Windows.Forms.TextBox txtValue01;
        private System.Windows.Forms.TextBox txtVar01;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bttnSelect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCD;
        private System.Windows.Forms.CheckBox chkIgnoreStdErr;
    }
}

