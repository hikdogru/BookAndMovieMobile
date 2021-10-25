using BookAndMovieMobile.Data.Concrete.EfCore;
using BooksAndMovies.Data.Abstract;
using BooksAndMovies.Data.Concrete.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookAndMovieMobile.View.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class User : ContentPage
    {
        private IUserRepository userRepository = new EfCoreUserRepository(new Data.Concrete.EfCore.BookAndMovieContext());
        public User()
        {
            InitializeComponent();
        }

        private void Login(object sender, EventArgs e)
        {
            txtPassword.Text = "123456";
            txtEmail.Text = "test@gmail.com";
            string password = txtPassword.Text;
            string email = txtEmail.Text;

            //if(userRepository.GetAll(x => x.Email == email).SingleOrDefault().Password == password)
            //{
            //    lblMessage.Text = "Login is successfull";
            //}


            var context = new BookAndMovieContext();
            var user = context.Users.ToList().Where(x => x.Email == email).SingleOrDefault().Password == password;
            if(user)
            {

            }

        }
    }
}