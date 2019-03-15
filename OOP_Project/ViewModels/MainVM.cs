﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System.IO;
using OOP_Project.Classes;
using ExcelDataReader;
//using OOP_Project.Views;
using OOP_Project.Windows;

namespace OOP_Project.ViewModels
{
    public class MainVM : ObservableObject
    {
        public List<Product> JewelryItemsList { get; } = new List<Product>();
        public List<Person> CustomerList { get; } = new List<Person>();
        public List<Person> EmployeeList { get; } = new List<Person>();
        public List<string> TestExcelReader { get; } = new List<string>();
        public Excel ReadExcel = new Excel();
        public Calculations Calculate = new Calculations();
        private LoanTransactionWindow _loanTransactionWindow;
        private PaymentTransactionWindow _paymentTransactionWindow;

        public ICommand LoanCommand => new RelayCommand(LoanProc);

        private void LoanProc()
        {
            _loanTransactionWindow = new LoanTransactionWindow();
            _loanTransactionWindow.Owner = Application.Current.MainWindow;
            _loanTransactionWindow.ShowDialog();
        }

        public ICommand PaymentCommand => new RelayCommand(PaymentProc);

        private void PaymentProc()
        {
            _paymentTransactionWindow = new PaymentTransactionWindow();
            _paymentTransactionWindow.Owner = Application.Current.MainWindow;
            _paymentTransactionWindow.ShowDialog();
        }

        public MainVM()
        {
            GetInventoryList();
        }

        private void GetInventoryList()
        {
            //Test = ReadExcel.ReadCell(5, 1);
            ReadExcel.Path = @"C:\Users\MCBManalo\Source\Repos\OOP_Project\OOP_Project\References\Jewelry Inventory.xlsx";
            var rowCounter = 2;
            while (ReadExcel.ReadCell(rowCounter, 1) != null && ReadExcel.ReadCell(rowCounter, 1) != "")
            {
                string name = "";
                float price = 0;
                decimal monthlyInterestRate = 0;
                int items = 0;
                string description = "";

                for (int column = 1; column < 6; column++)
                {
                    switch (column)
                    {
                        case 1:
                            name = Convert.ToString(ReadExcel.ReadCell(rowCounter, column));
                            break;
                        case 2:
                            price = float.Parse(ReadExcel.ReadCell(rowCounter, column));
                            break;
                        case 3:
                            monthlyInterestRate = decimal.Parse(ReadExcel.ReadCell(rowCounter, column));
                            break;
                        case 4:
                            items = int.Parse(ReadExcel.ReadCell(rowCounter, column));
                            break;
                        case 5:
                            description = Convert.ToString(ReadExcel.ReadCell(rowCounter, column));
                            JewelryItemsList.Add(new Product(name, price, monthlyInterestRate, items, description));
                            break;
                    }
                }

                rowCounter++;
            }

            ReadExcel.Row = rowCounter;
            ReadExcel.Column = 5;
            RaisePropertyChanged(nameof(JewelryItemsList));
        }

    }
}
