using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private int _cantidad;
        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
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
        public Facturad(int num, int por, string tipo, int subtotal, int cantidad, DateTime fecha, int desto, int tot)
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

        public Producto(int referencia, string nombre, int precio)
        {
            Referencia = referencia;
            Nombre = nombre;
            Precio = precio;
        }
    }
    #endregion
    #region Cliente
    public class Cliente
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private int _cedula;
        public int Cedula
        {
            get { return _cedula; }
            set { _cedula = value; }
        }
        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public Cliente(int id, int cedula, string nombre)
        {
            Id = id;
            Cedula = cedula;
            Nombre = nombre;
        }
    }
    #endregion
    public partial class MainWindow : Window
    {
        public ObservableCollection<Producto> produc;
        public MainWindow()
        {
            InitializeComponent();
            IniciarClases();
        }
        public void IniciarClases()
        {
            produc = new ObservableCollection<Producto>(){
                new Producto(01, "Empanada", 5000),
                new Producto(02, "Marihuana", 13000),
                new Producto(03, "Lechuga del demonio", 50000),
                new Producto(04, "Extasis", 70000),
                new Producto(05, "Burundanga", 85000),
                new Producto(06, "Butifarra", 3000),
        };
            ComboPro.ItemsSource = produc;
            ComboPro.DisplayMemberPath = "Nombre";
        }
    }
}
