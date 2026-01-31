namespace SlopBalancer;

partial class MainView
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
        splitContainer1 = new System.Windows.Forms.SplitContainer();
        btnUpdate = new System.Windows.Forms.Button();
        chkOnlyToBands = new System.Windows.Forms.CheckBox();
        chkCurrentOnly = new System.Windows.Forms.CheckBox();
        chkAddCash = new System.Windows.Forms.CheckBox();
        txtCashToAdd = new System.Windows.Forms.TextBox();
        txtTargets = new System.Windows.Forms.TextBox();
        txtCurrentShares = new System.Windows.Forms.TextBox();
        txtTickers = new System.Windows.Forms.TextBox();
        dataGridView1 = new System.Windows.Forms.DataGridView();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        SuspendLayout();
        // 
        // splitContainer1
        // 
        splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
        splitContainer1.Location = new System.Drawing.Point(0, 0);
        splitContainer1.Name = "splitContainer1";
        splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // splitContainer1.Panel1
        // 
        splitContainer1.Panel1.Controls.Add(btnUpdate);
        splitContainer1.Panel1.Controls.Add(chkOnlyToBands);
        splitContainer1.Panel1.Controls.Add(chkCurrentOnly);
        splitContainer1.Panel1.Controls.Add(chkAddCash);
        splitContainer1.Panel1.Controls.Add(txtCashToAdd);
        splitContainer1.Panel1.Controls.Add(txtTargets);
        splitContainer1.Panel1.Controls.Add(txtCurrentShares);
        splitContainer1.Panel1.Controls.Add(txtTickers);
        // 
        // splitContainer1.Panel2
        // 
        splitContainer1.Panel2.Controls.Add(dataGridView1);
        splitContainer1.Size = new System.Drawing.Size(1904, 1041);
        splitContainer1.SplitterDistance = 507;
        splitContainer1.TabIndex = 0;
        splitContainer1.Text = "splitContainer1";
        // 
        // btnUpdate
        // 
        btnUpdate.Location = new System.Drawing.Point(705, 193);
        btnUpdate.Name = "btnUpdate";
        btnUpdate.Size = new System.Drawing.Size(75, 23);
        btnUpdate.TabIndex = 7;
        btnUpdate.Text = "Update";
        btnUpdate.UseVisualStyleBackColor = true;
        // 
        // chkOnlyToBands
        // 
        chkOnlyToBands.Location = new System.Drawing.Point(934, 74);
        chkOnlyToBands.Name = "chkOnlyToBands";
        chkOnlyToBands.Size = new System.Drawing.Size(213, 24);
        chkOnlyToBands.TabIndex = 6;
        chkOnlyToBands.Text = "Only rebalance to 175 bps bands";
        chkOnlyToBands.UseVisualStyleBackColor = true;
        // 
        // chkCurrentOnly
        // 
        chkCurrentOnly.Location = new System.Drawing.Point(702, 104);
        chkCurrentOnly.Name = "chkCurrentOnly";
        chkCurrentOnly.Size = new System.Drawing.Size(230, 21);
        chkCurrentOnly.TabIndex = 5;
        chkCurrentOnly.Text = "Rebalance with current shares only";
        chkCurrentOnly.UseVisualStyleBackColor = true;
        // 
        // chkAddCash
        // 
        chkAddCash.Location = new System.Drawing.Point(702, 74);
        chkAddCash.Name = "chkAddCash";
        chkAddCash.Size = new System.Drawing.Size(249, 24);
        chkAddCash.TabIndex = 4;
        chkAddCash.Text = "Rebalance by adding new cash";
        chkAddCash.UseVisualStyleBackColor = true;
        // 
        // txtCashToAdd
        // 
        txtCashToAdd.Location = new System.Drawing.Point(141, 268);
        txtCashToAdd.Name = "txtCashToAdd";
        txtCashToAdd.Size = new System.Drawing.Size(409, 23);
        txtCashToAdd.TabIndex = 3;
        txtCashToAdd.Text = "cash to add";
        // 
        // txtTargets
        // 
        txtTargets.Location = new System.Drawing.Point(141, 199);
        txtTargets.Multiline = true;
        txtTargets.Name = "txtTargets";
        txtTargets.Size = new System.Drawing.Size(409, 23);
        txtTargets.TabIndex = 2;
        txtTargets.Text = "target percentages";
        // 
        // txtCurrentShares
        // 
        txtCurrentShares.Location = new System.Drawing.Point(141, 140);
        txtCurrentShares.Multiline = true;
        txtCurrentShares.Name = "txtCurrentShares";
        txtCurrentShares.Size = new System.Drawing.Size(409, 23);
        txtCurrentShares.TabIndex = 1;
        txtCurrentShares.Text = "current shares";
        // 
        // txtTickers
        // 
        txtTickers.Location = new System.Drawing.Point(141, 73);
        txtTickers.Multiline = true;
        txtTickers.Name = "txtTickers";
        txtTickers.Size = new System.Drawing.Size(409, 23);
        txtTickers.TabIndex = 0;
        txtTickers.Text = "tickers";
        // 
        // dataGridView1
        // 
        dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
        dataGridView1.Location = new System.Drawing.Point(0, 0);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.Size = new System.Drawing.Size(1904, 530);
        dataGridView1.TabIndex = 0;
        dataGridView1.Text = "dataGridView1";
        // 
        // MainView
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1904, 1041);
        Controls.Add(splitContainer1);
        Text = "MainView";
        splitContainer1.Panel1.ResumeLayout(false);
        splitContainer1.Panel1.PerformLayout();
        splitContainer1.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button btnUpdate;

    private System.Windows.Forms.TextBox txtCashToAdd;
    private System.Windows.Forms.CheckBox chkAddCash;
    private System.Windows.Forms.CheckBox chkCurrentOnly;
    private System.Windows.Forms.CheckBox chkOnlyToBands;

    private System.Windows.Forms.TextBox txtCurrentShares;
    private System.Windows.Forms.TextBox txtTargets;

    private System.Windows.Forms.TextBox txtTickers;

    private System.Windows.Forms.DataGridView dataGridView1;

    private System.Windows.Forms.SplitContainer splitContainer1;

    #endregion
}