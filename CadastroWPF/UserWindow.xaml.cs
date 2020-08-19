using CadastroWPF.DAL;
using CadastroWPF.Models;
using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace CadastroWPF
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private HttpClient client = new HttpClient();
        private static DAL_SERVICES service;
        private string ctrlBtn;

        public UserWindow()
        {
            InitializeComponent();

            //
            service = new DAL_SERVICES();

            //
            ctrlBtn = "default";
            CtrlBtn(ctrlBtn);
        }

        /// <summary>
        /// Controle dos botões e campos do formulario.
        /// </summary>
        /// <param name="_ctrlBtn">controla qual btn foi pressionado por ultimo.</param>
        private void CtrlBtn(string _ctrlBtn)
        {
            switch (_ctrlBtn)
            {
                case "default":
                    txtName.IsEnabled = false;
                    txtLastName.IsEnabled = false;
                    txtPhone.IsEnabled = false;

                    btnInsert.Visibility = Visibility.Visible;
                    btnUpdate.Visibility = Visibility.Visible;
                    btnDelete.Visibility = Visibility.Visible;
                    btnCancelar.Visibility = Visibility.Hidden;
                    btnConfirmar.Visibility = Visibility.Hidden;

                    clearFields();

                    break;

                case "insert":
                    txtName.IsEnabled = true;
                    txtLastName.IsEnabled = true;
                    txtPhone.IsEnabled = true;

                    btnInsert.Visibility = Visibility.Hidden;
                    btnUpdate.Visibility = Visibility.Hidden;
                    btnDelete.Visibility = Visibility.Hidden;
                    btnCancelar.Visibility = Visibility.Visible;
                    btnConfirmar.Visibility = Visibility.Visible;

                    clearFields();

                    break;

                case "update":
                    txtName.IsEnabled = true;
                    txtLastName.IsEnabled = true;
                    txtPhone.IsEnabled = true;

                    btnInsert.Visibility = Visibility.Hidden;
                    btnUpdate.Visibility = Visibility.Hidden;
                    btnDelete.Visibility = Visibility.Hidden;
                    btnCancelar.Visibility = Visibility.Visible;
                    btnConfirmar.Visibility = Visibility.Visible;

                    break;

                case "delete":
                    txtName.IsEnabled = false;
                    txtLastName.IsEnabled = false;
                    txtPhone.IsEnabled = false;

                    btnInsert.Visibility = Visibility.Hidden;
                    btnUpdate.Visibility = Visibility.Hidden;
                    btnDelete.Visibility = Visibility.Hidden;
                    btnCancelar.Visibility = Visibility.Visible;
                    btnConfirmar.Visibility = Visibility.Visible;

                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Limpa os campos.
        /// </summary>
        private void clearFields()
        {
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtPhone.Text = string.Empty;
        }

        /// <summary>
        /// Evento Click do Btn SAIR -> Sair da Aplicação.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSair_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        ///  Evento Click do Btn CANCELAR -> Cancelar Inclusão/Alteração/Exclusão.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            ctrlBtn = "default";
            CtrlBtn(ctrlBtn);
        }

        /// <summary>
        /// Evento Click do Btn CONFIRMAR -> Confirma Inclusão/Alteração/Exclusão.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            switch (ctrlBtn)
            {
                case "insert":

                    /// Verifica se o Nome e Sobrenome estão preenchidos.
                    if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtLastName.Text))
                    {
                        MessageBox.Show("Nome e/ou SobreNome não informado.", "Inclusão", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        ///Instancia um novo usuario.
                        User userNew = new User
                        {
                            Name = txtName.Text,
                            LastName = txtLastName.Text,
                            Phone = Convert.ToInt64(txtPhone.Text)
                        };

                        /// Chama o serviço para comunicar com a API
                        await service.Insert(userNew);

                        /// Verifica se não tem erro.
                        if (string.IsNullOrEmpty(service.messageAPI))
                        {
                            ctrlBtn = "default";
                            CtrlBtn(ctrlBtn);

                            GridUser.ItemsSource = null;
                            GridUser.ItemsSource = new ViewModel.UserViewModel();
                        }
                        else
                        {
                            MessageBox.Show(service.messageAPI, "Inclusão", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }


                    break;

                case "update":

                    /// Verifica se o Id, Nome e Sobrenome estão preenchidos.
                    if (string.IsNullOrEmpty(txtId.Text) || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtLastName.Text))
                    {
                        MessageBox.Show("Id, Nome e/ou SobreNome não informado.", "Alteração", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        ///Instancia um novo usuario.
                        User userUpdate = new User
                        {
                            Id = Convert.ToInt16(txtId.Text),
                            Name = txtName.Text,
                            LastName = txtLastName.Text,
                            Phone = Convert.ToInt64(txtPhone.Text)
                        };

                        /// Chama o serviço para comunicar com a API
                        await service.Update(userUpdate);

                        /// Verifica se não tem erro.
                        if (string.IsNullOrEmpty(service.messageAPI))
                        {
                            ctrlBtn = "default";
                            CtrlBtn(ctrlBtn);

                            GridUser.ItemsSource = null;
                            GridUser.ItemsSource = new ViewModel.UserViewModel();
                        }
                        else
                        {
                            MessageBox.Show(service.messageAPI, "Alteração", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                    break;

                case "delete":

                    if (string.IsNullOrEmpty(txtId.Text))
                    {
                        MessageBox.Show("Id não Informado.", "Exclusão", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        int Id = Convert.ToUInt16(txtId.Text);

                        /// Chama o serviço para comunicar com a API
                        await service.Delete(Id);

                        /// Verifica se não tem erro.
                        if (string.IsNullOrEmpty(service.messageAPI))
                        {
                            ctrlBtn = "default";
                            CtrlBtn(ctrlBtn);

                            GridUser.ItemsSource = null;
                            GridUser.ItemsSource = new ViewModel.UserViewModel();
                        }
                        else
                        {
                            MessageBox.Show(service.messageAPI, "Exclusão", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }

                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Validação do Numero de Telefone.(Somente Numeros)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
        /// Evento SelectionChanged -> Item Selecionado no DataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_SelectionChanged(object sender, RoutedEventArgs e)
        {
            User user = (User)GridUser.SelectedItem;
            if (user != null)
            {
                txtId.Text = user.Id.ToString();
                txtName.Text = user.Name;
                txtLastName.Text = user.LastName;
                txtPhone.Text = user.Phone.ToString();
            }
        }

        /// <summary>
        /// Evento Click do Btn EXCLUIR.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                ctrlBtn = "delete";
                CtrlBtn(ctrlBtn);
            }
            else
            {
                MessageBox.Show("Selecione um contato para excluir", "Exclusão", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Evento Click do Btn ALTERAR.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                ctrlBtn = "update";
                CtrlBtn(ctrlBtn);
            }
            else
            {
                MessageBox.Show("Selecione um contato para alterar", "Alteração", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Evento Click do Btn INSERIR.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {
            ctrlBtn = "insert";
            CtrlBtn(ctrlBtn);
        }
    }
}
