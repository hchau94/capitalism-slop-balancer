using System.ComponentModel;

namespace SlopBalancer.Views;

partial class MainView
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        lblCurrentShares = new System.Windows.Forms.Label();
        lblPrices = new System.Windows.Forms.Label();
        lblTargets = new System.Windows.Forms.Label();
        lblOutput = new System.Windows.Forms.Label();
        txtTickers = new System.Windows.Forms.TextBox();
        txtCurrentShares = new System.Windows.Forms.TextBox();
        txtPrices = new System.Windows.Forms.TextBox();
        txtTargets = new System.Windows.Forms.TextBox();
        lblTickers = new System.Windows.Forms.Label();
        txtOutput = new System.Windows.Forms.TextBox();
        lblControls = new System.Windows.Forms.Label();
        panelControls = new System.Windows.Forms.Panel();
        cmdBalance = new System.Windows.Forms.Button();
        lblCash = new System.Windows.Forms.Label();
        txtCash = new System.Windows.Forms.TextBox();
        chkOnlyToBands = new System.Windows.Forms.CheckBox();
        radioOnlyCurrent = new System.Windows.Forms.RadioButton();
        radioAddCash = new System.Windows.Forms.RadioButton();
        cmdRefresh = new System.Windows.Forms.Button();
        tableLayoutPanel1.SuspendLayout();
        panelControls.SuspendLayout();
        SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 6;
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        tableLayoutPanel1.Controls.Add(lblCurrentShares, 1, 0);
        tableLayoutPanel1.Controls.Add(lblPrices, 2, 0);
        tableLayoutPanel1.Controls.Add(lblTargets, 3, 0);
        tableLayoutPanel1.Controls.Add(lblOutput, 4, 0);
        tableLayoutPanel1.Controls.Add(txtTickers, 0, 1);
        tableLayoutPanel1.Controls.Add(txtCurrentShares, 1, 1);
        tableLayoutPanel1.Controls.Add(txtPrices, 2, 1);
        tableLayoutPanel1.Controls.Add(txtTargets, 3, 1);
        tableLayoutPanel1.Controls.Add(lblTickers, 0, 0);
        tableLayoutPanel1.Controls.Add(txtOutput, 4, 1);
        tableLayoutPanel1.Controls.Add(lblControls, 5, 0);
        tableLayoutPanel1.Controls.Add(panelControls, 5, 1);
        tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 2;
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.7857828F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 97.21422F));
        tableLayoutPanel1.Size = new System.Drawing.Size(1904, 1041);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // lblCurrentShares
        // 
        lblCurrentShares.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        lblCurrentShares.Location = new System.Drawing.Point(421, 6);
        lblCurrentShares.Name = "lblCurrentShares";
        lblCurrentShares.Size = new System.Drawing.Size(100, 23);
        lblCurrentShares.TabIndex = 1;
        lblCurrentShares.Text = "Current Shares";
        // 
        // lblPrices
        // 
        lblPrices.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        lblPrices.Location = new System.Drawing.Point(735, 6);
        lblPrices.Name = "lblPrices";
        lblPrices.Size = new System.Drawing.Size(100, 23);
        lblPrices.TabIndex = 2;
        lblPrices.Text = "Prices";
        // 
        // lblTargets
        // 
        lblTargets.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        lblTargets.Location = new System.Drawing.Point(1049, 6);
        lblTargets.Name = "lblTargets";
        lblTargets.Size = new System.Drawing.Size(100, 23);
        lblTargets.TabIndex = 3;
        lblTargets.Text = "Targets";
        // 
        // lblOutput
        // 
        lblOutput.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        lblOutput.Location = new System.Drawing.Point(1363, 6);
        lblOutput.Name = "lblOutput";
        lblOutput.Size = new System.Drawing.Size(100, 23);
        lblOutput.TabIndex = 4;
        lblOutput.Text = "Output";
        // 
        // txtTickers
        // 
        txtTickers.Dock = System.Windows.Forms.DockStyle.Fill;
        txtTickers.Location = new System.Drawing.Point(3, 32);
        txtTickers.Multiline = true;
        txtTickers.Name = "txtTickers";
        txtTickers.Size = new System.Drawing.Size(308, 1006);
        txtTickers.TabIndex = 5;
        // 
        // txtCurrentShares
        // 
        txtCurrentShares.Dock = System.Windows.Forms.DockStyle.Fill;
        txtCurrentShares.Location = new System.Drawing.Point(317, 32);
        txtCurrentShares.Multiline = true;
        txtCurrentShares.Name = "txtCurrentShares";
        txtCurrentShares.Size = new System.Drawing.Size(308, 1006);
        txtCurrentShares.TabIndex = 6;
        // 
        // txtPrices
        // 
        txtPrices.Dock = System.Windows.Forms.DockStyle.Fill;
        txtPrices.Location = new System.Drawing.Point(631, 32);
        txtPrices.Multiline = true;
        txtPrices.Name = "txtPrices";
        txtPrices.Size = new System.Drawing.Size(308, 1006);
        txtPrices.TabIndex = 7;
        // 
        // txtTargets
        // 
        txtTargets.Dock = System.Windows.Forms.DockStyle.Fill;
        txtTargets.Location = new System.Drawing.Point(945, 32);
        txtTargets.Multiline = true;
        txtTargets.Name = "txtTargets";
        txtTargets.Size = new System.Drawing.Size(308, 1006);
        txtTargets.TabIndex = 8;
        // 
        // lblTickers
        // 
        lblTickers.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        lblTickers.Location = new System.Drawing.Point(107, 6);
        lblTickers.Name = "lblTickers";
        lblTickers.Size = new System.Drawing.Size(100, 23);
        lblTickers.TabIndex = 0;
        lblTickers.Text = "Tickers";
        // 
        // txtOutput
        // 
        txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
        txtOutput.Enabled = false;
        txtOutput.Location = new System.Drawing.Point(1259, 32);
        txtOutput.Multiline = true;
        txtOutput.Name = "txtOutput";
        txtOutput.ReadOnly = true;
        txtOutput.Size = new System.Drawing.Size(308, 1006);
        txtOutput.TabIndex = 9;
        // 
        // lblControls
        // 
        lblControls.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        lblControls.Location = new System.Drawing.Point(1687, 6);
        lblControls.Name = "lblControls";
        lblControls.Size = new System.Drawing.Size(100, 23);
        lblControls.TabIndex = 10;
        lblControls.Text = "Controls";
        // 
        // panelControls
        // 
        panelControls.Controls.Add(cmdRefresh);
        panelControls.Controls.Add(cmdBalance);
        panelControls.Controls.Add(lblCash);
        panelControls.Controls.Add(txtCash);
        panelControls.Controls.Add(chkOnlyToBands);
        panelControls.Controls.Add(radioOnlyCurrent);
        panelControls.Controls.Add(radioAddCash);
        panelControls.Dock = System.Windows.Forms.DockStyle.Fill;
        panelControls.Location = new System.Drawing.Point(1573, 32);
        panelControls.Name = "panelControls";
        panelControls.Size = new System.Drawing.Size(328, 1006);
        panelControls.TabIndex = 11;
        // 
        // cmdBalance
        // 
        cmdBalance.Enabled = false;
        cmdBalance.Location = new System.Drawing.Point(80, 339);
        cmdBalance.Name = "cmdBalance";
        cmdBalance.Size = new System.Drawing.Size(164, 48);
        cmdBalance.TabIndex = 5;
        cmdBalance.Text = "Balance";
        cmdBalance.UseVisualStyleBackColor = true;
        // 
        // lblCash
        // 
        lblCash.Location = new System.Drawing.Point(70, 269);
        lblCash.Name = "lblCash";
        lblCash.Size = new System.Drawing.Size(50, 23);
        lblCash.TabIndex = 4;
        lblCash.Text = "Cash";
        lblCash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // txtCash
        // 
        txtCash.Enabled = false;
        txtCash.Location = new System.Drawing.Point(126, 269);
        txtCash.Name = "txtCash";
        txtCash.Size = new System.Drawing.Size(100, 23);
        txtCash.TabIndex = 3;
        // 
        // chkOnlyToBands
        // 
        chkOnlyToBands.Location = new System.Drawing.Point(62, 194);
        chkOnlyToBands.Name = "chkOnlyToBands";
        chkOnlyToBands.Size = new System.Drawing.Size(104, 24);
        chkOnlyToBands.TabIndex = 2;
        chkOnlyToBands.Text = "Only To Bands";
        chkOnlyToBands.UseVisualStyleBackColor = true;
        // 
        // radioOnlyCurrent
        // 
        radioOnlyCurrent.Location = new System.Drawing.Point(54, 124);
        radioOnlyCurrent.Name = "radioOnlyCurrent";
        radioOnlyCurrent.Size = new System.Drawing.Size(104, 24);
        radioOnlyCurrent.TabIndex = 1;
        radioOnlyCurrent.TabStop = true;
        radioOnlyCurrent.Text = "Only Current";
        radioOnlyCurrent.UseVisualStyleBackColor = true;
        // 
        // radioAddCash
        // 
        radioAddCash.Location = new System.Drawing.Point(42, 59);
        radioAddCash.Name = "radioAddCash";
        radioAddCash.Size = new System.Drawing.Size(104, 24);
        radioAddCash.TabIndex = 0;
        radioAddCash.TabStop = true;
        radioAddCash.Text = "Add Cash";
        radioAddCash.UseVisualStyleBackColor = true;
        // 
        // cmdRefresh
        // 
        cmdRefresh.Location = new System.Drawing.Point(64, 427);
        cmdRefresh.Name = "cmdRefresh";
        cmdRefresh.Size = new System.Drawing.Size(75, 23);
        cmdRefresh.TabIndex = 6;
        cmdRefresh.Text = "Refresh";
        cmdRefresh.UseVisualStyleBackColor = true;
        // 
        // MainView
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1904, 1041);
        Controls.Add(tableLayoutPanel1);
        Text = "Slop Balancer";
        tableLayoutPanel1.ResumeLayout(false);
        tableLayoutPanel1.PerformLayout();
        panelControls.ResumeLayout(false);
        panelControls.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button cmdRefresh;

    private System.Windows.Forms.Button cmdBalance;

    private System.Windows.Forms.RadioButton radioAddCash;
    private System.Windows.Forms.RadioButton radioOnlyCurrent;
    private System.Windows.Forms.CheckBox chkOnlyToBands;
    private System.Windows.Forms.TextBox txtCash;
    private System.Windows.Forms.Label lblCash;

    private System.Windows.Forms.TextBox txtOutput;
    private System.Windows.Forms.Label lblControls;
    private System.Windows.Forms.Panel panelControls;

    private System.Windows.Forms.Label lblTickers;
    private System.Windows.Forms.Label lblCurrentShares;
    private System.Windows.Forms.Label lblPrices;
    private System.Windows.Forms.Label lblTargets;
    private System.Windows.Forms.Label lblOutput;
    private System.Windows.Forms.TextBox txtTickers;
    private System.Windows.Forms.TextBox txtCurrentShares;
    private System.Windows.Forms.TextBox txtPrices;
    private System.Windows.Forms.TextBox txtTargets;

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

    #endregion
}