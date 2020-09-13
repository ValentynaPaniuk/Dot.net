using ShopLibrary.BLL.Model;
using ShopLibrary.BLL.Services;
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
        private readonly IShopService service;



        List<Address> addressDTOs = new List<Address>(); //Список всіх адрес
        List<ClientDTO> clientDTOs = new List<ClientDTO>(); //Список всіх клієнтів
        List<ProductDTO> productDTOs = new List<ProductDTO>(); //Список всіх продуктів


        public OrderDTO OrderDTO { get; set; }
        bool addNew; //Перевірка чи додати чи видалити

        public OrderWindow( OrderDTO orderDTO, bool addNew, IShopService orderService)
        {
            InitializeComponent();
            this.addNew = addNew;
            this.OrderDTO = orderDTO;
            this.service = orderService;
            this.addressDTOs = service.GetAddresses().ToList();
            this.clientDTOs = service.GetClients().ToList();
            //this.productDTOs = service.ToList();


            cb_Client.ItemsSource = clientDTOs;
            cb_Address.ItemsSource = addressDTOs;
            cb_Product.ItemsSource = productDTOs;

           

            //Якщо потрібно робити Update
            if (!addNew)
            {
                tb_Date.Text = orderDTO.Date.ToString();
                tb_Count.Text = orderDTO.Count.ToString();
                cb_Address.SelectedIndex = addressDTOs.FindIndex(x => x.Id == orderDTO.Id);
                cb_Product.SelectedIndex = productDTOs.FindIndex(x => x.Id == orderDTO.Id);
                cb_Client.SelectedIndex = clientDTOs.FindIndex(x => x.Id == orderDTO.Id);

              
            }

        }

      


        private void Bt_Add_Click(object sender, RoutedEventArgs e)
        {
          //Перевірка на нуль
            if (OrderDTO == null)
                OrderDTO = new OrderDTO();

            //Перевіряємо чи всі поля заповнені
            if (addNew)
            {
                if (String.IsNullOrWhiteSpace(tb_Date.Text) || String.IsNullOrWhiteSpace(tb_Count.Text) || cb_Client.SelectedIndex == -1 || cb_Address.SelectedIndex == -1 /*|| cb_Product.SelectedIndex==-1*/)
                    return;

                OrderDTO.Date = DateTime.Parse(tb_Date.Text);
                OrderDTO.Count = Int32.Parse(tb_Count.Text);

                OrderDTO.Address = (cb_Address.SelectedValue as Address).Country;
                OrderDTO.Client = (cb_Client.SelectedValue as ClientDTO).NameClient;
            }
            // string product = (cb_Product.SelectedValue as ProductDTO).NameProduct;// cb_Product.SelectedItem.ToString();
                 
                UpdateOrders(service);
                    
            this.DialogResult = true;

            service.AddOrder(OrderDTO);
            

        }


      

        private void UpdateOrders(IShopService shopService)
        {
            var windowOrder = this.Owner as MainWindow;
            windowOrder.Orders.Clear();
            var temp = shopService.GetOrders();
            foreach (var item in temp)
            {
               //Orders.Add(item);
            }
        }


    }
}
