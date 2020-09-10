﻿using ShopLibrary.BLL.Model;
using ShopLibrary.DAL;
using ShopLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ShopLibrary.Client
{
    /// <summary>
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {

        List<AddressDTO> addressDTOs = new List<AddressDTO>(); //Список всіх адрес
        List<ClientDTO> clientDTOs = new List<ClientDTO>(); //Список всіх клієнтів
        List<ProductDTO> productDTOs = new List<ProductDTO>(); //Список всіх продуктів




        public OrderDTO OrderDTO { get; set; }
        bool addNew; //Перевірка чи додати чи видалити

        public OrderWindow( OrderDTO orderDTO, bool addNew)
        {
            InitializeComponent();
            this.addNew = addNew;
            this.OrderDTO = orderDTO;

            cb_Client.ItemsSource = clientDTOs;
            cb_Address.ItemsSource = addressDTOs;
            cb_Product.ItemsSource = productDTOs;

            ReadDataFromClients();

            if (!addNew)
            {
                tb_Date.Text = orderDTO.Date.ToString();
                tb_Count.Text = orderDTO.Count.ToString();
                cb_Address.SelectedIndex = addressDTOs.FindIndex(x => x.Id == orderDTO.Id);
                cb_Product.SelectedIndex = productDTOs.FindIndex(x => x.Id == orderDTO.Id);
                cb_Client.SelectedIndex = clientDTOs.FindIndex(x => x.Id == orderDTO.Id);

              
            }

        }

        private void ReadDataFromClients()
        {
            
        }

        private void ReadDataFromAddress()
        {

        }



        private void Bt_Add_Click(object sender, RoutedEventArgs e)
        {
          //Перевірка на нуль
            if (OrderDTO == null)
                OrderDTO = new OrderDTO();

            //Перевіряємо чи всі поля заповнені
            if (String.IsNullOrWhiteSpace(tb_Date.Text) || String.IsNullOrWhiteSpace(tb_Count.Text) || cb_Client.SelectedIndex == -1 || cb_Address.SelectedIndex==-1 || cb_Product.SelectedIndex==-1)
                return;



            OrderDTO.Date = DateTime.Parse(tb_Date.Text);
            OrderDTO.Count =Int32.Parse(tb_Count.Text);

            string address = cb_Address.SelectedItem.ToString();
            string client = cb_Client.SelectedItem.ToString();
            string product = cb_Product.SelectedItem.ToString();

            OrderDTO.Id = addressDTOs.Find(x => x.Country == address).Id;
            OrderDTO.Id = productDTOs.Find(x => x.NameProduct == product).Id;
            OrderDTO.Id = clientDTOs.Find(x => x.NameClient == client).Id;
           

            if (addNew)
                AddOrder();
            else
                UpdateOrder();

            this.DialogResult = true;

            //service.AddOrder(OrderDTO);
            

        }


        //Метод додавання студента
        private void AddOrder()
        {
            OrderDTO orderDTO = new OrderDTO()
            {
                Date = DateTime.Parse(tb_Date.Text),
                Count = Int32.Parse(tb_Count.Text),
                Address = cb_Address.SelectedValue.ToString(),
                Client = cb_Client.SelectedValue.ToString(),
                
            };
        }

        private void UpdateOrder()
        {
            
        }
    }
}