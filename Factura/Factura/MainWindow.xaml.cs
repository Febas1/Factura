using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Factura
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    #region Factura
    public class Facturad
    {
        private int _numero;
        public int Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }
        private int _porImpuesto;
        public int PorImpuesto
        {
            get { return _porImpuesto; }
            set { _porImpuesto = value; }
        }
        private string _tipoImpuesto;
        public string TipoImpuesto
        {
            get { return _tipoImpuesto; }
            set { _tipoImpuesto = value; }
        }
        private int _subtotal;
        public int Subtotal
        {
            get { return _subtotal; }
            set { _subtotal = value; }
        }

        private DateTime _fechaFactura;
        public DateTime FechaFactura
        {
            get { return _fechaFactura; }
            set { _fechaFactura = value; }
        }
        private int _descuento;
        public int Descuento
        {
            get { return _descuento; }
            set { _descuento = value; }
        }
        private int _total;
        public int Total
        {
            get { return _total; }
            set { _total = value; }
        }
        public Facturad(int num, int por, string tipo, int subtotal, DateTime fecha, int desto, int tot)
        {
            Numero = num;
            PorImpuesto = por;
        }
    }
    #endregion
    #region Producto
    public class Producto
    {
        private int _referencia;
        public int Referencia
        {
            get { return _referencia; }
            set { _referencia = value; }
        }
        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        private int _precio;
        public int Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }
        private int _cantidad;
        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public Producto(int referencia, string nombre, int precio, int cant)
        {
            Referencia = referencia;
            Nombre = nombre;
            Precio = precio;
            Cantidad = cant;
        }
    }
    #endregion
    public partial class MainWindow : Window
    {

        public ObservableCollection<Producto> producExis;
        public ObservableCollection<Producto> producFac = new ObservableCollection<Producto>();
        public ObservableCollection<Facturad> factu;
        public MainWindow()
        {
            InitializeComponent();
            IniciarInventario();
        }

        public void IniciarInventario()
        {
            producExis = new ObservableCollection<Producto>()
            {
                new Producto(01, "Empanada", 5000, 0),
                new Producto(02, "Marihuana", 13000, 0),
                new Producto(03, "Lechuga del demonio", 50000, 0),
                new Producto(04, "Extasis", 70000, 0),
                new Producto(05, "Burundanga", 85000, 0),
                new Producto(06, "Butifarra", 3000, 0),
            };

            ComboPro.ItemsSource = producExis;
            ComboPro.DisplayMemberPath = "Nombre";
            ComboPro.SelectedValuePath = "Referencia";
        }

        public void DatosFactura()
        {
            factu = new ObservableCollection<Facturad>()
            {
                new Facturad(0001, 19, "IVA", 300000, DateTime.Today, 0, 357000),
                new Facturad(0002, 19, "IVA", 300000, DateTime.Today, 0, 357000),
            };
        }

        private void Selec_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Convert.ToString(ComboPro.SelectedValue));


            //producFac.Add(producExis.Where((x) => x.Referencia == Convert.ToInt32(ComboPro.SelectedValue)));
            if (string.IsNullOrEmpty(Convert.ToString(ComboPro.SelectedValue)))
            {
                MessageBox.Show("Ingrese un producto");
            }
            else
            {
                foreach (var item in producExis)
                {

                    if (Convert.ToInt32(ComboPro.SelectedValue) == item.Referencia)
                    {
                        producFac.Add(new Producto(Convert.ToInt32(item.Referencia), item.Nombre.ToString(), Convert.ToInt32(item.Precio), Convert.ToInt32(TXTCant.Text)));
                    }
                }
                ProduGrid.ItemsSource = producFac;
            }
            //ProduGrid.ItemsSource = producExis.Where((x) => x.Referencia == Convert.ToInt32(ComboPro.SelectedValue));
        }
    }
}
