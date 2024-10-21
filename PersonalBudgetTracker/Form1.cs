using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PersonalBudgetTracker
{
    public partial class Form1 : Form
    {
        // List to store transactions
        private List<Transaction> transactions = new List<Transaction>();

        public Form1()
        {
            InitializeComponent();
            // Add categories to the ComboBox (Income and Expense)
            cmbCategory.Items.Add("Income");
            cmbCategory.Items.Add("Expense");
            cmbCategory.SelectedIndex = 0; // Default to Income
        }

        // Event handler for adding a transaction
        private void btnAddTransaction_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrEmpty(txtTransactionName.Text) || string.IsNullOrEmpty(txtAmount.Text))
            {
                MessageBox.Show("Please enter a valid name and amount.");
                return;
            }

            decimal amount;
            if (!decimal.TryParse(txtAmount.Text, out amount))
            {
                MessageBox.Show("Please enter a valid number for the amount.");
                return;
            }

            // Create a new transaction
            Transaction newTransaction = new Transaction()
            {
                Name = txtTransactionName.Text,
                Category = cmbCategory.SelectedItem.ToString(),
                Amount = amount,
                Date = dtpTransactionDate.Value
            };

            // Add transaction to the list
            transactions.Add(newTransaction);

            // Update the DataGrid and totals
            UpdateDataGrid();
            UpdateTotals();
        }

        // Update the DataGridView with the transaction list
        private void UpdateDataGrid()
        {
            dataGridViewTransactions.DataSource = null;
            dataGridViewTransactions.DataSource = transactions;
        }

        // Calculate and update total income, expenses, and remaining balance
        private void UpdateTotals()
        {
            decimal totalIncome = transactions.Where(t => t.Category == "Income").Sum(t => t.Amount);
            decimal totalExpenses = transactions.Where(t => t.Category == "Expense").Sum(t => t.Amount);
            decimal balance = totalIncome - totalExpenses;

            lblTotalIncome.Text = $"Total Income: {totalIncome:C}";
            lblTotalExpenses.Text = $"Total Expenses: {totalExpenses:C}";
            lblRemainingBalance.Text = $"Remaining Balance: {balance:C}";
        }

        // Other event handlers (can be left as they are)
        private void Form1_Load(object sender, EventArgs e) { }
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtTransactionName_TextChanged(object sender, EventArgs e) { }
        private void txtAmount_TextChanged(object sender, EventArgs e) { }
        private void dtpTransactionDate_ValueChanged(object sender, EventArgs e) { }
        private void dataGridViewTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void lblTotalIncome_Click(object sender, EventArgs e) { }
        private void lblTotalExpenses_Click(object sender, EventArgs e) { }
        private void lblRemainingBalance_Click(object sender, EventArgs e) { }
    }

    // Transaction class to store each transaction's details
    public class Transaction
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
